using System.ComponentModel.DataAnnotations;
using Kit.Core;

namespace Kit.Dal.CQRS.Command.Login
{
    public class LoginCommand : SignInCommand
    {
        [Required(ErrorMessage = "Введите имя пользователя")]
        public string UserName { get; set; }

        [EncryptDataType(DataType.Password)]
        [Required(ErrorMessage = "Введите пароль")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Выберите сервер")]
        public string DataSource { get; set; }
    }
}
