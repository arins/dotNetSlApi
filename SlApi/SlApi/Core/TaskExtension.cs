using System.Threading;
using System.Threading.Tasks;

namespace SlApi.Core
{
    public static class TaskExtension
    {
        public static bool WaitWithTimeout(this Task task, int millisecondsTimeout)
        {
            var timeoutTask = Task.Factory.StartNew(() =>
            {
                var t = new ManualResetEvent(false);
                t.WaitOne(millisecondsTimeout);
            });
            var taskList = new[]
            {
                timeoutTask, task
            };
            return Task.WaitAny(taskList) == 1;
        }

        public static async Task<bool> WaitWithTimeoutAsync(this Task task, int millisecondsTimeout)
        {
            var timeoutTask = Task.Factory.StartNew(() =>
            {
                var t = new ManualResetEvent(false);
                t.WaitOne(millisecondsTimeout);
            });
            var taskList = new[]
            {
                timeoutTask, task
            };
            var result = await Task.Factory.ContinueWhenAny(taskList, task1 => task1 == task);
            return result;
        }
    }
}
