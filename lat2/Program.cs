using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lat2
{
    public class Travel
    {
        public string Asal { get; set; }
        public string Tujuan { get; set; }
        public double Qity { get; set; }
        public double Total { get; set; }
        public double HTiket { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {

            string asal, tujuan;
            double qity, totalTiket = 0;
            double harga, total = 0;
            int pilih = 0;
            
            //array Multidimensi untuk nampung harga tiket
            double[,] kota = new double[5, 5]
           {{0,45000,50000,35000,40000},
             {35000,0,15000,25000,15000},
             {40000,10000,0,35000, 35000},
             {25000,20000,45000,0,20000},
             {30000,15000,25000,25000,0}
           };

            //array untuk menampung kota asal dan tujuan
            string[] baris = { "Bandung", "Jakarta", "Banten", "Purwakarta", "Bekasi" };
            string[] kolom = { "Bandung", "Jakarta", "Banten", "Purwakarta", "Bekasi" };

            //list untuk menampung hasil input kota asal, tujuan serta harga di console
            List<Travel> travel = new List<Travel>{};

            //menu() running awal
            Menu();

            //void berisi menu
            void Menu()
            {
                Console.WriteLine("---------------------------------");
                Console.WriteLine("---------Travelkoka.com----------");
                Console.WriteLine("---------------------------------");
                Console.WriteLine();
                Console.WriteLine("---------------------------------");
                Console.WriteLine("Pilih Menu Dengan Menginput Angka");
                Console.WriteLine("---------------------------------");
                Console.WriteLine();
                Console.WriteLine("1) Daftar Seluruh Harga Tiket");
                Console.WriteLine("2) Daftar Harga Pertiket");
                Console.WriteLine("3) Transaksi Tiket");
                Console.WriteLine("4) Exit Command");
                Console.WriteLine("---------------------------------");
                Console.WriteLine();
                Console.Write("Pilih Menu: ");
                pilih = int.Parse(Console.ReadLine());

                if (pilih == 1)
                {
                    Console.Clear();
                    Menu1();
                }

                if (pilih == 2)
                {
                    Console.Clear();
                    Menu2();
                }

                if (pilih == 3)
                {
                    Console.Clear();
                    Menu3();
                }

                if (pilih == 4)
                {
                    Environment.Exit(0);
                }
            }

            //Menu1() untuk mengcek harga tiket
            void Menu1()
            {
                Perhitungan p = new Perhitungan(); //pemanggilan function uppercase di perhitungan

                //loop untuk menampilkan array harga tiket
                for (int i = 0; i < baris.Length; i++)
                {
                    for (int j = 0; j < kolom.Length; j++)
                    {
                        Console.WriteLine("Tiket " + baris[i] + " --> " + kolom[j] + " Harga " + kota[i, j]);
                    }
                }

                Console.Write("Kembali Ke menu utama (Y) ? ");
                string menu = Console.ReadLine();
                if (p.UppercaseFirst(menu) == "Y")
                {
                    Console.Clear();
                    Menu();
                }
            }

            void Menu2()
            {
                Console.WriteLine("------------------------------------------------");
                Console.WriteLine("Daftar Harga Tiket Peritem");
                Console.WriteLine("------------------------------------------------");
                Console.WriteLine();
                Boolean menu2 = true;
                Perhitungan p = new Perhitungan();


                while (menu2)
                {
                    try
                    {
                        Console.Write("Masukkan Kota Asal anda: ");
                        asal = Console.ReadLine();
                        Console.Write("Masukkan Kota Tujuan Anda : ");
                        tujuan = Console.ReadLine();
                        harga = kota[Array.IndexOf(baris, p.UppercaseFirst(asal)), Array.IndexOf(kolom, p.UppercaseFirst(tujuan))];
                        Console.WriteLine("Tiket Bus " + asal + " --> " + tujuan + " Harga = " + harga + " Rupiah");
                        Console.Write("Teruskan Pencarian Harga Tiket (Y/N) ? ");
                        String pilih1 = Console.ReadLine();
                        Console.WriteLine();

                        if (p.UppercaseFirst(pilih1) == "N")
                        {
                            menu2 = false;
                            Console.Clear();
                            Menu();
                        }
                    }

                    catch (Exception)
                    {
                        Console.WriteLine("Kata yg anda masukkan salah !!!");
                        Console.WriteLine();
                    }
                }
            }

            void Menu3()
            {
                Console.WriteLine("-------------------------------------");
                Console.WriteLine("Anda Masuk Ke layanan Pemesanan Tiket");
                Console.WriteLine("Masukkan Kota Asal Dan Tujuan Anda");
                Console.WriteLine("-------------------------------------");
                Console.WriteLine();
                Perhitungan p = new Perhitungan();
                Boolean loop = true;
                while (loop)
                {

                    try
                    {
                        
                        Console.Write("Asal : ");
                        asal = Console.ReadLine();
                        Console.Write("Tujuan : ");
                        tujuan = Console.ReadLine();
                        Console.Write("Qity : ");
                        qity = int.Parse(Console.ReadLine());
                        harga = p.Kali(qity, kota[Array.IndexOf(baris, asal), Array.IndexOf(kolom, tujuan)]);
                        travel.Add(new Travel { Asal = asal, Tujuan = tujuan, HTiket = kota[Array.IndexOf(baris, asal), Array.IndexOf(kolom, tujuan)], Qity = qity, Total = harga });
                        Console.Write("Lanjutkan Pemesanan (Y/N) ? ");
                        string jeda = Console.ReadLine();
                        Console.WriteLine();
                        if (p.UppercaseFirst(jeda) == "N")
                        {
                            loop = false;
                        }
                    }

                    catch (Exception)
                    {
                        Console.WriteLine("Anda Salah Memasukkan Kata Kunci !!!!");
                        Console.WriteLine();
                    }
                }

                Console.Clear();
                Console.WriteLine("*******************************************************************************");
                Console.WriteLine("*********************************Travelkoka.com********************************");
                Console.WriteLine("*******************************************************************************");
                Console.WriteLine();
                Console.WriteLine("----------------------------Print Resi Pembayaran------------------------------");
                Console.WriteLine();

                var output = from b in travel orderby b.Asal, b.Tujuan, b.Qity descending select new { b.Asal, b.Tujuan, b.HTiket, b.Qity, b.Total };
                foreach (var trav in output)
                    Console.WriteLine(trav);

                var output1 = from b in travel select b.Total;
                foreach (var tra in output1)
                    total = total + tra;

                var output2 = from b in travel select b.Qity;
                foreach (var tra in output2)
                    totalTiket = totalTiket + tra;

                Console.WriteLine("*******************************************************************************");
                Console.WriteLine("Total Tiket Yang Dibeli: " + totalTiket + " Tiket, Biaya Seluruh Tiket: " + total + " Rupiah");
                Console.WriteLine("*******************************************************************************");
            }
            Console.ReadKey();
        }
            
    }
}
