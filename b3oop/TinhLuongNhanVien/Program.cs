using System;
using System.Text;

namespace TinhLuongNhanVien
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("MSSV:6551071084");
            Console.WriteLine("========== HỆ THỐNG QUẢN LÝ LƯƠNG NHÂN VIÊN ==========\n");

            NhanVien nv1 = new NhanVien("NV001", "Nguyễn Văn A", 10_000_000m, 24, 2);

            NhanVien nv2 = new NhanVien();
            nv2.HoTen = "Trần Thị B";
            nv2.LuongCoBan = 12_000_000m;
            nv2.SoNgayLam = 22;

            NhanVien nv3 = new NhanVien(maNV: "NV003", hoTen: "Lê Văn C", soNgayLam: 20);

            Console.WriteLine("--- Danh sách thông tin chi tiết từng nhân viên ---");
            Console.WriteLine("[Nhân viên 1]");
            nv1.HienThiThongTin();

            Console.WriteLine("\n[Nhân viên 2]");
            nv2.HienThiThongTin();

            Console.WriteLine("\n[Nhân viên 3]");
            nv3.HienThiThongTin();

            Console.WriteLine("\n--- Tóm tắt thông tin qua ToString() ---");
            Console.WriteLine(nv1.ToString());
            Console.WriteLine(nv2.ToString());
            Console.WriteLine(nv3.ToString());

            Console.WriteLine("\n--- Kết quả các Overload TinhThuong trên NV1 (Lương CB: 10.000.000 VNĐ) ---");
            Console.WriteLine($"TinhThuong(): {nv1.TinhThuong():N0} VNĐ");
            Console.WriteLine($"TinhThuong(1.5m): {nv1.TinhThuong(1.5m):N0} VNĐ");
            Console.WriteLine($"TinhThuong(1.5m, coPhucLoi: true): {nv1.TinhThuong(1.5m, true):N0} VNĐ");
            Console.WriteLine($"TinhThuong(1.5m, coPhucLoi: false): {nv1.TinhThuong(1.5m, false):N0} VNĐ");

            Console.WriteLine("\n--- Thử nghiệm bắt ngoại lệ khi gán sai dữ liệu ---");

            try
            {
                Console.WriteLine("Thử gán SoNgayLam = 35 cho nhân viên 1...");
                nv1.SoNgayLam = 35;
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"[Lỗi bắt được]: {ex.Message}");
                Console.ResetColor();
            }

            try
            {
                Console.WriteLine("\nThử gán LuongCoBan = -5000000 cho nhân viên 2...");
                nv2.LuongCoBan = -5_000_000m;
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"[Lỗi bắt được]: {ex.Message}");
                Console.ResetColor();
            }

            Console.WriteLine("\nChương trình kết thúc thành công.");
            Console.ReadKey();
        }
    }
}