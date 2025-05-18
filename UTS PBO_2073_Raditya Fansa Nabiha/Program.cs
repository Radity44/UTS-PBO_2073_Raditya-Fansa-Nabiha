using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace UTS_PBO_2073_Raditya_Fansa_Nabiha
{
    class Program
    {
        static void Main(string[] args)
        {
            Perpustakaan perpustakaan = new Perpustakaan();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("--- Sistem Manajemen Perpustakaan Mini ---");
                Console.WriteLine("1. Tambah Buku");
                Console.WriteLine("2. Ubah Data Buku");
                Console.WriteLine("3. Lihat Semua Buku");
                Console.WriteLine("4. Pinjam Buku");
                Console.WriteLine("5. Kembalikan Buku");
                Console.WriteLine("6. Lihat Buku yang Dipinjam");
                Console.WriteLine("7. Keluar");
                Console.Write("Pilih: ");

                string input = Console.ReadLine();
                Console.Clear();

                switch (input)
                {
                    case "1":
                        Console.Write("Jenis Buku (1. Fiksi, 2. Non-Fiksi, 3. Majalah): ");
                        int jenis = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Judul: ");
                        string judul = Console.ReadLine();
                        Console.Write("Penulis: ");
                        string penulis = Console.ReadLine();
                        Console.Write("Tahun Terbit: ");
                        string tahun = Console.ReadLine();

                        if (jenis == 1)
                            perpustakaan.TambahBuku(new BukuFiksi(judul, penulis, tahun));
                        else if (jenis == 2)
                            perpustakaan.TambahBuku(new BukuNonFiksi(judul, penulis, tahun));
                        else if (jenis == 3)
                            perpustakaan.TambahBuku(new Majalah(judul, penulis, tahun));
                        else
                            Console.WriteLine("Jenis buku tidak valid.");
                        break;

                    case "2":
                        perpustakaan.LihatDaftarBuku();
                        Console.Write("Pilih nomor buku yang ingin diubah: ");
                        int ubahIndex = Convert.ToInt32(Console.ReadLine()) - 1;

                        Console.Write("Judul baru: ");
                        string judulBaru = Console.ReadLine();
                        Console.Write("Penulis baru: ");
                        string penulisBaru = Console.ReadLine();
                        Console.Write("Tahun Terbit baru: ");
                        string tahunBaru = Console.ReadLine();

                        perpustakaan.UbahBuku(ubahIndex, judulBaru, penulisBaru, tahunBaru);
                        break;

                    case "3":
                        perpustakaan.LihatDaftarBuku();
                        break;

                    case "4":
                        perpustakaan.LihatDaftarBuku();
                        Console.Write("Pilih nomor buku yang ingin dipinjam: ");
                        int pinjamIndex = Convert.ToInt32(Console.ReadLine()) - 1;
                        perpustakaan.PinjamBuku(pinjamIndex);
                        break;

                    case "5":
                        perpustakaan.LihatBukuDipinjam();
                        Console.Write("Pilih nomor buku yang ingin dikembalikan: ");
                        int kembaliIndex = Convert.ToInt32(Console.ReadLine()) - 1;
                        perpustakaan.KembalikanBuku(kembaliIndex);
                        break;

                    case "6":
                        perpustakaan.LihatBukuDipinjam();
                        break;

                    case "7":
                        Console.WriteLine("Terima kasih telah menggunakan sistem perpustakaan.");
                        return;

                    default:
                        Console.WriteLine("Pilihan tidak valid.");
                        break;
                }

                Console.WriteLine("\nTekan ENTER untuk kembali ke menu...");
                Console.ReadLine();
            }
        }
    }
    public interface IBuku
    {
        void TampilkanInfo();
    }

    abstract class Buku : IBuku
    {
        public string Judul { get; set; }
        public string Penulis { get; set; }
        public string TahunTerbit { get; set; }
        public bool Dipinjam { get; set; }

        public Buku(string judul, string penulis, string tahunTerbit)
        {
            Judul = judul;
            Penulis = penulis;
            TahunTerbit = tahunTerbit;
            Dipinjam = false;
        }   

        public abstract void TampilkanInfo();


        public void Pinjam()
        {
            Dipinjam = true;
        }

        public void Kembalikan()
        {
            Dipinjam = false;
        }

        public void EditData(string judul, string penulis, string tahunTerbit)
        {
            Judul = judul;
            Penulis = penulis;
            TahunTerbit = tahunTerbit;
        }
    }

    class BukuFiksi : Buku
    {
        public BukuFiksi(string judul, string penulis, string tahunTerbit)
           : base(judul, penulis, tahunTerbit) { }

        public override void TampilkanInfo()
        {
            Console.WriteLine($"[Fiksi] Judul: {Judul}, Penulis: {Penulis}, Tahun Terbit: {TahunTerbit}");
        }
    }

    class BukuNonFiksi : Buku
    {
        public BukuNonFiksi(string judul, string penulis, string tahunTerbit)
            : base(judul, penulis, tahunTerbit) { }

        public override void TampilkanInfo()
        {
            Console.WriteLine($"[Non-Fiksi] Judul: {Judul}, Penulis: {Penulis}, Tahun Terbit: {TahunTerbit}");
        }
    }

    class Majalah : Buku
    {
        public Majalah(string judul, string penulis, string tahunTerbit)
            : base(judul, penulis, tahunTerbit) { }

        public override void TampilkanInfo()
        {
            Console.WriteLine($"[Majalah] Judul: {Judul}, Penulis: {Penulis}, Tahun Terbit: {TahunTerbit}");
        }
    }
        
    class Perpustakaan
    {
        private List<Buku> daftarBuku = new List<Buku>();
        private List<Buku> bukuDipinjam = new List<Buku>();

        public void TambahBuku(Buku buku)
        {
            daftarBuku.Add(buku);
            Console.WriteLine($"Buku '{buku.Judul}' berhasil ditambahkan.");
        }

        public void UbahBuku(int index, string judul, string penulis, string tahunTerbit)
        {
            if (index >= 0 && index < daftarBuku.Count)
            {   
                daftarBuku[index].EditData(judul, penulis, tahunTerbit);
                Console.WriteLine("Data buku berhasil diubah.");
            }
            else
            {
                Console.WriteLine("Index tidak valid.");
            }
        }

        public void LihatDaftarBuku()
        {
            if (daftarBuku.Count == 0)
            {
                Console.WriteLine("Belum ada buku yang ditambahkan.");
                return;
            }

            Console.WriteLine("\n--- Daftar Buku ---");
            for (int i = 0; i < daftarBuku.Count; i++)
            {
                Console.Write($"{i + 1}. ");
                daftarBuku[i].TampilkanInfo();
            }
        }

            public void PinjamBuku(int index)
            {
                if (index < 0 || index >= daftarBuku.Count)
                {
                    Console.WriteLine("Index tidak valid.");
                    return;
                }

                if (bukuDipinjam.Count >= 3)
                {
                    Console.WriteLine("Batas peminjaman tercapai (maks 3 buku).");
                    return;
                }

                var buku = daftarBuku[index];
                if (buku.Dipinjam)
                {
                    Console.WriteLine("Buku sedang dipinjam.");
                }
                else
                {
                    buku.Pinjam();
                    bukuDipinjam.Add(buku); 
                    Console.WriteLine($"Buku '{buku.Judul}' berhasil dipinjam.");
                }
            }

        public void KembalikanBuku(int index)
        {
            if (index < 0 || index >= bukuDipinjam.Count)
            {
                Console.WriteLine("Index tidak valid.");
                return;
            }

            var buku = bukuDipinjam[index];
            buku.Kembalikan();
            bukuDipinjam.RemoveAt(index);
            Console.WriteLine($"Buku '{buku.Judul}' berhasil dikembalikan.");
        }

        public void LihatBukuDipinjam()
        {
            Console.WriteLine("\n--- Daftar Buku Dipinjam ---");
            if (bukuDipinjam.Count == 0)
            {
                Console.WriteLine("Tidak ada buku yang sedang dipinjam.");
                return;
            }

            
            for (int i = 0; i < bukuDipinjam.Count; i++)
            {
                Console.Write($"{i + 1}. ");
                bukuDipinjam[i].TampilkanInfo();
            }
        }
    }
}
