

using System;
using XinYu.Framework.Library.Factory.Configuration;

namespace XinYu.Framework.Library.Factory
{
    /// <summary>
    /// Hard code to implement IFactoryStrategy.
    /// It's not be implemented now.
    /// 
    /// 用hard code的方式来实现工厂策略, 目前没有实现该类.
    /// 一般情况下不再实现此类, 只当存在无法用其它策略实现的功能时, 才考虑实现该类.
    /// </summary>
    public class HardcodeFactoryStrategy : AbstractFactoryStrategy
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="configElement"></param>
        public HardcodeFactoryStrategy(FactoryConfigurationSection configSection)
            : base(configSection)
        {
        }

        public override TInterface CreateInstance<TInterface>(string instanceName)
        {
            throw new Exception("The method or operation is not implemented.");
        }
    }
}
