<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CustomerMaintenance.aspx.cs" Inherits="CustomerMaintenance"  Theme="BSTheme"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="header" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContentPlaceHolder" runat="Server">
    <h1 class="jumbotron">Customer Maintenance</h1>


    <div class="row form-body">
        <div class="col-md-6">
            <asp:Label ID="MessageBox" runat="server" Text=""></asp:Label>
            <br />
            <asp:Label ID="CustomerIDLbl" runat="server" Text="Customer ID:"></asp:Label>
            <asp:TextBox ID="CustomerIDTextBox" runat="server" CssClass="form-control" ValidationGroup="Lookup"></asp:TextBox>
            <asp:RequiredFieldValidator ID="CustIDReq" runat="server" ErrorMessage="Customer ID is required" Display="Dynamic" ControlToValidate="CustomerIDTextBox" ValidationGroup="Lookup"></asp:RequiredFieldValidator>

            <br />

            <asp:Button ID="LookupBtn" runat="server" Text="Lookup" CssClass="btn btn-primary" ValidationGroup="Lookup" OnClick="LookupBtn_Click" />
            <br />

            <asp:Panel ID="Panel1" runat="server" Visible="false">
                <asp:Label ID="CustIDLbl" runat="server" Text="Customer ID:"></asp:Label>
                <asp:TextBox ID="CustIDTB" runat="server" CssClass="form-control" ValidationGroup="Modify" ReadOnly="true"></asp:TextBox>
                <asp:RequiredFieldValidator ID="CustIDTBReq" runat="server" ErrorMessage="Customer ID is required" Display="Dynamic" ValidationGroup="Modify" ControlToValidate="CustIDTB"></asp:RequiredFieldValidator>
                <br />

                <asp:Label ID="CustNameLbl" runat="server" Text="Customer Name:"></asp:Label>
                <asp:TextBox ID="CustomerNameTextBox" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="CustNameReq" runat="server" ErrorMessage="Customer name is required" ValidationGroup="Modify" ControlToValidate="CustomerNameTextBox" Display="Dynamic"></asp:RequiredFieldValidator>
                <br />

                <asp:Label ID="AddressLbl" runat="server" Text="Address:"></asp:Label>
                <asp:TextBox ID="AddressTextBox" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="AddressReq" runat="server" ErrorMessage="Address is required" Display="Dynamic" ValidationGroup="Modify" ControlToValidate="AddressTextBox"></asp:RequiredFieldValidator>
                <br />

                <asp:Label ID="CityLbl" runat="server" Text="City:"></asp:Label>
                <asp:TextBox ID="CityTextBox" runat="server" CssClass="form-control" ValidationGroup="Modify"></asp:TextBox>
                <asp:RequiredFieldValidator ID="CityReq" runat="server" ErrorMessage="City is required" ValidationGroup="Modify" ControlToValidate="CityTextBox" Display="Dynamic"></asp:RequiredFieldValidator>
                <br />

                <asp:Label ID="PostalCodeLbl" runat="server" Text="Postal code:"></asp:Label>
                <asp:TextBox ID="PostalCodeTextBox" runat="server" CssClass="form-control" ValidationGroup="Modify"></asp:TextBox>
                <asp:RequiredFieldValidator ID="PCReq" runat="server" ErrorMessage="Postal Code is required" Display="Dynamic" ValidationGroup="Modify" ControlToValidate="PostalCodeTextBox"></asp:RequiredFieldValidator>
                <br />

                <asp:Label ID="ProvinceLbl" runat="server" Text="Province:"></asp:Label>
                <asp:TextBox ID="ProvinceTextBox" runat="server" CssClass="form-control" ValidationGroup="Modify"></asp:TextBox>
                <asp:RequiredFieldValidator ID="ProvinceReq" runat="server" ErrorMessage="Province is required" ValidationGroup="Modify" ControlToValidate="ProvinceTextBox" Display="Dynamic"></asp:RequiredFieldValidator>
                <br />
                <asp:Button ID="Modify" runat="server" Text="Modify" CssClass="btn btn-outline-primary" OnClick="Modify_Click" ValidationGroup="Modify" />
                <asp:Button ID="Delete" runat="server" Text="Delete" CssClass="btn btn-outline-danger" OnClick="Delete_Click" CausesValidation="false" OnClientClick="return confirm('Are you sure you want to delete this item?');" />
            </asp:Panel>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="footer" runat="Server">
</asp:Content>

