using System;
using Kit.Dal.DbManager;
using Kit.Kernel.CQRS.Command;
using Oracle.DataAccess.Client;

namespace Kit.Dal.CQRS.Command.Login
{
    public class LoginCommandHandlerWithResult : ICommandHandlerWithResult<LoginCommand, LoginCommandResult>
    {
        private readonly IDbManager _dbManager;
        public LoginCommandHandlerWithResult(IDbManager dbManager)
        {
            _dbManager = dbManager;
        }

        public LoginCommandResult Execute(LoginCommand command)
        {
            LoginStatus status = LoginStatus.Expired;
            string msg = null;
            msg = "Срок действия Вашего пароля истек. Смените пароль или обратитесь к администратору.";
            try
            {
                _dbManager.Open();
                _dbManager.Close();
            }
            catch (OracleException ex) when (ex.Number == 28001)
            {
                msg = "Срок действия Вашего пароля истек. Смените пароль или обратитесь к администратору.";
                status = LoginStatus.Expired;
            }
            catch (OracleException ex) when (ex.Number == 28002)
            {
                msg = "Срок действия Вашего пароля истекает, учетная запись будет заблокирована. Смените пароль или обратитесь к администратору.Сменить пароль?";
                status = LoginStatus.Expiring;
            }
            catch (Exception ex)
            {
                msg = ex.Message;
                status = LoginStatus.Failure;
            }
            finally
            {
                //_dbManager.Close();
            }
            

            return new LoginCommandResult() { Status = status, Message = msg };
        }
    }
}
