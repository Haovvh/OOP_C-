﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BLL;

namespace DoAn.Pages.MHNhaphang
{
    public class DeleteModel : PageModel
    {
        [Key]
        [Required]
        [BindProperty(SupportsGet = true)]
        public int Ma { get; set; }
        [Required]
        [BindProperty]
        public string Ten { get; set; }
        [Required]
        [BindProperty]
        public int Mamathang { get; set; }
        [Required]
        [BindProperty]
        public int Soluong { get; set; }
        [Required]
        [BindProperty]
        [DataType(DataType.Date)]
        public DateTime Ngaynhap { get; set; }
        public List<Mathang> dsMathang { get; set; }
        //private XLLoaihang Xulyloaihang = new XLLoaihang();
        private XLMathang Xulymathang = new XLMathang();
        private XLHoadonnhap Xulyhoadonnhap = new XLHoadonnhap();
        private XLHoadonban Xulyhoadonban = new XLHoadonban();
        public string ErrorMessage { get; set; }
        public void OnGet()
        {
            var ketqua = (Hoadonnhap)Xulyhoadonnhap.Timkiem(Ma);
            if (ketqua != null)
            {
                Ten = ketqua.Ten;
                Mamathang = ketqua.MaMathang;
                Soluong = ketqua.Soluong;
                Ngaynhap = ketqua.Ngaynhap;
                dsMathang = Xulymathang.Doc().Cast<Mathang>().ToList();
            }
            else
            {
                Response.StatusCode = 404;
            }
        }

        public void OnPost()
        {
            dsMathang = Xulymathang.Doc().Cast<Mathang>().ToList();            
            Hoadonnhap hoadonnhap = new Hoadonnhap(Ma, Ten, Mamathang, Soluong, Ngaynhap);
            Xulyhoadonnhap.Xoa(hoadonnhap.Ma);
            Response.Redirect("/MHNhaphang/");                
        }
    }
}
