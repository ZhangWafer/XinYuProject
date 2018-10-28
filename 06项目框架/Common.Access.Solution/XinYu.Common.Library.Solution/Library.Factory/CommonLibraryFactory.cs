
using System;
using System.Configuration;
using XinYu.Framework.Library.Factory.Configuration;

namespace XinYu.Framework.Library.Factory
{
    /// <summary>
    /// Common library factory.
    /// </summary>
    public static class CommonLibraryFactory
    {
        const string sectionName = "commonLibraryFactoryConfiguration";

        static FactoryConfigurationSection configSection;

        static IFactoryStrategy factoryStrategy;
                
        /// <summary>
        /// Static constructor.
        /// </summary>
        static CommonLibraryFactory()
        {
            // Get configuration section.
            configSection = (FactoryConfigurationSection)ConfigurationManager.GetSection(sectionName);

            // Create a factory strategy.
            factoryStrategy = GetFactoryStrategy(configSection);
        }

        /// <summary>
        /// Factory strategy.
        /// </summary>
        static IFactoryStrategy FactoryStrategy
        {
            get { return factoryStrategy; }
        }

        /// <summary>
        /// Get a factory strategy instance.
        /// </summary>
        /// <param name="configSection"></param>
        /// <returns>a factory strategy instance.</returns>
        public static IFactoryStrategy GetFactoryStrategy(FactoryConfigurationSection configSection)
        {
            object obj = Activator.CreateInstance(configSection.StrategyType, new object[]{configSection});
            return (obj as IFactoryStrategy);
        }

        /// <summary>
        /// Create a interface instance object.
        /// </summary>
        /// <typeparam name="TInterface">Interface type.</typeparam>
        /// <param name="instanceName">Instance name.</param>
        /// <returns>A interface instance object.</returns>
        public static TInterface CreateInstance<TInterface>(string instanceName)
        {
            return factoryStrategy.CreateInstance<TInterface>(instanceName);
        }

        /// <summary>
        /// Create a interface instance object.
        /// </summary>
        /// <typeparam name="TInterface">Interface type.</typeparam>
        /// <returns>A interface instance object.</returns>
        public static TInterface CreateInstance<TInterface>()
        {
            return factoryStrategy.CreateInstance<TInterface>();
        }

        #region Motheds for creating a implemential interface. (Commented)

        //public static ICacheManager CreateCacheManager()
        //{
        //    return CreateInstance<ICacheManager>();
        //}

        //public static ICacheManager CreateCacheManager(string instanceName)
        //{
        //    return CreateInstance<ICacheManager>(instanceName);
        //}

        //public static IEmailSender CreateEmailSender()
        //{
        //    return CreateInstance<IEmailSender>();
        //}

        //public static IEmailSender CreateEmailSender(string instanceName)
        //{
        //    return CreateInstance<IEmailSender>(instanceName);
        //}

        //public static IExceptionHandler CreateExceptionHandler()
        //{
        //    return CreateInstance<IExceptionHandler>();
        //}

        //public static IExceptionHandler CreateExceptionHandler(string instanceName)
        //{
        //    return CreateInstance<IExceptionHandler>(instanceName);
        //}

        //public static IHashCryptographer CreateHashCryptographer()
        //{
        //    return CreateInstance<IHashCryptographer>();
        //}

        //public static IHashCryptographer CreateHashCryptographer(string instanceName)
        //{
        //    return CreateInstance<IHashCryptographer>(instanceName);
        //}

        //public static ILogger CreateLogger()
        //{
        //    return CreateInstance<ILogger>();
        //}

        //public static ILogger CreateLogger(string instanceName)
        //{
        //    return CreateInstance<ILogger>(instanceName);
        //}

        //public static IMessageQueue CreateMessasgeQueue()
        //{
        //    return CreateInstance<IMessageQueue>();
        //}

        //public static IMessageQueue CreateMessasgeQueue(string instanceName)
        //{
        //    return CreateInstance<IMessageQueue>(instanceName);
        //}

        //public static ISymmetricCryptographer CreateSymmetricCryptographer()
        //{
        //    return CreateInstance<ISymmetricCryptographer>();
        //}

        //public static ISymmetricCryptographer CreateSymmetricCryptographer(string instanceName)
        //{
        //    return CreateInstance<ISymmetricCryptographer>(instanceName);
        //}
        #endregion
    }
}