<%@ page language="c#" inherits="Sitecore.Mvp.Core.Views.DefaultLayoutView" %>

<%@ outputcache location="None" varybyparam="none" %>

<!DOCTYPE html>
<html lang="en" xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    
    <title><%= Model.Title %></title>
    <meta name="description" content="<%# Model.Description %>" />
    <meta name="keywords" content="<%# Model.Keywords %>" />

    <meta property="og:title" content="<%# Model.OgTitle %>" />
    <meta property="og:type" content="website" />
    <meta property="og:image" content="<%# Model.OgImage.Src %>" />
    <meta property="og:url" content="<%# Model.CanonicalUrl %>" />
    <meta property="og:description" content="<%# Model.OgDescription %>" />

    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <meta name="CODE_LANGUAGE" content="C#" />
    <meta name="vs_defaultClientScript" content="JavaScript" />
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5" />
    
    <link href="/Content/bootstrap.min.css" rel="stylesheet" />
    <link href="/Content/site.css" rel="stylesheet" />

    <script src="/Scripts/jquery-3.1.1.min.js"></script>
    <script src="/Scripts/bootstrap.min.js"></script>
    
    <sc:visitoridentification runat='server' />

</head>

<body>
    <form method="post" runat="server">
        <div class="container">
            <sc:placeholder key="main" runat="server" />
        </div>
    </form>
</body>

</html>
