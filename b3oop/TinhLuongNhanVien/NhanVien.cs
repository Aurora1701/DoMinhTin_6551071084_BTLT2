using System;
using System.Collections.Generic;
using System.Text;

namespace TinhLuongNhanVien
{
    public class NhanVien
    {
        private decimal _luongCoBan;
        private int _soNgayLam;

        public string MaNV { get; }
        public string HoTen { get; set; }
        public int SoNgayNghiPhep { get; set; }

        public decimal LuongCoBan
        {
            get => _luongCoBan;
            set => _luongCoBan = value >= 0 ? value : throw new ArgumentOutOfRangeException(nameof(value), "Lương cơ bản không thể âm.");
        }

        public int SoNgayLam
        {
            get => _soNgayLam;
            set => _soNgayLam = (value >= 0 && value <= 31) ? value : throw new ArgumentOutOfRangeException(nameof(value), "Số ngày làm phải từ 0 đến 31.");
        }

        public decimal LuongThucNhan => Math.Round(((LuongCoBan / 26m) * SoNgayLam) - (LuongCoBan * 0.08m), 2);

        public NhanVien()
        {
            this.MaNV = "NV000";
            this.HoTen = "Chưa có tên";
            this.LuongCoBan = 5_000_000m;
            this.SoNgayLam = 26;
            this.SoNgayNghiPhep = 0;
        }

        public NhanVien(string maNV, string hoTen)
        {
            this.MaNV = maNV;
            this.HoTen = hoTen;
            this.LuongCoBan = 5_000_000m;
            this.SoNgayLam = 26;
            this.SoNgayNghiPhep = 0;
        }

        public NhanVien(string maNV, string hoTen, decimal luongCoBan, int soNgayLam, int soNgayNghiPhep)
        {
            this.MaNV = maNV;
            this.HoTen = hoTen;
            this.LuongCoBan = luongCoBan;
            this.SoNgayLam = soNgayLam;
            this.SoNgayNghiPhep = soNgayNghiPhep;
        }

        public NhanVien(string maNV, string hoTen, decimal luong = 5_000_000m, int soNgayLam = 26)
        {
            this.MaNV = maNV;
            this.HoTen = hoTen;
            this.LuongCoBan = luong;
            this.SoNgayLam = soNgayLam;
            this.SoNgayNghiPhep = 0;
        }

        public decimal TinhThuong() => 0m;

        public decimal TinhThuong(decimal heSo) => LuongCoBan * heSo;

        public decimal TinhThuong(decimal heSo, bool coPhucLoi) => (LuongCoBan * heSo) + (coPhucLoi ? 500_000m : 0m);

        public void HienThiThongTin()
        {
            Console.WriteLine($"Mã NV: {MaNV}");
            Console.WriteLine($"Họ tên: {HoTen}");
            Console.WriteLine($"Lương cơ bản: {LuongCoBan:N0} VNĐ");
            Console.WriteLine($"Số ngày làm: {SoNgayLam}");
            Console.WriteLine($"Nghỉ phép: {SoNgayNghiPhep}");
            Console.WriteLine($"Lương thực nhận: {LuongThucNhan:N0} VNĐ");
        }

        public override string ToString()
        {
            return $"Mã NV: {MaNV}, Họ tên: {HoTen}, Lương CB: {LuongCoBan:N0} VNĐ, Ngày làm: {SoNgayLam}, Thực nhận: {LuongThucNhan:N0} VNĐ";
        }
    }

}
