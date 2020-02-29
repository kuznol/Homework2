using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework2
{
    class Program
    {
        static void Main(string[] args)
        {

            Worker worker = (new FixedSalary(1500),
                new FixedSalary(1700), new HourlyWage(100),
                new HourlyWage(200), new HourlyWage(150));

            Console.WriteLine("Array not sorted");
            
            {
                Console.Write("{0}, ", worker.WageRate);
            }
            Console.WriteLine();
           

        }
    }



    public abstract class Worker
        {

        public double WageRate { get; set; }

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            Worker otherWorker = obj as Worker;
            if (otherWorker != null)
                return WageRate.CompareTo(otherWorker.WageRate);
            else
                throw new ArgumentException("Object is not a Worker");
        }

        public abstract double Salary();

        public static void Sort(object[] workers)
        {
            Array.Sort(workers);
        }


        public class FixedSalary : Worker
        {

            public FixedSalary(double wagerate)
            {
                WageRate = wagerate;
            }

                public override double Salary()
            {
                // среднемесячная заработная плата = 20.8 * 8 * почасовую ставку
                return WageRate * 20.8 * 8;
            }
        }


        public class HourlyWage : Worker
        {
            public HourlyWage(double wagerate)
            {
                WageRate = wagerate;

            }
            public override double Salary()
            {
                // среднемесячная заработная плата = фиксированной месячной оплате
                return WageRate;
            }


        }


    }
}

}