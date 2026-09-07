using System;
using System.Text;

namespace QuanLySachCoBan
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("MSSV:6551071084");
            Console.WriteLine("========== HỆ THỐNG QUẢN LÝ SÁCH THƯ VIỆN ==========\n");

            Sach sach1 = new Sach("B001", "Lập trình C# từ cơ bản đến nâng cao", "Nguyễn Văn A", 2021, 150000);

            Sach sach2 = new Sach();
            sach2.TenSach = "Cấu trúc dữ liệu và giải thuật";
            sach2.TacGia = "Trần Thị B";
            sach2.NamXuatBan = 2019;
            sach2.CapNhatGia(120000);

            Sach sach3 = new Sach("B003", "Thiết kế Hướng đối tượng", "Lê Văn C", 2020, 185000)
            {
                TenSach = "Thiết kế Hướng đối tượng (Tái bản 2022)",
                NamXuatBan = 2022
            };

            Console.WriteLine("--- Danh sách thông tin chi tiết từng cuốn sách ---");
            Console.WriteLine("[Sách 1]");
            sach1.HienThiThongTin();

            Console.WriteLine("\n[Sách 2]");
            sach2.HienThiThongTin();

            Console.WriteLine("\n[Sách 3]");
            sach3.HienThiThongTin();

            Console.WriteLine("\n--- Tóm tắt thông tin qua ToString() ---");
            Console.WriteLine(sach1.ToString());
            Console.WriteLine(sach2.ToString());
            Console.WriteLine(sach3.ToString());

            Console.WriteLine("\n--- Thử nghiệm bắt ngoại lệ khi gán sai năm xuất bản ---");

            try
            {
                Console.WriteLine("Thử gán NamXuatBan = 1850 cho cuốn sách 1...");
                sach1.NamXuatBan = 1850;
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"[Lỗi bắt được]: {ex.Message}");
                Console.ResetColor();
            }

            int namTuongLai = DateTime.Now.Year + 5;
            try
            {
                Console.WriteLine($"\nThử gán NamXuatBan = {namTuongLai} cho cuốn sách 2...");
                sach2.NamXuatBan = namTuongLai;
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"[Lỗi bắt được]: {ex.Message}");
                Console.ResetColor();
            }

            try
            {
                Console.WriteLine("\nThử gán TenSach = \"   \"...");
                sach1.TenSach = "   ";
            }
            catch (ArgumentException ex)
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