using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestTask.Workers
{
    public abstract class AbstractWorker
    {
        protected double rate;
        public int Id { get; set; }
        public string Name { get; set; }

        public abstract double Salary { get; }

        public AbstractWorker(int id, string name, double rate)
        {
            Id = id;
            Name = name;
            this.rate = rate;
        }
    }
}
