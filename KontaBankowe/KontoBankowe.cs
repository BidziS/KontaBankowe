using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KontaBankowe
{
    public class KontoBankowe
    {
        private int saldo;

        public KontoBankowe(int saldo)
        {
            this.saldo = saldo;
        }

        public int Wplac(int kwota)
        {
            saldo += kwota;

            return saldo;
        }

        public int Wyplac(int kwota)
        {
            if (kwota > saldo)
            {
                throw new TooMuchMoneyException();
            }
            saldo -= kwota;

            return saldo;
        }

        public int SprawdzSaldo()
        {
            return saldo;
        }

        public void TransferPieniedzy(int kwota, KontoBankowe odbiorca)
        {
            if (kwota > saldo)
            {
                throw new TooMuchMoneyException();
            }
            Wyplac(kwota);
            odbiorca.Wplac(kwota);
            
        }
    }
}
