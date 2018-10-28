using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Spotmau.Framework.Web.Controls
{
    [ToolboxData("<{0}:UserRatingStar runat=server></{0}:UserRatingStar>")]
    public class UserRatingStar : WebControl, IPostBackDataHandler
    {
        Image starImage1 = new Image();
        Image starImage2 = new Image();
        Image starImage3 = new Image();
        Image starImage4 = new Image();
        Image starImage5 = new Image();

        string fullStartImageSrc = "~/image/star/star_red_full.gif";
        string halfStartImageSrc = "~/image/star/star_red_half.gif";
        string emptyStartImageSrc = "~/image/star/star_red_empty.gif";
        string starImageClassName = "starimg";

        #region Public properties.

        [Category("Appearance")]
        [DefaultValue("")]
        public float Value
        {
            get
            {
                if (this.ViewState[this.UniqueID + "_Value"] == null)
                    this.ViewState[this.UniqueID + "_Value"] = (float)3;
                return (float)this.ViewState[this.UniqueID + "_Value"];
            }
            set
            {
                this.ViewState[this.UniqueID + "_Value"] = value;
            }
        }

        [Category("Appearance")]
        [DefaultValue("~/image/star/star_red_full.gif")]
        public string FullStarImageSrc
        {
            get { return this.fullStartImageSrc; }
            set { this.fullStartImageSrc = value; }
        }

        [Category("Appearance")]
        [DefaultValue("~/image/star/star_red_half.gif")]
        public string HalfStarImageSrc
        {
            get { return this.halfStartImageSrc; }
            set { this.halfStartImageSrc = value; }
        }

        [Category("Appearance")]
        [DefaultValue("~/image/star/star_red_empty.gif")]
        public string EmptyStarImageSrc
        {
            get { return this.emptyStartImageSrc; }
            set { this.emptyStartImageSrc = value; }
        }

        [Category("Appearance")]
        [DefaultValue("starimg")]
        public string StarImageClassName
        {
            get { return this.starImageClassName; }
            set { this.starImageClassName = value; }
        }

        #endregion

        protected override HtmlTextWriterTag TagKey
        {
            get { return HtmlTextWriterTag.Div; }
        }

        protected override void CreateChildControls()
        {
            base.CreateChildControls();
        }

        protected override void Render(HtmlTextWriter writer)
        {
            base.Render(writer);
        }

        protected override void RenderChildren(HtmlTextWriter writer)
        {
            this.starImage1.CssClass = this.StarImageClassName;
            this.starImage2.CssClass = this.StarImageClassName;
            this.starImage3.CssClass = this.StarImageClassName;
            this.starImage4.CssClass = this.StarImageClassName;
            this.starImage5.CssClass = this.StarImageClassName;

            this.starImage1.ImageUrl = this.EmptyStarImageSrc;
            this.starImage2.ImageUrl = this.EmptyStarImageSrc;
            this.starImage3.ImageUrl = this.EmptyStarImageSrc;
            this.starImage4.ImageUrl = this.EmptyStarImageSrc;
            this.starImage5.ImageUrl = this.EmptyStarImageSrc;

            if (this.Value >= 1) this.starImage1.ImageUrl = this.FullStarImageSrc;
            else if (this.Value >= 0.5) this.starImage1.ImageUrl = this.HalfStarImageSrc;

            if (this.Value >= 2) this.starImage2.ImageUrl = this.FullStarImageSrc;
            else if (this.Value >= 1.5) this.starImage2.ImageUrl = this.HalfStarImageSrc;

            if (this.Value >= 3) this.starImage3.ImageUrl = this.FullStarImageSrc;
            else if (this.Value >= 2.5) this.starImage3.ImageUrl = this.HalfStarImageSrc;

            if (this.Value >= 4) this.starImage4.ImageUrl = this.FullStarImageSrc;
            else if (this.Value >= 3.5) this.starImage4.ImageUrl = this.HalfStarImageSrc;

            if (this.Value >= 5) this.starImage5.ImageUrl = this.FullStarImageSrc;
            else if (this.Value >= 4.5) this.starImage5.ImageUrl = this.HalfStarImageSrc;

            this.starImage1.RenderControl(writer);
            this.starImage2.RenderControl(writer);
            this.starImage3.RenderControl(writer);
            this.starImage4.RenderControl(writer);
            this.starImage5.RenderControl(writer);

            base.RenderChildren(writer);
        }

        #region IPostBackDataHandler ≥…‘±

        public bool LoadPostData(string postDataKey, System.Collections.Specialized.NameValueCollection postCollection)
        {
            return false;
        }

        public void RaisePostDataChangedEvent()
        {
        }

        #endregion
    }
}
