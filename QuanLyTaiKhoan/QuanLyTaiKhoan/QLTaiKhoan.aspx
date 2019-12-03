<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QLTaiKhoan.aspx.cs" Inherits="QuanLyTaiKhoan.QLTaiKhoan" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 59px;
        }
        .auto-style2 {
            height: 26px;
            align-items: center;
        }
        .auto-style3 {
            height: 26px;
            width: 119px;
        }
        .auto-style4 {
            height: 26px;
            align-items: center;
            width: 413px;
        }
        .auto-style5 {
            height: 59px;
            width: 119px;
        }
        .auto-style6 {
            height: 26px;
            align-items: center;
            width: 119px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table style="width: 37%; height: 331px; margin-top: 21px;">
            <tr>
                <td class="auto-style2" colspan="2">QUẢN LÝ TÀI KHOẢN<br />
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Tên Đăng Nhập</td>
                <td class="auto-style6">
                    <asp:TextBox ID="txtUserName" runat="server" ></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Mật Khẩu</td>
                <td class="auto-style3">
                    <asp:TextBox ID="txtPass" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Tên</td>
                <td class="auto-style3">
                    <asp:TextBox ID="txtFirtName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">Giới Tính</td>
                <td class="auto-style5" >
                    <asp:RadioButton ID="RadioButton1" runat="server" Text="Nam" GroupName="gender" />
                    <br />
                    <asp:RadioButton ID="RadioButton2" runat="server" Text="Nữ"  GroupName="gender" />
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Họ Và Tên Đệm</td>
                <td class="auto-style3">
                    <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Email</td>
                <td class="auto-style3">
                    <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Địa Chỉ</td>
                <td class="auto-style3">
                    <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Hình Ảnh</td>
                <td class="auto-style3">
                    <asp:FileUpload ID="fupAvatar" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="auto-style2" colspan="2" align="center" >
                    <asp:Button ID="btnSave"  runat="server" Text="Lưu" OnClick="Button1_Click"/>
                    <asp:Button ID="btnDelete" runat="server" Text="Xóa" OnClick="btnDelete_Click" OnClientClick =" return confirm ('Bạn muốn xóa người dùng này ?')" />
                    <asp:Button ID="btnClear" runat="server" Text="Xóa Trống Form" OnClick="btnClear_Click" />
                    <asp:Button ID="btnCapNhat" runat="server" OnClick="btnCapNhat_Click" Text="Cập Nhật" />
                    <asp:LinkButton ID="lkbChuyenTrang" runat="server" OnClick="lkbChuyenTrang_Click">Chuyển Trang</asp:LinkButton>
                </td>
            </tr>
            <tr>
                <td class="auto-style4" colspan="2">
                    <asp:Label ID="lblThongBao" runat="server" Text="Label"></asp:Label>
                    <asp:GridView ID="gvUser" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="gvUser_SelectedIndexChanged" OnRowDeleting="gvUser_RowDeleting" >
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="UserName" HeaderText="UserName" />
                            <asp:BoundField DataField="FisrtName" HeaderText="FisrtName" />
                            <asp:BoundField DataField="LastName" HeaderText="LastName" />
                            <asp:BoundField DataField="Email" HeaderText="Email" />
                            <asp:CheckBoxField DataField="Gender" HeaderText="Gender" />
                            <asp:ImageField DataImageUrlField="Avatar" DataImageUrlFormatString="~/image/{0}" HeaderText="Hình Ảnh">
                                <ControlStyle Height="100px" Width="100px" />
                            </asp:ImageField>
                            <asp:CommandField ShowSelectButton="True" />
                            <asp:CommandField ShowDeleteButton="True" />
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:Button ID="btnXoa1" runat="server" OnClick="btnXoa1_Click" CommandArgument='<%#Eval ("UserName") %>' OnClientClick="return confirm ('Bạn có muốn xóa không ?')" Text="Xóa" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:HyperLinkField DataNavigateUrlFields="UserName" DataNavigateUrlFormatString="ChinhSuaTaiKhoan.aspx?uname={0}" Text="Chỉnh Sửa" />
                            <asp:TemplateField HeaderText="Hinh Anh 2">
                                <ItemTemplate>
                                    <asp:Image ID ="Image1" runat="server" ImageUrl='<%# Eval ("Avatar","~/image/{0}") %>' Width="100px" Height="100px" />
                                </ItemTemplate>

                            </asp:TemplateField>
                        </Columns>
                        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                        <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                        <SortedAscendingCellStyle BackColor="#FDF5AC" />
                        <SortedAscendingHeaderStyle BackColor="#4D0000" />
                        <SortedDescendingCellStyle BackColor="#FCF6C0" />
                        <SortedDescendingHeaderStyle BackColor="#820000" />
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
