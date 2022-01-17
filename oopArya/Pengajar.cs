using System;
using System.Collections.Generic;
using System.Text;

namespace oopArya
{
    public class Pengajar
    {
        public string Name { get; set; }
        public string Matkul { get; set; }
        public string Kelas { get; set; }
        public double Kkm { get; set; }
        public int Tugas { get; set; }

        public virtual void Introduction()
        {
            Console.WriteLine("======================================");
            Console.WriteLine($"Nama :{Name}");
        }
        public void Introduction2()
        {
            Console.WriteLine($"Mata Kuliah:{Matkul}");
            Console.WriteLine($"Kelas:{Kelas}");
            Console.WriteLine($"KKM:{Kkm}");
            Console.WriteLine($"Jumlah Tugas:{Tugas}");
            Console.WriteLine("======================================");
        }
    }
}
