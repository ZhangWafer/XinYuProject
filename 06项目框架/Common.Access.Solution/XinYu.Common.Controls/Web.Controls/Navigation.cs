using System;
using System.Xml;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;

namespace Spotmau.Framework.Web.Controls
{

    /// <summary>
    /// RecordNavigation 的摘要说明。
    /// </summary>
    [DefaultProperty("TargetGridViewID")]
    [ToolboxData("<{0}:Navigation runat=server></{0}:Navigation>")]
    public class Navigation : CompositeControl, IPostBackEventHandler, IPostBackDataHandler
    {
        const string EVENT_NEXTPAGE = "下一页";
        const string EVENT_PREVPAGE = "上一页";
        const string EVENT_FIRSTPAGE = "首 页";
        const string EVENT_LASTPAGE = "最后页";
        const string EVENT_MOVEPAGE = "跳 转";
        const string EVENT_PAGESIZE = "每页记录";

        const int Default_MaxPageSize = 100;
        const int Default_PageSize = 20;
        const int Default_CurPageIndex = 1;

        public event NavigationEventHandler NavigationStatusChanged;

        private ImageButton nextButton = new ImageButton();
        private ImageButton prevButton = new ImageButton();
        private ImageButton firstButton = new ImageButton();
        private ImageButton lastButton = new ImageButton();
        private ImageButton moveButton = new ImageButton();
        private ImageButton sizeButton = new ImageButton();

        private TextBox txtCurPage = new TextBox();
        private TextBox txtPageSize = new TextBox();

        /// <summary>
        /// Constructor.
        /// </summary>
        public Navigation()
        {
            // 页控制按钮
            nextButton.AlternateText = "Next";
            nextButton.ImageUrl = "~/Background/img/nav/Next.gif";
            nextButton.ToolTip = "Next Page";

            prevButton.AlternateText = "Previous";
            prevButton.ImageUrl = "~/Background/img/nav/Previous.gif";
            prevButton.ToolTip = "Previous Page";

            firstButton.AlternateText = "First";
            firstButton.ImageUrl = "~/Background/img/nav/First.gif";
            firstButton.ToolTip = "First Page";

            lastButton.AlternateText = "Last";
            lastButton.ImageUrl = "~/Background/img/nav/Last.gif";
            lastButton.ToolTip = "Last Page";

            moveButton.AlternateText = "Go";
            moveButton.ImageUrl = "~/Background/img/nav/Go.gif";
            moveButton.ToolTip = "Go to the page";

            sizeButton.AlternateText = "Set";
            sizeButton.ImageUrl = "~/Background/img/nav/Size.gif";
            sizeButton.ToolTip = "Set Page Size";

            this.txtCurPage.Width = 30;
            this.txtCurPage.Height = 16;
            this.txtCurPage.MaxLength = 5;
            this.txtCurPage.Text = Default_CurPageIndex.ToString();
            this.txtCurPage.Attributes.Add("onkeyup", "javascript:var regx = /[^0-9]/g;this.value = this.value.replace(regx, '');");

            this.txtPageSize.Width = 30;
            //this.txtPageSize.Height = 13;
            this.txtPageSize.MaxLength = 5;
            this.txtPageSize.Text = Default_PageSize.ToString();
            this.txtPageSize.Attributes.Add("onkeyup", "javascript:var regx = /[^0-9]/g;this.value = this.value.replace(regx, '');");
        }

        /// <summary>
        /// Bind data for the navigation control.
        /// </summary>
        public void DataBind(int pageIndex, int pageSize, int totalRecords)
        {
            this.PageIndex = pageIndex;
            this.PageSize = pageSize;

            this.TotalRecords = totalRecords;

            this.Visible = (totalRecords > 0);
        }

        /// <summary>
        /// Navigation
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        void onNavigationStatusChanged()
        {
            if (this.NavigationStatusChanged != null)
            {
                NavigationEventArgs e = new NavigationEventArgs(this, this.PageIndex, this.PageSize);
                this.NavigationStatusChanged(this, e);
            }
        }

        #region 按钮图片路径属性。

        /// <summary>
        /// Image path of the First Button.this.TargetDataView.Table = 
        /// </summary>
        [DefaultValue("~/img/nav/First.gif")]
        [UrlProperty]
        public string FirstImagePath
        {
            get { return this.firstButton.ImageUrl; }
            set { this.firstButton.ImageUrl = value; }
        }

        /// <summary>
        /// Image path of the Next Button.
        /// </summary>
        [DefaultValue("~/img/nav/Next.gif")]
        [UrlProperty]
        public string NextImagePath
        {
            get { return this.nextButton.ImageUrl; }
            set { this.nextButton.ImageUrl = value; }
        }

        /// <summary>
        /// Image path of the Previous Button.
        /// </summary>
        [DefaultValue("~/img/nav/Previous.gif")]
        [UrlProperty]
        public string PreviousImagePath
        {
            get { return this.prevButton.ImageUrl; }
            set { this.prevButton.ImageUrl = value; }
        }

        /// <summary>
        /// Image path of the Last Button.
        /// </summary>
        [DefaultValue("~/img/nav/Last.gif")]
        [UrlProperty]
        public string LastImagePath
        {
            get { return this.lastButton.ImageUrl; }
            set { this.lastButton.ImageUrl = value; }
        }

        /// <summary>
        /// Image path of the Last Button.
        /// </summary>
        [DefaultValue("~/img/nav/Go.gif")]
        [UrlProperty]
        public string MoveImagePath
        {
            get { return this.moveButton.ImageUrl; }
            set { this.moveButton.ImageUrl = value; }
        }

        /// <summary>
        /// Image path of the Last Button.
        /// </summary>
        [DefaultValue("~/img/nav/Size.gif")]
        [UrlProperty]
        public string PageSizeImagePath
        {
            get { return this.sizeButton.ImageUrl; }
            set { this.sizeButton.ImageUrl = value; }
        }
        #endregion

        #region 页码属性。

        [Category("Appearance")]
        public int TotalRecords
        {
            get
            {
                if (this.ViewState[this.UniqueID + "_TotalRecords"] == null)
                    this.ViewState[this.UniqueID + "_TotalRecords"] = 0;
                return (int)this.ViewState[this.UniqueID + "_TotalRecords"];
            }
            set
            {
                this.ViewState[this.UniqueID + "_TotalRecords"] = value;
            }
        }

        [Category("Appearance")]
        public int PageCount
        {
            get
            {
                int total = this.TotalRecords;
                int pageSize = this.PageSize;

                return ((total % pageSize) == 0) ? total / pageSize : total / pageSize + 1;
            }
        }

        /// <summary>
        /// The current page index.
        /// </summary>
        [Category("Appearance")]
        public int PageIndex
        {
            get { return Convert.ToInt32(this.txtCurPage.Text.Trim()); }
            set { this.txtCurPage.Text = value.ToString(); }
        }

        /// <summary>
        /// Page size.
        /// </summary>
        [Category("Appearance")]
        public int PageSize
        {
            get { return Convert.ToInt32(this.txtPageSize.Text.Trim()); }
            set { this.txtPageSize.Text = value.ToString(); }
        }

        /// <summary>
        /// The first item index in the current page.
        /// </summary>
        [Category("Appearance")]
        public int FirstItemIndex
        {
            get { return (this.PageIndex - 1) * this.PageSize + 1; }
        }

        /// <summary>
        /// The last item index in the current page.
        /// </summary>
        [Category("Appearance")]
        public int LastItemIndex
        {
            get
            {
                int lastItemIndex = this.FirstItemIndex + this.PageSize - 1;
                if (lastItemIndex > this.TotalRecords)
                    lastItemIndex = TotalRecords;

                return lastItemIndex;
            }
        }
        #endregion

        #region IPostBackDataHandler 成员

        public void RaisePostDataChangedEvent()
        {
        }

        public bool LoadPostData(string postDataKey, System.Collections.Specialized.NameValueCollection postCollection)
        {
            // 目前只有一个需返回的状态值
            // 获取所设置的页面大小，并进行设置			
            string lPostData = postCollection[postDataKey];

            int lIndex = lPostData.IndexOf(",");
            if (lIndex >= 0)
            {
                string lCurPage = lPostData.Substring(0, lIndex);
                string lPageCount = lPostData.Substring(lIndex + 1, lPostData.Length - lIndex - 1);

                this.PageIndex = Convert.ToInt32(lCurPage);
                this.PageSize = Convert.ToInt32(lPageCount);
            }
            else
            {
                this.PageIndex = int.Parse(lPostData);
                //this.PageSize = int.Parse(lPostData);
            }

            return false;
        }
        #endregion

        #region IPostBackEventHandler 成员

        public void RaisePostBackEvent(string eventArgument)
        {
            // 从参数中取出事件名
            int lIndex = eventArgument.IndexOf("$");

            string lEventName = string.Empty;
            string lParString = string.Empty;
            if (lIndex < 0)
            {
                lEventName = eventArgument;
            }
            else
            {
                lEventName = eventArgument.Substring(0, lIndex);
                lParString = eventArgument.Substring(lIndex + 1, eventArgument.Length - lIndex - 1);
            }

            // 整行单击事件
            switch (lEventName)
            {
                // ####################################################################
                case EVENT_NEXTPAGE:
                    // 下一页
                    if (this.PageIndex < this.PageCount)
                        this.PageIndex += 1;
                    break;

                // ####################################################################
                case EVENT_PREVPAGE:
                    // 上一页
                    if (this.PageIndex > 1)
                        this.PageIndex -= 1;
                    break;

                //####################################################################
                case EVENT_PAGESIZE:
                    // 改变每页显示大小
                    this.PageIndex = 1;
                    break;

                // ####################################################################
                case EVENT_MOVEPAGE:
                    // 当前页码已在LoadPostData()方法中改变。
                    if (this.PageIndex > this.PageCount)
                        this.PageIndex = this.PageCount;
                    if (this.PageIndex < 1)
                        this.PageIndex = 1;

                    this.onNavigationStatusChanged();
                    break;

                // ####################################################################
                case EVENT_FIRSTPAGE:
                    // 首页
                    this.PageIndex = 1;
                    this.onNavigationStatusChanged();
                    break;

                // ####################################################################
                case EVENT_LASTPAGE:
                    this.PageIndex = this.PageCount;
                    break;

                // ####################################################################
                default:
                    break;
            }

            this.onNavigationStatusChanged();
        }

        #endregion

        protected override System.Web.UI.HtmlTextWriterTag TagKey
        {
            get { return HtmlTextWriterTag.Table; }
        }

        protected override void CreateChildControls()
        {
            // 实现某些事件
            this.nextButton.Attributes.Add("onclick", Page.ClientScript.GetPostBackEventReference(new PostBackOptions(this, EVENT_NEXTPAGE)));
            this.prevButton.Attributes.Add("onclick", Page.ClientScript.GetPostBackEventReference(new PostBackOptions(this, EVENT_PREVPAGE)));
            this.firstButton.Attributes.Add("onclick", Page.ClientScript.GetPostBackEventReference(new PostBackOptions(this, EVENT_FIRSTPAGE)));
            this.lastButton.Attributes.Add("onclick", Page.ClientScript.GetPostBackEventReference(new PostBackOptions(this, EVENT_LASTPAGE)));

            this.moveButton.Attributes.Add("onclick", Page.ClientScript.GetPostBackEventReference(new PostBackOptions(this, EVENT_MOVEPAGE)));
            this.sizeButton.Attributes.Add("onclick", Page.ClientScript.GetPostBackEventReference(new PostBackOptions(this, EVENT_PAGESIZE)));

            // 检查当前页所在位置，以决定是否显示上下页按钮
            this.firstButton.Enabled = (this.PageIndex > 1);
            this.nextButton.Enabled = (this.PageIndex < this.PageCount);
            this.prevButton.Enabled = (this.PageIndex > 1);
            this.lastButton.Enabled = (this.PageIndex < this.PageCount);

            base.CreateChildControls();
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
        }

        /// <summary> 
        /// 将此控件呈现给指定的输出参数。
        /// </summary>
        /// <param name="output"> 要写出到的 HTML 编写器 </param>
        protected override void Render(HtmlTextWriter output)
        {
            output.AddAttribute("border", "0");
            output.AddAttribute("cellpadding", "0");
            output.AddAttribute("cellspacing", "0");

            //output.AddStyleAttribute("float", "left");

            base.Render(output);
        }

        protected override void RenderChildren(System.Web.UI.HtmlTextWriter writer)
        {
            writer.AddAttribute("align", "left");
            writer.AddStyleAttribute("vertical-align", "middle");
            writer.RenderBeginTag(HtmlTextWriterTag.Tr);

            writer.Write(Environment.NewLine);

            // 显示按钮：第一页
            writer.AddAttribute("align", "left");
            writer.AddStyleAttribute("vertical-align", "middle");
            writer.RenderBeginTag(HtmlTextWriterTag.Td);
            this.firstButton.RenderControl(writer);
            writer.RenderEndTag();
            writer.Write(Environment.NewLine);


            // 显示按钮：上一页
            writer.AddAttribute("align", "left");
            writer.AddStyleAttribute("vertical-align", "middle");
            writer.RenderBeginTag(HtmlTextWriterTag.Td);
            this.prevButton.RenderControl(writer);
            writer.RenderEndTag();
            writer.Write(Environment.NewLine);

            // 显示提示内容
            writer.AddAttribute("align", "left");
            writer.AddStyleAttribute("vertical-align", "middle");
            writer.RenderBeginTag(HtmlTextWriterTag.Td);
            writer.Write(string.Format("&nbsp;({0} - {1} of {2})&nbsp;", this.FirstItemIndex, this.LastItemIndex, this.TotalRecords));
            writer.RenderEndTag();
            writer.Write(Environment.NewLine);

            // 显示按钮：下一页
            writer.AddAttribute("align", "left");
            writer.AddStyleAttribute("vertical-align", "middle");
            writer.RenderBeginTag(HtmlTextWriterTag.Td);
            this.nextButton.RenderControl(writer);
            writer.RenderEndTag();
            writer.Write(Environment.NewLine);


            // 显示按钮：最后一页
            writer.AddAttribute("align", "left");
            writer.AddStyleAttribute("vertical-align", "middle");
            writer.RenderBeginTag(HtmlTextWriterTag.Td);
            this.lastButton.RenderControl(writer);
            writer.RenderEndTag();
            writer.Write(Environment.NewLine);


            // 转到第几页
            writer.AddAttribute("align", "left");
            writer.AddStyleAttribute("vertical-align", "middle");
            writer.RenderBeginTag(HtmlTextWriterTag.Td);

            this.txtCurPage.CssClass = "input_text";
            this.txtCurPage.ID = this.UniqueID;// +"_PageIndex";
            this.txtCurPage.RenderControl(writer);

            writer.RenderEndTag();
            writer.Write(Environment.NewLine);

            writer.AddAttribute("align", "left");
            writer.AddStyleAttribute("vertical-align", "middle");
            writer.RenderBeginTag(HtmlTextWriterTag.Td);

            this.moveButton.RenderControl(writer);
            //writer.Write("Page&nbsp;");

            writer.RenderEndTag();
            writer.Write(Environment.NewLine);


            ////// 设每页几行
            writer.AddAttribute("align", "left");
            writer.AddStyleAttribute("vertical-align", "middle");
            writer.RenderBeginTag(HtmlTextWriterTag.Td);

            //this.sizeButton.RenderControl(writer);
            this.txtPageSize.ID = this.UniqueID;// +"_PageSize";
            this.txtPageSize.Style.Add("display", "none");
            this.txtPageSize.RenderControl(writer);
            ////writer.Write("Per Page");

            writer.RenderEndTag();
            writer.Write(Environment.NewLine);


            writer.RenderEndTag();
            writer.Write(Environment.NewLine);
        }
    }

    public delegate void NavigationEventHandler(object sender, NavigationEventArgs e);


    /// <summary>
    /// Navigation Event Args类。
    /// </summary>
    public class NavigationEventArgs : EventArgs
    {
        object sender;

        int pageIndex;
        int pageSize;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        public NavigationEventArgs(object sender, int pageIndex, int pageSize)
        {
            this.sender = sender;
            this.pageIndex = pageIndex;
            this.pageSize = pageSize;
        }

        public object Sender
        {
            get { return this.sender; }
        }

        public int PageIndex
        {
            get { return this.pageIndex; }
        }

        public int PageSize
        {
            get { return this.pageSize; }
        }

        public int FirstItemIndex
        {
            get { return (this.pageIndex - 1) * this.PageSize + 1; }
        }
    }
}
