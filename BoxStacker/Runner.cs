using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoxStacker
{
    public class Runner<T>
    {
        private int taskCount;
        private Task<T>[] currentTasks;
        private int maxConcurrency;

        public Runner(int maxConcurrency)
        {
            this.maxConcurrency = maxConcurrency;
            currentTasks = new Task<T>[maxConcurrency];
        }

        public T AddTask(Task<T> task)
        {
            var returnValue = default(T);
            AddTaskToArray(task);
            taskCount++;
            if (taskCount == maxConcurrency)
            {
                var taskindex = Task.WaitAny(currentTasks);
                returnValue = currentTasks[taskindex].Result;
                currentTasks[taskindex] = null;
                taskCount--;
            }
            return returnValue;
        }

        public IEnumerable<T> WaitRemainingTasks()
        {
            var runningTasks = currentTasks.Where(t => t != null).ToArray();
            if (taskCount > 0)
            {
                Task.WaitAll(runningTasks);
            }
            return runningTasks.Select(t => t.Result);
        }

        private void AddTaskToArray(Task<T> task)
        {
            for (int i = 0; i < currentTasks.Length; i++)
            {
                if (currentTasks[i] == null)
                {
                    currentTasks[i] = task;
                    break;
                }
            }
        }
    }
}