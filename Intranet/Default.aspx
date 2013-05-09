<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" ValidateRequest="false" Inherits="_Default" %>

<%@ Register TagPrefix="CKEditor" Namespace="CKEditor.NET" Assembly="CKEditor.NET, Version=3.6.4.0, Culture=neutral, PublicKeyToken=e379cdf2f8354999" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div>
            <CKEditor:CKEditorControl ID="CKEditor1" BasePath="~/ckeditor" runat="server" Height="200">
&lt;p&gt;
	This is some &lt;strong&gt;sample text&lt;/strong&gt;. You are using &lt;a href="http://ckeditor.com/"&gt;CKEditor&lt;/a&gt;.&lt;/p&gt;</CKEditor:CKEditorControl>
        </div>
    </div>
    <asp:Button runat="server" ID="BtnSubmit" Text="Submit" OnClick="BtnSubmit_Click" />
    <script type="text/javascript">
        //        var editor = CKEDITOR.replace('CKEditor1');
        //        editor.setData('<p>Test.</p>');
        //        CKFinder.setupCKEditor(editor, 'ckfinder/');

        //        CKEDITOR.replace('CKEditor1',
        //{
        //    filebrowserBrowseUrl: '/ckfinder/ckfinder.html',
        //    filebrowserImageBrowseUrl: '/ckfinder/ckfinder.html?type=Images',
        //    filebrowserFlashBrowseUrl: '/ckfinder/ckfinder.html?type=Flash',
        //    filebrowserUploadUrl:
        // 	   '/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Files&currentFolder=/archive/',
        //    filebrowserImageUploadUrl:
        //	   '/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Images&currentFolder=/cars/',
        //    filebrowserFlashUploadUrl: '/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Flash'
        //});
    </script>
    <%--<script type="text/javascript" src="ckeditor/ckeditor.js"></script>
    <script type="text/javascript" src="ckfinder/ckfinder.js"></script>--%>
    <%--<asp:TextBox ID="TextBox1" runat="server" Rows="10" TextMode="MultiLine"></asp:TextBox>
    <script type="text/javascript">        CKEDITOR.replace('TextBox1')</script>--%>
    </form>
</body>
</html>
