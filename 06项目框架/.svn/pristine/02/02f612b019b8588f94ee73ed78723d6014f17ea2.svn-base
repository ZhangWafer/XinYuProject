using System.Configuration;

namespace XinYu.Framework.Library.Factory.Configuration
{
    /// <summary>
    /// Interface configuration element.
    /// </summary>
    public class InterfaceElement : NameTypeConfigurationElement
    {
        const string defaultInstanceProperty = "defaultInstance";
        const string instanceProperty = "instances";

        /// <summary>
        /// Constructor.
        /// </summary>
        public InterfaceElement()
        {
        }

        /// <summary>
        /// Default instance name of this interface.
        /// </summary>
        [ConfigurationProperty(defaultInstanceProperty, IsRequired = false)]
        public string DefaultInstanceName
        {
            get 
            {
                string name = (string)this[defaultInstanceProperty];

                // If not define the attribute, the first instance would be the default instance.
                if (name == null || name.Length == 0)
                {
                    if (this.Instances.Count == 0)
                        throw new FactoryConfigurationException(XinYu.Framework.Library.Factory.Properties.Resources.NotDefineInterfaceInstance);

                    name = this.Instances.Get(0).Name;
                }
                return name;
            }
        }

        /// <summary>
        /// All instance configuration elements.
        /// </summary>
        [ConfigurationProperty(instanceProperty, IsRequired = true)]
        public NamedConfigurationElementCollection<InstanceElement> Instances
        {
            get { return (NamedConfigurationElementCollection<InstanceElement>)this[instanceProperty]; }
        }
    }
}
