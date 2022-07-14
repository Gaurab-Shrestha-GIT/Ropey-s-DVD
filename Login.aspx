<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="GroupCoursework.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <div style="background-color: lightblue; width: 550px; height: 420px; margin-left: 37%; border-radius: 10px;">


        <form id="form1" runat="server" style="text-align: center; margin-top: 100px;">
            <div class="text-center ">
                <div style="padding-top: 20px;">
                    <img src="logo.png" style="height: 150px;" />
                </div>
            </div>
            <div style="margin-top: 20px;">
                <asp:Label ID="Label1" runat="server" Text="Username:"></asp:Label>
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            </div>
            <div style="margin-top: 20px;">

                <asp:Label ID="Label2" runat="server" Text="Password:"></asp:Label>

                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            </div>
            <div style="margin-top: 20px;">
                <asp:Label ID="Label3" runat="server" Text="User Type:"></asp:Label>
                <asp:DropDownList ID="UserDropDownList" runat="server">
                    <asp:ListItem>Manager</asp:ListItem>
                    <asp:ListItem>Assistant</asp:ListItem>

                </asp:DropDownList>
            </div>
            <div style="margin-top: 10px;">
                <asp:CheckBox ID="CheckBox1" runat="server" Text="Remember Me?" />
            </div>
            <div style="margin-top: 10px;">
                <asp:Button ID="LoginBtn" runat="server" Text="Login" OnClick="LoginBtn_Click" Style="height: 29px;" />
            </div>
            <div style="margin-top: 10px;">

                <button><a style="text-decoration: none;" href="FeatureOne.aspx">Actor as a Cast Member</a> </button>
                <button><a style="text-decoration: none;" href="FeatureTwo.aspx">At Least One Film Played by Actor</a> </button>
            </div>
            <div class="text-center" style="color: green;">
                <asp:Label ID="resultLabel" runat="server"></asp:Label>
            </div>
        </form>
    </div>

</body>
</html>
