using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaHang
{
    [Serializable]
    
    internal class HoaDon
    {
       
        private string m_soPhieu;
        private DateTime m_ngayTao;
        private string m_tenBan;
        private string m_thuNgan;
        private double m_tongTien;

        
        public string soPhieu { 
            get { return m_soPhieu;}
            set { m_soPhieu = value;}
        }

        public DateTime ngayTao
        {
            get { return m_ngayTao;}
            set
            {
                m_ngayTao = value;
            }
        }

        public string tenBan
        {
            get { return m_tenBan; }
            set { m_tenBan = value; }
        }

        public string thuNgan
        {
            get { return m_thuNgan; }
            set { m_thuNgan = value; }
        }
        public double tongTien
        {
            get { return m_tongTien; }
            set { m_tongTien = value;}
        }

        public HoaDon()
        {
            
            m_soPhieu=" ";
            m_ngayTao =DateTime.Now;
            m_thuNgan =" ";
            m_tongTien =0;

        }

        public HoaDon ( string so, DateTime ngay, string thungan, double tong)
        {
            
            m_soPhieu=so;
            m_ngayTao=ngay;
            m_thuNgan=thungan;
            m_tongTien = tong;
        }
      



    }

    

}
