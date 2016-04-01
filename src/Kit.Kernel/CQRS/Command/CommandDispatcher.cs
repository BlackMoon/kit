using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Kit.Kernel.CQRS.Validation;

namespace Kit.Kernel.CQRS.Command
{
    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly IServiceProvider _serviceProvider;

        public CommandDispatcher(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public void Dispatch<TParameter>(TParameter command) where TParameter : ICommand
        {
            if (command == null)
                throw new ArgumentNullException(nameof(command));

            var handler = _serviceProvider.GetService<ICommandHandler<TParameter>>();
            handler?.Execute(command);
        }

        public TResult Dispatch<TParameter, TResult>(TParameter command) where TParameter : ICommand where TResult : ICommandResult
        {
            if (command == null)
                throw new ArgumentNullException(nameof(command));

            var handler = _serviceProvider.GetService<ICommandHandlerWithResult<TParameter, TResult>>();
            return (handler != null) ? handler.Execute(command) : default(TResult);
        }

        /// <summary>
        /// Валидация
        /// </summary>
        /// <typeparam name="TParameter"></typeparam>
        /// <param name="command"></param>
        /// <returns></returns>
        public IEnumerable<ValidationResult> Validate<TParameter>(TParameter command) where TParameter : ICommand
        {
            if (command == null)
                throw new ArgumentNullException(nameof(command));

            var handler = _serviceProvider.GetService<IValidationHandler<TParameter>>();
            return handler?.Validate(command);
        }
    }
}