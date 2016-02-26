using System;
using System.Diagnostics;
using PostSharp.Aspects;

namespace Kit.Kernel
{
    /// <summary>
    /// Аттрибут. Выводит время выполнения метода(ов)
    /// </summary>
    [Serializable]
    public class ProfilerAttribute : OnMethodBoundaryAspect
    {
        public override void OnEntry(MethodExecutionArgs args)
        {
            args.MethodExecutionTag = Stopwatch.StartNew();
        }

        public override void OnExit(MethodExecutionArgs args)
        {
            Stopwatch sw = (Stopwatch)args.MethodExecutionTag;
            sw.Stop();

            string output = $"{args.Instance}.{args.Method.Name} executed in {sw.Elapsed} seconds";

            Debug.WriteLine(output);
        }
    }
}
