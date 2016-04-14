using System.ComponentModel.DataAnnotations;
using Kit.Kernel.CQRS.Command;
using Kit.Kernel.Web.EncryptData;

namespace Kit.Dal.CQRS.Command.ChangePassword
{
    public class ChangePasswordCommand : ICommand
    {
        [EncryptDataType(DataType.Password)]
        [Required(ErrorMessage = "Введите новый пароль")]
        public string NewPassword { get; set; }

        [EncryptDataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "Новый пароль не совпадает с подтверждением")]
        public string ConfirmPassword { get; set; }

    }
}
