using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLySanPhamCuaHang
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("MSSV: 6551071084");
            Console.WriteLine("========== QUẢN LÝ SẢN PHẨM CỬA HÀNG ==========\n");

            List<SanPham> danhSachSanPham = new List<SanPham>
            {
                new SanPham
                {
                    MaSP = "SP001",
                    TenSP = "Sổ tay da ghi chép",
                    Gia = 80_000m,
                    SoLuongTon = 50
                },
                new SanPhamThucPham
                {
                    MaSP = "TP001",
                    TenSP = "Sữa chua tiệt trùng",
                    Gia = 40_000m,
                    SoLuongTon = 30,
                    NgayHetHan = DateTime.Now.AddDays(2),
                    NhietDoBaoQuan = 4
                },
                new SanPhamThucPham
                {
                    MaSP = "TP002",
                    TenSP = "Bánh mì tươi ngũ cốc",
                    Gia = 25_000m,
                    SoLuongTon = 20,
                    NgayHetHan = DateTime.Now.AddDays(10),
                    NhietDoBaoQuan = 25
                },
                new SanPhamDienTu
                {
                    MaSP = "DT001",
                    TenSP = "Nồi chiên không dầu",
                    Gia = 1_500_000m,
                    SoLuongTon = 15,
                    BaoHanhThang = 24,
                    HangSanXuat = "Philips"
                },
                new SanPhamDienTu
                {
                    MaSP = "DT002",
                    TenSP = "Tai nghe không dây",
                    Gia = 600_000m,
                    SoLuongTon = 40,
                    BaoHanhThang = 6,
                    HangSanXuat = "Sony"
                }
            };

            decimal tongGiaTriKhoHang = 0;
            Console.WriteLine("MSSV:6551071084");
            Console.WriteLine("--- DANH SÁCH SẢN PHẨM & TÍNH ĐA HÌNH TẠI RUNTIME ---\n");

            foreach (SanPham sp in danhSachSanPham)
            {
                decimal giaBanHienTai = sp.TinhGiaBan();
                decimal giaTriTonKho = sp.Gia * sp.SoLuongTon;
                tongGiaTriKhoHang += giaTriTonKho;

                Console.WriteLine(sp.MoTa());
                Console.WriteLine($" => Giá bán thực tế: {giaBanHienTai:N0} VNĐ | Giá trị tồn kho: {giaTriTonKho:N0} VNĐ\n");
            }

            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine($"TỔNG GIÁ TRỊ KHO HÀNG: {tongGiaTriKhoHang:N0} VNĐ");
            Console.WriteLine("--------------------------------------------------");

            Console.ReadKey();
        }
    }
}