using Kit.Core.CQRS.Command;

namespace Kit.Dal.CQRS.Command
{
    public class SignInCommand : ICommand
    {
        /// <summary>
        /// Identity ReturnUrl (аутентификация через OpenId)
        /// </summary>
        public string ReturnUrl { get; set; } = "/";
    }
}
