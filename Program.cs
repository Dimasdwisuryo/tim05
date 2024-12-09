// # Kelas:IS-07-04 //
// # Kelompok:5 //
// # Anggota Kelompok: //
// #1. Azizah Ftria Wibisono (102062400142) //
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
        public string? Judul { get; set; }
        public string? Durasi { get; set; }
        public string? Genre { get; set; }
        public double Harga { get; set; }
    }

    class Program
    {
        static List<Film> daftarFilm = new List<Film>();
        static int idCounter = 1;

        static void Main(string[] args)
        {
            if (Login())
            {
                Console.WriteLine("Selamat datang di kasir bioskop");

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
                        LihatFilm();
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
                        Console.WriteLine("Pilihan tidak ada, coba lagi.");
                        break;
                }
            }
        }
        else
        {
            Console.WriteLine("Username atau password salah.");
        }
    }

    static bool Login()
    {
        Console.WriteLine("=== Login Kasir Bioskop ===");
        Console.Write("Masukkan username: ");
        string? username = Console.ReadLine();
        Console.Write("Masukkan password: ");
        string? password = Console.ReadLine();

        if (username == "admin" && password == "admin")
        {
            Console.WriteLine("Login berhasil!");
            return true;
        }
        else
        {
            Console.WriteLine("Login gagal.");
            return false;
        }
    }

        static void TambahFilm()
        {
            Console.Write("Masukkan Judul Film: ");
            string? judul = Console.ReadLine();

            Console.Write("Masukkan Durasi Film: ");
            string? durasi = Console.ReadLine();

            Console.Write("Masukkan Genre Film: ");
            string? genre = Console.ReadLine();

            Console.Write("Masukkan Harga Tiket: ");
            if (double.TryParse(Console.ReadLine(), out double harga))
            {
                Film filmBaru = new Film
                {
                    Id = idCounter++,
                    Judul = judul,
                    Durasi = durasi,
                    Genre = genre,
                    Harga = harga
                };
                daftarFilm.Add(filmBaru);
                Console.WriteLine("Film berhasil ditambahkan.");
            }
            else
            {
                Console.WriteLine("Harga tidak valid. Film tidak ditambahkan.");
            }
        }

        static void LihatFilm()
        {
            Console.WriteLine("=== Daftar Film ===");
            if (daftarFilm.Count == 0)
            {
                Console.WriteLine("Belum ada film yang terdaftar.");
                return;
            }

            foreach (var film in daftarFilm)
            {
                Console.WriteLine($"ID: {film.Id}, Judul: {film.Judul}, Genre: {film.Genre}, Harga: Rp{film.Harga}");
            }
        }
        

        static void UpdateFilm()
        {
            Console.Write("Masukkan ID Film yang ingin diubah: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var film = daftarFilm.Find(f => f.Id == id);
                if (film != null)
                {
                    Console.Write("Masukkan Judul Film Baru: ");
                    film.Judul = Console.ReadLine();

                    Console.Write("Masukkan Durasi Film Baru: ");
                    film.Durasi = Console.ReadLine();

                    Console.Write("Masukkan Genre Film Baru: ");
                    film.Genre = Console.ReadLine();

                    Console.Write("Masukkan Harga Tiket Baru: ");
                    if (double.TryParse(Console.ReadLine(), out double hargaBaru))
                    {
                        film.Harga = hargaBaru;
                        Console.WriteLine("Data film berhasil diubah.");
                    }
                    else
                    {
                        Console.WriteLine("Harga tidak valid. Data tidak diubah.");
                    }
                }
                else
                {
                    Console.WriteLine("Film dengan ID tersebut tidak ditemukan.");
                }
            }
            else
            {
                Console.WriteLine("ID tidak valid.");
            }
        }

        static void HapusFilm()
        {
            Console.Write("Masukkan ID Film yang ingin dihapus: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var film = daftarFilm.Find(f => f.Id == id);
                if (film != null)
                {
                    daftarFilm.Remove(film);
                    Console.WriteLine("Film berhasil dihapus.");
                }
                else
                {
                    Console.WriteLine("Film dengan ID tersebut tidak ditemukan.");
                }
            }
            else
            {
                Console.WriteLine("ID tidak valid.");
            }
        }

        static void CariFilm()
        {
            Console.Write("Masukkan Judul Film yang ingin dicari: ");
            string? judul = Console.ReadLine();

            var film = daftarFilm.Find(f => f.Judul == judul);
            if (film != null)
            {
                Console.WriteLine($"ID: {film.Id}, Judul: {film.Judul}, Genre: {film.Genre}, Harga: Rp{film.Harga}");
            }
            else
            {
                Console.WriteLine("Film tidak ditemukan.");
            }
        }

        static void FilterFilm()
        {
            Console.Write("Masukkan Durasi Film yang ingin difilter: ");
    }
}
}
