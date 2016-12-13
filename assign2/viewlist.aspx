<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="viewlist.aspx.cs" Inherits="assign2.viewlist" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <h1>Item List</h1>
    <a href="addlist.aspx" class="btn btn-success">Add a new item</a>
    <asp:GridView ID="grdList" runat="server" CssClass="table table-striped" autogeneratecolumns="false"
        DataKeyNames="itemID" OnRowDeleting="grdList_RowDeleting">
        <EmptyDataTemplate>Your list is empty. Please add the item to your list</EmptyDataTemplate>
        <Columns>
            <asp:BoundField DataField="itemID" HeaderText="ID" />
            <asp:BoundField DataField="itemName" HeaderText="Item Name" />
            <asp:HyperLinkField HeaderText="Edit" Text="Edit" 
                NavigateUrl="~/addlist.aspx"
                DataNavigateUrlFields="itemID" 
                DataNavigateUrlFormatString="~/addlist.aspx?itemID={0}" ControlStyle-CssClass="btn-primary btn-sm"   /> 
            <asp:CommandField HeaderText="Delete" ShowDeleteButton="true" ControlStyle-CssClass="confirmation btn-primary btn-sm" />
        </Columns>
    </asp:GridView>
    <label id="lblCount"></label>
</asp:Content>
