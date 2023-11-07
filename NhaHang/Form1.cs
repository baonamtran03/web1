using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NhaHang
{

    [Serializable]
    public partial class Form1 : Form
    {
        private XuLyHoaDon xulyhd;

        //public List<HoaDon> dsHD;


        public Form1()
        {
            InitializeComponent();
        }
        private void hienThi(List<HoaDon> dsHD)
        {
            BindingSource bs = new BindingSource(); // kết nối với hóa đơn
            bs.DataSource = HoaDonView.chuyenDoi(dsHD);
            dgvDanhSach.DataSource = bs;
        }


        //bool ghiThanhCong;
        //private void btnThem_Click(object sender, EventArgs e)
        //{
        //    if (txtSoPhieu.Text==" ")
        //    {
        //        MessageBox.Show("Chua co");
        //        return;
        //    }
        //    HoaDon a=new HoaDon();
        //    a.soPhieu= txtSoPhieu.Text;
        //    a.ngayTao = dtpNgayTao.Value;
        //    a.tenBan = txtTenBan.Text;
        //   // a.tongTien = double.Parse(txtTongTien.Text);
        //    a.thuNgan =txtThuNgan.Text;
        //    if (xulyhd.them(a)==false )
        //    {
        //        MessageBox.Show("Đã nhập rồi");

        //    }
        //    else
        //    {
        //        hienThi(xulyhd.getdsHD());
        //    }




        //}



        private void btnSua_Click(object sender, EventArgs e)
        {
            HoaDon a= new HoaDon();
            a.ngayTao= dtpNgayTao.Value;
            a.soPhieu = txtSoPhieu.Text;
            a.tenBan= txtTenBan.Text;
           // a.thuNgan= txtThuNgan.Text;

            if (xulyhd.sua(a))
            {
                MessageBox.Show("Thông tin đã được sửa");
                hienThi(xulyhd.getdsHD());
            }
            else
            {
                MessageBox.Show("Không tìm thấy hóa đơn có số phiếu tương ứng.");
            }


        } 
        private void btnXoa_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow r in dgvDanhSach.SelectedRows)
            {
                string so = r.Cells[0].Value.ToString();
                if (!string.IsNullOrEmpty(so))
                {
                    xulyhd.xoa(so);

                }
                    
            }
            hienThi(xulyhd.getdsHD());
        }

        private void bntTim_Click(object sender, EventArgs e)
        {
            string soPhieu = txtTim.Text;
            HoaDon a =xulyhd.timHd(soPhieu);
            if (a != null)
            {
                txtSoPhieu.Text = a.soPhieu;
                dtpNgayTao.Value = a.ngayTao;
                txtTenBan.Text = a.tenBan;
                //txtThuNgan.Text= a.thuNgan;
                hienThi(xulyhd.getdsHD());
            }
        }

        //public void btnTongTien_Click(object sender, EventArgs e)
        //{
        //    double tongTien = 0;
        //    foreach (HoaDon a in dsHD)
        //    {
        //        tongTien+= a.tongTien;
        //    }
        //    MessageBox.Show(" Tổng tiền là " + tongTien.ToString());


        //}




        //private void Form1_Load(object sender, EventArgs e)
        //{
        //    xulyhd = new XuLyHoaDon();
        //    string s = "luu";
        //    xulyhd.LuuFile(s);
        //    xulyhd.DocFile("luu.dat"); // Gọi phương thức DocFile sau khi ghi
        //    hienThi(xulyhd.getdsHD());
        //}
        //private void Form1_Load(object sender, EventArgs e)
        //{
        //    xulyhd = new XuLyHoaDon();
        //    string s = "luu";

        //    // Bước 1: Ghi dữ liệu vào tệp "luu.dat"
        //    bool ghiThanhCong = xulyhd.LuuFile(s);
        //    if (ghiThanhCong)
        //    {
        //        // Bước 2: Đọc dữ liệu từ tệp "luu.dat" sau khi đã ghi thành công
        //        bool docThanhCong = xulyhd.DocFile("luu.dat");
        //        if (docThanhCong)
        //        {
        //            // Hiển thị dữ liệu sau khi đã đọc

        //            hienThi(xulyhd.getdsHD());
        //        }
        //        else
        //        {
        //            // Xử lý lỗi khi đọc dữ liệu
        //            Console.WriteLine("Không thể đọc dữ liệu từ tệp 'luu.dat'");
        //        }
        //    }
        //    else
        //    {
        //        // Xử lý lỗi khi ghi dữ liệu
        //        Console.WriteLine("Không thể ghi dữ liệu vào tệp 'luu.dat'");
        //    }
        //}




        //private void hienThi(List<HoaDon> dsHD)
        //{
        //    BindingSource bs = new BindingSource();
        //    bs.DataSource = HoaDonView.chuyenDoi(dsHD);
        //    dgvDanhSach.DataSource = bs;

        //}



        private void Form1_Load(object sender, EventArgs e)
        {
            xulyhd = new XuLyHoaDon(); 
             dgvDanhSach.AutoGenerateColumns = false;
            try
            {
                string s = "QuanAn.dat";
                xulyhd.docFile(s);
                hienThi(xulyhd.getdsHD());
                //FileStream fs = new FileStream("QuanAn.dat", FileMode.OpenOrCreate);
                //BinaryFormatter bf = new BinaryFormatter();
                //xulyhd.dsHD = (List<HoaDon>)bf.Deserialize(fs);
                //fs.Close();

                if (xulyhd.dsHD != null)
                    hienThi(xulyhd.getdsHD());
                else
                {
                    xulyhd.dsHD = new List<HoaDon>();
                    hienThi(xulyhd.getdsHD());

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Loi" +ex.Message);
            }

        } 
        private void btnThem_Click(object sender, EventArgs e)
        {
            HoaDon hd = new HoaDon();
            hd.soPhieu = txtSoPhieu.Text;
            hd.ngayTao = dtpNgayTao.Value;
            hd.tenBan = txtTenBan.Text;
           // hd.thuNgan = txtThuNgan.Text;
            xulyhd.them(hd);
            hienThi(xulyhd.getdsHD());

        }
        
      
        private void dgvDanhSach_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvDanhSach.Rows.Count)
            {
                txtSoPhieu.Text = dgvDanhSach.Rows[e.RowIndex].Cells[0].Value.ToString();
                dtpNgayTao.Value = Convert.ToDateTime(dgvDanhSach.Rows[e.RowIndex].Cells[1].Value);
                txtTenBan.Text = dgvDanhSach.Rows[e.RowIndex].Cells[2].Value.ToString();
                //txtThuNgan.Text = dgvDanhSach.Rows[e.RowIndex].Cells[3].Value.ToString();
            }

            
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string s = "QuanAn.dat";
            xulyhd.LuuFile(s);
        }


        //private void btnLuu_Click(object sender, EventArgs e)
        //{
        //    FileStream fs = new FileStream("QuanAn.dat", FileMode.Create);
        //    BinaryFormatter bf = new BinaryFormatter();
        //    bf.Serialize(fs, xulyhd.dsHD);
        //    fs.Close();


        //}





        //private void btnThemMoi_Click(object sender, EventArgs e)
        //{
        //    HoaDon hoaDonMoi = new HoaDon();
        //    dsHD.Add(hoaDonMoi);

        //    // Ghi dữ liệu sau khi thêm mới
        //    bool ghiThanhCong = xulyhd.LuuFile("luu.dat");
        //    if (ghiThanhCong)
        //    {
        //        hienThi(dsHD);
        //    }
        //    else
        //    {
        //        // Xử lý lỗi khi ghi dữ liệu
        //        Console.WriteLine("Không thể ghi dữ liệu vào tệp 'luu.dat'");
        //    }
        //}
    }
}
