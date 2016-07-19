using Kit.Kernel.CQRS.Command;

namespace Kit.Dal.CQRS.Command.Login
{
    public class LoginCommandResult : ICommandResult
    {
        public LoginStatus Status { get; set; }

        public string Message { get; set; }
    }
}