using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyTaiKhoan
{
    public class User
    {
        string tenDangNhap;
        string matKhau;
        string Ten;
        bool gioiTinh;
        string hoTen;
        string email;
        string diaChi;

        public string Firstname
        {
            get { return Ten; }
            set { Ten = value; }
        }
        public string Lastname
        {
            get { return hoTen; }
            set { hoTen = value; }
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        public bool Gender
        {
            get { return gioiTinh; }
            set { gioiTinh = value; }
        }
        public string Address
        {
            get { return diaChi; }
            set { diaChi = value; }
        }
        public string Username
        {
            get { return tenDangNhap; }
            set { tenDangNhap = value; }
        }
        public string Password
        {
            get { return matKhau; }
            set { matKhau = value; }
        }
    }
}