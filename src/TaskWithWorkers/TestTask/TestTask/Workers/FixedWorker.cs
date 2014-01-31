using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestTask.Workers
{
    public class FixedWorker : AbstractWorker
    {
        public FixedWorker(int id, string name, double rate) : base(id, name, rate) { }

        public override double GetSalary()
        {
            return rate;
        }
    }
}
