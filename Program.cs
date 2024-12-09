// # Kelas:IS-07-04 //
// # Kelompok:5 //
// # Anggota Kelompok: //
// #1. Azizah Fitria Wibisono (102062400142) //
// #2. Dimas Arya Irwansyah (102062400113) //
// #3. Dimas Dwi Suryo Aji (102062400139) //
// #4. Gita Naisya Wardani (102062400034)//

using System;
using System.Collections.Generic;

namespace BioskopManagement
{
    class Film
    {
        public int Id { get; set; }
        public required string Judul { get; set; }
        public required string Genre { get; set; }
        public double Harga { get; set; }
    }

    class Program
    {
        static List<Film> daftarFilm = new List<Film>();
        static int idCounter = 1;

        static void Main(string[] args)
        {
            // Login
            if (Login())
            {
                Console.WriteLine("Selamat datang di sistem kasir bioskop!");

                while (true)
                {
                    Console.WriteLine("=== Aplikasi Manajemen Bioskop ===");
                    Console.WriteLine("1. Tambah Film");
                    Console.WriteLine("2. Tampilkan Semua Film");
                    Console.WriteLine("3. Update Film");
                    Console.WriteLine("4. Hapus Film");
                    Console.WriteLine("5. Cari Film");
                    Console.WriteLine("6. Filter Film Berdasarkan Durasi");
                    Console.WriteLine("7. Keluar");
                    Console.Write("Pilih menu: ");

                    string? pilihan = Console.ReadLine();

                    switch (pilihan)
                    {
                        case "1":
                            TambahFilm();
                            break;
                        case "2":
                            TampilkanSemuaFilm();
                            break;
                        case "3":
                            UpdateFilm();
                            break;
                        case "4":
                            HapusFilm();
                            break;
                        case "5":
                            CariFilm();
                            break;
                        case "6":
                            FilterFilm();
                            break;
                        case "7":
                            Console.WriteLine("Terima kasih telah menggunakan aplikasi ini!");
                            return;
                        default:
                            Console.WriteLine("Pilihan tidak valid, coba lagi.");
                            break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Login gagal. Silakan coba lagi.");
            }
        }

        // Login
        static bool Login()
        {
            Console.WriteLine("=== Login Kasir Bioskop ===");
            Console.Write("Masukkan username: ");
            string? username = Console.ReadLine();
            Console.Write("Masukkan password: ");
            string? password = Console.ReadLine();

            if (username == "dimas" && password == "dimasarya")
            {
                Console.WriteLine("Login berhasil!\n");
                return true; // Login berhasil
            }
            else
            {
                Console.WriteLine("Username atau password salah.\n");
                return false; // Login gagal
            }
        }

        // Fungsi lain (TambahFilm, TampilkanSemuaFilm, dll) tetap sama.
        static void TambahFilm() 
        static void TampilkanSemuaFilm() 
        static void UpdateFilm() 
        static void HapusFilm() 
        static void CariFilm() 
        static void FilterFilm()
}
