// ============================================================================
// Author:          赵劼
// Create Date:     2018-05-08
// Description:     采用依赖注射的方法实现工厂策略.
// Modify History:
// ============================================================================

using System.Collections.Generic;
using Microsoft.Practices.ObjectBuilder;
using XinYu.Framework.Library.Factory.Configuration;

namespace XinYu.Framework.Library.Factory
{
    /// <summary>
    /// Dependency injection factory strategy.
    /// 
    /// 采用依赖注射的方法实现工厂策略.
    /// </summary>
    public class DependencyInjectionFactoryStrategy : AbstractFactoryStrategy
    {
        // ObjectBuild中的Builder对象.
        Builder builder = null;

        // 用于保存已构造对象的容器.
        Locator locator = new Locator();
        LifetimeContainer lifetimeContainer = new LifetimeContainer();
        
        /// <summary>
        /// Constructor.
        /// </summary>
        public DependencyInjectionFactoryStrategy(FactoryConfigurationSection configSection)
            : base(configSection)
        {
            locator.Add(typeof(ILifetimeContainer), lifetimeContainer);

            builder = new Builder();
            this.applyConfigurationToBuilder(configSection, this.builder);
        }

        /// <summary>
        /// Create a interface instance object.
        /// </summary>
        /// <typeparam name="TInterface">Interface type.</typeparam>
        /// <param name="instanceName">Instance name.</param>
        /// <returns>A interface instance object.</returns>
        public override TInterface CreateInstance<TInterface>(string instanceName)
        {
            return builder.BuildUp<TInterface>(locator, instanceName, null);
        }

        /// <summary>
        /// 根据配置文件的设置, 将构造原则(IPolicy)实例添加至Builder对象的构造原则链中.
        /// </summary>
        /// <param name="configSection">配置文件对象.</param>
        /// <param name="builder">Builder对象</param>
        private void applyConfigurationToBuilder(FactoryConfigurationSection configSection, IBuilder<BuilderStage> builder)
        {
            foreach (InterfaceElement interfaceEle in configSection.Interfaces)
            {
                foreach (InstanceElement instanceEle in interfaceEle.Instances)
                {
                    // 添加接口与实现的Map关系!!
                    TypeMappingPolicy tmp = new TypeMappingPolicy(instanceEle.Type, instanceEle.Name);
                    builder.Policies.Set<ITypeMappingPolicy>(tmp, interfaceEle.Type, instanceEle.Name);

                    // 添加接口实例的构造原则(IPolicy)(添加实例构造函数的参数列表).
                    List<IParameter> paras = new List<IParameter>();
                    foreach (ConstructorParameterElement conParaEle in instanceEle.ConstructorParameters)
                    {
                        paras.Add(new ValueParameter(conParaEle.Type, conParaEle.GetParameterValue()));
                    }

                    ConstructorPolicy csp = new ConstructorPolicy(paras.ToArray());
                    builder.Policies.Set<ICreationPolicy>(csp, instanceEle.Type, instanceEle.Name);

                    // 添加是否单件的构造原则(IPolicy).
                    SingletonPolicy slp = new SingletonPolicy(instanceEle.IsSingleton);
                    builder.Policies.Set<ISingletonPolicy>(slp, instanceEle.Type, instanceEle.Name);
                }
            }
        }

    }
}
