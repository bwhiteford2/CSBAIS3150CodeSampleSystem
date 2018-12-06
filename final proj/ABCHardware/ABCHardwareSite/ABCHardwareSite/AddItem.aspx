<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AddItem.aspx.cs" Inherits="AddItem" Theme="BSTheme" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="header" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContentPlaceHolder" runat="Server">
    <h1 class="jumbotron">Add Item</h1>

    <asp:Label ID="MessageBox" runat="server" Text=""></asp:Label>
    <div class="row form-body">
        <div class="col-md-6">
            <asp:Label ID="ItemCodeLbl" runat="server" Text="Item Code:"></asp:Label>
            <asp:TextBox ID="ItemCodeTextBox" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="ReqItemCode" runat="server" ErrorMessage="Item code is required" ControlToValidate="ItemCodeTextBox" Display="Dynamic"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="ItemCodeRegex" runat="server" ErrorMessage="Must be between 1-7 alpha numeric characters" ControlToValidate="ItemCodeTextBox" ValidationExpression="^[a-zA-Z0-9]{1,7}$" Display="Dynamic" ></asp:RegularExpressionValidator>

            <br />

            <asp:Label ID="DescriptionLbl" runat="server" Text="Description"></asp:Label>
            <asp:TextBox ID="DescriptionTextBox" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="ReqDesc" runat="server" ErrorMessage="Description is required" ControlToValidate="DescriptionTextBox" Display="Dynamic"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="DescRegex" runat="server" ErrorMessage="Description must be 40 alpha numeric characters or lower" ControlToValidate="DescriptionTextBox" Display="Dynamic" ValidationExpression="^[a-zA-Z0-9]{1,40}$"></asp:RegularExpressionValidator>

            <br />
            <asp:Label ID="UnitPriceLbl" runat="server" Text="Unit Price"></asp:Label>
            <asp:TextBox ID="UnitPriceTextBox" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="ReqUnitPrice" runat="server" ErrorMessage="Unit price is required" ControlToValidate="UnitPriceTextBox" Display="Dynamic"></asp:RequiredFieldValidator>
            <asp:RangeValidator ID="UnitPriceRange" runat="server" ErrorMessage="Must be 0.01 or greater" ControlToValidate="UnitPriceTextBox" MinimumValue="0.01" Display="Dynamic" Type="double" MaximumValue="214748.3647" ></asp:RangeValidator>

            <br />
            <asp:Button ID="Submit" runat="server" Text="Add Item" CssClass="btn btn-primary" OnClick="Submit_Click" />
        </div>
    </div>

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="footer" runat="Server">
</asp:Content>

