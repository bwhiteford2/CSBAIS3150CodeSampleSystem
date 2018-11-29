<%@ Page Title="" Language="C#" MasterPageFile="~/BootstrapMasterPage.master" AutoEventWireup="true" CodeFile="FindStudent.aspx.cs" Inherits="FindStudent"  Theme="RedTheme"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" Runat="Server">
    <div class="jumbotron">
        <h1>Find Student</h1>
    </div>

     <div class="col-md-6 form-group form-body">
        
        <asp:Label ID="MessageLabel" runat="server" Text=""></asp:Label>
        <br />
        <asp:Label ID="FindStudentLabel" runat="server" Text="Find Student"></asp:Label>
        <br />
        <asp:TextBox ID="FindStudentTextBox" runat="server" class="form-control"></asp:TextBox>
        <br />
        <asp:Button ID="Submit" runat="server" Text="Submit" OnClick="Submit_Click" class="btn btn-primary" />
    </div>
</asp:Content>

