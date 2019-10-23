<%@ Page Title="Contact Manager" Language="C#" MasterPageFile="~/ContactNewsLetterManagementMasterPage.master" AutoEventWireup="true" CodeFile="contact.aspx.cs" Inherits="contact" %>

<asp:Content ID="ContactForm" ContentPlaceHolderID="MainContent" Runat="Server">	
    <h3>Enter Contact Information Below</h3>
    <div class="entryform">
        <asp:Label CssClass="label" ID="fNameLabel" runat="server" Text="First Name:"></asp:Label>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Name field cannot be blank" ControlToValidate="fName" ForeColor="Red"></asp:RequiredFieldValidator><br />  
        <asp:TextBox CssClass="textbox" ID="fName" runat="server"></asp:TextBox><br /><br />
          
        <asp:Label CssClass="label" ID="lNameLabel" runat="server" Text="Last Name:"></asp:Label>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Name field cannot be blank" ControlToValidate="lName" ForeColor="Red"></asp:RequiredFieldValidator><br />  
        <asp:TextBox CssClass="textbox" ID="lName" runat="server" Width="154px"></asp:TextBox><br /><br />

        <asp:Label CssClass="label" ID="eMailLabel" runat="server" Text="e-Mail Address:"></asp:Label>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Email cannot be blank" ControlToValidate="eMail" ForeColor="Red"></asp:RequiredFieldValidator>  
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="eMail" ErrorMessage="Enter proper email format" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator><br />  
        <asp:TextBox CssClass="textbox" ID="eMail" runat="server" Width="230px"></asp:TextBox><br /><br />
  

   	    <asp:Label CssClass="label" ID="PhoneLabel" runat="server" Text="Phone Number"></asp:Label><br />
        <asp:TextBox CssClass="textbox" ID="Phone" runat="server"></asp:TextBox><br /><br />

   		<asp:Label CssClass="label" ID="CommentsLabel" runat="server" Text="Comments:"></asp:Label><br />
        <asp:TextBox CssClass="label" ID="Comments" runat="server" Height="102px" Rows="10" TextMode="MultiLine" Width="381px"></asp:TextBox>
            <br /><br /><br /><br /><br /><br /><br />
          
        <asp:Button ID="Prev" runat="server" Text="<-] Prev" OnClick="Prev_Click" />
         &nbsp;
        <asp:Button ID="Add" runat="server" Text="Add" OnClick="Add_Click" />
        <asp:Button ID="Update" runat="server" Text="Update" OnClick="Update_Click" style="height: 26px; width: 61px" />
        <asp:Button ID="Remove" runat="server" Text="Remove" OnClick="Remove_Click" />
        <asp:Button ID="reset" runat="server" Text="Reset" OnClick="Reset_Click" />&nbsp; 
         &nbsp;
        <asp:Button ID="Next" runat="server" Text="Next [->" OnClick="Next_Click" /><br /><br />
    </div>
</asp:Content>

