#region Header
// BoxStacker/Runner.cs - Created on 2018-02-16 at 1:37 AM by Alexander Johnston.
#endregion

#region Using
using System.Collections.Generic ;
using System.Linq ;
using System.Threading.Tasks ;
#endregion

#region Extensions
// ReSharper disable FieldCanBeMadeReadOnly.Local
#endregion

namespace BoxStacker
{
    public class Runner <T>
    {
        #region Properties & Fields
        private readonly int       _maxConcurrency ;
        private          Task<T>[] _currentTasks ;
        private          int       taskCount ;
        #endregion

        #region Constructors
        public Runner (int maxConcurrency)
        {
            _maxConcurrency = maxConcurrency ;
            _currentTasks   = new Task<T>[maxConcurrency] ;
        }
        #endregion

        #region Members
        public T AddTask (Task<T> task)
        {
            var returnValue = default( T ) ;
            AddTaskToArray (task) ;
            taskCount++ ;
            if ( taskCount == _maxConcurrency )
            {
                var taskindex = Task.WaitAny (_currentTasks) ;
                returnValue              = _currentTasks[taskindex].Result ;
                _currentTasks[taskindex] = null ;
                taskCount-- ;
            }

            return returnValue ;
        }

        public IEnumerable<T> WaitRemainingTasks ()
        {
            var runningTasks = _currentTasks.Where (t => t != null).ToArray () ;
            if ( taskCount > 0 ) Task.WaitAll (runningTasks) ;
            return runningTasks.Select (t => t.Result) ;
        }

        private void AddTaskToArray (Task<T> task)
        {
            for ( var i = 0 ; i < _currentTasks.Length ; i++ )
                if ( _currentTasks[i] == null )
                {
                    _currentTasks[i] = task ;
                    break ;
                }
        }
        #endregion
    }
}
