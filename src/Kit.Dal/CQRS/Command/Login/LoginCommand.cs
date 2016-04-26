using System.ComponentModel.DataAnnotations;
using Kit.Kernel;
using Kit.Kernel.CQRS.Command;
using Kit.Kernel.Web.EncryptData;

namespace Kit.Dal.CQRS.Command.Login
{
    public class LoginCommand : ICommand
    {
        [Required(ErrorMessage = "Введите имя пользователя")]
        public string UserName { get; set; }

        [EncryptDataType(DataType.Password)]
        [Required(ErrorMessage = "Введите пароль")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Выберите сервер")]
        public string DataSource { get; set; }

        /// <summary>
        /// Identity Token Id (аутентификация через OpenId)
        /// </summary>
        public string SignInId { get; set; }
    }
}
