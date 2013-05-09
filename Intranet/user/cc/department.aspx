<%@ Page Title="" Language="C#" MasterPageFile="~/user/cc/cc.master" AutoEventWireup="true" CodeFile="department.aspx.cs" Inherits="user_cc_department" %>
<%@ Register Src="../controls/iscroller.ascx" TagName="iscroller" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="h" Runat="Server">
 <script src="../../scripts/galleria-1.2.9.min.js" type="text/javascript"></script>
    <script src="../../scripts/themes/classic/galleria.classic.min.js" type="text/javascript"></script>
    <style type="text/css">
        input[type=button]
        {
            background: none !important;
            border: none;
            padding: 0 !important; /*border is optional*/            
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="b" runat="Server">
    <uc1:iscroller ID="iscroller1" runat="server" />
</asp:Content>
