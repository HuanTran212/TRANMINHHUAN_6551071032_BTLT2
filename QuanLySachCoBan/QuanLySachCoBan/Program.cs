namespace QuanLySachCoBan
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Sach sach1 = new Sach(
                "S001",
                "Lập trình C#",
                "Nguyễn Văn A",
                2020,
                150000
            );

            Sach sach2 = new Sach();
            sach2.TenSach = "Lập trình Java";
            sach2.TacGia = "Trần Thị B";
            sach2.NamXuatBan = 2021;

            Sach sach3 = new Sach
            {
                TenSach = "Lập trình Python",
                TacGia = "Lê Văn C",
                NamXuatBan = 2022
            };


            Console.WriteLine("========== THÔNG TIN SÁCH ==========\n");

            sach1.HienThiThongTin();
            sach2.HienThiThongTin();
            sach3.HienThiThongTin();


            try
            {
                Console.WriteLine("\nThử gán năm xuất bản = 1800:");
                sach1.NamXuatBan = 1800;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Lỗi: {ex.Message}");
            }


            try
            {
                Console.WriteLine("\nThử gán năm xuất bản = 2027:");

                sach2.NamXuatBan = 2027;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Lỗi: {ex.Message}");
            }


            Console.WriteLine("\n========== TOSTRING ==========");

            Console.WriteLine(sach1.ToString());
            Console.WriteLine(sach2.ToString());
            Console.WriteLine(sach3.ToString());

            Console.ReadKey();
        }


        class Sach
        {
            private string _maSach;
            private string _tenSach;
            private string _tacGia;
            private int _namXuatBan;
            private double _giaBan;


            public Sach(
                string maSach,
                string tenSach,
                string tacGia,
                int namXuatBan,
                double giaBan)
            {
                _maSach = maSach;
                TenSach = tenSach;
                _tacGia = tacGia;
                NamXuatBan = namXuatBan;
                _giaBan = giaBan;
            }


            public Sach()
            {
                _maSach = "S000";
                _tenSach = "Chưa có tên";
                _tacGia = "Chưa có tác giả";
                _namXuatBan = DateTime.Now.Year;
                _giaBan = 0;
            }


            public string MaSach
            {
                get { return _maSach; }
            }


            public string TenSach
            {
                get { return _tenSach; }

                set
                {
                    if (string.IsNullOrWhiteSpace(value))
                    {
                        throw new ArgumentException(
                            "Tên sách không được để trống."
                        );
                    }

                    _tenSach = value;
                }
            }


            public string TacGia
            {
                get { return _tacGia; }

                set
                {
                    _tacGia = value;
                }
            }


            public int NamXuatBan
            {
                get { return _namXuatBan; }

                set
                {
                    int namHienTai = DateTime.Now.Year;

                    if (value < 1900 || value > namHienTai)
                    {
                        throw new ArgumentException(
                            $"Năm xuất bản phải từ 1900 đến {namHienTai}."
                        );
                    }

                    _namXuatBan = value;
                }
            }


            public double GiaBan
            {
                get { return _giaBan; }
            }


            public void HienThiThongTin()
            {
                Console.WriteLine("======================================");
                Console.WriteLine("           THÔNG TIN SÁCH");
                Console.WriteLine("======================================");

                Console.WriteLine($"Mã sách       : {MaSach}");
                Console.WriteLine($"Tên sách      : {TenSach}");
                Console.WriteLine($"Tác giả       : {TacGia}");
                Console.WriteLine($"Năm xuất bản  : {NamXuatBan}");
                Console.WriteLine($"Giá bán       : {GiaBan:N0} VND");

                Console.WriteLine("======================================");
                Console.WriteLine();
            }


            public override string ToString()
            {
                return $"Mã sách: {MaSach}, " +
                       $"Tên sách: {TenSach}, " +
                       $"Tác giả: {TacGia}, " +
                       $"Năm xuất bản: {NamXuatBan}, " +
                       $"Giá bán: {GiaBan:N0} VND";
            }
        }
    }
}
