using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace KontaBankowe
{
    [Serializable()]
    public class TooMuchMoneyException : Exception
    {
        public TooMuchMoneyException()
        {
        }

        public TooMuchMoneyException(string message) : base(message)
        {
            Console.WriteLine();
        }

        public TooMuchMoneyException(string message, Exception innerException) : base(message, innerException)
        {
            Console.WriteLine();
        }

        protected TooMuchMoneyException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            Console.WriteLine("Wyjątek");
        }
    }
}
