using XinYu.Framework.Library.Factory.Configuration;

namespace XinYu.Framework.Library.Factory
{
    /// <summary>
    /// Abstract factory strategy.
    /// </summary>
    public abstract class AbstractFactoryStrategy : IFactoryStrategy
    {
        FactoryConfigurationSection configSection = null;

        /// <summary>
        /// Protected constructor.
        /// </summary>
        /// <param name="configElement"></param>
        protected AbstractFactoryStrategy(FactoryConfigurationSection configSection)
        {
            this.configSection = configSection;
        }

        #region IFactoryStrategy Element.

        public virtual FactoryConfigurationSection ConfigSection
        {
            get { return this.configSection; }
        }

        public virtual TInterface CreateInstance<TInterface>()
        {
            string defaultInstanceName = this.configSection.GetDefaultInstanceName<TInterface>();

            return this.CreateInstance<TInterface>(defaultInstanceName);
        }

        /// <summary>
        /// Abstarct method to create an instance object.
        /// </summary>
        /// <typeparam name="TInterface"></typeparam>
        /// <param name="instanceName"></param>
        /// <returns></returns>
        public abstract TInterface CreateInstance<TInterface>(string instanceName);

        #endregion
    }
}
