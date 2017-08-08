<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="adminPics.aspx.cs" Inherits="sns.admin.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../css/bootstrap.css" rel="stylesheet" />
    <link href="../../css/bootstrap.min.css" rel="stylesheet" />
    <style type="text/css">
        .glyphicon-adjust {
            width: 550px;
            margin-left: 0px;
        }
    </style>
</head>
<body>
    <div class="jumbotron vertical-center">
        <div class="container">

            <form class="form-horizontal col-xs-4 col-xs-offset-4" runat="server">
                <div class="form-group">
                    <label class="col-md-12 bg-primary text-white text-center">Dashbord</label>
                </div>
                <div class="form-group">
                    <div class="col-md-3 col-md-offset-1">
                        <asp:FileUpload ID="FileUpload1" runat="server" />
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-md-10 col-md-offset-1">

                        <asp:TextBox ID="displayname" runat="server" CssClass="form-control" placeholder="DisplayName"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-md-10 col-md-offset-1">

                        <asp:TextBox ID="pictype" runat="server" CssClass="form-control" placeholder="PicType"></asp:TextBox>
                    </div>
                </div>

                <div class="form-group">
                    <div class="col-md-6 col-md-offset-4">

                        <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" Width="84px" />
                    </div>
                </div>
                <div>
                    <div class="row">
                        <asp:TextBox ID="search" runat="server" Width="246px"></asp:TextBox>
                        <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
                    </div>
                </div>
                <div class="glyphicon-adjust">
                    <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Horizontal"  AutoGenerateColumns="False" OnRowEditing="GridView1_RowEditing" AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowUpdating="GridView1_RowUpdating" PageSize="3" OnRowDeleting="GridView1_RowDeleting" OnRowCommand="GridView1_RowCommand" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                        <AlternatingRowStyle BackColor="#F7F7F7" />
                        <Columns>
                            <asp:TemplateField HeaderText="pid">
                                <ItemTemplate>
                                    <asp:Label ID="pid" runat="server" Text='<%#Eval("pid") %>'>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="displayname">
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%#Eval("displayname") %>'>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtDisplayName" runat="server" Text='<%#Eval("displayname") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="type">
                                <ItemTemplate>
                                    <asp:Label ID="Label2" runat="server" Text='<%#Eval("type") %>'>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:DropDownList ID="ddType" runat="server">
                                        <asp:ListItem Value="nature"></asp:ListItem>
                                        <asp:ListItem Value="beauty"></asp:ListItem>
                                        <asp:ListItem Value="logo"></asp:ListItem>
                                    </asp:DropDownList>
                                </EditItemTemplate>
                            </asp:TemplateField>

                            <asp:ImageField DataImageUrlField="picname"
                                dataimageurlformatstring="../images/{0}"
                                ControlStyle-Width="100"
                                ControlStyle-Height = "100"
                                NullDisplayText="No image"
                                HeaderText="Photo"/>                        

                                <asp:CommandField ShowEditButton="True" />
                                <asp:CommandField ShowDeleteButton="True" />
                                <asp:CommandField HeaderText="makePP" ShowSelectButton="True" />
                        </Columns>
                        <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                        <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
                        <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
                        <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
                        <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
                        <SortedAscendingCellStyle BackColor="#F4F4FD" />
                        <SortedAscendingHeaderStyle BackColor="#5A4C9D" />
                        <SortedDescendingCellStyle BackColor="#D8D8F0" />
                        <SortedDescendingHeaderStyle BackColor="#3E3277" />
                    </asp:GridView>
                </div>
            </form>

        </div>
    </div>

</body>
</html>
