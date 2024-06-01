using System.Threading.Tasks;
using KudoCode.Services.Scheduler.Quartz.Infrastructure.Interfaces;
using Quartz;

namespace KudoCode.Services.Scheduler.Quartz.Infrastructure
{
    public abstract class ScheduleHandler : IJob
    {
        protected abstract void Action();

        public Task Execute(IJobExecutionContext context)
        {
            Action();

            return Task.FromResult<object>(null);
        }
    }
}