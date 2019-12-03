<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChinhSuaTaiKhoan.aspx.cs" Inherits="QuanLyTaiKhoan.ChinhSuaTaiKhoan" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
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
                <td class="auto-style2">
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
                <td class="auto-style1" >
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
                <td class="auto-style2" colspan="2" align="center" >
                    
                    <asp:Button ID="btnCapNhatCS" runat="server" OnClick="btnCapNhat_Click" Text="Cập Nhật" />
                </td>
            </tr>
        <tr>
                <td class="auto-style4" colspan="2">
                    <asp:LinkButton ID="lbQuayLai" runat="server" OnClick="lbQuayLai_Click">Quay Lại</asp:LinkButton>
                </td>
            </tr>
        <tr>
                <td class="auto-style4" colspan="2">
                    <asp:Label ID="lblThongBao" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
    </table>
    </div>
    </form>
</body>
</html>
