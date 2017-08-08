<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="main.aspx.cs" Inherits="sns.main" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <!-- The above 3 meta tags *must* come first in the head; any other head content must come *after* these tags -->
    <title>Save n Share</title>

    <!-- Bootstrap -->
    <link href="css/bootstrap.min.css" rel="stylesheet">
    <link href="css/StyleSheet.css" rel="stylesheet" />
    <link href="css/footer.css" rel="stylesheet" />

    <!-- HTML5 shim and Respond.js for IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
      <script src="https://oss.maxcdn.com/html5shiv/3.7.3/html5shiv.min.js"></script>
      <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
    <![endif]-->

    <script language="C#" runat="server"></script>
</head>
<body>
    <form runat="server">
        <!--navigation bar-->
        <div class="navbar navbar-default navbar-static-top navbar-inverse">
            <div class="container-fluid">
                <!-- Brand and toggle get grouped for better mobile display -->
                <div class="navbar-header">
                    <a class="navbar-brand" href="#">
                        <img class="img-circle" alt="Brand" src="sns.jpeg">
                    </a>
                    <a href="#" class="navbar-brand"><span class="label label-info">Save and Share</span></a>
                    <!--for responsive in small screen -->
                    <button class="navbar-toggle" data-toggle="collapse" data-target=".navHeaderCollapse">
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                    </button>
                </div>

                <!-- Collect the nav links, forms, and other content for toggling -->
                <div class="collapse navbar-collapse navHeaderCollapse">
                    <ul class="nav navbar-nav navbar-right">
                        <li class="active"><a href="#">Sign Up</a></li>
                        <li><a href="#">Login</a></li>
                        <li class="dropdown">
                            <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Recent Uploads <span class="caret"></span></a>
                            <ul class="dropdown-menu">
                                <li><a href="#">All</a></li>
                                <li><a href="#">Your circle</a></li>
                                <li role="separator" class="divider"></li>
                                <li><a href="#">Specific</a></li>
                            </ul>
                        </li>
                    </ul>
                </div>
            </div>
        </div>
        <!-- main body -->
        <div class="jumbotron">
            <div class="container cont-size">
                <div class="row">
                    <div class="col-sx-6 col-sx-offset-3">

                        <h1 class="text-center">Welcome to Save and Share</h1>
                    </div>
                    <div class="row">
                        <div class="col-md-6 col-md-offset-3 text-center">
                            <br />
                            <br />

                            <div class="input-group">
                                <asp:TextBox ID="search" CssClass="form-control" placeholder="Search for snippets" runat="server"></asp:TextBox>
                                <div class="input-group-btn">
                                    <div class="btn-group" role="group">
                                        <asp:LinkButton ID="btnRandom" runat="server" CssClass="btn btn-success" OnClick="LinkButton_Click"><span aria-hidden="true" class="glyphicon glyphicon-search"></span></asp:LinkButton>
                                    </div>
                                </div>
                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- pictures -->
        <!--<div class="container">
            <div class="row">
                <div class="col-md-4">
                    <a href="viber.jpg" class="thumbnail">
                        <p>chilled</p>
                        <img src="viber.jpg" />
                    </a>
                </div>
            </div>
        </div>-->
        <!--<div class="container">
            <asp:Panel ID="Panel1" runat="server" Width="440px" BorderStyle="Dashed" BorderColor="#000066"></asp:Panel>
        </div>-->
        <asp:DataList ID="DataList1" runat="server" RepeatColumns="3" RepeatDirection="Horizontal"
            Width="100%" BorderStyle="Solid" BorderWidth="3px">

            <ItemTemplate>
                <asp:Label ID="Label1" runat="server" Text='<%# Eval("displayname") %>' Font-Bold="True" Font-Size="1.2em" ForeColor="Navy" /><br />
                <asp:Image ID="Image1" CssClass="img-responsive" runat="server" Width="400px" Height="300px" ImageUrl='<%# "~/admin/images/" + Eval("picname") %>' />
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
</asp:DataList>
        <!--nested loop test-->

        <!--what's new -->
        <div class="container">
            <div class="row">
                <h1 class="text-center text-success">What is Save and Share</h1>
                <div class="col-md-4 col-sx-12">
                    <div class="whatsnew">
                        <span aria-hidden="true" class="glyphicon glyphicon-search"></span>
                        <div class="row text-center text-success pad">Store pic for your memories.</div>
                        <div class="row">
                            <asp:Button CssClass="btn btn-primary" runat="server" Text="Store" />
                        </div>
                    </div>
                </div>
                <div class="col-md-4 col-sx-12">
                    <div class="whatsnew">
                        <span aria-hidden="true" class="glyphicon glyphicon-search"></span>
                        <div class="row text-center text-success pad">Share as much as you can.</div>
                        <div class="row">
                            <asp:Button CssClass="btn btn-primary" runat="server" Text="Share" />
                        </div>
                    </div>
                </div>
                <div class="col-md-4 col-sx-12">
                    <div class="whatsnew">
                        <span aria-hidden="true" class="glyphicon glyphicon-search"></span>
                        <div class="row text-center text-success pad">Print hard copy.</div>
                        <div class="row">
                            <asp:Button CssClass="btn btn-primary" runat="server" Text="Print" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!--footer-->
        <footer id="myFooter">
            <div class="container">
                <div class="row">
                    <div class="col-sm-3">
                        <h5>Get started</h5>
                        <ul>
                            <li><a href="#">Home</a></li>
                            <li><a href="#">Sign up</a></li>
                            <li><a href="#">Downloads</a></li>
                        </ul>
                    </div>
                    <div class="col-sm-3">
                        <h5>About us</h5>
                        <ul>
                            <li><a href="#">Company Information</a></li>
                            <li><a href="#">Contact us</a></li>
                            <li><a href="#">Reviews</a></li>
                        </ul>
                    </div>
                    <div class="col-sm-3">
                        <h5>Support</h5>
                        <ul>
                            <li><a href="#">FAQ</a></li>
                            <li><a href="#">Help desk</a></li>
                            <li><a href="#">Forums</a></li>
                        </ul>
                    </div>
                    <div class="col-sm-3">
                        <h5>Legal</h5>
                        <ul>
                            <li><a href="#">Terms of Service</a></li>
                            <li><a href="#">Terms of Use</a></li>
                            <li><a href="#">Privacy Policy</a></li>
                        </ul>
                    </div>
                </div>
                <!-- Here we use the Google Embed API to show Google Maps. -->
                <!-- In order for this to work in your project you will need to generate a unique API key.  
            <iframe id="map-container" frameborder="0" style="border:0"
                src="https://www.google.com/maps/embed/v1/place?q=place_id:ChIJOwg_06VPwokRYv534QaPC8g&key=AIzaSyBdJm9Amm4KALkKlZObWn40dcpRyH119zg" >
            </iframe>
            -->
            </div>
            <div class="social-networks text-center">
                <a href="#" class="twitter"><span class="fa fa-twitter"></span></a>
                <a href="#" class="facebook"><i class="fa fa-facebook"></i></a>
                <a href="#" class="google"><i class="fa fa-google-plus"></i></a>
            </div>
            <div class="footer-copyright text-right">
                <p>© 2017 Copyright Text </p>
            </div>
        </footer>
        <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
        <script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    </form>
</body>
</html>
