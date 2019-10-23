<%@ Page Title="Send Mail" Language="C#" MasterPageFile="~/ContactNewsLetterManagementMasterPage.master" AutoEventWireup="true" CodeFile="Send.aspx.cs" Inherits="Send" %>


<asp:Content ID="ContentSend" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:Button ID="ButtonSendMail" runat="server" Text="Send Mail" OnClick="ButtonSendMail_Click" />
    <center>
    <asp:TextBox ID="TextBoxResponse" runat="server" MaxLength="100" TextMode="MultiLine" Width="830px" Height="195px"></asp:TextBox>
    </center>
</asp:Content>

