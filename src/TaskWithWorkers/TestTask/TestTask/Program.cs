using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using TestTask.Workers;

namespace TestTask
{
    class Program
    {
        static void Main(string[] args)
        {
            var workers = PopulateWorkers(50);
            foreach (var worker in workers)
            {
                Console.WriteLine("Worker Id: {0}, Name: {1}, Salary {2}, Type: {3}", worker.Id, worker.Name, worker.Salary, worker.GetType());
            }

            SerializeData("workers.xml", workers);

            Console.ReadLine();
        }

        private static void SerializeData(string filename, IEnumerable<AbstractWorker> workers)
        {
            var ser = new XmlSerializer(typeof(AbstractWorker));
            var writer = new StreamWriter(filename);
            foreach (var worker in workers)
            {
                ser.Serialize(writer, worker);
            }
            
            writer.Close();
        }

        private static IEnumerable<AbstractWorker> PopulateWorkers(int count)
        {
            var rand = new Random();

            for (int i = 0; i < count; i++)
            {
                var type = rand.Next(0, 1);
                double rate;

                AbstractWorker worker;
                switch (type)
                {
                    case 0:
                        rate = (double)rand.Next(10, 100) / 10;
                        worker = new BasedOnTimeWorker(i, String.Format("{0}Worker", i), rate);
                        break;
                    case 1:
                        rate = rand.Next(100, 1000);
                        worker = new FixedWorker(i, String.Format("{0}Worker", i), rate);
                        break;
                    default:
                        throw new NotImplementedException("Are You kidding me?!");
                        break;
                }
                yield return worker;
            }
        }
    }
}
