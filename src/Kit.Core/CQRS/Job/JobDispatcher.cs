using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace Kit.Core.CQRS.Job
{
    public class JobDispatcher : IJobDispatcher
    {
        private readonly IServiceProvider _serviceProvider;

        public JobDispatcher(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public void Dispatch<TParameter>() where TParameter : IJob
        {
            IEnumerable<TParameter> jobs = _serviceProvider.GetServices<TParameter>();

            foreach (TParameter j in jobs)
            {
                j.Run();
            }
        }
    }
}
