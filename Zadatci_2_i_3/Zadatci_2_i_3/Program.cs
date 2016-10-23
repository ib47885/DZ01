﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadatci_2_i_3
{
    class Program
    {
        static void Main(string[] args)
        {
            IGenericList<string> stringList = new GenericList<string>();
            stringList.Add(" Hello ");
            stringList.Add(" World ");
            stringList.Add("!");
            try
            {
                foreach (string value in stringList)
                {
                    Console.WriteLine(value);
                }
            }
            catch( Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.ReadLine();
            }
        }
    }
}
