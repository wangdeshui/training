using System;
using System.ComponentModel.Composition;
using Foundation.Plugin;
using PlanAlgorithm.Contracts;

namespace PlanAlgorithm.PluginB
{
    [Export(typeof(IPlanAlgorithmPlugin))]
    [PluginMetadata(name: "Plugin B", description: "Plugin for second plan algorithm")]
    public class SecondPlanAlgorithm : IPlanAlgorithmPlugin
    {
        public void DoSomething()
        {
            Console.WriteLine("This is plugin B");
        }
    }
}
