using Kit.Kernel.CQRS.Command;

namespace Kit.Dal.CQRS.Command
{
    public class SignInCommand : ICommand
    {
        /// <summary>
        /// Identity Token Id (аутентификация через OpenId)
        /// </summary>
        public string SignInId { get; set; }
    }
}
