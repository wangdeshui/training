namespace Foundation.Plugin
{
    public interface IPluginMetadata
    {
        string Name { get;  }
        string Description { get;  }
        string Version { get;  }
    }
}