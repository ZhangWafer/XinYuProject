using System;
using System.Configuration;

namespace XinYu.Framework.Library.Factory.Configuration
{
    /// <summary>
    /// Common library factory configuration section.
    /// </summary>
    public class FactoryConfigurationSection : ConfigurationSection
    {
        const string strategyTypeProperty = "strategyType";
        const string interfaceProperty = "interfaces";

        /// <summary>
        /// Constructor.
        /// </summary>
        public FactoryConfigurationSection()
        {
        }

        /// <summary>
        /// Factory strategy type name.
        /// </summary>
        [ConfigurationProperty(strategyTypeProperty, IsRequired = true)]
        public string StrategyTypeName
        {
            get { return (string)this[strategyTypeProperty]; }
        }

        /// <summary>
        /// All interface configuration elements.
        /// </summary>
        [ConfigurationProperty(interfaceProperty, IsRequired = true)]
        public NamedConfigurationElementCollection<InterfaceElement> Interfaces
        {
            get { return (NamedConfigurationElementCollection<InterfaceElement>)this[interfaceProperty]; }
        }
 
        /// <summary>
        /// Factory strategy type.
        /// </summary>
        public Type StrategyType
        {
            get { return Type.GetType(this.StrategyTypeName); }
        }

        /// <summary>
        /// Get default instance name.
        /// </summary>
        /// <typeparam name="TInterface"></typeparam>
        /// <returns></returns>
        public string GetDefaultInstanceName<TInterface>()
        {
            return this.GetDefaultInstanceName(typeof(TInterface));
        }

        /// <summary>
        /// Get default instance name.
        /// </summary>
        /// <param name="interfaceType"></param>
        /// <returns></returns>
        public string GetDefaultInstanceName(Type interfaceType)
        {
            foreach (InterfaceElement ele in this.Interfaces)
            {
                if (ele.Type.Equals(interfaceType))
                {
                    return ele.DefaultInstanceName;
                }
            }

            string message = string.Format(XinYu.Framework.Library.Factory.Properties.Resources.Culture,
                XinYu.Framework.Library.Factory.Properties.Resources.NotDefineTheInterface, interfaceType);
            throw new FactoryConfigurationException();
        }
    }
}