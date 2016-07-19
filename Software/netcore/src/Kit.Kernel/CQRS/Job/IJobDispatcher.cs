namespace Kit.Kernel.CQRS.Job
{
    public interface IJobDispatcher
    {
        void Dispatch<TParameter>() where TParameter : IJob;
    }
}
