using System.Configuration;

namespace XinYu.Framework.Library.Factory.Configuration
{
    /// <summary>
    /// Instance configuration element.
    /// </summary>
    public class InstanceElement : NameTypeConfigurationElement
    {
        const string constructorParameterProperty = "constructorParameters";
        const string isSingletonProperty = "isSingleton";

        /// <summary>
        /// Constructor.
        /// </summary>
        public InstanceElement()
        {
        }

        [ConfigurationProperty(isSingletonProperty, DefaultValue="True", IsRequired = false)]
        public bool IsSingleton
        {
            get 
            {
                bool ret;
                if (bool.TryParse(this[isSingletonProperty].ToString(), out ret))
                    return ret;

                return true;
            }
        }

        /// <summary>
        /// All constructor parameter configuration elements.
        /// </summary>
        [ConfigurationProperty(constructorParameterProperty, IsRequired = false)]
        public NamedConfigurationElementCollection<ConstructorParameterElement> ConstructorParameters
        {
            get { return (NamedConfigurationElementCollection<ConstructorParameterElement>)this[constructorParameterProperty]; }
        }
    }
}
