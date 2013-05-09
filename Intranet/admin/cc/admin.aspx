<%@ Page Title="" Language="C#" MasterPageFile="~/admin/a.master" AutoEventWireup="true" CodeFile="admin.aspx.cs" Inherits="admin_cc_admin" %>
<%@ Register TagPrefix="CKEditor" Namespace="CKEditor.NET" Assembly="CKEditor.NET, Version=3.6.4.0, Culture=neutral, PublicKeyToken=e379cdf2f8354999" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div>
            <CKEditor:CKEditorControl ID="CKEditor1" BasePath="~/ckeditor" runat="server" Height="200">
&lt;p&gt;
	This is some &lt;strong&gt;sample text&lt;/strong&gt;. You are using &lt;a href="http://ckeditor.com/"&gt;CKEditor&lt;/a&gt;.&lt;/p&gt;</CKEditor:CKEditorControl>
        </div>
</asp:Content>

