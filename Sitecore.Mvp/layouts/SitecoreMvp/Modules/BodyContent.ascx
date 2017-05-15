<%@ Control Language="C#" AutoEventWireup="true" Inherits="Sitecore.Mvp.Core.Views.Modules.BodyContentView" %>

<div style="padding: 20px">
    <%= Editable(x => x.Content) %>
</div>