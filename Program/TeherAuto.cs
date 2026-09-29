using System;
using System.Collections.Generic;
using System.Text;

namespace Program
{
    public class TeherAuto : Jarmu
    {
        private int rakomany;
        public int Rakomany
        {
            get => rakomany;
            set
            {
                if (value < 0) rakomany = 0;
                else if (value > 20) rakomany = 20;
                else rakomany = value;
            }
        }

        public TeherAuto(string rendszam, int kor, int kilometerOra, int uzemanyagSzint, int rakomany)
            : base(rendszam, kor, kilometerOra, uzemanyagSzint)
        {
            Rakomany = rakomany;
        }

        public override void InformaciotAd()
        {
            System.Console.WriteLine($"{Rendszam} - {Kor} éves teherautó, {KilometerOra} km-rel, rakomány: {Rakomany} tonna");
        }

        public override void Szervizel(int dij)
        {
            Rakomany = 0;
            base.Szervizel(dij);
        }
    }
}
