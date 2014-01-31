using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestTask.Workers
{
    public class BasedOnTimeWorker : AbstractWorker
    {
        public BasedOnTimeWorker(int id, string name, double rate) : base(id, name, rate) { }

        public override double GetSalary()
        {
            return 20.8 * 8 * rate;
        }
    }
}
