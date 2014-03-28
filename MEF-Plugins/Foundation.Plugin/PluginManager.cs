using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;

namespace Foundation.Plugin
{
    public class PluginManager
    {
        private IEnumerable<DirectoryCatalog> _directoryCatalogs;
        private readonly CompositionContainer _container;

        public PluginManager(params string[] pluginDirectories)
        {
            _directoryCatalogs = pluginDirectories.Select(directory => new DirectoryCatalog(directory));
            _container = new CompositionContainer(new AggregateCatalog(_directoryCatalogs));
            _container.ComposeParts();
        }

        public IEnumerable<Lazy<TPlugin, IPluginMetadata>> GetPlugins<TPlugin>() where TPlugin : IPlugin
        {
            try
            {
                return _container.GetExports<TPlugin, IPluginMetadata>();
            }
            catch (Exception exc)
            {

                throw exc;
            }
            
        }

        public void RefreshPlugins()
        {
            foreach (var directoryCatalog in _directoryCatalogs)
            {
                directoryCatalog.Refresh();
            }
        }
    }
}
