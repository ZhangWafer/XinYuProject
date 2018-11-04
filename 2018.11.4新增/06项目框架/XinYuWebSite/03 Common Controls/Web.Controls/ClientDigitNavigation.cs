using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Spotmau.Framework.Web.Controls
{
    [DefaultProperty("Text")]
    [ToolboxData("<{0}:ClientDigitNavigation runat=server></{0}:ClientDigitNavigation>")]
    public class ClientDigitNavigation : WebControl, IPostBackEventHandler
    {
        public event NavigationEventHandler NavigationStatusChanged;

        #region Public properties.

        /// <summary>
        /// The current page index. Start from 0.
        /// </summary>
        [Category("Appearance")]
        public int PageIndex
        {
            get
            {
                if (this.ViewState[this.UniqueID + "_PageIndex"] == null)
                    this.ViewState[this.UniqueID + "_PageIndex"] = 0;
                return (int)this.ViewState[this.UniqueID + "_PageIndex"];
            }
            set
            {
                this.ViewState[this.UniqueID + "_PageIndex"] = value;
            }
        }

        /// <summary>
        /// Page size.
        /// </summary>
        [Category("Appearance")]
        public int PageSize
        {
            get
            {
                if (this.ViewState[this.UniqueID + "_PageSize"] == null)
                    this.ViewState[this.UniqueID + "_PageSize"] = 20;
                return (int)this.ViewState[this.UniqueID + "_PageSize"];
            }
            set
            {
                this.ViewState[this.UniqueID + "_PageSize"] = value;
            }
        }

        [Category("Appearance")]
        public int TotalRecords
        {
            get
            {
                if (this.ViewState[this.UniqueID + "_TotalRecords"] == null)
                    this.ViewState[this.UniqueID + "_TotalRecords"] = 124587;
                return (int)this.ViewState[this.UniqueID + "_TotalRecords"];
            }
            set
            {
                this.ViewState[this.UniqueID + "_TotalRecords"] = value;
            }
        }

        /// <summary>
        /// The first item index in the current page.
        /// </summary>
        [Category("Appearance")]
        public int FirstItemIndex
        {
            get { return (this.PageIndex - 1) * this.PageSize + 1; }
        }

        [Category("Appearance")]
        public int PageCount
        {
            get
            {
                if (this.PageSize == 0) return 0;

                int total = this.TotalRecords;
                int pageSize = this.PageSize;

                return ((total % pageSize) == 0) ? total / pageSize : total / pageSize + 1;
            }
        }

        [Category("Appearance")]
        [DefaultValue("active")]
        public string ActiveClassName
        {
            get
            {
                if (this.ViewState[this.UniqueID + "_ActiveClass"] == null)
                    this.ViewState[this.UniqueID + "_ActiveClass"] = "active";
                return (string)this.ViewState[this.UniqueID + "_ActiveClass"];
            }
            set
            {
                this.ViewState[this.UniqueID + "_ActiveClass"] = value;
            }
        }

        /// <summary>
        /// 显示的页码数量
        /// </summary>
        [Category("Appearance")]
        [DefaultValue(7)]
        public int DisplayDigitItemCount
        {
            get
            {
                if (this.ViewState[this.UniqueID + "_DisplayDigitItemCount"] == null)
                    this.ViewState[this.UniqueID + "_DisplayDigitItemCount"] = 7;
                return (int)this.ViewState[this.UniqueID + "_DisplayDigitItemCount"];
            }
            set
            {
                this.ViewState[this.UniqueID + "_DisplayDigitItemCount"] = value;
            }
        }

        /// <summary>
        /// 中间的页码索引（从1开始计算，在通常情况下为当前页码的显示位置，但有特例的存在）
        /// </summary>
        [Category("Appearance")]
        [DefaultValue(4)]
        public int MiddleDisplayDigitItemIndex
        {
            get
            {
                if (this.ViewState[this.UniqueID + "_MiddleNavItemIndex"] == null)
                    this.ViewState[this.UniqueID + "_MiddleNavItemIndex"] = 4;
                return (int)this.ViewState[this.UniqueID + "_MiddleNavItemIndex"];
            }
            set
            {
                this.ViewState[this.UniqueID + "_MiddleNavItemIndex"] = value;
            }
        }

        #endregion

        /// <summary>
        /// Bind data for the navigation control.
        /// </summary>
        public void DataBind(int pageIndex, int pageSize, int totalRecords)
        {
            this.PageIndex = pageIndex - 1;
            this.PageSize = pageSize;
            this.TotalRecords = totalRecords;

            this.Visible = (totalRecords > 0);
        }

        /// <summary>
        /// Navigation
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        private void onNavigationStatusChanged()
        {
            if (this.NavigationStatusChanged != null)
            {
                NavigationEventArgs e = new NavigationEventArgs(this, this.PageIndex + 1, this.PageSize);
                this.NavigationStatusChanged(this, e);
            }
        }

        protected override void Render(HtmlTextWriter output)
        {
            int pageIndex = this.PageIndex + 1;
            int pageSize = this.PageSize;
            int pageCount = this.PageCount;

            // 首先确定显示的第一个页码索引
            int displayStartPageIndex = 1;
            if (pageIndex > this.DisplayDigitItemCount && pageIndex > (pageCount - this.DisplayDigitItemCount))
            {
                displayStartPageIndex = pageCount - this.DisplayDigitItemCount + 1;
            }
            else if (pageCount > this.DisplayDigitItemCount && pageIndex > this.MiddleDisplayDigitItemIndex)
            {
                displayStartPageIndex = pageIndex - this.MiddleDisplayDigitItemIndex + 1;
            }

            // 生成html页面的显示内容
            if (pageIndex > 1)
            {
                this.RenderItem(output, "Prev", string.Empty, this.GetOnclickText(pageIndex - 1));
            }

            if (displayStartPageIndex > 2)
            {
                this.RenderItem(output, displayStartPageIndex.ToString(), string.Empty, this.GetOnclickText(1));
                this.RenderSuspensionItem(output, string.Empty);
            }

            int index = displayStartPageIndex;
            for (int i = 0; i < this.DisplayDigitItemCount; i++)
            {
                if (index > pageCount) break;

                if (index == pageIndex)
                {
                    this.RenderItem(output, index.ToString(), this.ActiveClassName, "javascript:void(0);");
                }
                else
                {
                    this.RenderItem(output, index.ToString(), string.Empty, this.GetOnclickText(index));
                }

                index++;
            }

            if (index < pageCount)
            {
                this.RenderItem(output, pageCount.ToString(), string.Empty, this.GetOnclickText(pageCount));
            }

            if (pageIndex < pageCount)
            {
                this.RenderSuspensionItem(output, string.Empty);
                this.RenderItem(output, "Next", string.Empty, this.GetOnclickText(pageIndex + 1));
            }

            base.Render(output);

        }

        private string GetOnclickText(int pageIndex)
        {
            string onclickText = "javascript:" + Page.ClientScript.GetPostBackEventReference(this, pageIndex.ToString());
            //onchange="javascript:setTimeout('__doPostBack(\'ctl00$ContentPlaceHolder1$ddlPageSize\',\'\')', 0)" 
            //string onclickText = string.Format(@"javascript:setTimeout('__doPostBack(\'{0}\',\'{1}\')', 0)", this.ClientID, pageIndex);

            return onclickText;
        }

        private void RenderItem(HtmlTextWriter output, string text, string className, string onclickText)
        {
            if (!string.IsNullOrEmpty(className)) output.AddAttribute(HtmlTextWriterAttribute.Class, className);

            //output.AddAttribute(HtmlTextWriterAttribute.Href, "javascript:void(0);");
            //output.AddAttribute(HtmlTextWriterAttribute.Onclick, onclickText);
            output.AddAttribute(HtmlTextWriterAttribute.Href, onclickText);
            output.RenderBeginTag(HtmlTextWriterTag.A);
            output.Write(text);
            output.RenderEndTag();
            output.Write(Environment.NewLine);
        }

        private void RenderSuspensionItem(HtmlTextWriter output, string className)
        {
            if (!string.IsNullOrEmpty(className)) output.AddAttribute(HtmlTextWriterAttribute.Class, className);

            output.AddAttribute(HtmlTextWriterAttribute.Href, "javascript:void(0);");
            output.AddAttribute(HtmlTextWriterAttribute.Onclick, "javascript:void(0);");
            output.RenderBeginTag(HtmlTextWriterTag.A);
            output.Write("...");
            output.RenderEndTag();
        }

        #region IPostBackEventHandler 成员

        public void RaisePostBackEvent(string eventArgument)
        {
            // 从参数中取出事件名
            int pageIndex;
            if (int.TryParse(eventArgument, out pageIndex))
            {
                this.PageIndex = pageIndex - 1;

                this.onNavigationStatusChanged();
            }
        }

        #endregion
    }
}
