using System;
using System.Collections.Generic;
using System.Linq;
using Foundation.Plugin;
using PlanAlgorithm.Contracts;

namespace Simple
{
    public class PlanService
    {
        public IEnumerable<Lazy<IPlanAlgorithmPlugin, IPluginMetadata>> _planAlgorithms;

        public PlanService(PluginManager pluginManager)
        {
            _planAlgorithms = pluginManager.GetPlugins<IPlanAlgorithmPlugin>();
        }

        public IEnumerable<string> GetAvailableAlgorithmNames()
        {
            return _planAlgorithms.Select(x => x.Metadata.Name);
        }

        public void Execute(string algorithmName)
        {
            foreach (var planAlgorithm in _planAlgorithms)
            {
                if (planAlgorithm.Metadata.Name == algorithmName)
                {
                    planAlgorithm.Value.DoSomething();
                }
            }
        }
    }
}
