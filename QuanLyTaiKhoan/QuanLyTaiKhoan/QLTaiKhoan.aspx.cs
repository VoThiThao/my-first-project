using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QuanLyTaiKhoan
{
    public partial class QLTaiKhoan : System.Web.UI.Page
    {
        private void LayDuLieuTuGirdview()
        {
            UserDao userDao = new UserDao();
            gvUser.DataSource = userDao.GetAllUser();
            gvUser.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LayDuLieuTuGirdview();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            User user = LayDuLieuTuForm();
            UserDao userDao = new UserDao();
            bool exist = userDao.checkUser(user.Username);
            if (exist)
            {
                lblThongBao.Text = "Username đã tồn tại";
            }
            else
            {
                bool result = userDao.Insert(user);
                UploadAvatar(user.AvatarFileName);
                if (result)
                {
                    lblThongBao.Text = "Đăng Ksi thành công";
                    LayDuLieuTuGirdview();

                }
                else
                {
                    lblThongBao.Text = "Có Lỗi. Vui Lòng Thử Lại";
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
            string extension = System.IO.Path.GetExtension(fupAvatar.FileName);
            string filename = tenDangNhap + extension;
            User user = new User
            {
                Firstname = Ten,
                Lastname = hoTen,
                Email = email,
                Gender = gioiTinh,
                Address = diaChi,
                Username = tenDangNhap,
                Password = matKhau,
                AvatarFileName = filename
            };
            return user;
        }
        private void UploadAvatar(string fileName)
        {
            string filePath = "~/image/" + fileName;
            if (fupAvatar.HasFile)
            {
                fupAvatar.SaveAs(Server.MapPath(filePath));
            }
        }

        protected void gvUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            string username = gvUser.SelectedRow.Cells[0].Text;
            UserDao userDao = new UserDao();
            User user = userDao.GetUserByUserName(username);
            if (user != null)
            {
                DoDuLieuLenForm(user);
            }
        }

         private void DoDuLieuLenForm(User user)
        {
            txtFirtName.Text = user.Firstname;
            txtLastName.Text = user.Lastname;
            txtEmail.Text = user.Email;
            txtPass.Text = user.Password;
            txtUserName.Text = user.Username;
            txtAddress.Text = user.Address;
            RadioButton1.Checked = user.Gender ? true : false;
            RadioButton2.Checked = user.Gender ? false : true; 


        }

         protected void btnCapNhat_Click(object sender, EventArgs e)
         {
             User user = LayDuLieuTuForm();
             UserDao userDao = new UserDao();
             bool result = userDao.UpdateUser(user);
             if (result)
             {
                 lblThongBao.Text = "Cập Nhật Thành Công Cho Người Dùng" + user.Username;
                 LayDuLieuTuGirdview();
             }
             else
             {
                 lblThongBao.Text = "Cập Nhật không thành công. Vui Lòng kiểm tra lại";
             }
         }

         protected void btnClear_Click(object sender, EventArgs e)
         {
             txtFirtName.Text = "";
             txtLastName.Text = "";
             txtEmail.Text = "";
             txtPass.Text = "";
             txtUserName.Text = "";
             txtAddress.Text = "";
             RadioButton1.Checked = false;
             RadioButton2.Checked = false;
         }

         protected void btnDelete_Click(object sender, EventArgs e)
         {
             UserDao userDao = new UserDao();
             bool result = userDao.DeleteUser(txtUserName.Text);
             if (result)
             {
                 lblThongBao.Text = "Xoa Thành Công";
                 LayDuLieuTuGirdview();
             }
             else
             {
                 lblThongBao.Text = "Xoa không thành công. Vui Lòng kiểm tra lại";
             }
         }

         protected void gvUser_RowDeleting(object sender, GridViewDeleteEventArgs e)
         {
             string username = gvUser.Rows[e.RowIndex].Cells[0].Text;
             UserDao userDao = new UserDao();
             bool result = userDao.DeleteUser(username);
             if (result)
             {
                 lblThongBao.Text = "Đã xóa thành công cho người dùng: " + username;
                 LayDuLieuTuGirdview();
             }
             else
             {
                 lblThongBao.Text = "Xóa không thành công vui lòng kiểm tra lại";
             }

         }

         protected void btnXoa1_Click(object sender, EventArgs e)
         {
             string username = (sender as Button).CommandArgument;
             UserDao userDao = new UserDao();
             bool result = userDao.DeleteUser(username);
             if (result)
             {
                 lblThongBao.Text = "Đã xóa thành công cho người dùng: " + username;
                 LayDuLieuTuGirdview();
             }
             else
             {
                 lblThongBao.Text = "Xóa không thành công vui lòng kiểm tra lại";
             }
         }

        /* protected void lkbChuyenTrang_Click(object sender, EventArgs e)
         {
             Response.Redirect("TimKiem.aspx");
         }*/
 
    }
}