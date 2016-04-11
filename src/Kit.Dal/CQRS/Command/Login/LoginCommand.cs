using System.ComponentModel.DataAnnotations;
using Kit.Kernel.CQRS.Command;

namespace Kit.Dal.CQRS.Command.Login
{
    public class LoginCommand : ICommand
    {
        [Required(ErrorMessage = "Введите имя пользователя")]
        public string Login { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Введите пароль")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Выберите сервер")]
        public string DataSource { get; set; }
    }
}
