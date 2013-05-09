<%@ Page Title="" Language="C#" MasterPageFile="~/admin/cc/acc.master" AutoEventWireup="true"
    CodeFile="addgallery.aspx.cs" Inherits="admin_cc_addgallery" %>

<%@ Register src="../controls/addgallery.ascx" tagname="addgallery" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="h" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="b" runat="Server">
    <uc1:addgallery ID="a" runat="server" />
</asp:Content>
