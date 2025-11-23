using HotelManagement.CTControls;
using HotelManagement.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Data.Entity.Validation;
using System.Linq;
using System.Windows.Forms;

namespace HotelManagement.DAO
{
    internal class PhieuThueDAO
    {
        private static PhieuThueDAO instance;
        public static PhieuThueDAO Instance
        {
            get { if (instance == null) instance = new PhieuThueDAO(); return instance; }
            private set { instance = value; }
        }

        private PhieuThueDAO() { }


        // GET ALL – luôn tạo context mới + Include
        public List<PhieuThue> GetPhieuThues()
        {
            using (var db = new HotelDTO())
            {
                return db.PhieuThues
                         .Include("KhachHang")
                         .Include("NhanVien")
                         .ToList();
            }
        }


        // GET by ID – luôn fresh từ DB

        public PhieuThue GetPhieuThue(string MaPT)
        {
            using (var db = new HotelDTO())
            {
                return db.PhieuThues
                         .Include("KhachHang")
                         .Include("NhanVien")
                         .SingleOrDefault(p => p.MaPT == MaPT);
            }
        }

        // UPDATE – đảm bảo KH & NV được load mới 

        public void UpdatePhieuThue(PhieuThue phieuThue)
        {
            try
            {
                using (var db = new HotelDTO())
                {
                    phieuThue.DaXoa = false;

                    phieuThue.KhachHang = db.KhachHangs.Find(phieuThue.MaKH);
                    phieuThue.NhanVien = db.NhanViens.Find(phieuThue.MaNV);

                    db.PhieuThues.AddOrUpdate(phieuThue);
                    db.SaveChanges();
                }
            }
            catch (DbEntityValidationException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        // SEARCH theo tên

        public List<PhieuThue> GetPhieuThuesWithNameCus(string name)
        {
            using (var db = new HotelDTO())
            {
                return db.PhieuThues
                         .Include("KhachHang")
                         .Include("NhanVien")
                         .Where(p => p.KhachHang.TenKH.Contains(name))
                         .ToList();
            }
        }


        // LẤY MÃ NEXT

        public string GetMaPTNext()
        {
            using (var db = new HotelDTO())
            {
                var list = db.PhieuThues.ToList();
                if (list.Count == 0) return "PT001";

                string MaMax = list[list.Count - 1].MaPT;
                int num = int.Parse(MaMax.Substring(2));
                num++;

                return "PT" + num.ToString("000");
            }
        }

        // DELETE 

        public void RemoveAllPhieuThueWithMaKH(List<PhieuThue> phieuThues)
        {
            using (var db = new HotelDTO())
            {
                if (phieuThues != null)
                {
                    foreach (var pt in phieuThues)
                    {
                        var fresh = db.PhieuThues.Find(pt.MaPT);
                        if (fresh != null)
                            db.PhieuThues.Remove(fresh);
                    }
                }
                db.SaveChanges();
            }
        }
    }
}
