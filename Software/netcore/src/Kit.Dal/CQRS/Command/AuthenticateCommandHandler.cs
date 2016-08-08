﻿using System;
using Kit.Dal.CQRS.Command.ChangePassword;
using Kit.Dal.CQRS.Command.Login;
using Kit.Dal.DbManager;
using Kit.Kernel.CQRS.Command;
using Oracle.DataAccess.Client;

namespace Kit.Dal.CQRS.Command
{
    public class AuthenticateCommandHandler :
        ICommandHandlerWithResult<ChangePasswordCommand, LoginCommandResult>,
        ICommandHandlerWithResult<LoginCommand, LoginCommandResult>
    {
        private readonly IDbManager _dbManager;
        public AuthenticateCommandHandler(IDbManager dbManager)
        {
            _dbManager = dbManager;
        }

        public LoginCommandResult Execute(ChangePasswordCommand command)
        {
            LoginStatus status = LoginStatus.Success;
            string msg = null;

            try
            {
                _dbManager.OpenWithNewPassword(command.NewPassword);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
                status = LoginStatus.Failure;
            }

            return new LoginCommandResult() { Message = msg, Status = status };
        }

        public LoginCommandResult Execute(LoginCommand command)
        {
            LoginStatus status = LoginStatus.Success;
            string msg = null;

            try
            {
                _dbManager.Open($"Data Source={command.DataSource};User Id={command.UserName};Password={command.Password}");
            }
            catch (OracleException ex) when (ex.Number == 28001)
            {
                msg = "Срок действия Вашего пароля истек. Смените пароль или обратитесь к администратору.";
                status = LoginStatus.Expired;
            }
            catch (OracleException ex) when (ex.Number == 28002)
            {
                msg = "Срок действия Вашего пароля истекает, учетная запись будет заблокирована. Смените пароль или обратитесь к администратору. Сменить пароль?";
                status = LoginStatus.Expiring;
            }
            catch (Exception ex)
            {
                msg = ex.Message;
                status = LoginStatus.Failure;
            }
            finally
            {
                _dbManager.Close();
            }

            return new LoginCommandResult() { Status = status, Message = msg };
        }
    }
}
