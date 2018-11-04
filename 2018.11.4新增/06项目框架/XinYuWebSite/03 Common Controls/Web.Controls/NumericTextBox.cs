using System.Web.UI;
using System.Collections.Generic;
using System.Text;
using System;

namespace Spotmau.Framework.Web.Controls
{
    public class NumericTextBox:System.Web.UI.WebControls.TextBox  
    {
        private int _DecimalPlaces ;
        private bool _AllowDecimal;
        private bool _AllowNegative  ;
       // private string _script ;
        public int DecimalPlaces
        {
            get
            {
                return _DecimalPlaces;
            }
            set 
            {
                _DecimalPlaces = value;
            }

        }

        /// <summary>
        /// 是否允许小数 Bool
        /// </summary>
        public bool AllowDecimal
        {
            get
            {
                return _AllowDecimal;
            }

            set
            {
                _AllowDecimal = value;
            }
        }


        /// <summary>
        /// 是否允许负数 Bool
        /// </summary>
        public bool AllowNegative
        {
            get
            {
                return _AllowNegative;
            }

            set
            {
                _AllowNegative = value;
            }
        }


         private string js=string.Empty ;

        public void New()
        {
             _DecimalPlaces = -1;
            
        }

        protected override void OnPreRender(System.EventArgs e)
        {
            base.OnPreRender(e);

            int decPlaces = 0;
            if (AllowDecimal)
            {
                decPlaces = _DecimalPlaces;
            }

            this.Attributes.Add("onblur", this.Attributes["onblur"] + "extractNumber(this," + decPlaces.ToString () + "," + _AllowNegative.ToString().ToLower() + ");");
            this.Attributes.Add("onkeyup", this.Attributes["onkeyup"] + "extractNumber(this," + decPlaces.ToString() + "," + _AllowNegative.ToString().ToLower() + ");");
            this.Attributes.Add("onkeypress", this.Attributes["onkeypress"] + "return blockNonNumbers(this, event," + _AllowDecimal.ToString().ToLower() + "," + _AllowNegative.ToString().ToLower() + ");");

        }
           

     

    }
}