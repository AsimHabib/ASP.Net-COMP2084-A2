<%@ Page Title="Add List Item" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="addlist.aspx.cs" Inherits="assign2.addlist" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Add List item</h1>

    <div class="form-group">
        <label for="txtitemName" class="col-sm-3 control-label">Item Name:</label>
        <asp:TextBox ID="txtitemName" runat="server" required />       
    </div>
    <asp:button class="btn btn-success col-sm-offset-3" id="btnSave"
        runat="server" text="Save" OnClick="btnSave_Click" />
    <asp:Label ID="lbltest" runat="server" />

</asp:Content>
