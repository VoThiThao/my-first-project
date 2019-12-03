using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QuanLyTaiKhoan
{
    public partial class TimKiem : System.Web.UI.Page
    {
        private void LayDuLieuTuGirdview()
        {
            UserDao userDao = new UserDao();
            gvTimUser.DataSource = userDao.GetAllUser();
            gvTimUser.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LayDuLieuTuGirdview();
            }
        }
        private User LayDuLieuTuFormm()
        {
            string timUser = txtTimUser.Text;
           
            User user = new User
            {
                TimUser = timUser,
                
            };
            return user;
        }
        protected void btnTimKiem_Click(object sender, EventArgs e)
        {
            string timUser = (sender as Button).CommandArgument;
            User user = LayDuLieuTuFormm();
            UserDao userDao = new UserDao();
            bool exist = userDao.checkUserTim(user.TimUser);
            if (exist)
            {
                lblThongBao.Text = "Khong Tim Thay";
            }
            else
            {
                bool result = userDao.TimKiemUser(timUser);
               
                if (result)
                {
                    lblThongBao.Text = "Tim thành công";
                    LayDuLieuTuGirdview();

                }
                else
                {
                    lblThongBao.Text = "Có Lỗi. Vui Lòng Thử Lại";
                }
            }
        }

        
    }
}