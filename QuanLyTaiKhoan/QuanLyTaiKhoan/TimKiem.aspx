<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TimKiem.aspx.cs" Inherits="QuanLyTaiKhoan.TimKiem" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
        }
        .auto-style2 {
            width: 330px;
        }
        .auto-style3 {
            width: 441px;
            height: 42px;
        }
        .auto-style4 {
            width: 330px;
            height: 42px;
        }
        .auto-style5 {
            width: 68px;
            height: 42px;
        }
        .auto-style6 {
            width: 68px;
        }
        .auto-style7 {
            height: 23px;
        }
        .auto-style8 {
            width: 330px;
            height: 23px;
        }
        .auto-style9 {
            width: 68px;
            height: 23px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table style="width: 58%; height: 112px;">
            <tr>
                <td class="auto-style3"></td>
                <td class="auto-style4" style="font-family: 'Buxton Sketch'; font-size: xx-large; font-weight: 300; font-style: italic; color: #800000; text-decoration: underline; background-color: #C0C0C0; clip: rect(auto, auto, auto, auto)">TÌM KIẾM</td>
                <td class="auto-style5"></td>
            </tr>
            <tr>
                <td class="auto-style1">UserName</td>
                <td class="auto-style2">
                    <asp:TextBox ID="txtTimUser" runat="server" Width="319px"></asp:TextBox>
                </td>
                <td class="auto-style6">
                    <asp:Button ID="btnTimKiem" runat="server" BackColor="#CC66FF" BorderColor="#33CC33" BorderStyle="Double" ForeColor="Black" OnClick="btnTimKiem_Click" Text="Tìm Kiếm" />
                </td>
            </tr>
            <tr>
                <td class="auto-style7"></td>
                <td class="auto-style8">
                    <asp:Label ID="lblThongBao" runat="server" Text="Label"></asp:Label>
                </td>
                <td class="auto-style9"></td>
            </tr>
            <tr>
                <td class="auto-style1" colspan="3">
                       
                    <asp:GridView ID="gvTimUser" runat="server" AutoGenerateColumns="False">
                        <Columns>
                            <asp:BoundField DataField="UserName" HeaderText="UserName" />
                            <asp:BoundField DataField="FisrtName" HeaderText="FirstName" />
                            <asp:BoundField DataField="Email" HeaderText="Email" />
                        </Columns>
                    </asp:GridView>
                       
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
