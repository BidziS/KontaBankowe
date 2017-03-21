using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KontaBankowe;
using NUnit.Framework;

namespace KontraBankowe.Tests
{
    [TestFixture]
    class KontoBankoweTests
    {
        [Test]
        public void Wplac_WplacKwote_Calculated()
        {
            var konto = new KontoBankowe(100);
            int saldo = konto.Wplac(20);
            Assert.AreEqual(120, saldo);
        }

        [Test]
        public void Wyplac_WyplacKwoteMniejszaNizSaldo_Calculated()
        {
            var konto = new KontoBankowe(100);
            int saldo = konto.Wyplac(20);
            Assert.AreEqual(80, saldo);
        }

        [Test]
        public void Wyplac_WyplacKwoteWiekszaNizSaldo_Calculated()
        {
            var konto = new KontoBankowe(100);
            Assert.Throws<TooMuchMoneyException>(() => konto.Wyplac(120));
        }
        [Test]
        public void SprawdzSaldo_SprawdzanieSalda_Wrote()
        {
            var konto = new KontoBankowe(100);
            var saldo = konto.SprawdzSaldo();
            Assert.AreEqual(100,saldo);
        }
        [Test]
        public void TransferPieniedzy_WyplacKwoteMniejszaNizSaldoStronaNadawcy_Calculated()
        {
            var konto = new KontoBankowe(100);
            var odbiorca = new KontoBankowe(20);            

            konto.TransferPieniedzy(80, odbiorca);

            int saldo = konto.SprawdzSaldo();

            Assert.AreEqual(20, saldo);
        }
        [Test]
        public void TransferPieniedzy_WyplacKwoteMniejszaNizSaldoStronaOdbiorcy_Calculated()
        {
            var konto = new KontoBankowe(100);
            var odbiorca = new KontoBankowe(20);

            konto.TransferPieniedzy(80, odbiorca);

            int saldo = odbiorca.SprawdzSaldo();

            Assert.AreEqual(100, saldo);
        }
        [Test]
        public void TransferPieniedzy_WyplacKwoteWiekszaNizSaldo_Calculated()
        {
            var konto = new KontoBankowe(100);
            var odbiorca = new KontoBankowe(20);
            
            Assert.Throws<TooMuchMoneyException>(() => konto.TransferPieniedzy(110, odbiorca));
        }

    }
}
