<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/PageDesignFiles/InfoRanchGlobal.Master" CodeBehind="RegisterPage.aspx.vb" Inherits="InfoRanch.RegisterPage" 
    title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="InfoRanchGlobalContent" runat="server">
    <table style="width: 100%">
        <tr>
            <td style="text-align: center;" colspan="2">
                <asp:Label ID="userExistsError" runat="server" Font-Bold="True" 
                    Font-Size="Large" ForeColor="Red" 
                    Text="Username already exists, pick a new one" Visible="False"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 122px">
                <asp:Label ID="Label2" runat="server" Text="First Name:"></asp:Label>
            </td>
            <td style="width: 468px">
                <asp:TextBox ID="firstNameTB" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="firstNameValidator" runat="server" 
                    ControlToValidate="firstNameTB" ErrorMessage="All fields required">*</asp:RequiredFieldValidator>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 122px">
                <asp:Label ID="Label3" runat="server" Text="Last Name:"></asp:Label>
            </td>
            <td style="width: 468px">
                <asp:TextBox ID="lastNameTB" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="lastNameValidator" runat="server" 
                    ControlToValidate="lastNameTB" ErrorMessage="All fields required">*</asp:RequiredFieldValidator>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 122px">
                <asp:Label ID="Label4" runat="server" Text="Address 1:"></asp:Label>
            </td>
            <td style="width: 468px">
                <asp:TextBox ID="addressOneTB" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="address1Validator" runat="server" 
                    ControlToValidate="addressOneTB" ErrorMessage="All fields required">*</asp:RequiredFieldValidator>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 122px">
                <asp:Label ID="Label5" runat="server" Text="Address2"></asp:Label>
            </td>
            <td style="width: 468px">
                <asp:TextBox ID="addressTwoTB" runat="server"></asp:TextBox>
                <%-- <asp:RequiredFieldValidator ID="address2Validator" runat="server" 
                    ControlToValidate="addressTwoTB" ErrorMessage="All fields required">*</asp:RequiredFieldValidator>--%>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 122px">
                <asp:Label ID="Label6" runat="server" Text="City:"></asp:Label>
            </td>
            <td style="width: 468px">
                <asp:TextBox ID="cityTB" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="cityValidator" runat="server" 
                    ControlToValidate="cityTB" ErrorMessage="All fields required">*</asp:RequiredFieldValidator>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 122px; height: 23px">
                <asp:Label ID="Label7" runat="server" Text="State:"></asp:Label>
            </td>
            <td style="height: 23px; width: 468px">
                <asp:DropDownList ID="stateDropDownList1" runat="server" Width="126px">
                    <asp:ListItem Value="AK">AK</asp:ListItem>
                    <asp:ListItem>AL</asp:ListItem>
                    <asp:ListItem>AR</asp:ListItem>
                    <asp:ListItem>AZ</asp:ListItem>
                    <asp:ListItem>CA</asp:ListItem>
                    <asp:ListItem>CO</asp:ListItem>
                    <asp:ListItem>CT</asp:ListItem>
                    <asp:ListItem>DE</asp:ListItem>
                    <asp:ListItem>FL</asp:ListItem>
                    <asp:ListItem>GA</asp:ListItem>
                    <asp:ListItem>HI</asp:ListItem>
                    <asp:ListItem>IA</asp:ListItem>
                    <asp:ListItem>ID</asp:ListItem>
                    <asp:ListItem>IL</asp:ListItem>
                    <asp:ListItem>IN</asp:ListItem>
                    <asp:ListItem>KS</asp:ListItem>
                    <asp:ListItem>KY</asp:ListItem>
                    <asp:ListItem>LA</asp:ListItem>
                    <asp:ListItem>MA</asp:ListItem>
                    <asp:ListItem>MD</asp:ListItem>
                    <asp:ListItem>ME</asp:ListItem>
                    <asp:ListItem>MI</asp:ListItem>
                    <asp:ListItem>MN</asp:ListItem>
                    <asp:ListItem>MO</asp:ListItem>
                    <asp:ListItem>MS</asp:ListItem>
                    <asp:ListItem>MT</asp:ListItem>
                    <asp:ListItem>NC</asp:ListItem>
                    <asp:ListItem>ND</asp:ListItem>
                    <asp:ListItem>NE</asp:ListItem>
                    <asp:ListItem>NH</asp:ListItem>
                    <asp:ListItem>NJ</asp:ListItem>
                    <asp:ListItem>NM</asp:ListItem>
                    <asp:ListItem>NV</asp:ListItem>
                    <asp:ListItem>NY</asp:ListItem>
                    <asp:ListItem>OH</asp:ListItem>
                    <asp:ListItem>OK</asp:ListItem>
                    <asp:ListItem>OR</asp:ListItem>
                    <asp:ListItem>PA</asp:ListItem>
                    <asp:ListItem>RI</asp:ListItem>
                    <asp:ListItem>SC</asp:ListItem>
                    <asp:ListItem>SD</asp:ListItem>
                    <asp:ListItem>TN</asp:ListItem>
                    <asp:ListItem>TX</asp:ListItem>
                    <asp:ListItem>UT</asp:ListItem>
                    <asp:ListItem>VA</asp:ListItem>
                    <asp:ListItem>VT</asp:ListItem>
                    <asp:ListItem>WA</asp:ListItem>
                    <asp:ListItem>WI</asp:ListItem>
                    <asp:ListItem>WV</asp:ListItem>
                    <asp:ListItem>WY</asp:ListItem>
                    <asp:ListItem>DC</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="stateValidator" runat="server" 
                    ControlToValidate="stateDropDownList1" ErrorMessage="All fields required">*</asp:RequiredFieldValidator>
            </td>
            <td style="height: 23px">
            </td>
        </tr>
        <tr>
            <td style="width: 122px">
                <asp:Label ID="Label8" runat="server" Text="Zip Code:"></asp:Label>
            </td>
            <td style="width: 468px">
                <asp:TextBox ID="zipTB" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                    ControlToValidate="zipTB" ErrorMessage="All fields required">*</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="validZipCodeFormat" runat="server" 
                    ControlToValidate="zipTB" ErrorMessage="Inalid Zip Code" 
                    ValidationExpression="\d{5}(-\d{4})?"></asp:RegularExpressionValidator>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 122px">
                <asp:Label ID="Label9" runat="server" Text="Phone Number:"></asp:Label>
            </td>
            <td style="width: 468px">
                <asp:TextBox ID="phoneTB" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="phoneNumberReqValidator" runat="server" 
                    ControlToValidate="phoneTB" ErrorMessage="All fields required">*</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="validPhoneNumberFormat" runat="server" 
                    ControlToValidate="phoneTB" ErrorMessage="Invalid phone number" 
                    ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}"></asp:RegularExpressionValidator>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 122px">
                <asp:Label ID="Label10" runat="server" Text="Email:"></asp:Label>
            </td>
            <td style="width: 468px">
                <asp:TextBox ID="emailTB" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="emailReqValidator" runat="server" 
                    ControlToValidate="emailTB" ErrorMessage="All fields required">*</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="validEmailFormat" runat="server" 
                    ControlToValidate="emailTB" ErrorMessage="Invalid Email Address" 
                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 122px">
                <asp:Label ID="Label11" runat="server" Text="Username:"></asp:Label>
            </td>
            <td style="width: 468px">
                <asp:TextBox ID="userNameTB" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="userNameValidator" runat="server" 
                    ControlToValidate="userNameTB" ErrorMessage="All fields required">*</asp:RequiredFieldValidator>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 122px">
                <asp:Label ID="Label13" runat="server" Text="Password:"></asp:Label>
            </td>
            <td style="width: 468px">
                <asp:TextBox ID="userPasswordTB" runat="server" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="passwordValidator" runat="server" 
                    ControlToValidate="userPasswordTB" ErrorMessage="All fields required">*</asp:RequiredFieldValidator>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 122px">
                &nbsp;<asp:Label ID="confirmPasswordLabel" runat="server" 
                    Text="Confirm Password:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="confirmPasswordTB0" runat="server" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="confirmValidator" runat="server" 
                    ControlToValidate="confirmPasswordTB0" ErrorMessage="All fields required">*</asp:RequiredFieldValidator>
                <asp:CompareValidator ID="comparePasswordValidator" runat="server" 
                    ControlToCompare="userPasswordTB" ControlToValidate="confirmPasswordTB0" 
                    ErrorMessage="Passwords do not match"></asp:CompareValidator>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="Label12" runat="server" 
                    Text="I am at least 18 years of age and I accept the "></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:HyperLink ID="HyperLink1" runat="server" Font-Underline="True" 
                    ForeColor="Maroon" 
                    NavigateUrl="~/FooterPages/Inforanch_Terms_and_Conditions.pdf">Terms and 
                Conditions</asp:HyperLink>
&nbsp;&nbsp;
                <asp:CheckBox ID="agreeCB" runat="server" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 122px">
                &nbsp;</td>
            <td style="width: 468px">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 122px">
                <asp:Button ID="submitBTN" runat="server" 
                    Text="Submit" />
            </td>
            <td style="width: 468px">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
    
    
     </asp:Content>
