﻿using BaiTap06.Models;
using Microsoft.AspNetCore.Mvc;

namespace BaiTap06.Controllers
{
    public class TaiKhoaiController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult DangKy(TaiKhoanViewModel taikhoan)
        { 
            if (taikhoan != null && taikhoan.Password !=null  !&& (taikhoan.Password).Length>0)
            {
                taikhoan.Password = taikhoan.Password + "chuoi_ma_hoa";
            }
            
            return View(taikhoan);
        }
    }
}
