using System;
using System.ComponentModel.Composition;
using Foundation.Plugin;
using PlanAlgorithm.Contracts;

namespace PlanAlgorithm.PluginA
{
    [Export(typeof(IPlanAlgorithmPlugin))]
    [PluginMetadata(name: "Plugin A", description: "A plugin for first plan algorithm")]
    public class FirstPlanAlgorithm : IPlanAlgorithmPlugin
    {
        public void DoSomething()
        {
            Console.WriteLine("This is plugin A");
        }
    }
}
