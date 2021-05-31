using System;
using System.Threading;
using System.Threading.Tasks;

namespace WCA_PL.Services.TaskQue
{
    public interface IBackgorundTaskQueue
    {
        public int Size { get; }

        void QueueBackgorundWorkItem(Func<CancellationToken, Task> workItem); // Принимаеи задачи

        Task<Func<CancellationToken, Task>> DeQueueAsync(CancellationToken cancellationToken); // Убираем задачу из очереди
    }
}
