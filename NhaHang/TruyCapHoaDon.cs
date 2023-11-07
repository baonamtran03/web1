using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaHang
{
    internal class TruyCapHoaDon
    {
        private static TruyCapHoaDon m_data = null;
        private List<HoaDon> m_dsHoaDon;

        private TruyCapHoaDon()
        {
            m_dsHoaDon = new List<HoaDon>();
        }

        public static TruyCapHoaDon khoitao()
        {
            if (m_data == null)
            {
                m_data = new TruyCapHoaDon();
            }
            return m_data;
        }

        public List<HoaDon> getdsHoaDon()
        {
            return m_dsHoaDon; 
        }
    }

}
