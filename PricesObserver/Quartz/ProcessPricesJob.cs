using PricesObserver.PriceObservers;
using Quartz;
using System.Threading.Tasks;

namespace MyShop.BuildingBlocks.Infrastructure._Configuration.TransactionalCommands.Outbox
{
    [DisallowConcurrentExecution]
    public class ProcessPricesJob : IJob
    {
        private readonly IPriceObserverScheduler _scheduler;
        public ProcessPricesJob(IPriceObserverScheduler scheduler)
        {
            _scheduler = scheduler;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            await _scheduler.Run();
        }
    }
}