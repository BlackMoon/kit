using System.ComponentModel.DataAnnotations;
using Kit.Kernel;
using Kit.Kernel.CQRS.Command;

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

        /// <summary>
        /// Identity Token Id (аутентификация через OpenId)
        /// </summary>
        public string SignInId { get; set; }
    }
}
