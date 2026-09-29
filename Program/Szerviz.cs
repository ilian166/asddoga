using System;
using System.Collections.Generic;
using System.Text;

namespace Program
{
    public class Szerviz
    {
        private List<Jarmu> jarmuvek = new List<Jarmu>();

        public void JarmuFelvetele(Jarmu jarmu)
        {
            jarmuvek.Add(jarmu);
            System.Console.WriteLine("A jármű megérkezett a szervizbe.");
        }

        public void InformaciokListazasa()
        {
            foreach (var jarmu in jarmuvek)
            {
                jarmu.InformaciotAd();
            }
        }

        public void CsoportosSzerviz(int dij)
        {
            foreach (var jarmu in jarmuvek)
            {
                if (jarmu.SzervizSzukseges)
                {
                    jarmu.Szervizel(dij);
                }
                else
                {
                    System.Console.WriteLine($"A {jarmu.Rendszam} szervizelése jelenleg nem szükséges.");
                }
            }
        }
    }
}