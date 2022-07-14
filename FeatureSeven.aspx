﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FeatureSeven.aspx.cs" Inherits="GroupCoursework.FeatureSeven" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
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
                        <li class="nav-item">
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

        <div class="text-center mt-4">
            <h3>Record DVD Returned</h3>
            <div>
                <asp:Label ID="Label8" runat="server" Text="Date Due:"></asp:Label>
                <asp:Label ID="Date_Due_Label" runat="server" Text=""></asp:Label>


            </div>
            <div>
                <asp:Label ID="Label9" runat="server" Text="Date Return:"></asp:Label><asp:Label ID="Date_Return_Label" runat="server" Text=""></asp:Label></div>

            <div>
                <asp:Label ID="Label14" runat="server" Text="Date Duration:"></asp:Label><asp:Label ID="Date_Duration_Label" runat="server" Text=""></asp:Label></div>


            <div>
                <asp:Label ID="Label10" runat="server" Text="Penalty Charge:"></asp:Label><asp:Label ID="Label11" runat="server" Text="Rs."></asp:Label><asp:Label ID="PenaltyChargeLabel" runat="server" Text=""></asp:Label></div>
            <div>
                <asp:Label ID="Label12" runat="server" Text="Total Penalty Charge:"></asp:Label><asp:Label ID="Label13" runat="server" Text="Rs."></asp:Label><asp:Label ID="TotalPenaltyChargeLabel" runat="server" Text=""></asp:Label></div>
            <div>

                <asp:TextBox ID="Text_Loan_Number" runat="server" type="hidden"></asp:TextBox>
            </div>
            <div>
                <asp:Button ID="Button1" runat="server" Text="Update" OnClick="Button1_Click" />
            </div>
            <div>

                <asp:Label ID="resultLabel" runat="server" Text=""></asp:Label>
            </div>
            <div class="mt-4">

                <asp:GridView ID="GridView1" runat="server" OnRowCommand="GV1_RowCommand" AutoGenerateColumns="False" HorizontalAlign="Center" CellPadding="4" ForeColor="#333333" GridLines="None">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:TemplateField HeaderText="Loan Number">
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%#Eval("Loan_Number") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Loan Type Number">
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%#Eval("Loan_Type_Number") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Copy Number">
                            <ItemTemplate>
                                <asp:Label ID="Label3" runat="server" Text='<%#Eval("Copy_Number") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Member Number">
                            <ItemTemplate>
                                <asp:Label ID="Label4" runat="server" Text='<%#Eval("Member_Number") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Date Out">
                            <ItemTemplate>
                                <asp:Label ID="Label5" runat="server" Text='<%#Eval("Date_Out") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Date Due">
                            <ItemTemplate>
                                <asp:Label ID="Label6" runat="server" Text='<%#Eval("Date_Due") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Date Return">
                            <ItemTemplate>
                                <asp:Label ID="Label7" runat="server" Text='<%#Eval("Date_Returned") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Action">
                            <ItemTemplate>
                                <asp:LinkButton ID="View" runat="server" CommandName="view" CommandArgument='<%#Bind("Loan_Number")%>'>Edit</asp:LinkButton>
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
