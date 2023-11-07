using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections;

namespace NhaHang
{
    [Serializable]
    internal class XuLyHoaDon

    {
       public List<HoaDon> dsHD;

        public XuLyHoaDon()
        {
            TruyCapHoaDon data = TruyCapHoaDon.khoitao();
            dsHD = data.getdsHoaDon();
        }

        public List<HoaDon> getdsHD() { return dsHD; }


        public HoaDon timHd(string soPhieu)
        {

            foreach (HoaDon a in dsHD)// duyệt qua tất cả dshd
            {
                if (a.soPhieu == soPhieu)// tim xem so phieu co trung voi dang tim
                {
                    return a;
                }
            }
            return null;
        }

        public bool them(HoaDon a)
        {
            HoaDon n = timHd(a.soPhieu);// tạo biến n gán kq tìm với a.phieu, kiểm tra xem có trùng k
            if (n != null)
                return false;
            dsHD.Add(a);
            return true;


        }

        public bool xoa(string soPhieu)
        {
            HoaDon n = timHd(soPhieu);
            if (n == null) return false;// k tồn tại false
            dsHD.Remove(n); // xóa nếu tồn tại
            return true; // trả về true khi xóa
        }


        public bool sua(HoaDon a)
        {
            HoaDon n = timHd(a.soPhieu);
            if (n == null)
            {
                Console.WriteLine("Hóa đơn không tồn tại");
                return false;

            }
            Console.WriteLine("Hóa đơn đang được cập nhật...");
            n.soPhieu = a.soPhieu;
            n.ngayTao = a.ngayTao;
            n.tenBan = a.tenBan;
            n.thuNgan = a.thuNgan;


            Console.WriteLine("Hóa đơn đã cập nhật");
            return true;

        }
        public double Tong(HoaDon a)
        {
            if (a != null && a.tongTien >= 0)
            {
                return a.tongTien;
            }
            return 0;

        }
       public bool LuuFile(string tenfile)
        {
            FileStream fs = new FileStream("QuanAn.dat", FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, dsHD);
            fs.Close();
            return true;
        }
        public bool docFile(string tenfile)
        {
            try
            {
                FileStream fs= new FileStream(tenfile,FileMode.Open);
                BinaryFormatter bf= new BinaryFormatter();
                dsHD =(List<HoaDon>)bf.Deserialize(fs);
                dsHD =bf.Deserialize(fs) as List<HoaDon>;
                fs.Close() ;
                return true;
            }
            catch { 
                return false; 
            }
        }


        //public bool DocFile(string tenfile)
        //{
        //    //try
        //    //{
        //    //    FileStream fs = new FileStream(tenfile, FileMode.Open);
        //    //        BinaryFormatter bf = new BinaryFormatter();
        //    //         dsHD =(List<HoaDon>) bf.Deserialize(fs);
        //    //        dsHD = bf.Deserialize(fs) as List<HoaDon>;
        //    //    fs.Close();
        //    //    return true;
        //    //}
        //    //catch (Exception ex)
        //    //{
        //    //    // Xử lý ngoại lệ và ghi log hoặc thông báo lỗi
        //    //    Console.WriteLine("Lỗi: " + ex.Message);
        //    //    return false;
        //    //}
        //    try
        //    {
        //        FileStream fs = new FileStream("luu.dat", FileMode.Create);
        //        BinaryFormatter bf = new BinaryFormatter();
        //        bf.Serialize(fs, dsHD);
        //        fs.Close();
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Lỗi: " + ex.Message);
        //        return false;
        //    }

        //}


        //public bool LuuFile(string tenfile)
        //{
        //    FileStream fs = new FileStream("luu.dat", FileMode.Create);
        //    BinaryFormatter bf = new BinaryFormatter();
        //    bf.Serialize(fs, dsHD);
        //    fs.Close();
        //    return true;
        //}
        //public bool LuuFile(string tenfile)
        //{
        //    FileStream fs = new FileStream("QuanAn.dat", FileMode.Create);
        //    BinaryFormatter bf= new BinaryFormatter();
        //    bf.Serialize(fs, dsHD);
        //    fs.Close();
        //    return true;
        //}


    }
}





