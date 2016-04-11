using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Kit.Kernel.CQRS.Command;

namespace Kit.Kernel.CQRS.Validation
{
    public interface IValidationHandler<in TParameter> where TParameter : ICommand
    {
        IEnumerable<ValidationResult> Validate(TParameter command);
    }
}