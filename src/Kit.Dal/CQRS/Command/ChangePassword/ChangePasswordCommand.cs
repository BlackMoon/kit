using System.ComponentModel.DataAnnotations;
using Kit.Kernel.CQRS.Command;

namespace Kit.Dal.CQRS.Command.ChangePassword
{
    public class ChangePasswordCommand : ICommand
    {
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Введите новый пароль")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "Новый пароль не совпадает с подтверждением")]
        public string ConfirmPassword { get; set; }

    }
}
