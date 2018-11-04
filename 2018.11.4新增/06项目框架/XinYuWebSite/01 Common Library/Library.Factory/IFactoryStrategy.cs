

using XinYu.Framework.Library.Factory.Configuration;

namespace XinYu.Framework.Library.Factory
{
    /// <summary>
    /// Factory strategy interface.
    /// </summary>
    public interface IFactoryStrategy
    {
        /// <summary>
        /// Configuration Element object for Common Library Factory.
        /// </summary>
        FactoryConfigurationSection ConfigSection
        {
            get;
        }

        /// <summary>
        /// Create a instance object of the appointed interface.
        /// </summary>
        /// <typeparam name="TInterface">Interface type.</typeparam>
        /// <returns>A instance object.</returns>
        TInterface CreateInstance<TInterface>();

        /// <summary>
        /// Create a instance object of the appointed interface.
        /// </summary>
        /// <typeparam name="TInterface">Interface type.</typeparam>
        /// <param name="instanceName">Instance name.</param>
        /// <returns>A instance object.</returns>
        TInterface CreateInstance<TInterface>(string instanceName);
    }
}
