﻿using System;
using System.Collections.Generic;
using System.Web;
using System.IO;
using System.Text;
using System.Configuration;
using System.Net;
using System.Web.UI;
using System.Text.RegularExpressions;


using XinYu.Framework.Membership.Model;
using XinYu.Framework.Membership.BLL;
/// <summary>
///PageUtility 的摘要说明
/// </summary>
public static class PageUtility
{
    const string CONST_SESSION_KEY_ADMIN_USER = "__adminuser";
    const string CONST_SESSION_KEY_MODULETREE = "__moduleTree";

    public const string COSNT_BUTTON_TEXT_ADD = "添  加";
    public const string COSNT_BUTTON_TEXT_SAVE = "保  存";

    public const string CONST_MENU_IMAGE = "img/framework/main_menu.gif";
    public const string CONST_SUBMENU_IMAGE1 = "img/framework/main_submenu1.gif";
    public const string CONST_SUBMENU_IMAGE2 = "img/framework/main_submenu2.gif";

    public const int NAVIGATION_DEFAULT_PAGESIZE = 20;
    public const int NAVIGATION_DEFAULT_PAGEINDEX = 1;

    public const int CONST_ISHOT_INDEX = 100;

    public const int CONST_PARENT_VLAUE = 0;

    public const string DEFAULT_FALSE_JS_PATH = "~/js/img.js";


    #region 后台用户验证相关方法

    public static UserInfo User
    {

        get { return HttpContext.Current.Session[CONST_SESSION_KEY_ADMIN_USER] as UserInfo; }
    }

    public static bool IsLogin
    {
        get { return User != null; }
    }

    public static void Login(UserInfo user)
    {
        HttpContext.Current.Session.Timeout = 1440;
        HttpContext.Current.Session[CONST_SESSION_KEY_ADMIN_USER] = user;
    }

    public static void Logout()
    {
        HttpContext.Current.Session[CONST_SESSION_KEY_ADMIN_USER] = null;
        HttpContext.Current.Session.Clear();
        //HttpContext.Current.Session.Abandon();
    }

    public static Tree<ModuleInfo> SessionModuleTree
    {
        get
        {
            var ret = HttpContext.Current.Session[CONST_SESSION_KEY_MODULETREE] as Tree<ModuleInfo>;
            if (ret == null)
            {
                ret = new AccountBLL().GetAccessableModules(User);
                HttpContext.Current.Session[CONST_SESSION_KEY_MODULETREE] = ret;
            }
            return ret;
        }
    }

    #endregion

    #region Path Properties.

    public static string ApplicationPath
    {
        get
        {
            string applicationPath = HttpContext.Current.Request.ApplicationPath;

            return applicationPath == "/" ? string.Empty : applicationPath;
        }
    }

    public static string BackupDataDirectory
    {
        get { return Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase, "Backup"); }
    }

    #endregion

    public static void RedirectLogout()
    {
        HttpContext.Current.Response.Redirect("~/Background/Logout.aspx");
    }

    public static void Alter(Page page, string msg)
    {
        var sb = new StringBuilder();
        sb.Append("<script type=\"text/javascript\"> ");
        sb.Append(string.Format("alert('{0}');", msg.Replace("'", "\"")));
        sb.Append("</script>");

        page.ClientScript.RegisterClientScriptBlock(typeof(Page), "Alter", sb.ToString());
    }


    /// <summary>
    /// 去除Html标签
    /// </summary>
    /// <returns></returns>
    public static string ClearHtml(string html)
    {
        var regex1 = new Regex(@"<script[\s\S]+</script *>", RegexOptions.IgnoreCase);
        var regex2 = new Regex(@" href *= *[\s\S]*script *:", RegexOptions.IgnoreCase);
        var regex3 = new Regex(@" no[\s\S]*=", RegexOptions.IgnoreCase);
        var regex4 = new Regex(@"<iframe[\s\S]+</iframe *>", RegexOptions.IgnoreCase);
        var regex5 = new Regex(@"<frameset[\s\S]+</frameset *>", RegexOptions.IgnoreCase);
        var regex6 = new Regex(@"\<img[^\>]+\>", RegexOptions.IgnoreCase);
        var regex7 = new Regex(@"</p>", RegexOptions.IgnoreCase);
        var regex8 = new Regex(@"<p>", RegexOptions.IgnoreCase);
        var regex9 = new Regex(@"<[^>]*>", RegexOptions.IgnoreCase);
        html = regex1.Replace(html, "");
        html = regex2.Replace(html, "");
        html = regex3.Replace(html, " _disibledevent=");
        html = regex4.Replace(html, "");
        html = regex5.Replace(html, "");
        html = regex6.Replace(html, "");
        html = regex7.Replace(html, "");
        html = regex8.Replace(html, "");
        html = regex9.Replace(html, "");
        html = html.Replace(" ", "");
        html = html.Replace("</strong>", "");
        html = html.Replace("<strong>", "");
        return html;
    }

    public static string NoHTML(string htmlstring)
    {
        //删除脚本
        htmlstring = Regex.Replace(htmlstring, @"<script[^>]*?>.*?</script>", "", RegexOptions.IgnoreCase);
        //删除HTML
        htmlstring = Regex.Replace(htmlstring, @"<(.[^>]*)>", "", RegexOptions.IgnoreCase);
        htmlstring = Regex.Replace(htmlstring, @"([\r\n])[\s]+", "", RegexOptions.IgnoreCase);
        htmlstring = Regex.Replace(htmlstring, @"-->", "", RegexOptions.IgnoreCase);
        htmlstring = Regex.Replace(htmlstring, @"<!--.*", "", RegexOptions.IgnoreCase);
        htmlstring = Regex.Replace(htmlstring, @"&(quot|#34);", "\"", RegexOptions.IgnoreCase);
        htmlstring = Regex.Replace(htmlstring, @"&(amp|#38);", "&", RegexOptions.IgnoreCase);
        htmlstring = Regex.Replace(htmlstring, @"&(lt|#60);", "<", RegexOptions.IgnoreCase);
        htmlstring = Regex.Replace(htmlstring, @"&(gt|#62);", ">", RegexOptions.IgnoreCase);
        htmlstring = Regex.Replace(htmlstring, @"&(nbsp|#160);", " ", RegexOptions.IgnoreCase);
        htmlstring = Regex.Replace(htmlstring, @"&(iexcl|#161);", "\xa1", RegexOptions.IgnoreCase);
        htmlstring = Regex.Replace(htmlstring, @"&(cent|#162);", "\xa2", RegexOptions.IgnoreCase);
        htmlstring = Regex.Replace(htmlstring, @"&(pound|#163);", "\xa3", RegexOptions.IgnoreCase);
        htmlstring = Regex.Replace(htmlstring, @"&(copy|#169);", "\xa9", RegexOptions.IgnoreCase);
        htmlstring = Regex.Replace(htmlstring, @"&#(\d+);", "", RegexOptions.IgnoreCase);
        htmlstring.Replace("<", "");
        htmlstring.Replace(">", "");
        htmlstring.Replace("\r\n", "");
        htmlstring = HttpContext.Current.Server.HtmlEncode(htmlstring).Trim();

        return htmlstring;
    }

    /// <summary>
    /// 消除危险字符
    /// </summary>
    /// <param name="strContent"></param>
    /// <returns></returns>
    public static string ClearHtmlName(string strContent)
    {
        strContent = strContent.Replace(" ", "-");
        strContent = strContent.Replace("&", "-");
        strContent = strContent.Replace("'", "-");
        strContent = strContent.Replace("<", "-");
        strContent = strContent.Replace(">", "-");
        strContent = strContent.Replace(">", "-");
        strContent = strContent.Replace("%", "-");
        strContent = strContent.Replace("\"", "-");
        strContent = strContent.Replace("/", "-");
        strContent = strContent.Replace("\\", "-");
        strContent = strContent.Replace("\r\n", "-");
        strContent = strContent.Replace("?", "-");
        strContent = strContent.Replace(":", "-");
        strContent = strContent.Replace(",", "-");
        strContent = strContent.Replace("!", "-");
        strContent = strContent.Replace("+", "-");
        strContent = strContent.Replace("--", "-");
        strContent = strContent.Replace("|", "-");
        return strContent;
    }

    /// <summary>
    /// 返回IP
    /// </summary>
    /// <returns></returns>
    public static string GetIP()
    {
        var ip = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
        if (string.IsNullOrEmpty(ip))
        {
            ip = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
        }

        return ip;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="length"></param>
    /// <param name="title"></param>
    /// <returns></returns>
    public static string GetStringLength(int length, string title)
    {
        var i = title.Length;

        if (i > length)
        {
            return title.Substring(0, length) + "...";
        }
        return title;
    }


    /// <summary>
    /// 判断URL是否存在
    /// </summary>
    /// <param name="url"></param>
    /// <returns></returns>
    public static bool UrlExists(string url)
    {
        var ret = false;

        try
        {
            var webrt = (HttpWebRequest)WebRequest.Create(url);

            //返回对Internet请求的响应
            var webrs = (HttpWebResponse)webrt.GetResponse();

            ret = true;

            //关闭资源
            webrs.Close();
        }
        catch (Exception)
        {
            ret = false;
        }

        return ret;
    }

    public static string FromatDecimal(object obj)
    {
        var value = Convert.ToInt32((decimal)obj);
        return value.ToString();
    }

}