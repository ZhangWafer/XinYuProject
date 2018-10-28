using System.Configuration;

namespace XinYu.Framework.Library.Factory.Configuration
{
    /// <summary>
    /// Represents a named <see cref="ConfigurationElement"/> where the name is the key to a collection.
    /// </summary>
    /// <remarks>
    /// This class is used in conjunction with a <see cref="Configuration.NamedElementCollection&lt;T&gt;"/>.
    /// </remarks>
    public class NamedConfigurationElement : ConfigurationElement
    {
        /// <summary>
        /// Name of the property that holds the name of <see cref="NamedConfigurationElement"/>.
        /// </summary>
        const string nameProperty = "name";

        /// <summary>
        /// Initialize a new instance of a <see cref="NamedConfigurationElement"/> class.
        /// </summary>
        public NamedConfigurationElement()
        {
        }

        /// <summary>
        /// Gets or sets the name of the element.
        /// </summary>
        /// <value>
        /// The name of the element.
        /// </value>
        [ConfigurationProperty(nameProperty, IsKey = true, IsRequired = true)]
        public string Name
        {
            get { return (string)this[nameProperty]; }
        }
    }
}
