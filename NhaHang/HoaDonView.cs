using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaHang
{
    internal class HoaDonView
    {
       

        
        public string soPhieu { get; set; }
        public string ngayTao { get; set; }
        public string tenBan { get; set; }

        public double tongTien { get; set; }
        public string thuNgan { get; set; }

        public static List <HoaDonView> chuyenDoi(List<HoaDon> danhSachHoaDon)
        {
            List<HoaDonView> ds= new List<HoaDonView>();// ds hoadon2 lưu trữ các đối tượng
            foreach(HoaDon a  in danhSachHoaDon) // duyệt qua từng hóa đơn trong ds
            {
                HoaDonView b = new HoaDonView();// tạo đối tượng mới 

                b.soPhieu= a.soPhieu;
                b.ngayTao = a.ngayTao.ToShortDateString();
                b.tenBan = a.tenBan;
                b.tongTien = a.tongTien;
                b.thuNgan= a.thuNgan;
                ds.Add(b);
                
            } 
            return ds;
        }
        
    }
}
