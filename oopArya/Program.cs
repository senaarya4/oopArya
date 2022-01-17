using System;
using System.Collections.Generic;

namespace oopArya
{
    public class Program
    {
        private static int jTugas;
        private static double kkm;
        private static string pengajar, matkul, kelas;
        private static List<string> namaMHS = new List<string>();
        private static List<double> nilaiMHS = new List<double>();

        static void Main(string[] args)
        {
            Menu();
        }

        private static void Menu()
        {
            Console.WriteLine("Program Penilaian Mata Kuliah");
            Console.WriteLine("======================================");
            Console.WriteLine("1. Isi Data Dosen");
            Console.WriteLine("2. Isi Nilai Mahasiswa");
            Console.WriteLine("3. Exit");
            Console.WriteLine("======================================");
            Console.Write("Masukkan Pilihan Anda ");
            InputMenu();
        }

        private static void InputMenu()
        {
            int pilihMenu = Convert.ToInt32(Console.ReadLine());

            switch (pilihMenu)
            {
                case 1:
                    Console.Clear();
                    InputDataPengajar();
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("Anda Harus Input Data Dosen Terlebih Dahulu!");
                    Console.WriteLine("======================================");
                    InputDataPengajar();
                    break;
                case 3:
                    Console.Clear();
                    break;
                default:
                    Console.WriteLine("Input Salah, Silahkan Ulangi");
                    InputMenu();
                    break;
            }
        }

        public static void InputDataPengajar()
        {

            Console.Write("Nama Dosen: ");
            pengajar = Console.ReadLine();
            Console.Write("Mata Kuliah: ");
            matkul = Console.ReadLine();
            Console.Write("Kelas: ");
            kelas = Console.ReadLine();

            try
            {
                Console.Write("KKM: ");
                kkm = Convert.ToDouble(Console.ReadLine());
                Console.Write("Jumlah Tugas: ");
                jTugas = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Format Salah, silahkan ulangi");
                InputDataPengajar();
            }
            Pengajar dosen = new Pengajar();
            dosen.Name = pengajar;
            dosen.Matkul = matkul;
            dosen.Kelas = kelas;
            dosen.Kkm = kkm;
            dosen.Tugas = jTugas;

            Console.WriteLine("======================================");
            Console.WriteLine("Berhasil Input Data Dosen!");
            Console.WriteLine("======================================");

            Console.WriteLine("Input Nilai Siswa? (Y/N)");
            string confInSis = Console.ReadLine().ToLower();

            switch (confInSis)
            {
                case "y":
                    Console.Clear();
                    dosen.Introduction();
                    dosen.Introduction2();
                    InputMurid();
                    break;

                case "n":
                    Console.Clear();
                    break;

                default:
                    Console.WriteLine("Input Salah, Ulangi");
                    break;
            }

        }

        public static void InputMurid()
        {
            double sumTugas = 0;

            double[] tTugas = new double[(int)jTugas];

            Console.Write("Nama Mahasiswa: ");
            string nMurid = Console.ReadLine();

            for (int i = 0; i<jTugas; i++)
            {
                Console.Write($"Nilai Tugas {i + 1}: ");
                double nTgs = Convert.ToDouble(Console.ReadLine());
                tTugas[i] = nTgs;
            }

            foreach (double item in tTugas)
            {
                sumTugas += item;
            }

            double ratTugas = sumTugas / jTugas;
                        
            Console.Write("Nilai UTS: ");
            double nUTS = Convert.ToDouble(Console.ReadLine());
            Console.Write("Nilai UAS: ");
            double nUAS = Convert.ToDouble(Console.ReadLine());

            double nAkh = (ratTugas*0.2)+(nUTS*0.3)+(nUAS*0.5);

            Murid siswa = new Murid();
            siswa.Name = nMurid;
            siswa.NlTgs = ratTugas;
            siswa.NlUTS = nUTS;
            siswa.NlUAS = nUAS;
            siswa.NlAkhr = nAkh;
            //isi list disini
            namaMHS.Add(siswa.Name);
            nilaiMHS.Add(siswa.NlAkhr);
            siswa.Introduction();
            Console.Write("Masukkan Nilai Siswa Lain? (Y/N) ");

            AskAgain();
            
        }

        private static void AskAgain()
        {
            string ulang = Console.ReadLine().ToLower();

            switch (ulang)
            {
                case "y":
                    Console.SetCursorPosition(0, Console.CursorTop - 1);
                    ClearCurrentConsoleLine();
                    InputMurid();
                    break;

                case "n":
                    showList();
                    break;

                default:
                    Console.WriteLine("Input Salah, Ulangi");
                    AskAgain();
                    break;
            }
        }

        private static void showList()
        {
            Console.Clear();
            //tampilkan list
            Console.WriteLine("======================================");
            foreach (var item in namaMHS)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine("");
            foreach (var item in nilaiMHS)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine("");
            Console.WriteLine("======================================");
            Console.WriteLine("1. Edit Data");
            Console.WriteLine("2. Hapus Data");
            Console.WriteLine("3. Selesai");
            Console.WriteLine("======================================");
            Console.Write("Pilih Perintah ");
            string perintah = Console.ReadLine();

            switch (perintah)
            {
                case "1":
                    Console.SetCursorPosition(0, Console.CursorTop - 1);
                    ClearCurrentConsoleLine();
                    EditRecord();
                    break;
                case "2":
                    Console.SetCursorPosition(0, Console.CursorTop - 1);
                    ClearCurrentConsoleLine();
                    HapusRecord();
                    break;
                case "3":
                    Console.Clear();
                    break;
                default:
                    Console.WriteLine("Input Salah, ulangi");
                    showList();
                    break;
            }
        }

        private static void EditRecord()
        {
            try
            {
                Console.Write("Pilih Record untuk Diedit: ");
                int edit = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("");
                Console.Write("Masukkan Nilai Baru: ");
                double edit2 = Convert.ToDouble(Console.ReadLine());
                nilaiMHS[edit - 1] = edit2;
            }
            catch (FormatException)
            {
                Console.WriteLine("Format Salah, Silahkan Input Ulang");
                EditRecord();
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Data Tidak Ditemukan, Silahkan Input Ulang");
                EditRecord();
            }

            showList();
        }

        private static void HapusRecord()
        {
            try
            {
                Console.Write("Pilih Record untuk Dihapus: ");
                int del = Convert.ToInt32(Console.ReadLine());
                namaMHS.RemoveAt(del - 1);
                nilaiMHS.RemoveAt(del - 1);
            }
            catch (FormatException)
            {
                Console.WriteLine("Format Salah, Silahkan Input Ulang");
                HapusRecord();
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Data Tidak Ditemukan, Silahkan Input Ulang");
                HapusRecord();
            }
            
            
            showList();
        }

        public static void ClearCurrentConsoleLine()
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);
        }
    }
}
