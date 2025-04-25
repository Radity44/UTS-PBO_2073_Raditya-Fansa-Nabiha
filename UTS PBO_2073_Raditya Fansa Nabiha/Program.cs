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
            Console.WriteLine($"\n---- Management Perpustakaan Mini");
            Console.WriteLine($"1. Tambah Buku");
            Console.WriteLine($"2. Ubah Data Buku");
            Console.WriteLine($"3. Pinjam Buku");
            Console.WriteLine($"4. Kembalikan Buku");
            Console.WriteLine($"5. Tampilkan Semua Buku");
            Console.WriteLine($"6. Tampilkan Buku Yang di Pinjam");

            string pilihan = Console.ReadLine();


        }
    }

    interface IBuku
    {
        void Tampilkaninfo();
    }
    abstract class Buku : IBuku
    {
        public string id { get; set; }
        public string judul { get; set; }

        public string penulis { get; set; }
        public int tahun { get; set; }

        public virtual void TampilkanInfo()
        {
            Console.WriteLine($" ");
        }
    }

    class bukufiksi : Buku
    {
        public override void TampilkanInfo()
        {
            Console.WriteLine($"");
        }
    }
    class bukunonfiksi : Buku
    {
        public override void TampilkanInfo()
        {

        }
    }

    class majalah : Buku
    {
        public override void TampilkanInfo()
        {

        }
    }

    class Perpustakaan
    {
        static void Main(string[] args)
        {

        }

    }
}