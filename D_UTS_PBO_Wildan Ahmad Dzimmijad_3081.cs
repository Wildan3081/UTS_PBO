
using System;
using System.Collections.Generic;
using System.Linq;

namespace PickMM
{
    abstract class MahasiswaBase
    {
        public abstract void TampilkanInfo();
    }
    class Mahasiswa : MahasiswaBase
    {
        public string NIM { get; private set; }
        public string Nama { get; set; }
        public string Jurusan { get; set; }

        public Mahasiswa(string nim, string nama, string jurusan)
        {
            NIM = nim;
            Nama = nama;
            Jurusan = jurusan;
        }
        public override void TampilkanInfo()
        {
            Console.WriteLine($"NIM     : {NIM}");
            Console.WriteLine($"Nama    : {Nama}");
            Console.WriteLine($"Jurusan : {Jurusan}");
            Console.WriteLine(new string('-', 40));
        }
    }

    class MahasiswaManager
    {
        private List<Mahasiswa> daftarMahasiswa = new List<Mahasiswa>();

        public void TambahMahasiswa()
        {
            Console.Clear();
            Console.WriteLine("=== Tambah Mahasiswa Baru ===");

            Console.Write("Masukkan NIM     : ");
            string nim = Console.ReadLine()?.Trim();



            if (daftarMahasiswa.Any(m => m.NIM == nim))
            {
                Console.WriteLine("NIM tersebut sudah terdaftar. Gunakan NIM yang lain ya.");
                return;
            }

            Console.Write("Masukkan Nama    : ");
            string nama = Console.ReadLine()?.Trim();
            Console.Write("Masukkan Jurusan : ");
            string jurusan = Console.ReadLine()?.Trim();

            daftarMahasiswa.Add(new Mahasiswa(nim, nama, jurusan));
            Console.WriteLine("\nMahasiswa berhasil ditambahkan!");
        }

        public void LihatMahasiswa()
        {
            Console.Clear();
            Console.WriteLine("=== Daftar Mahasiswa ===");

            if (daftarMahasiswa.Count == 0)
            {
                Console.WriteLine("Data masih kosong mas bro. tambahin dulu mahasiswanya.");
                return;
            }

            foreach (var mhs in daftarMahasiswa)
            {
                mhs.TampilkanInfo();
            }
        }



        class Program
        {
            static void Main()
            {
                MahasiswaManager manager = new MahasiswaManager();
                int pilihan;
                do
                {
                    Console.WriteLine("\n=== Menu Utama ===");
                    Console.WriteLine("1. Tambah Mahasiswa");
                    Console.WriteLine("2. Lihat Mahasiswa");
                    Console.WriteLine("3. Keluar");
                    Console.Write("Pilih menu (1-5): ");

                    if (!int.TryParse(Console.ReadLine(), out pilihan))
                    {
                        Console.WriteLine("Input tidak valid. Harap masukkan angka antara 1 sampai 5.");
                        continue;
                    }

                    switch (pilihan)
                    {
                        case 1:
                            manager.TambahMahasiswa();
                            break;
                        case 2:
                            manager.LihatMahasiswa();
                            break;
                        case 3:
                            Console.WriteLine("\nTerima kasih telah menggunakan Aplikasi PickMM. Sampai jumpa!");
                            break;
                        default:
                            Console.WriteLine("Menu tidak tersedia. Silakan coba lagi.");
                            break;
                    }

                    if (pilihan != 5)
                    {
                        Console.WriteLine("\nTekan ENTER untuk kembali ke menu...");
                        Console.ReadLine();
                        Console.Clear();
                    }

                } while (pilihan != 3);
            }
        }
    }
}



