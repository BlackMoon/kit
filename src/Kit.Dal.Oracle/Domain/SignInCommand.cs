using Kit.Core.CQRS.Command;

namespace Kit.Dal.Oracle.Domain
{
    public class SignInCommand : ICommand
    {
        /// <summary>
        /// Identity ReturnUrl (аутентификация через OpenId)
        /// </summary>
        public string ReturnUrl { get; set; } = "/";
    }
}
