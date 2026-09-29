using System;
using System.Collections.Generic;
using System.Text;

namespace Program
{
    public class Jarmu
    {
        
        
        public string Rendszam
        {
            get => rendszam;
            set => rendszam = string.IsNullOrWhiteSpace(value) ? "ISMERETLEN" : value;
        }

     
        public int kor
        {
            get => kor;
            set => kor = Math.Max(0, value);
        }
 
        public int KilometerOra
        {
            get => kilometerOra;
            set => kilometerOra = value < 0 ? 0 : value;
        }


        public int UzemanyagSzint
        {
            get => uzemanyagSzint;
            set
            {
                if (value < 0) uzemanyagSzint = 0;
                else if (value > 100) uzemanyagSzint = 100;
                else uzemanyagSzint = value;
            }
        }

        public bool SzervizSzukseges => KilometerOra >= 200000;

        public Jarmu(string rendszam, int kor, int kilometerOra, int uzemanyagSzint)
        {
            Rendszam = rendszam;
            Kor = kor;
            KilometerOra = kilometerOra;
            UzemanyagSzint = uzemanyagSzint;
        }

        public virtual void InformaciotAd()
        {
            System.Console.WriteLine($"{Rendszam} - {Kor} éves jármű, {KilometerOra} km-rel.");
        }

        public virtual void Szervizel(int dij)
        {
            if (dij > 100000)
            {
                KilometerOra = System.Math.Max(0, KilometerOra - 10000);
            }
            UzemanyagSzint = System.Math.Max(0, UzemanyagSzint - 10);
            System.Console.WriteLine("A jármű szervizelése megtörtént.");
        }


    }
    }

