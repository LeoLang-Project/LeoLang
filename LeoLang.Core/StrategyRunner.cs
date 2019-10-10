using System.Collections.Generic;

namespace LeoLang.Core
{
    public class StrategyRunner<T>
    {
        public void Add(IStrategy<T> strategie)
        {
            _strategies.Add(strategie);
        }

        public T Run(T arg)
        {
            T tmp = arg;

            foreach (var s in _strategies)
            {
                tmp = s.Do(tmp);
            }
            return tmp;
        }

        private List<IStrategy<T>> _strategies;
    }
}