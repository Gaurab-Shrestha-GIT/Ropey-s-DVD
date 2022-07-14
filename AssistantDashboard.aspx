<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AssistantDashboard.aspx.cs" Inherits="GroupCoursework.AssistantDashboard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Assistant Dashboard</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous" />
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-MrcW6ZMFYlzcLA8Nl+NtUVF0sA7MsXsP1UyJoMp4YLEuNSfAP+JcXn/tWtIaxVXM" crossorigin="anonymous"></script>

    <style>
        a {
            text-decoration: none;
            color: black;
        }

        .col {
            padding: 20px 10px 20px 10px;
        }

        .card {
            text-align: center;
            padding: 40px 10px 40px 10px;
            background-color: lightblue;
            font-weight: 500;
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
                        <li style="margin-left: 58em;">
                            <asp:Button ID="Button2" runat="server" Text="Logout" OnClick="Button1_Click" />

                        </li>

                    </ul>

                </div>
            </div>
        </nav>
        <div style="font-size: 30px; text-align: center; margin-top: 15px;">
            WELCOME "<asp:Label ID="Label1" runat="server" Text=""></asp:Label>" to ASSISTANT DASHBOARD
            <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
        </div>


        <div class="container">
            <div class="row">

                <div class="col">
                    <div class="card">

                        <a href="FeatureOne.aspx">Actor as Cast Member
                        </a>
                    </div>
                </div>



                <div class="col">

                    <div class="card">

                        <a href="FeatureTwo.aspx">At Least One Film Played by Actor
                        </a>
                    </div>


                </div>

                <div class="col">

                    <div class="card">
                        <a href="FeatureThree.aspx">DVD Loaned By Member in Last 31 Days
                        </a>
                    </div>

                </div>

            </div>

            <div class="row">
                <div class="col">

                    <div class="card">

                        <a href="FeatureFour.aspx">Sort By Date Released and Cast Member
                        </a>
                    </div>


                </div>

                <div class="col">

                    <div class="card">

                        <a href="FeatureFive.aspx">Loan Details by Copy Number
                        </a>
                    </div>


                </div>
                <div class="col">
                    <div class="card">

                        <a href="FeatureSeven.aspx">Record DVD Returned
                        </a>
                    </div>

                </div>



            </div>
            <div class="row">
                <div class="col">

                    <div class="card">

                        <a href="FeatureEight.aspx">Member and Loan Details
                        </a>
                    </div>


                </div>
                <div class="col">

                    <div class="card">

                        <a href="FeatureTen.aspx">Delete DVD that is more than 365 days old
                        </a>
                    </div>


                </div>

                <div class="col">
                    <div class="card">
                        <a href="FeatureEleven.aspx">DVD Currently on Loan
                        </a>
                    </div>

                </div>






            </div>
            <div class="row">
                <div class="col">
                    <div class="card">
                        <a href="FeatureTwelve.aspx">Not Loaned by Members 
                        </a>
                    </div>

                </div>
                <div class="col">

                    <div class="card">
                        <a href="FeatureThriteen.aspx">No Copy Loaned
                        </a>
                    </div>

                </div>

                <div class="col">
                    <div class="card">
                        <a href="ChangeAssistantPassword.aspx">Change Password
                        </a>
                    </div>
                </div>
            </div>
        </div>

    </form>
</body>
</html>
