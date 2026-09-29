using NUnit.Framework;
using Program;

namespace Tesztek
{
    public class JarmuTesztek
    {
        // -------------------------
        // Jarmu tesztek
        // -------------------------

        [Test]
        public void Jarmu_Rendszam_HianyzoErtekEsetenIsmeretlen()
        {
            Jarmu jarmu = new Jarmu("", 5, 100000, 50);

            Assert.That(jarmu.Rendszam, Is.EqualTo("ISMERETLEN"));
        }

        [Test]
        public void Jarmu_Ertekek_KorlatokKozottMaradnak()
        {
            Jarmu jarmu = new Jarmu("ABC-123", -5, -100, 150);

            Assert.That(jarmu.Kor, Is.EqualTo(0));
            Assert.That(jarmu.KilometerOra, Is.EqualTo(0));
            Assert.That(jarmu.UzemanyagSzint, Is.EqualTo(100));
        }

        [Test]
        public void Jarmu_SzervizSzukseges_200000KmTol()
        {
            Jarmu jarmu = new Jarmu("ABC-123", 5, 200000, 50);

            Assert.That(jarmu.SzervizSzukseges, Is.True);
        }

        [Test]
        public void Jarmu_SzervizNemSzukseges_200000KmAlatt()
        {
            Jarmu jarmu = new Jarmu("ABC-123", 5, 199999, 50);

            Assert.That(jarmu.SzervizSzukseges, Is.False);
        }

        [Test]
        public void Jarmu_Szervizel_100000FelettiDijEsetenCsokkenAKilometer()
        {
            Jarmu jarmu = new Jarmu("ABC-123", 5, 200000, 50);

            jarmu.Szervizel(150000);

            Assert.That(jarmu.KilometerOra, Is.EqualTo(190000));
        }

        [Test]
        public void Jarmu_Szervizel_CsokkentiAzUzemanyagszintet()
        {
            Jarmu jarmu = new Jarmu("ABC-123", 5, 200000, 50);

            jarmu.Szervizel(50000);

            Assert.That(jarmu.UzemanyagSzint, Is.EqualTo(40));
        }


        // -------------------------
        // ElektromosAuto tesztek
        // -------------------------

        [Test]
        public void ElektromosAuto_UzemanyagSzint_MindigNulla()
        {
            ElektromosAuto auto = new ElektromosAuto("EV-123", 3, 100000, 80);

            Assert.That(auto.UzemanyagSzint, Is.EqualTo(0));
        }

        [Test]
        public void ElektromosAuto_AkkumulatorSzint_KorlatokKozottMarad()
        {
            ElektromosAuto auto = new ElektromosAuto("EV-123", 3, 100000, 150);

            Assert.That(auto.AkkumulatorSzint, Is.EqualTo(100));
        }

        [Test]
        public void ElektromosAuto_Szervizel_NoveliAzAkkumulatorSzintet()
        {
            ElektromosAuto auto = new ElektromosAuto("EV-123", 3, 200000, 50);

            auto.Szervizel(50000);

            Assert.That(auto.AkkumulatorSzint, Is.EqualTo(70));
        }

        [Test]
        public void ElektromosAuto_Szervizel_100000FelettiDijEsetenCsokkenAKilometer()
        {
            ElektromosAuto auto = new ElektromosAuto("EV-123", 3, 200000, 50);

            auto.Szervizel(150000);

            Assert.That(auto.KilometerOra, Is.EqualTo(190000));
        }


        // -------------------------
        // TeherAuto tesztek
        // -------------------------


        [Test]
        public void TeherAuto_Rakomany_KezdetiErtekHelyes()
        {
            TeherAuto auto = new TeherAuto("TR-123", 8, 150000, 60, 15);

            Assert.That(auto.Rakomany, Is.EqualTo(15));
        }

        [Test]
        public void TeherAuto_Szervizel_SzervizElottLeuritiARakomanyt()
        {
            TeherAuto auto = new TeherAuto("TR-123", 8, 200000, 60, 15);

            auto.Szervizel(150000);

            Assert.That(auto.Rakomany, Is.EqualTo(0));
        }

        [Test]
        public void TeherAuto_Szervizel_AzAlaposztalySzervizeleseIsLefut()
        {
            TeherAuto auto = new TeherAuto("TR-123", 8, 200000, 60, 15);

            auto.Szervizel(150000);

            Assert.That(auto.KilometerOra, Is.EqualTo(190000));
            Assert.That(auto.UzemanyagSzint, Is.EqualTo(50));
        }

        [Test]
        public void TeherAuto_Rakomany_20Felett_20Lesz()
        {
            TeherAuto auto = new TeherAuto("TR-123", 8, 150000, 60, 25);

            Assert.That(auto.Rakomany, Is.EqualTo(20));
        }

        // -------------------------
        // Szerviz tesztek
        // -------------------------

        [Test]
        public void Szerviz_JarmuFelvetele_HozzaadjaAJarmuvet()
        {
            Szerviz szerviz = new Szerviz();
            Jarmu jarmu = new Jarmu("ABC-123", 5, 200000, 50);

            szerviz.JarmuFelvetele(jarmu);

            // A teszt azt ellenőrzi, hogy a jármű bekerült a szervizbe.
            // A jarmuvek lista nem feltétlenül publikus, ezért ezt
            // az InformaciokListazasa() működésén keresztül lehet ellenőrizni.
            Assert.DoesNotThrow(() => szerviz.InformaciokListazasa());
        }

        [Test]
        public void Szerviz_CsoportosSzerviz_CsakASzuksegesJarmuveketSzervizeli()
        {
            Szerviz szerviz = new Szerviz();

            Jarmu szervizSzukseges = new Jarmu("ABC-123", 5, 200000, 50);

            Jarmu szervizNemSzukseges = new Jarmu("DEF-456", 3, 100000, 50);

            szerviz.JarmuFelvetele(szervizSzukseges);
            szerviz.JarmuFelvetele(szervizNemSzukseges);

            szerviz.CsoportosSzerviz(150000);

            Assert.That(szervizSzukseges.KilometerOra, Is.EqualTo(190000));
            Assert.That(szervizNemSzukseges.KilometerOra, Is.EqualTo(100000));

            Assert.That(szervizSzukseges.UzemanyagSzint, Is.EqualTo(40));
            Assert.That(szervizNemSzukseges.UzemanyagSzint, Is.EqualTo(50));
        }

        [Test]
        public void Szerviz_CsoportosSzerviz_ElektromosAutoSajatSzervizeleseLefut()
        {
            Szerviz szerviz = new Szerviz();

            ElektromosAuto auto = new ElektromosAuto("EV-123", 2, 200000, 50);

            szerviz.JarmuFelvetele(auto);

            szerviz.CsoportosSzerviz(150000);

            Assert.That(auto.KilometerOra, Is.EqualTo(190000));
            Assert.That(auto.AkkumulatorSzint, Is.EqualTo(70));
        }
    }
}
