namespace Kit.Kernel.CQRS.Job
{
    /// <summary>
    /// Интерфейс задачи
    /// </summary>
    public interface IJob
    {
        void Run();
    }
}