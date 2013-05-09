<%@ Control Language="C#" AutoEventWireup="true" CodeFile="addgallery.ascx.cs" Inherits="admin_controls_addgallery" %>
<%--<link rel="Stylesheet" type="text/css" href="../services/f/CSS/uploadify.css" />--%>
<%--<script type="text/javascript" src="../services/f/scripts/jquery.uploadify.js"></script>--%>
<script src="../../scripts/jquery-migrate-1.1.1.min.js" type="text/javascript"></script>
<%--<script src="../../scripts/jquery.validate.min.js" type="text/javascript"></script>--%>
<style type="text/css">
    .altText
    {
        border: blue solid thin;
        width: 100%;
    }
    input[type="file"]
    {
        width: 100%;
    }
</style>
<br />
<asp:ScriptManager ID="s" runat="server">
</asp:ScriptManager>
<div style="padding-left: 5px">
    <asp:Button runat="server" Text="<%$Resources:AAddGallery,ShowExistingGallery %>"
        ID="BtnShow" OnClick="BtnShow_Click" CausesValidation="False" />
    <asp:Button runat="server" Text="<%$Resources:AAddGallery,AddNewGallery %>" ID="BtnNew"
        OnClick="BtnNew_Click" CausesValidation="False" />
    <asp:Button runat="server" Text="<%$Resources:AAddGallery,EditGallery %>" ID="BtnEdit"
        OnClick="BtnEdit_Click" CausesValidation="False" />
</div>
<br />
<asp:Panel runat="server" ID="pnlExisting" Visible="False">
    <asp:UpdatePanel ID="u1" runat="server">
        <ContentTemplate>
            <div style="padding-left: 5px; padding-bottom: 5px;">
                <asp:Literal runat="server" Text="<%$Resources:AAddGallery,SelectSite %>" ID="lSelectSite"></asp:Literal>
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:DropDownList runat="server" ID="dSitesEx">
                </asp:DropDownList>
                <br />
                <br />
                <asp:Button runat="server" ID="BtnShowExisting" Text="Show Galleries" OnClick="BtnShowExisting_Click"
                    CausesValidation="False" />
                <br />
                <br />
                <asp:GridView ID="gExisting" runat="server" DataKeyNames="GalleryId" CellPadding="4"
                    ForeColor="#000000" CssClass="gvtest" Font-Names="Verdana" Font-Size="11px" Font-Bold="false"
                    Caption="List Of Galleries" CaptionAlign="Top" GridLines="Both" EmptyDataRowStyle-BackColor="White"
                    ShowFooter="false" AutoGenerateColumns="false" Width="100%" AllowSorting="false"
                    EmptyDataText="No Gallery" AllowPaging="false" PageSize="100" OnRowDataBound="gExisting_RowDataBound">
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Center" Height="10px"
                        CssClass="gvr" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <HeaderStyle BackColor="Darkgray" Font-Bold="True" ForeColor="Black" CssClass="_widgetHead ui-widget-header gvh" />
                    <AlternatingRowStyle BackColor="White" ForeColor="#000099" />
                    <EmptyDataRowStyle BackColor="White" HorizontalAlign="Center" />
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <%# Container.DataItemIndex + 1 %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:HyperLink runat="server" ID="hView"></asp:HyperLink>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="SiteId" HeaderText="Id" />
                        <asp:BoundField DataField="GalleryId" HeaderText="Gallery" />
                        <asp:BoundField DataField="GalleryName" HeaderText="Gallery Name" />
                        <asp:BoundField DataField="Status" HeaderText="Status" />
                        <asp:BoundField DataField="UpdatedBy" HeaderText="UpdatedBy" />
                        <asp:BoundField DataField="UpdatedOn" HeaderText="Updated On" />
                        <asp:BoundField DataField="IsDefault" HeaderText="IsDefault" />
                    </Columns>
                </asp:GridView>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Panel>
<asp:Panel runat="server" ID="pnlNew" Visible="False">
    <%--  <asp:UpdatePanel ID="u2" runat="server">
        <ContentTemplate>--%>
    <div style="padding-left: 5px; padding-bottom: 5px;">
        Select Site: &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList runat="server" ID="dSites">
        </asp:DropDownList>
        <br />
        <br />
        Enter Gallery Name: &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox runat="server" ID="tGalleryName" Width="100%"></asp:TextBox>
        <asp:RequiredFieldValidator runat="server" ControlToValidate="tGalleryName" ErrorMessage="Please Enter Gallery Name"
            SetFocusOnError="True" CssClass="error" Display="Dynamic"></asp:RequiredFieldValidator>
        <fieldset>
            <legend>Upload Multiple Photos</legend>
            <div id="div1" runat="server">
                <input type="file" runat="server" id="f1" />
                <br />
                <input type="text" runat="server" id="t1" class="altText" />
                &nbsp;&nbsp;Text
                <br />
                <input type="file" runat="server" id="f2" />
                <br />
                <input type="text" runat="server" id="t2" class="altText" />
                &nbsp;&nbsp;Text
                <br />
                <input type="file" runat="server" id="f3" />
                <br />
                <input type="text" runat="server" id="t3" class="altText" />
                &nbsp;&nbsp;Text
                <br />
                <input type="file" runat="server" id="f4" />
                <br />
                <input type="text" runat="server" id="t4" class="altText" />
                &nbsp;&nbsp;Text
                <br />
                <input type="file" runat="server" id="f5" />
                <br />
                <input type="text" runat="server" id="t5" class="altText" />
                &nbsp;&nbsp;Text
            </div>
            <br />
            <div id="div2" runat="server" visible="false">
                <input type="file" runat="server" id="f6" />
                <br />
                <input type="text" runat="server" id="t6" class="altText" />
                &nbsp;&nbsp;Text
                <br />
                <input type="file" runat="server" id="f7" />
                <br />
                <input type="text" runat="server" id="t7" class="altText" />
                &nbsp;&nbsp;Text
                <br />
                <input type="file" runat="server" id="f8" />
                <br />
                <input type="text" runat="server" id="t8" class="altText" />
                &nbsp;&nbsp;Text
                <br />
                <input type="file" runat="server" id="f9" />
                <br />
                <input type="text" runat="server" id="t9" class="altText" />
                &nbsp;&nbsp;Text
                <br />
                <input type="file" runat="server" id="f10" />
                <br />
                <input type="text" runat="server" id="t10" class="altText" />
                &nbsp;&nbsp;Text
                <br />
            </div>
            <br />
            <asp:CheckBox runat="server" ID="chkMakeDefault" Text="Make This Gallery Default" />
            <asp:Button ID="BtnUpload" runat="server" Text="Upload" OnClick="BtnUpload_Click" />
            <asp:Button ID="ButtonMore" runat="server" Text="Add 10 Photos" OnClick="ButtonMore_Click"
                CausesValidation="False" />
        </fieldset>
        <br />
        <div id="div5" runat="server" visible="false">
            <fieldset>
                <legend>Show Photos</legend>
                <div id="div3" runat="server">
                    <asp:Image ID="Image1" runat="server" Height="100" Width="100" ImageUrl="../../images/Image.gif" />
                    <asp:Image ID="Image2" runat="server" Height="100" Width="100" ImageUrl="../../images/Image.gif" />
                    <asp:Image ID="Image3" runat="server" Height="100" Width="100" ImageUrl="../../images/Image.gif" />
                    <asp:Image ID="Image4" runat="server" Height="100" Width="100" ImageUrl="../../images/Image.gif" />
                    <asp:Image ID="Image5" runat="server" Height="100" Width="100" ImageUrl="../../images/Image.gif" />
                </div>
                <br />
                <div id="div4" runat="server" visible="false">
                    <asp:Image ID="Image6" runat="server" Height="100" Width="100" ImageUrl="../../images/Image.gif" />
                    <asp:Image ID="Image7" runat="server" Height="100" Width="100" ImageUrl="../../images/Image.gif" />
                    <asp:Image ID="Image8" runat="server" Height="100" Width="100" ImageUrl="../../images/Image.gif" />
                    <asp:Image ID="Image9" runat="server" Height="100" Width="100" ImageUrl="../../images/Image.gif" />
                    <asp:Image ID="Image10" runat="server" Height="100" Width="100" ImageUrl="../../images/Image.gif" />
                </div>
            </fieldset>
        </div>
    </div>
    <%--   </ContentTemplate>
    </asp:UpdatePanel>--%>
</asp:Panel>
<asp:Panel runat="server" ID="pEdit" Visible="False">
    <asp:UpdatePanel ID="u3" runat="server">
        <ContentTemplate>
            <div style="padding-left: 5px; padding-bottom: 5px;">
                Select Site: &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:DropDownList runat="server" ID="dEdit">
                </asp:DropDownList>
                <br />
                <br />
                <asp:Button runat="server" ID="BShowEdit" Text="Show Galleries" OnClick="BShowEdit_Click"
                    CausesValidation="False" />
                <asp:UpdateProgress runat="server" AssociatedUpdatePanelID="u3">
                    <ProgressTemplate>
                        <img src="../../images/upg/ablue.gif" alt="Updating" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
                <br />
                <br />
                <asp:GridView ID="gEdit" runat="server" DataKeyNames="SiteId,GalleryId" CellPadding="4"
                    ForeColor="#000000" CssClass="gvtest" Font-Names="Verdana" Font-Size="11px" Font-Bold="false"
                    Caption="List Of Galleries" CaptionAlign="Top" GridLines="Both" EmptyDataRowStyle-BackColor="White"
                    ShowFooter="false" AutoGenerateColumns="false" Width="100%" AllowSorting="false"
                    EmptyDataText="No Gallery" AllowPaging="false" PageSize="100" OnRowDataBound="gEdit_RowDataBound"
                    OnSelectedIndexChanged="gEdit_SelectedIndexChanged">
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Center" Height="10px"
                        CssClass="gvr" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <HeaderStyle BackColor="Darkgray" Font-Bold="True" ForeColor="Black" CssClass="_widgetHead ui-widget-header gvh" />
                    <SelectedRowStyle BackColor="Yellow"></SelectedRowStyle>
                    <AlternatingRowStyle BackColor="White" ForeColor="#000099" />
                    <EmptyDataRowStyle BackColor="White" HorizontalAlign="Center" />
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <%# Container.DataItemIndex + 1 %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:CommandField ShowSelectButton="True" />
                        <asp:BoundField DataField="SiteId" HeaderText="Id" />
                        <asp:BoundField DataField="GalleryId" HeaderText="Gallery" />
                        <asp:BoundField DataField="GalleryName" HeaderText="Gallery Name" />
                        <asp:BoundField DataField="Status" HeaderText="Status" />
                        <asp:BoundField DataField="UpdatedBy" HeaderText="UpdatedBy" />
                        <asp:BoundField DataField="UpdatedOn" HeaderText="Updated On" />
                        <%--<asp:BoundField DataField="IsDefault" HeaderText="IsDefault" />--%>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                Is Default</HeaderTemplate>
                            <ItemTemplate>
                                <asp:CheckBox runat="server" ID="c" AutoPostBack="true" OnCheckedChanged="CheckedChanged"
                                    Checked='<%# Convert.ToBoolean(Eval("IsDefault").ToString()) %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <br />
                <br />
                <asp:GridView ID="gPhotos" runat="server" DataKeyNames="GalleryId" CellPadding="4"
                    ForeColor="#000000" CssClass="gvtest" Font-Names="Verdana" Font-Size="11px" Font-Bold="false"
                    Caption="List Of Galleries" CaptionAlign="Top" GridLines="Both" EmptyDataRowStyle-BackColor="White"
                    ShowFooter="false" AutoGenerateColumns="false" Width="100%" AllowSorting="false"
                    EmptyDataText="No Gallery" AllowPaging="false" PageSize="100" OnRowDataBound="gPhotos_RowDataBound">
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Center" Height="10px"
                        CssClass="gvr" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <HeaderStyle BackColor="Darkgray" Font-Bold="True" ForeColor="Black" CssClass="_widgetHead ui-widget-header gvh" />
                    <AlternatingRowStyle BackColor="White" ForeColor="#000099" />
                    <EmptyDataRowStyle BackColor="White" HorizontalAlign="Center" />
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <%# Container.DataItemIndex + 1 %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                Is Active</HeaderTemplate>
                            <ItemTemplate>
                                <asp:CheckBox runat="server" ID="c" AutoPostBack="true" OnCheckedChanged="ChkBlockChanged"
                                    Checked='<%# Convert.ToInt32(Eval("Status").ToString())==1 %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="AltText" HeaderText="AltText" />
                        <asp:TemplateField HeaderText="Preview Image">
                            <ItemTemplate>
                                <asp:ImageButton ID="ib1" runat="server" ImageUrl='<%# Eval("PictureUrl")%>' Width="250px"
                                    Height="200px" Style="cursor: pointer" OnClientClick="return LoadDiv(this.src);" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="PictureUrl" HeaderText="Image Name" />
                        <asp:BoundField DataField="Status" HeaderText="Status" />
                        <asp:BoundField DataField="UpdatedBy" HeaderText="UpdatedBy" />
                        <asp:BoundField DataField="UpdatedOn" HeaderText="Updated On" />
                    </Columns>
                </asp:GridView>
                <br />
                <fieldset runat="server" id="fieldS" visible="False">
                    <legend>Add New Photo</legend>
                    <div id="div6" runat="server">
                        <asp:FileUpload runat="server" Width="100%" ID="fNew" />
                        <br />
                        <asp:RequiredFieldValidator runat="server" ID="r1" ControlToValidate="fNew" ErrorMessage="Please Select An Image To Upload."
                            Display="Dynamic"></asp:RequiredFieldValidator>
                        <br />
                        <input type="text" size="65" runat="server" id="t11" class="altText" />
                        &nbsp;&nbsp;Text
                        <br />
                        <asp:RequiredFieldValidator runat="server" ID="r2" ControlToValidate="t11" ErrorMessage="Please Select Alternate Text For The Image."
                            Display="Dynamic"></asp:RequiredFieldValidator>
                    </div>
                    <br />
                    <asp:Button runat="server" Text="Upload Image" ID="BtnUploadSingle" OnClick="BtnUploadSingle_Click" />
                </fieldset>
                <div id="divBackground" class="modal">
                </div>
                <div id="divImage" class="info">
                    <table style="height: 100%; width: 100%">
                        <tr>
                            <td valign="middle" align="center">
                                <img id="imgLoader" alt="" src="../../images/upg/loader.gif" />
                                <img id="imgFull" runat="server" alt="" src="" style="display: none; height: 500px;
                                    width: 590px" />
                            </td>
                        </tr>
                        <tr>
                            <td align="center" valign="bottom">
                                <input id="btnClose" type="button" value="close" onclick="HideDiv()" />
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <style type="text/css">
                caption
                {
                    background-color: #333300;
                    color: #FFFFFF;
                    font-weight: bold;
                }
                .popBox
                {
                    position: absolute;
                    z-index: 10000000;
                    opacity: 1.0;
                    background: #989898;
                    color: #FFFFFF;
                    width: auto;
                    height: auto;
                    padding: 0.3em;
                    border: 1px solid gray;
                    text-align: left;
                }
                .popBoxCancel
                {
                    position: absolute;
                    z-index: 2;
                    background: #FFFF66;
                    width: 100px;
                    height: 100px;
                    padding: 0.3em;
                    border: 1px solid gray;
                    text-align: left;
                }
                .text
                {
                    font-family: Verdana;
                    font-weight: bold;
                    font-size: 11px;
                }
                .modal
                {
                    display: none;
                    position: absolute;
                    top: 0px;
                    left: 0px;
                    background-color: black;
                    z-index: 100;
                    opacity: 0.8;
                    filter: alpha(opacity=60);
                    -moz-opacity: 0.8;
                    min-height: 100%;
                }
                #divImage
                {
                    display: none;
                    z-index: 1000;
                    position: fixed;
                    top: 0;
                    left: 0;
                    background-color: White;
                    height: 550px;
                    width: 600px;
                    padding: 3px;
                    border: solid 1px black;
                }
                * html #divImage
                {
                    position: absolute;
                }
            </style>
            <script type="text/javascript">
                function LoadDiv(url) {
                    var img = new Image();
                    var bcgDiv = document.getElementById("divBackground");
                    var imgDiv = document.getElementById("divImage");
                    var imgFull = document.getElementById("ctl00_b_a_imgFull");
                    var imgLoader = document.getElementById("imgLoader");

                    imgLoader.style.display = "block";
                    img.onload = function () {
                        imgFull.src = img.src;
                        imgFull.style.display = "block";
                        imgLoader.style.display = "none";
                    };
                    img.src = url;
                    var width = document.body.clientWidth;
                    if (document.body.clientHeight > document.body.scrollHeight) {
                        bcgDiv.style.height = document.body.clientHeight + "px";
                    }
                    else {
                        bcgDiv.style.height = document.body.scrollHeight + "px";
                    }

                    imgDiv.style.left = (width - 650) / 2 + "px";
                    imgDiv.style.top = "20px";
                    bcgDiv.style.width = "100%";

                    bcgDiv.style.display = "block";
                    imgDiv.style.display = "block";
                    return false;
                }
                function HideDiv() {
                    var bcgDiv = document.getElementById("divBackground");
                    var imgDiv = document.getElementById("divImage");
                    var imgFull = document.getElementById("ctl00_b_a_imgFull");
                    if (bcgDiv != null) {
                        bcgDiv.style.display = "none";
                        imgDiv.style.display = "none";
                        imgFull.style.display = "none";
                    }
                }
            </script>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="BtnUploadSingle" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Panel>
