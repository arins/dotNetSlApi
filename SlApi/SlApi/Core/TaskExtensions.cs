using System.Threading.Tasks;

namespace SlApi.Core
{
    public static class TaskExtensions
    {
        /// <summary>
        /// Waits until either the timeout is done 
        /// </summary>
        /// <param name="task">The task you want to wait for</param>
        /// <param name="timeoutMilliseconds">timeout in milliseconds</param>
        /// <returns></returns>
        public static bool WaitUntilDoneWithTimeoutAsync(this Task task, int timeoutMilliseconds)
        {
            var result = Task.WhenAny(task, Task.Delay(timeoutMilliseconds));
            result.Wait();
            return result.Result == task;


        }
    }
}
