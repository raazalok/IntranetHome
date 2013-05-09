<%@ Page Title="" Language="C#" MasterPageFile="~/admin/cc/acc.master" AutoEventWireup="true"
    CodeFile="viewgallery.aspx.cs" Inherits="admin_cc_viewgallery" %>

<%@ Register Src="~/admin/controls/iscroller.ascx" TagName="iscroller" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="h" runat="Server">
    <script src="../../scripts/galleria-1.2.9.min.js" type="text/javascript"></script>
    <script src="../../scripts/themes/classic/galleria.classic.min.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="b" runat="Server">
    <uc1:iscroller ID="is" runat="server" />
</asp:Content>
