using System.Collections.Generic;

namespace MyLibrary.EventSystem
{
    internal class SubscribersList<TSubscriber> 
        where TSubscriber : class
    {
        private bool _isNeedsCleanUp = false;

        public bool IsExecuting;

        public readonly List<TSubscriber> List = new List<TSubscriber>();

        public void Add(TSubscriber subscriber)
        {
            List.Add(subscriber);
        }

        public void Remove(TSubscriber subscriber)
        {
            if (IsExecuting)
            {
                var i = List.IndexOf(subscriber);
                if (i >= 0)
                {
                    _isNeedsCleanUp = true;
                    List[i] = null;
                }
            }
            else
            {
                List.Remove(subscriber);
            }
        }

        public void Cleanup()
        {
            if (!_isNeedsCleanUp)
            {
                return;
            }

            List.RemoveAll(s => s == null);
            _isNeedsCleanUp = false;
        }
    }
}
