<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="sns.admin.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 500px;
        }

        .auto-style2 {
            width: 140px;
        }
    </style>
    <link href="../css/bootstrap.css" rel="stylesheet" />
    <link href="../css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>

    <div class="jumbotron vertical-center">
        <div class="container">

            <form class="form-horizontal col-xs-4 col-xs-offset-4" runat="server">
                <div class="form-group">
                    <label class="col-md-12 bg-primary text-white text-center">Admin Login</label>
                </div>
                <div class="form-group">
                    <label for="inputEmail3" class="col-sm-3 control-label">Email</label>
                    <div class="col-sm-9">

                        <asp:TextBox ID="username" CssClass="form-control" placeholder="Email" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <label for="inputPassword3" class="col-sm-3 control-label">Password </label>
                    <div class="col-sm-9">

                        <asp:TextBox ID="password" runat="server" CssClass="form-control" placeholder="Password"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-sm-offset-2 col-sm-9">
                        <div class="checkbox">
                            <label>
                                <asp:CheckBox ID="rememberme" runat="server" />
                                Remember me
                            </label>
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-sm-offset-2 col-sm-10">
                        <asp:Button ID="btnLogin" CssClass="btn btn-default btn-primary" runat="server" Text="Sign in" OnClick="btnLogin_Click1" />

                    </div>
                </div>
            </form>

        </div>
    </div>

</body>
</html>
