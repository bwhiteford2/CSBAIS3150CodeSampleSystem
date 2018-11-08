<%@ Page Title="" Language="C#" MasterPageFile="~/BootstrapMasterPage.master" AutoEventWireup="true" CodeFile="FindStudentsByProgram.aspx.cs" Inherits="FindStudentsByProgram" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="Server">
    <div class="jumbotron">
        <h1>Find Students By Program</h1>
    </div>

    <div class="form-body form-group col-md-6">
        <asp:Label ID="MessageLabel" runat="server" Text=""></asp:Label>
        <br />

        <asp:Label ID="FindStudentsByProgramLabel" runat="server" Text="Find Students by Program"></asp:Label>
        <asp:TextBox ID="FindStudentsByProgramTextBox" runat="server" CssClass="form-control"></asp:TextBox>

        <br />
        <asp:Button ID="Submit" runat="server" Text="Submit" OnClick="Submit_Click" CssClass="btn btn-primary" />
        <br />

        <asp:Table ID="StudentTable" runat="server" CssClass="table"></asp:Table>
    </div>
</asp:Content>

