using System;
using System.Configuration;

namespace XinYu.Framework.Library.Factory.Configuration
{
    /// <summary>
    /// Constructor parameter configuration elements.
    /// </summary>
    public class ConstructorParameterElement : NameTypeConfigurationElement
    {
        const string valueProperty = "value";
        
        /// <summary>
        /// Constructor.
        /// </summary>
        public ConstructorParameterElement()
        {
        }

        /// <summary>
        /// Value.
        /// </summary>
        [ConfigurationProperty(valueProperty, IsRequired = false)]
        public string ValueString
        {
            get { return (string)this[valueProperty]; }
        }
        
        /// <summary>
        /// Get parameter instance object.
        /// </summary>
        /// <returns>Paremter value.</returns>
        public object GetParameterValue()
        {
            return this.getPrimitiveParameter(this.Name, this.Type, this.ValueString);
        }

        private object getPrimitiveParameter(string paramName, Type primitiveType, string valueString)
        {
            if (primitiveType == null)
                throw new ArgumentNullException("primitiveType");
            if (valueString == null)
                throw new ArgumentNullException("valueString");

            // The type should be a primitive type.
            if (!primitiveType.IsPrimitive && !primitiveType.Equals(typeof(string)))
            {
                string message = string.Format(XinYu.Framework.Library.Factory.Properties.Resources.Culture,
                    XinYu.Framework.Library.Factory.Properties.Resources.ConstructorParameterIsNotPrimitiveClass, paramName, primitiveType);
                throw new FactoryConfigurationException(message);
            }

            try
            {
                if (primitiveType.Equals(typeof(Boolean)))
                    return Boolean.Parse(valueString);

                else if (primitiveType.Equals(typeof(SByte)))
                    return SByte.Parse(valueString);

                else if (primitiveType.Equals(typeof(Byte)))
                    return Byte.Parse(valueString);

                else if (primitiveType.Equals(typeof(Int16)))
                    return Int16.Parse(valueString);

                else if (primitiveType.Equals(typeof(UInt16)))
                    return UInt16.Parse(valueString);

                else if (primitiveType.Equals(typeof(Int32)))
                    return Int32.Parse(valueString);

                else if (primitiveType.Equals(typeof(UInt32)))
                    return UInt32.Parse(valueString);

                else if (primitiveType.Equals(typeof(Int64)))
                    return Int64.Parse(valueString);

                else if (primitiveType.Equals(typeof(UInt64)))
                    return UInt64.Parse(valueString);

                else if (primitiveType.Equals(typeof(Single)))
                    return Single.Parse(valueString);

                else if (primitiveType.Equals(typeof(Double)))
                    return Double.Parse(valueString);

                else if (primitiveType.Equals(typeof(Decimal)))
                    return Decimal.Parse(valueString);

                else if (primitiveType.Equals(typeof(DateTime)))
                    return DateTime.Parse(valueString);

                else if (primitiveType.Equals(typeof(Char)))
                    return valueString[0];

                else if (primitiveType.Equals(typeof(String)))
                    return valueString;
            }
            catch (Exception e)
            {
                string message = string.Format(XinYu.Framework.Library.Factory.Properties.Resources.Culture,
                    XinYu.Framework.Library.Factory.Properties.Resources.ConstructorParameterValueDefineError, paramName);
                throw new FactoryConfigurationException(message, e);
            }

            string msg = string.Format(XinYu.Framework.Library.Factory.Properties.Resources.Culture,
                XinYu.Framework.Library.Factory.Properties.Resources.ConstructorParameterTypeDefineError, paramName);
            throw new FactoryConfigurationException(msg);
        }
    }
}
