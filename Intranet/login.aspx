<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login"
    EnableViewState="false" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>
        <asp:Literal runat="server" Text="<%$ Resources:IHome,Title %>"></asp:Literal>
    </title>
    <link rel="shortcut icon" type="image/ico" href="Images/Pgcil.ico" />
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <meta charset="utf-8">
    <meta name="viewport" content="target-densitydpi=device-dpi, width=device-width, initial-scale=1.0, maximum-scale=1">
    <meta name="author" content="Alok Raj">
    <meta name="keywords" content="Powergrid India, Powergrid Corporation of India Limited, PGCIL, Powergrid Information Technology Department">
    <meta http-equiv="X-UA-Compatible" content="IE=Edge" />
    <meta name="description" content="Account Login Membership User Password" />
    <link href="Styles/account.css" rel="stylesheet" type="text/css" />
    <script src="scripts/jquery-1.8.3.min.js" type="text/javascript"></script>
    <script src="scripts/jquery.ui.all.js" type="text/javascript"></script>
    <script src="scripts/jquery.watermarkinput.js" type="text/javascript"></script>
    <script src="scripts/jquery.validate.min.js" type="text/javascript"></script>
   
</head>
<body>
    <form id="form1" runat="server" autocomplete="off">
    <div class="page">
        <div class="header">
            <div class="title">
                <img alt="Powergrid India Intranet" src="images/LOGO.png" title="PowerGrid Logo" />
            </div>
            <div class="loginDisplay">
                <a href="http://www.powergridindia.com" runat="server" title="<%$ Resources:IHome,ReturnToPGWebsite %>">
                    <asp:Literal ID="l1" runat="server" Text="<%$ Resources:IHome,ReturnToPGWebsite %>"></asp:Literal>
                </a>
            </div>
            <div class="loginDisplay">
                <asp:DropDownList runat="server" ID="dL" AutoPostBack="True">
                    <asp:ListItem Text="English" Value="en-US"></asp:ListItem>
                    <asp:ListItem Text="हिंदी" Value="hi-IN"></asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
        <div class="clear">
        </div>
        <br />
        <div class="main">
            <div id="StatusBox">
                <div id="AdminStatus" runat="server" style="display: none">
                </div>
            </div>
            <div class="accountInfo">
                <div class="login">
                    <h1>
                        <asp:Label runat="server" ID="lblTitle" Text="<%$ Resources:IHome,LogInSmall %>"></asp:Label></h1>
                    <div class="field">
                        <asp:Literal ID="l2" runat="server" Text="<%$ Resources:IHome,UserName %>"></asp:Literal>
                        <div class="boxRound">
                            <asp:TextBox ID="tUserName" runat="server" AutoCompleteType="None" CssClass="textEntry"></asp:TextBox>
                        </div>
                    </div>
                    <div class="field">
                        <asp:Literal ID="l3" runat="server" Text="<%$ Resources:IHome,Password %>"></asp:Literal>
                        <div class="boxRound">
                            <asp:TextBox ID="tPassword" runat="server" CssClass="passwordEntry" TextMode="Password"></asp:TextBox>
                        </div>
                        <br />
                        <asp:CheckBox runat="server" ID="chkr" Text="<%$ Resources:IHome,RememberMe %>" />
                    </div>
                    <div class="submitButton">
                        <asp:Button ID="LoginButton" runat="server" Text="<%$ Resources:IHome,LogInSmall %>"
                            OnClick="LoginButton_Click" />
                        <asp:PlaceHolder ID="phResetPassword" runat="server"><span>
                            <asp:HyperLink runat="server" ID="linkForgotPassword" Text="<%$ Resources:IHome,ForgetPassword %>" />
                        </span></asp:PlaceHolder>
                    </div>
                </div>
            </div>
            <div class="alertmsg">
            </div>
            <script type="text/javascript">
                $(document).ready(function () {
                    $("input[name$='UserName']").focus();
                });
                
            </script>
        </div>
    </div>
    <div class="ui-widget-header ui-corner-all" id="footer" style="text-align: center">
        <strong>
            <asp:Literal ID="l4" runat="server" Text="<%$ Resources:IHome,CopyRight %>"></asp:Literal>
        </strong>
    </div>
    <script type="text/javascript">
        $(document).ready(function () {
            var validator = $("#form1").validate({
                rules: {
                    tUserName: "required",
                    tPassword: { required: true, minlength: 5 }
                },
                messages: {
                    tUserName: "Please enter your UserName.",tPassword: { required: "Please enter your Password.",
                        minlength: "Password should be at least 5 characters long"
                    }
                },
                wrapper: 'li',
                errorLabelContainer: $("#form1 div.alertmsg")
            });
            $("#LoginButton").click(function (e) {
                //e.preventDefault();
                //$("#tUserName").val("");
                //$("#tPassword").val("");
            });
        });
    </script>
    </form>
</body>
</html>
