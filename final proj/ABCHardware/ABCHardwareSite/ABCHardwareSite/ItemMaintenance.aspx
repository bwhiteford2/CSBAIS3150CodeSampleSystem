<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ItemMaintenance.aspx.cs" Inherits="ItemMaintenance" Theme="BSTheme" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="header" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContentPlaceHolder" runat="Server">
    <h1 class="jumbotron">Item Maintenance</h1>


    <div class="row form-body">
        <div class="col-md-6">
            <asp:Label ID="MessageBox" runat="server" Text=""></asp:Label>
            <br />
            <asp:Label ID="IC" runat="server" Text="Item Code:"></asp:Label>
            <asp:TextBox ID="ItemCodeLookupTextBox" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="ReqItemCode" runat="server" ErrorMessage="Item code is required" ControlToValidate="ItemCodeLookupTextBox" Display="Dynamic" ValidationGroup="Lookup"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="ItemCodeRegex" runat="server" ErrorMessage="Must be between 1-7 alpha numeric characters" ControlToValidate="ItemCodeLookupTextBox" ValidationExpression="^[a-zA-Z0-9]{1,7}$" Display="Dynamic" ValidationGroup="Lookup"></asp:RegularExpressionValidator>

            <br />

            <asp:Button ID="LookupBtn" runat="server" Text="Lookup" CssClass="btn btn-primary" ValidationGroup="Lookup" OnClick="LookupBtn_Click" />
            <br />

            <asp:Panel ID="Panel1" runat="server" Visible="false">
                <asp:Label ID="ItemCode" runat="server" Text="Item Code:"></asp:Label>
                <asp:TextBox ID="ItemCodeTB" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>

                <asp:Label ID="DescriptionLbl" runat="server" Text="Description"></asp:Label>
                <asp:TextBox ID="DescriptionTextBox" runat="server" CssClass="form-control" ValidationGroup="Modify"></asp:TextBox>
                <asp:RequiredFieldValidator ID="ReqDesc" runat="server" ErrorMessage="Description is required" ControlToValidate="DescriptionTextBox" Display="Dynamic" ValidationGroup="Modify"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="DescRegex" runat="server" ErrorMessage="Description must be 40 alpha numeric characters or lower" ControlToValidate="DescriptionTextBox" ValidationGroup="Modify" Display="Dynamic" ValidationExpression="^[a-zA-Z0-9]{1,40}$"></asp:RegularExpressionValidator>

                <br />
                <asp:Label ID="UnitPriceLbl" runat="server" Text="Unit Price"></asp:Label>
                <asp:TextBox ID="UnitPriceTextBox" runat="server" CssClass="form-control" ValidationGroup="Modify"></asp:TextBox>
                <asp:RequiredFieldValidator ID="ReqUnitPrice" runat="server" ErrorMessage="Unit price is required" ControlToValidate="UnitPriceTextBox" Display="Dynamic" ValidationGroup="Modify"></asp:RequiredFieldValidator>
                <asp:RangeValidator ID="UnitPriceRange" runat="server" ErrorMessage="Must be 0.01 or greater" ControlToValidate="UnitPriceTextBox" MinimumValue="0.01" Display="Dynamic" Type="double" ValidationGroup="Modify" MaximumValue="214748.3647"></asp:RangeValidator>
                <br />

                <asp:Label ID="QoHLbl" runat="server" Text="Quantity on Hand"></asp:Label>
                <asp:TextBox ID="QoHTextBox" runat="server" CssClass="form-control" Text="0" ValidationGroup="Modify"></asp:TextBox>
                <asp:RangeValidator ID="QoHRangeValidator" runat="server" ErrorMessage="Must be between 0 and 2,147,483,647" ControlToValidate="QoHTextBox" Type="Double" MinimumValue="0" ValidationGroup="Modify" MaximumValue="2147483647" Display="Dynamic"></asp:RangeValidator>

                <br />

                <asp:Label ID="ActiveLbl" runat="server" Text="Active"></asp:Label>
                <asp:CheckBox ID="ActiveCB" runat="server" CssClass="" Checked="true" />
                <br />
                <br />
                <asp:Button ID="Modify" runat="server" Text="Modify" CssClass="btn btn-outline-primary" OnClick="Modify_Click" ValidationGroup="Modify" />
                <asp:Button ID="Delete" runat="server" Text="Delete" CssClass="btn btn-outline-danger" OnClick="Delete_Click" CausesValidation="false" OnClientClick="return confirm('Are you sure you want to delete this item?');" />
            </asp:Panel>
        </div>
    </div>

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="footer" runat="Server">
</asp:Content>

