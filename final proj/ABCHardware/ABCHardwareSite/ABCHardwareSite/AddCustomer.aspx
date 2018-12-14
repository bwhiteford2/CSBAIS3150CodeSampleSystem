<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AddCustomer.aspx.cs" Inherits="AddCustomer" Theme="BSTheme" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="header" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContentPlaceHolder" Runat="Server">
    <h1 class="jumbotron">Add Customer</h1>

    
    <div class="row form-body">
        <div class="col-md-6"> 
            <asp:Label ID="MessageBox" runat="server" Text=""></asp:Label>
            <br />

            <asp:Label ID="CustomerIDLbl" runat="server" Text="Customer ID:"></asp:Label>
            <asp:TextBox ID="CustomerIDTextBox" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="CustIDReq" runat="server" ErrorMessage="Customer ID is required" Display="Dynamic" ControlToValidate="CustomerIDTextBox" ></asp:RequiredFieldValidator>
            <br />

            <asp:Label ID="CustNameLbl" runat="server" Text="Customer Name:"></asp:Label>
            <asp:TextBox ID="CustomerNameTextBox" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="CustNameReq" runat="server" ErrorMessage="Customer name is required" ControlToValidate="CustomerNameTextBox" Display="Dynamic"></asp:RequiredFieldValidator>
            <br />

            <asp:Label ID="AddressLbl" runat="server" Text="Address:"></asp:Label>
            <asp:TextBox ID="AddressTextBox" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="AddressReq" runat="server" ErrorMessage="Address is required" Display="Dynamic" ControlToValidate="AddressTextBox"></asp:RequiredFieldValidator>
            <br />

            <asp:Label ID="CityLbl" runat="server" Text="City:"></asp:Label>
            <asp:TextBox ID="CityTextBox" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="CityReq" runat="server" ErrorMessage="City is required" ControlToValidate="CityTextBox" Display="Dynamic"></asp:RequiredFieldValidator>
            <br />

            <asp:Label ID="PostalCodeLbl" runat="server" Text="Postal code:"></asp:Label>
            <asp:TextBox ID="PostalCodeTextBox" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="PCReq" runat="server" ErrorMessage="Postal Code is required" Display="Dynamic" ControlToValidate="PostalCodeTextBox"></asp:RequiredFieldValidator>
            <br />

            <asp:Label ID="Province" runat="server" Text="Province:"></asp:Label>
            <asp:TextBox ID="ProvinceTextBox" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="ProvinceReq" runat="server" ErrorMessage="Province is required" ControlToValidate="ProvinceTextBox" Display="Dynamic"></asp:RequiredFieldValidator>
            <br />

            <asp:Button ID="Submit" runat="server" Text="Submit" CssClass="btn btn-primary" OnClick="Submit_Click" />

        </div>
    </div>

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="footer" Runat="Server">
</asp:Content>

