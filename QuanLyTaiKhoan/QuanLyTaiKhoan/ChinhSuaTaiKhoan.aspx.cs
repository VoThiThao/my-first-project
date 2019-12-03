    using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QuanLyTaiKhoan
{
    public partial class ChinhSuaTaiKhoan : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string username = Request.QueryString["uname"];
            Response.Write(username);
            if (username != null)
            {
                UserDao userDao = new UserDao();
                User user = userDao.GetUserByUserName(username);
                if (user != null)
                {
                    DoDuLieuLenForm(user);
                }
            }
        }

        private User LayDuLieuTuForm()
        {
            string tenDangNhap = txtUserName.Text;
            string matKhau = txtPass.Text;
            string Ten = txtFirtName.Text;
            bool gioiTinh = RadioButton1.Checked ? true : false;
            string hoTen = txtLastName.Text;
            string email = txtEmail.Text;
            string diaChi = txtAddress.Text;
            User user = new User
            {
                Firstname = Ten,
                Lastname = hoTen,
                Email = email,
                Gender = gioiTinh,
                Address = diaChi,
                Username = tenDangNhap,
                Password = matKhau
            };
            return user;
        }
        private void DoDuLieuLenForm(User user)
        {
           txtUserName.Text = user.Firstname;
            txtLastName.Text = user.Lastname;
            txtEmail.Text = user.Email;
            txtPass.Text = user.Password;
            txtUserName.Text = user.Username;
            txtAddress.Text = user.Address;
            RadioButton1.Checked = user.Gender ? true : false;
            RadioButton2.Checked = user.Gender ? false : true;


        }
       

        protected void lbQuayLai_Click(object sender, EventArgs e)
        {
            Response.Redirect("QLTaiKhoan.aspx");
        }

        protected void btnCapNhat_Click(object sender, EventArgs e)
        {
            User user = LayDuLieuTuForm();
            UserDao userDao = new UserDao();
            bool result = userDao.UpdateUser(user);
            if (result)
            {
                lblThongBao.Text = "Cập Nhật Thành Công Cho Người Dùng" + user.Username;

            }
            else
            {
                lblThongBao.Text = "Cập Nhật không thành công. Vui Lòng kiểm tra lại";
            }
        }
    }
}