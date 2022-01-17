using System;
using System.Collections.Generic;
using System.Text;

namespace oopArya
{
    public class Murid : Pengajar
    {
        public double NlTgs { get; set; }
        public double NlUTS { get; set; }
        public double NlUAS { get; set; }
        public double NlAkhr { get; set; }

        public override void Introduction()
        {
            base.Introduction();
            Console.WriteLine($"Nilai Akhir:{NlAkhr}");
            Console.WriteLine("======================================");

        }
    }
}
