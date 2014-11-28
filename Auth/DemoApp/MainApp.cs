using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApp
{
    public class MainApp
    {
        public void AllCanDoThis()
        {
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("Any person can invoke this method.");
            Console.WriteLine(Environment.NewLine);
        }

        public void AdminsCanDoThis()
        {
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("Only the person with 'admin' role can invoke this method.");
            Console.WriteLine(Environment.NewLine);
        }
    }
}
