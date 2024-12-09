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

        static void TambahFilm()
        {
            Console.Write("Masukkan Judul Film: ");
            string? judul = Console.ReadLine();

            Console.Write("Masukkan Genre Film: ");
            string? genre = Console.ReadLine();

            Console.Write("Masukkan Harga Tiket: ");
            if (double.TryParse(Console.ReadLine(), out double harga))
            {
                Film filmBaru = new Film
                {
                    Id = idCounter++,
                    Judul = judul,
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

        static void TampilkanSemuaFilm()
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
