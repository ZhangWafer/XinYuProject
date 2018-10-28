using System;
using System.Configuration;

namespace XinYu.Framework.Library.Factory.Configuration
{
    /// <summary>
    /// Represents a <see cref="ConfigurationElement"/> that has a name and type.
    /// </summary>
    public class NameTypeConfigurationElement : NamedConfigurationElement
    {
        /// <summary>
        /// Name of the property that holds the type of <see cref="NameTypeConfigurationElement"/>.
        /// </summary>
        const string typeProperty = "type";

        /// <summary>
        /// Intialzie an instance of the <see cref="NameTypeConfigurationElement"/> class.
        /// </summary>
        public NameTypeConfigurationElement()
        {
        }

        /// <summary>
        /// Gets or sets the fully qualified name of the <see cref="Type"/> the element is the configuration for.
        /// </summary>
        /// <value>
        /// the fully qualified name of the <see cref="Type"/> the element is the configuration for.
        /// </value>
        [ConfigurationProperty(typeProperty, IsRequired = true)]
        public string TypeName
        {
            get { return (string)this[typeProperty]; }
        }

        /// <summary>
        /// Gets the <see cref="Type"/> the element is the configuration for.
        /// </summary>
        /// <value>
        /// The <see cref="Type"/> the element is the configuration for.
        /// </value>
        public Type Type
        {
            get { return Type.GetType(this.TypeName); }
        }
    }
}
