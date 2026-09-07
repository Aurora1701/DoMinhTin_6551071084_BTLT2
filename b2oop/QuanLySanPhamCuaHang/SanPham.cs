using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLySanPhamCuaHang
{
    public class SanPham
    {
        private string _maSP;
        private string _tenSP;
        private decimal _gia;
        private int _soLuongTon;

        public string MaSP
        {
            get => _maSP;
            set => _maSP = value;
        }

        public string TenSP
        {
            get => _tenSP;
            set => _tenSP = value;
        }

        public decimal Gia
        {
            get => _gia;
            set => _gia = value >= 0 ? value : throw new ArgumentOutOfRangeException(nameof(value), "Giá không thể âm.");
        }

        public int SoLuongTon
        {
            get => _soLuongTon;
            set => _soLuongTon = value >= 0 ? value : throw new ArgumentOutOfRangeException(nameof(value), "Số lượng tồn không thể âm.");
        }

        public SanPham()
        {
        }

        public SanPham(string maSP, string tenSP, decimal gia, int soLuongTon)
        {
            _maSP = maSP;
            _tenSP = tenSP;
            Gia = gia;
            SoLuongTon = soLuongTon;
        }

        public virtual decimal TinhGiaBan() => _gia;

        public virtual string MoTa() =>
            $"[Cơ bản] Mã: {_maSP} | Tên: {_tenSP} | Tồn kho: {_soLuongTon} | Giá gốc: {_gia:N0} VNĐ";
    }

    public class SanPhamThucPham : SanPham
    {
        private DateTime _ngayHetHan;
        private int _nhietDoBaoQuan;

        public DateTime NgayHetHan
        {
            get => _ngayHetHan;
            set => _ngayHetHan = value;
        }

        public int NhietDoBaoQuan
        {
            get => _nhietDoBaoQuan;
            set => _nhietDoBaoQuan = value;
        }

        public SanPhamThucPham() : base()
        {
        }

        public SanPhamThucPham(string maSP, string tenSP, decimal gia, int soLuongTon, DateTime ngayHetHan, int nhietDoBaoQuan)
            : base(maSP, tenSP, gia, soLuongTon)
        {
            _ngayHetHan = ngayHetHan;
            _nhietDoBaoQuan = nhietDoBaoQuan;
        }

        public override decimal TinhGiaBan()
        {
            double soNgayConLai = (_ngayHetHan.Date - DateTime.Now.Date).TotalDays;
            if (soNgayConLai >= 0 && soNgayConLai <= 3)
            {
                return Gia * 0.7m;
            }
            return Gia;
        }

        public override string MoTa() =>
            $"[Thực phẩm] Mã: {MaSP} | Tên: {TenSP} | HSD: {_ngayHetHan:dd/MM/yyyy} | BQ: {_nhietDoBaoQuan}°C | Tồn kho: {SoLuongTon} | Giá gốc: {Gia:N0} VNĐ";
    }

    public class SanPhamDienTu : SanPham
    {
        private int _baoHanhThang;
        private string _hangSanXuat;

        public int BaoHanhThang
        {
            get => _baoHanhThang;
            set => _baoHanhThang = value >= 0 ? value : throw new ArgumentOutOfRangeException(nameof(value), "Thời gian bảo hành không thể âm.");
        }

        public string HangSanXuat
        {
            get => _hangSanXuat;
            set => _hangSanXuat = value;
        }

        public SanPhamDienTu() : base()
        {
        }

        public SanPhamDienTu(string maSP, string tenSP, decimal gia, int soLuongTon, int baoHanhThang, string hangSanXuat)
            : base(maSP, tenSP, gia, soLuongTon)
        {
            BaoHanhThang = baoHanhThang;
            _hangSanXuat = hangSanXuat;
        }

        public override decimal TinhGiaBan()
        {
            if (_baoHanhThang > 12)
            {
                return Gia * 1.1m;
            }
            return Gia;
        }

        public override string MoTa() =>
            $"[Điện tử] Mã: {MaSP} | Tên: {TenSP} | Hãng: {_hangSanXuat} | BH: {_baoHanhThang} tháng | Tồn kho: {SoLuongTon} | Giá gốc: {Gia:N0} VNĐ";
    }

}
