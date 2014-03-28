using System;
using System.ComponentModel;
using System.ComponentModel.Composition;

namespace Foundation.Plugin
{
    [MetadataAttribute]
    public class PluginMetadataAttribute : Attribute
    {
        public string Name { set; get; }
        public string Description { get; set; }

        [DefaultValue("1.0.0.0")]
        public string Version { set; get; }

        public PluginMetadataAttribute(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
