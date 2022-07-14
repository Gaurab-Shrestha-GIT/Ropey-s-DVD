<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DVDCategory.aspx.cs" Inherits="GroupCoursework.DVDCategory" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>DVD Category</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous" />
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-MrcW6ZMFYlzcLA8Nl+NtUVF0sA7MsXsP1UyJoMp4YLEuNSfAP+JcXn/tWtIaxVXM" crossorigin="anonymous"></script>

    <style type="text/css">
        .auto-style1 {
            height: 32px;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">
        <nav class="navbar navbar-expand-lg navbar-light bg-info">
            <div class="container-fluid">
                <a href="ManagerDashboard.aspx">
                    <img src="logo.png" style="height: 70px" />
                </a>

                <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                </button>
                <div class="collapse navbar-collapse" id="navbarSupportedContent">
                    <ul class="navbar-nav me-auto mb-2 mb-lg-0">
                        <li class="nav-item" style="margin-left: 35px;">
                            <a class="nav-link active" aria-current="page" href="AssistantDashboard.aspx">Dashboard</a>
                        </li>

                        <li class="nav-item dropdown">
                            <a class="nav-link dropdown-toggle" href="#" id="navbarDropdown" role="button" data-bs-toggle="dropdown" aria-expanded="false">Actor
                            </a>
                            <ul class="dropdown-menu" aria-labelledby="navbarDropdown">
                                <li><a class="dropdown-item" href="Actor.aspx">Add New Actor</a></li>

                                <li><a class="dropdown-item" href="CastMember.aspx">Cast Member</a></li>
                            </ul>
                        </li>
                        <li class="nav-item dropdown">
                            <a class="nav-link dropdown-toggle" href="#" id="navbarDropdown" role="button" data-bs-toggle="dropdown" aria-expanded="false">DVD
                            </a>
                            <ul class="dropdown-menu" aria-labelledby="navbarDropdown">
                                <li><a class="dropdown-item" href="DVDTitle.aspx">DVD Title</a></li>


                                <li><a class="dropdown-item" href="DVDCopy.aspx">DVD Copy</a></li>
                                <li><a class="dropdown-item" href="DVDCategory.aspx">DVD Category</a></li>
                                <li><a class="dropdown-item" href="Studio.aspx">Studio</a></li>
                                <li><a class="dropdown-item" href="Producer.aspx">Producer</a></li>

                            </ul>

                        </li>
                        <li class="nav-item dropdown">
                            <a class="nav-link dropdown-toggle" href="#" id="navbarDropdown" role="button" data-bs-toggle="dropdown" aria-expanded="false">Loan
                            </a>
                            <ul class="dropdown-menu" aria-labelledby="navbarDropdown">
                                <li><a class="dropdown-item" href="Loan.aspx">Issue Loan to Member</a></li>


                                <li><a class="dropdown-item" href="LoanType.aspx">Loan Type</a></li>
                            </ul>

                        </li>
                        <li class="nav-item dropdown">
                            <a class="nav-link dropdown-toggle" href="#" id="navbarDropdown" role="button" data-bs-toggle="dropdown" aria-expanded="false">Member
                            </a>
                            <ul class="dropdown-menu" aria-labelledby="navbarDropdown">
                                <li><a class="dropdown-item" href="Member.aspx">Member</a></li>


                                <li><a class="dropdown-item" href="MembershipCategory.aspx">Membership Category</a></li>
                            </ul>

                        </li>

                    </ul>

                </div>
            </div>
        </nav>

        <div>
            <div class="mt-2 " style="background-color: lightblue; width: 450px; height: 180px; margin-left: 37%; border-radius: 10px;">


                <div class="text-center" style="margin-top: 20px; font-size: 20px; font-weight: bold; color: darkblue;">
                    DVD CATEGORY 
                    <asp:TextBox ID="Text_Category_Number" runat="server" type="hidden"></asp:TextBox>

                </div>
                <div class="text-center mt-3">
                    Category Description: 
                    <asp:TextBox ID="Text_Category_Description" runat="server"></asp:TextBox>






                </div>
                <div class="text-center" style="margin-top: 10px;">

                    <div>
                        Age Restricted: 
   <asp:DropDownList ID="ageDropDown" runat="server" OnSelectedIndexChanged="ageDropDown_SelectedIndexChanged">
       <asp:ListItem>Age is not Restricted</asp:ListItem>
       <asp:ListItem>Age is Restricted</asp:ListItem>
   </asp:DropDownList>

                    </div>

                </div>
                <div class="text-center" style="margin-top: 15px;">
                    <asp:Button ID="AddProducerButton" runat="server" Text="ADD DVD CATEGORY" OnClick="AddDVDCategoryButton_Click" />
                    <asp:Button ID="UpdateButton" runat="server" Text="UPDATE" OnClick="UpdateButton_Click" />
                </div>

                <div class="text-center" style="color: green;">
                    <asp:Label ID="resultLabel" runat="server"></asp:Label>

                </div>
            </div>
            <div class="mt-5" style="margin-left: 37%;">
                <asp:GridView ID="DVDCategoryGridView" runat="server" OnRowCommand="GVDVDCategory_RowCommand" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>

                        <asp:TemplateField HeaderText="Category Number">
                            <ItemTemplate>

                                <asp:Label ID="lblCategoryNumber" runat="server" Text='<%#Eval("Category_Number") %>'>

                                </asp:Label>
                            </ItemTemplate>

                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Category Description">
                            <ItemTemplate>

                                <asp:Label ID="lblCategoryDescription" runat="server" Text='<%#Eval("Category_Description") %>'>

                                </asp:Label>
                            </ItemTemplate>

                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Age Restricted">
                            <ItemTemplate>

                                <asp:Label ID="lblAgeRestricted" runat="server" Text='<%#Eval("Age_Restricted") %>'>

                                </asp:Label>
                            </ItemTemplate>

                        </asp:TemplateField>



                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="View" runat="server" CommandName="view" CommandArgument='<%#Bind("Category_Number") %>'>
                                            Edit
                                </asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <EditRowStyle BackColor="#2461BF" />
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EFF3FB" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                    <SortedDescendingHeaderStyle BackColor="#4870BE" />
                </asp:GridView>
            </div>


        </div>
    </form>
</body>
</html>
