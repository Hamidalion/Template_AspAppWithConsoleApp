using System;
using System.Collections.Concurrent; // https://professorweb.ru/my/csharp/charp_theory/level12/12_15.php
using System.Threading;
using System.Threading.Tasks;

namespace WCA_PL.Services.TaskQue
{
    class BackgorundTaskQueue : IBackgorundTaskQueue
    {
        private ConcurrentQueue<Func<CancellationToken, Task>> workItems = 
                    new ConcurrentQueue<Func<CancellationToken, Task>>(); // коллекция для паралельного программирования
        private SemaphoreSlim signal = new SemaphoreSlim(0); // для управлением потока

        public int Size { get; }

        public async Task<Func<CancellationToken, Task>> DeQueueAsync(CancellationToken cancellationToken) // https://metanit.com/sharp/tutorial/12.5.php
        {
            await signal.WaitAsync(cancellationToken); // ждем пока освободиться семафор 
            workItems.TryDequeue(out var workItem); // пробуем убрать задачу

            return workItem;
        }

        public void QueueBackgorundWorkItem(Func<CancellationToken, Task> workItem)
        {
            if (workItem == null)
            {
                throw new ArgumentNullException(nameof(workItem));
            }

            workItems.Enqueue(workItem);
            signal.Release(); //чтобы не зохватить забачу в момент ее добавления
        }
    }
}
