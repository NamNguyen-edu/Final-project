using HotelManagement.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelManagement.DAO;

namespace HotelManagement.BUS
{
    internal class TienNghiBUS
    {
        private static TienNghiBUS instance;
        public static TienNghiBUS Instance
        {
            get { if (instance == null) instance = new TienNghiBUS(); return instance; }
            private set { instance = value; }
        }
        private TienNghiBUS() { }
        public List<TienNghi> GetTienNghis()
        {
            return TienNghiDAO.Instance.GetTienNghis();
        }
        // Tìm tiện nghi theo mã
        public TienNghi FindTienNghi(string MaTN)
        {
            return TienNghiDAO.Instance.FindTienNghi(MaTN);
        }
        // Xóa tiện nghi
        public void RemoveTN(TienNghi tienNghi)
        {
            TienNghiDAO.Instance.RemoveTN(tienNghi);
        }
        // Thêm hoặc cập nhật tiện nghi 
        public void InsertOrUpdate(TienNghi tienNghi)
        {
            TienNghiDAO.Instance.InsertOrUpdate(tienNghi);
        }
        // Tìm dịch vụ theo tên 
        public List<TienNghi> FindTienNghiWithName(string name)
        {
            return TienNghiDAO.Instance.FindTienNghiWithName(name);
        }
        // Lấy mã tiện nghi tiếp theo 
        public string GetMaTNNext()
        {
            return TienNghiDAO.Instance.GetMaTNNext();
        }    
    }
}
