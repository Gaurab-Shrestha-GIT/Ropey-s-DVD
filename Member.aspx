<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Member.aspx.cs" Inherits="GroupCoursework.Member" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Member</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous" />
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-MrcW6ZMFYlzcLA8Nl+NtUVF0sA7MsXsP1UyJoMp4YLEuNSfAP+JcXn/tWtIaxVXM" crossorigin="anonymous"></script>


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
            <div class="mt-2 " style="background-color: lightblue; width: 450px; height: 280px; margin-left: 37%; border-radius: 10px;">


                <div class="text-center" style="margin-top: 20px; font-size: 20px; font-weight: bold; color: darkblue;">
                    MEMBER  
                    <asp:TextBox ID="Text_Member_Number" runat="server" type="hidden"></asp:TextBox>

                </div>
                <div class="text-center mt-3">
                    Membership Category Number:    
                    <asp:DropDownList ID="MembershipCategoryNumberDropDownList" runat="server"></asp:DropDownList>






                </div>
                <div class="text-center" style="margin-top: 10px;">

                    <div>
                        Member Last Name: 
                        <asp:TextBox ID="Text_Member_Last_Name" runat="server"></asp:TextBox>

                    </div>

                </div>
                <div class="text-center" style="margin-top: 10px;">

                    <div>
                        Member First Name: 

  <asp:TextBox ID="Text_Member_First_Name" runat="server"></asp:TextBox>

                    </div>

                </div>
                <div class="text-center" style="margin-top: 10px;">

                    <div>
                        Member Address: 

                        <asp:TextBox ID="Text_Member_Address" runat="server"></asp:TextBox>

                    </div>

                </div>
                <div class="text-center" style="margin-top: 10px;">

                    <div>
                        Member Date of Birth: 

                        <asp:TextBox ID="Text_Member_Date_Of_Birth" runat="server"></asp:TextBox>

                    </div>

                </div>
                <div class="text-center" style="margin-top: 15px;">
                    <asp:Button ID="AddMemberButton" runat="server" Text="ADD MEMBER" OnClick="AddMemberButton_Click" />
                    <asp:Button ID="UpdateButton" runat="server" Text="UPDATE" OnClick="UpdateButton_Click" />
                </div>

                <div class="text-center" style="color: green;">
                    <asp:Label ID="resultLabel" runat="server"></asp:Label>

                </div>
            </div>
            <div class="mt-4">
                <asp:GridView ID="MemberGridView" runat="server" CellPadding="4" ForeColor="#333333" OnRowCommand="GVMember_RowCommand" GridLines="None" AutoGenerateColumns="False" HorizontalAlign="Center">
                    <AlternatingRowStyle BackColor="White" />
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
                    <Columns>

                        <asp:TemplateField HeaderText="Member Number">
                            <ItemTemplate>

                                <asp:Label ID="lblNumber" runat="server" Text='<%#Eval("Member_Number") %>'>

                                </asp:Label>
                            </ItemTemplate>

                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Membership Category Number">
                            <ItemTemplate>

                                <asp:Label ID="lblMembershipCategoryNumber" runat="server" Text='<%#Eval("Membership_Category_Number") %>'>

                                </asp:Label>
                            </ItemTemplate>

                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Member Last Name">
                            <ItemTemplate>

                                <asp:Label ID="lblLastName" runat="server" Text='<%#Eval("Member_Last_Name") %>'>

                                </asp:Label>
                            </ItemTemplate>

                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Member First Name">
                            <ItemTemplate>

                                <asp:Label ID="lblFirstName" runat="server" Text='<%#Eval("Member_First_Name") %>'>

                                </asp:Label>
                            </ItemTemplate>

                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Member Address">
                            <ItemTemplate>

                                <asp:Label ID="lblAddress" runat="server" Text='<%#Eval("Member_Address") %>'>

                                </asp:Label>
                            </ItemTemplate>

                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Member Date of Birth">
                            <ItemTemplate>

                                <asp:Label ID="lblDob" runat="server" Text='<%#Eval("Member_Date_Of_Birth") %>'>

                                </asp:Label>
                            </ItemTemplate>

                        </asp:TemplateField>


                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="View" runat="server" CommandName="view" CommandArgument='<%#Bind("Member_Number") %>'>
                                            Edit
                                </asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>

    </form>
</body>
</html>
