<%@ Page Title="Scheduler" Language="C#" MasterPageFile="~/ContactNewsLetterManagementMasterPage.master" AutoEventWireup="true" CodeFile="schedule.aspx.cs" Inherits="schedule" %>

<asp:Content ID="ContentSchedule" ContentPlaceHolderID="MainContent" runat="Server">
    <h1>Newsletter Scheduler</h1>

   
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
        SelectCommand="SELECT * FROM [Schedule]" 
        InsertCommand="INSERT INTO [Schedule] VALUES (@Descript, @SendFile, @SendDate)"
        UpdateCommand="UPDATE [Schedule] SET Descript = @Descript, SendFile = @SendFile, SendDate= @SendDate WHERE pKey = @pKey"
        DeleteCommand="DELETE FROM Schedule WHERE pKey = @pKey" >
        
        <InsertParameters>
            <asp:Parameter Name="Descript"  Type="String" />
            <asp:Parameter Name="SendFile"  Type="String" />
            <asp:Parameter Name="SendDate"  Type="DateTime" />
        </InsertParameters>
        <UpdateParameters>
           <asp:Parameter Name="Descript"  Type="String" />
           <asp:Parameter Name="SendFile"  Type="String" />
           <asp:Parameter Name="SendDate"  Type="DateTime" />
        </UpdateParameters>
        <DeleteParameters>
            <asp:Parameter Name="pKey"     Type="Int32" />
        </DeleteParameters>
    </asp:SqlDataSource>


    <asp:gridview id="GridViewSchedule" runat="server" autogeneratecolumns="False" backcolor="#DEBA84" bordercolor="#DEBA84" borderstyle="None" borderwidth="1px" cellpadding="3" cellspacing="2" datakeynames="pKey" datasourceid="SqlDataSource1" width="927px" height="100px" style="margin-top: 0px; margin-bottom: 0px;" AllowPaging="True" ShowFooter="True">
        <Columns>
            <asp:TemplateField ShowHeader="False">
                <EditItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" ValidationGroup="grpEdit" CommandName="Update" Text="Update"></asp:LinkButton>
                    &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel"></asp:LinkButton>
                </EditItemTemplate>

                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton3" runat="server" CausesValidation="False" CommandName="Edit" Text="Edit"></asp:LinkButton>
                    &nbsp;<asp:LinkButton ID="LinkButton4" runat="server" CausesValidation="False" CommandName="Delete"  Text="Delete"></asp:LinkButton>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:LinkButton ID="LinkButtonInsert" runat="server" CausesValidation="false" CommandName="Insert" Text="Insert" OnClick="InsertButton_Click" Visible="True"></asp:LinkButton>
                    <asp:LinkButton ID="LinkSubmit" runat="server" CausesValidation="True" ValidationGroup="grpInsert" CommandName="Submit" Text="Submit" OnClick="SubmitButton_Click" Visible="False"></asp:LinkButton>
                    &nbsp;<asp:LinkButton ID="InsertCanselButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" Visible="False"></asp:LinkButton>
                 </FooterTemplate>
            </asp:TemplateField>
   
            <asp:BoundField DataField="pKey" HeaderText="Id. No." ReadOnly="True" SortExpression="pKey" Visible="False" />
           
            <asp:TemplateField HeaderText="Description" SortExpression="Descript">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox3"  runat="server" Text='<%# Bind("Descript") %>'></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="grpEdit" runat="server" ErrorMessage="*" ControlToValidate="TextBox3" ForeColor="Red"></asp:RequiredFieldValidator>
               </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label5" runat="server" Text='<%# Bind("Descript") %>'></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="InsertDesc" runat="server" Text='<%# Bind("Descript") %>' Visible="False"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="grpInsert" runat="server" ErrorMessage="*" ControlToValidate="InsertDesc" ForeColor="Red"></asp:RequiredFieldValidator>
                </FooterTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="File to Send" SortExpression="SendFile">
                <EditItemTemplate>
                    <asp:Label ID="TextBoxSendFile" runat="server" Text='<%# Bind("SendFile") %>'></asp:Label>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="LabelSendFile" runat="server" Text='<%# Bind("SendFile") %>'></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:FileUpload ID="FileToUpload" runat="server" Visible="False"/>
                </FooterTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Date to Send" SortExpression="SendDate">
                <EditItemTemplate>
                    <asp:Calendar ID="Calendar1" runat="server" SelectedDate='<%# Bind("SendDate") %>'></asp:Calendar>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="LabelSendDate" runat="server" Text='<%# Bind("SendDate", "{0:MMM dd, yyyy}") %>'> </asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:Calendar ID="Calendar2" runat="server" Visible="false" SelectedDate='<%# DateTime.Today %>'></asp:Calendar>
                </FooterTemplate>
           </asp:TemplateField>
    
        </Columns>
        <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
        <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
        <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
        <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
        <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#FFF1D4" />
        <SortedAscendingHeaderStyle BackColor="#B95C30" />
        <SortedDescendingCellStyle BackColor="#F1E5CE" />
        <SortedDescendingHeaderStyle BackColor="#93451F" />
    </asp:gridview>

    <asp:ValidationSummary ID="ValidationSummary1" HeaderText="Required - " ValidationGroup="grpEdit" ForeColor="Red" runat="server" DisplayMode="SingleParagraph" />
    <asp:ValidationSummary ID="ValidationSummary2" HeaderText="Required - " ValidationGroup="grpInsert" ForeColor="Red" runat="server" DisplayMode="SingleParagraph"/>
</asp:Content>

