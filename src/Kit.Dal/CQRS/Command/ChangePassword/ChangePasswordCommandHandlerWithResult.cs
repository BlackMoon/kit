using System;
using Kit.Dal.CQRS.Command.Login;
using Kit.Dal.DbManager;
using Kit.Kernel.CQRS.Command;

namespace Kit.Dal.CQRS.Command.ChangePassword
{
    public class ChangePasswordCommandHandlerWithResult : ICommandHandlerWithResult<ChangePasswordCommand, LoginCommandResult>
    {
        private readonly IDbManager _dbManager;
        public ChangePasswordCommandHandlerWithResult(IDbManager dbManager)
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
    }
}
