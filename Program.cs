// # Kelas:IS-07-04 //
// # Kelompok:5 //
// # Anggota Kelompok: //
// #1. Azizah Ftria Wibisono (102062400142) //
// #2. Dimas Arya Irwansyah (102062400113) //
// #3. Dimas Dwi Suryo Aji (102062400139) //
// #4. Gita Naisya Wardani (102062400034)//

using System;
using System.Collections.Generic;

namespace AplikasiManajemenBioskop_0405
{
    class Film
    {
        public int Id { get; set; }
        public string? Judul { get; set; }
        public string? Durasi { get; set; }
        public string? Genre { get; set; }
        public double Harga { get; set; }
    }

    class Pemesanan
    {
        public int Id { get; set; }
        public string? NamaPembeli{ get; set; }
        public string? JudulFilm { get; set; }
        public string? JamTayang { get; set; }
        public string? Kursi { get; set; }
        public string? Kategori { get; set; }
        public double HargaTiket { get; set; }
        public double Diskon { get; set; }
        public double TotalBayar { get; set; }
    }

    class Program
    {
        static List<Film> daftarFilm = new List<Film>();
        static List<Pemesanan> daftarPemesanan = new List<Pemesanan>();
        static int idCounter = 1;
        static int idPemesananCounter = 1;

        static void Main(string[] args)
        {
            if (Login_0405())
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
                        TambahFilm_0405();
                        break;
                    case "2":
                        LihatFilm_0405();
                        break;
                    case "3":
                        UpdateFilm_0405();
                        break;
                    case "4":
                        HapusFilm_0405();
                        break;
                    case "5":
                        CariFilm_0405();
                        break;
                    case "6":
                        FilterFilm_0405();
                        break;
                    case "7":
                        PemesananTiket_0405();
                        break;
                    case "8":
                        TampilkanInvoice_0405();
                        break;
                    case "9":
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
            Console.WriteLine("Username atau password salah.");
        }
    }

    // halaman login
    static bool Login_0405()
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

    // Tambah Film
        static void TambahFilm_0405()
        {
            Console.WriteLine("=== Tambah Film ===");
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

        // Lihat Daftar Film
        static void LihatFilm_0405()
        {
            Console.WriteLine("=== Daftar Film ===");
            if (daftarFilm.Count == 0)
            {
                Console.WriteLine("Belum ada film yang terdaftar.");
                return;
            }

            foreach (var film in daftarFilm)
            {
                Console.WriteLine($"ID: {film.Id}, Judul: {film.Judul}, Genre: {film.Genre}, Harga: Rp{film.Harga:F2}");
            }
        }
        
        // Update Film
        static void UpdateFilm_0405()
        {
            Console.WriteLine("=== Update Film ===");
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

        // Hapus Film
        static void HapusFilm_0405()
        {
            Console.WriteLine("=== Hapus Film ===");
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

        // Cari Film
        static void CariFilm_0405()
        {
            Console.WriteLine("=== Cari Film ===");
            Console.Write("Masukkan Judul Film yang ingin dicari: ");
            string? judul = Console.ReadLine();

            var film = daftarFilm.Find(f => f.Judul.ToLower().Contains(judul.ToLower()));
            if (film != null)
            {
                Console.WriteLine($"ID: {film.Id}, Judul: {film.Judul}, Genre: {film.Genre}, Harga: Rp{film.Harga:F2}");
            }
            else
            {
                Console.WriteLine("Film tidak ditemukan.");
            }
        }

        static void FilterFilm()
        {
            Console.Write("Masukkan Harga Tiket Minimal: ");
            if (double.TryParse(Console.ReadLine(), out double hargaMin))
            {
                Console.Write("Masukkan Harga Tiket Maksimal: ");
                if (double.TryParse(Console.ReadLine(), out double hargaMax))
                {
                    var film = daftarFilm.FindAll(f => f.Harga >= hargaMin && f.Harga <= hargaMax);
                    if (film.Count > 0)
                    {
                        Console.WriteLine("=== Daftar Film ===");
                        foreach (var f in film)
                        {
                            Console.WriteLine($"ID: {f.Id}, Judul: {f.Judul}, Genre: {f.Genre}, Harga: Rp{f.Harga:F2}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Film tidak ditemukan.");
                    }
                }
                else
                {
                    Console.WriteLine("Harga tidak valid.");
                }
            }
            else
            {
                Console.WriteLine("Harga tidak valid.");
            }
        }
    }
}
