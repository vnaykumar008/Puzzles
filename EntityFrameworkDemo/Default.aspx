<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="_Default.aspx.cs" %>

<!DOCTYPE html>
<script runat="server">

    Protected Sub btnSubmit_Click(sender As Object, e As EventArgs)

    End Sub
</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
</head>
<body>
    <form runat="server">
    <asp:Label ID="lblName" Text="Name" runat="server"></asp:Label>
    <asp:TextBox ID="txtName" Text="" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="reqNameField" ErrorMessage="Please enter Name" ControlToValidate="txtName" runat="server"></asp:RequiredFieldValidator>
    <br />
    <asp:Label ID="lblAge" Text="Age" runat="server"></asp:Label>
    <asp:TextBox ID="txtAge" Text="" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="reqAge" ErrorMessage="Please enter Age" ControlToValidate="txtAge" runat="server"></asp:RequiredFieldValidator><br />
    <asp:Label ID="lblEmailId" Text="Email Id" runat="server"></asp:Label>
    <asp:TextBox ID="txtEmailId" Text="" runat="server"></asp:TextBox>
    <asp:RegularExpressionValidator ID="regEmailId" runat="server" ControlToValidate="txtEmailId" ValidationExpression="^[a-zA-Z0-9]{1,}@.com$" ErrorMessage="Please enter correct email id"></asp:RegularExpressionValidator>
    <br />
    <asp:Label ID="lblPassword" Text="Password" runat="server"></asp:Label>
    <asp:TextBox ID="txtPassword" Text="" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ErrorMessage="Please enter Password" ControlToValidate="txtPassword" runat="server"></asp:RequiredFieldValidator>
    <br />
    <asp:Label ID="lblPasswordRepeat" Text="Repeat Password" runat="server"></asp:Label>
    <asp:TextBox ID="txtRepeatPassword" Text="" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ErrorMessage="Please enter password again" ControlToValidate="txtRepeatPassword" runat="server"></asp:RequiredFieldValidator>
    <asp:CompareValidator ID="cmpPasswordValidator" runat="server" ErrorMessage="Password is not matching" ControlToValidate="txtPassword" ControlToCompare="txtRepeatPassword"></asp:CompareValidator>
    <br />
    <asp:Button ID="btnSubmit" Text="Submit" runat="server" OnClick="btnSubmit_Click" />
</form>
</body>
</html>
