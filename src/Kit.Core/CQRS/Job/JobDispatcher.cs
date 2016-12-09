using System;
using System.Collections.Generic;
using Castle.Core.Internal;

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
            jobs.ForEach(j => j.Run());
        }
    }
}
