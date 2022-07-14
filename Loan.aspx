<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Loan.aspx.cs" Inherits="GroupCoursework.Loan" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Loan</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous" />
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-MrcW6ZMFYlzcLA8Nl+NtUVF0sA7MsXsP1UyJoMp4YLEuNSfAP+JcXn/tWtIaxVXM" crossorigin="anonymous"></script>

    <style type="text/css">
        .auto-style1 {
            width: 339px;
        }
    </style>

</head>
<body>
    <form id="form2" runat="server">
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
            <div>
                <div class="mt-2 " style="background-color: lightblue; width: 500px; height: 400px; margin-left: 37%; border-radius: 10px;">


                    <div class="text-center" style="margin-top: 20px; padding-top: 10px; font-weight: bold; color: darkblue;">
                        ISSUE LOAN TO MEMBER 
                        <asp:TextBox ID="Text_Loan_Number" runat="server" type="hidden"></asp:TextBox>

                    </div>
                    <div class="text-center mt-3">
                        Loan Type Number:
                        <asp:DropDownList ID="LoanTypeNumberDropDownList" AutoPostBack="true" runat="server" OnSelectedIndexChanged="LoanTypeNumberDropDownList_SelectedIndexChanged"></asp:DropDownList>






                    </div>
                    <div class="text-center" style="margin-top: 10px;">

                        <div>
                            Copy Number:
                            <asp:DropDownList ID="CopyNumberDropDownList" AutoPostBack="true" runat="server" OnSelectedIndexChanged="CopyNumberDropDownList_SelectedIndexChanged"></asp:DropDownList>

                        </div>

                    </div>
                    <div class="text-center" style="margin-top: 10px;">

                        <div>
                            Member Number:     
                            <asp:DropDownList ID="MemberDropDownList" runat="server" AutoPostBack="true" OnSelectedIndexChanged="MemberDropDownList_SelectedIndexChanged"></asp:DropDownList>

                        </div>

                    </div>
                    <div class="text-center" style="margin-top: 10px;">

                        <div>
                            Date Out:                        
                            <asp:Label ID="Date_Out_Label" runat="server" Text=""></asp:Label>

                        </div>

                    </div>
                    <div class="text-center" style="margin-top: 10px;">

                        <div>
                            Date Due:
                            <asp:Label ID="Date_Due_Label" runat="server" Text=""></asp:Label>

                        </div>

                    </div>
                    <div class="text-center" style="margin-top: 10px;">

                        <div>
                            Loan Duration: 
 <asp:Label ID="Loan_Duration_Label" runat="server" Text=""></asp:Label>
                            Days
                    
                        </div>

                    </div>
                    <div class="text-center row" style="margin-top: 10px;">

                        <div class="text-center col">
                            Charge Per Day Rs. <b>
                                <asp:Label ID="ChargePerDayLabel" runat="server" Text=""></asp:Label></b>

                        </div>
                        <div class="text-center col">
                            Total Charge Rs. <b>
                                <asp:Label ID="TotalChargePerDayLabel" runat="server" Text=""></asp:Label></b>
                        </div>

                    </div>
                    <div class="text-center row" style="margin-top: 10px;">

                        <div class="text-center col">
                            Member Age: <b>
                                <asp:Label ID="MemberAgeLabel" runat="server" Text=""></asp:Label></b>

                        </div>
                        <div class="text-center col">
                            Age Restriction <b>
                                <asp:Label ID="AgeRestrictionLabel" runat="server" Text=""></asp:Label></b>
                        </div>

                    </div>
                    <div class="text-center" style="margin-top: 15px;">
                        <asp:Button ID="AddLoanButton" runat="server" Text="ADD LOAN TITLE" OnClick="AddLoanButton_Click" />
                    </div>

                    <div class="text-center" style="color: green;">
                        <asp:Label ID="resultLabel" runat="server"></asp:Label>

                    </div>
                </div>
                <div class="mt-5">
                    <asp:GridView ID="LoanGridView" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" HorizontalAlign="Center">
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

                            <asp:TemplateField HeaderText="Loan Number">
                                <ItemTemplate>

                                    <asp:Label ID="lblLoanNumber" runat="server" Text='<%#Eval("Loan_Number") %>'>

                                    </asp:Label>
                                </ItemTemplate>

                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Loan Type Number">
                                <ItemTemplate>

                                    <asp:Label ID="lblLoanTypeNumber" runat="server" Text='<%#Eval("Loan_Type_Number") %>'>

                                    </asp:Label>
                                </ItemTemplate>

                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Copy Number">
                                <ItemTemplate>

                                    <asp:Label ID="lblCopyNumber" runat="server" Text='<%#Eval("Copy_Number") %>'>

                                    </asp:Label>
                                </ItemTemplate>

                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Member Number">
                                <ItemTemplate>

                                    <asp:Label ID="lblMemberNumber" runat="server" Text='<%#Eval("Member_Number") %>'>

                                    </asp:Label>
                                </ItemTemplate>

                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Date Out">
                                <ItemTemplate>

                                    <asp:Label ID="lblDateOut" runat="server" Text='<%#Eval("Date_Out") %>'>

                                    </asp:Label>
                                </ItemTemplate>

                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Date Due">
                                <ItemTemplate>

                                    <asp:Label ID="lblDateDue" runat="server" Text='<%#Eval("Date_Due") %>'>

                                    </asp:Label>
                                </ItemTemplate>

                            </asp:TemplateField>







                        </Columns>
                    </asp:GridView>
                </div>



            </div>

            <div>
            </div>
            <div>
            </div>
        </div>
    </form>
</body>
</html>

