<%@ Page Title="" Language="C#" MasterPageFile="~/user/er1/er1.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="user_er1_Default" %>

<%@ Register src="../controls/iscroller.ascx" tagname="iscroller" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="h" runat="Server">
    <script src="../../scripts/galleria-1.2.9.min.js" type="text/javascript"></script>
    <script src="../../scripts/themes/classic/galleria.classic.min.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="b" runat="Server">
    <uc1:iscroller ID="iscroller1" runat="server" />
</asp:Content>
