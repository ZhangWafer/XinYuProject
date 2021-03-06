<%@ Page Language="c#" Trace="false" Inherits="FredCK.FCKeditorV2.FileBrowser.Connector" AutoEventWireup="false" %>
<%@ Register Src="config.ascx" TagName="Config" TagPrefix="FCKeditor" %>
<%--
 * FCKeditor - The text editor for Internet - http://www.fckeditor.net
 * Copyright (C) 2003-2007 Frederico Caldeira Knabben
 *
 * == BEGIN LICENSE ==
 *
 * Licensed under the terms of any of the following licenses at your
 * choice:
 *
 *  - GNU General Public License Version 2 or later (the "GPL")
 *    http://www.gnu.org/licenses/gpl.html
 *
 *  - GNU Lesser General Public License Version 2.1 or later (the "LGPL")
 *    http://www.gnu.org/licenses/lgpl.html
 *
 *  - Mozilla Public License Version 1.1 or later (the "MPL")
 *    http://www.mozilla.org/MPL/MPL-1.1.html
 *
 * == END LICENSE ==
 *
 * This is the File Browser Connector for ASP.NET.
 *
 * The code of this page if included in the FCKeditor.Net package,
 * in the FredCK.FCKeditorV2.dll assembly file. So to use it you must
 * include that DLL in your "bin" directory.
 *
 * To download the FCKeditor.Net package, go to our official web site:
 * http://www.fckeditor.net
--%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <FCKeditor:Config id="Config" runat="server"></FCKeditor:Config>
    </form>
</body>
</html>
