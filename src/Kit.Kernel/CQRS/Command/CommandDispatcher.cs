namespace Kit.Kernel.CQRS.Command
{
    public class CommandDispatcher : ICommandDispatcher
    {
        

        public void Dispatch<TParameter>(TParameter command) where TParameter : ICommand
        {
           
        }

    }
}