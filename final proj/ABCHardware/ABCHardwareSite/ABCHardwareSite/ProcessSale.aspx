<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ProcessSale.aspx.cs" Inherits="ProcessSale" Theme="BSTheme" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="header" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContentPlaceHolder" Runat="Server">
    <h1 class="jumbotron">Process Sale</h1>

    <h3>Incomplete :(</h3>

    <div class="row form-body">
        <div class="col-md-6">
            <asp:Label ID="MessageBox" runat="server" Text=""></asp:Label>
            <br />

            <asp:Label ID="ItemCodeLbl" runat="server" Text="Item Code:"></asp:Label>
            <asp:TextBox ID="ItemCodeTextBox" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="ReqItemCode" runat="server" ErrorMessage="Item code is required" ControlToValidate="ItemCodeTextBox" Display="Dynamic"></asp:RequiredFieldValidator>

            <br />

            <asp:Label ID="QtyLbl" runat="server" Text="Quantity"></asp:Label>
            <asp:TextBox ID="QtyTextbox" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="QtyReq" runat="server" ErrorMessage="Quantity is required" Display="Dynamic" ControlToValidate="QtyTextBox" ></asp:RequiredFieldValidator>            

            <asp:Button ID="AddToCart" runat="server" Text="Add To Cart" CssClass="btn btn-primary" OnClick="AddToCart_Click" />
        </div>

        <div class="col-md-6">
            <asp:Label ID="CartLbl" runat="server" Text="Cart"></asp:Label>
            <asp:Table ID="Table1" runat="server" CssClass="table"></asp:Table>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="footer" Runat="Server">
</asp:Content>

