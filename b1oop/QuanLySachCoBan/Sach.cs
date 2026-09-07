using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLySachCoBan
{
    public class Sach
    {
        private string tenSach;
        private int namXuatBan;

        public string MaSach { get; }
        public string TacGia { get; set; }
        public double GiaBan { get; private set; }

        public Sach(string maSach, string tenSach, string tacGia, int namXuatBan, double giaBan)
        {
            this.MaSach = maSach;
            this.TenSach = tenSach;
            this.TacGia = tacGia;
            this.NamXuatBan = namXuatBan;
            this.GiaBan = giaBan >= 0 ? giaBan : throw new ArgumentException("Giá bán không thể âm.");
        }

        public Sach(string maSach, string tenSach, string tacGia, int namXuatBan)
            : this(maSach, tenSach, tacGia, namXuatBan, 0)
        {
        }

        public Sach()
        {
            this.MaSach = "MS-DEFAULT";
            this.TenSach = "Sách chưa đặt tên";
            this.TacGia = "Khuyết danh";
            this.NamXuatBan = DateTime.Now.Year;
            this.GiaBan = 0;
        }

        public string TenSach
        {
            get => tenSach;
            set => tenSach = !string.IsNullOrWhiteSpace(value) ? value.Trim()
                   : throw new ArgumentException("Tên sách không được rỗng.");
        }

        public int NamXuatBan
        {
            get => namXuatBan;
            set => namXuatBan = (value >= 1900 && value <= DateTime.Now.Year) ? value
                   : throw new ArgumentOutOfRangeException(nameof(value), "Năm không hợp lệ.");
        }

        public void CapNhatGia(double giaMoi)
        {
            GiaBan = giaMoi >= 0 ? giaMoi : throw new ArgumentException("Giá bán không thể âm.");
        }

        public void HienThiThongTin()
        {
            Console.WriteLine($"Mã sách: {MaSach}");
            Console.WriteLine($"Tên sách: {TenSach}");
            Console.WriteLine($"Tác giả: {TacGia}");
            Console.WriteLine($"Năm xuất bản: {NamXuatBan}");
            Console.WriteLine($"Giá bán: {GiaBan:N0} VNĐ");
        }

        public override string ToString()
        {
            return $"Mã sách: {MaSach}, Tên sách: {TenSach}, Tác giả: {TacGia}, Năm xuất bản: {NamXuatBan}, Giá bán: {GiaBan:N0} VNĐ";
        }
    }

}
