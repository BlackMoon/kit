namespace Kit.Kernel.CQRS
{
    public class CommandDispatcher : ICommandDispatcher
    {
        

        public void Dispatch<TParameter>(TParameter command) where TParameter : ICommand
        {
           
        }

    }
}