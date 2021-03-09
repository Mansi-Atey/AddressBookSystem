using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBook
{
    class AddressBook
    {
        static void Main(string[] args)
        {

            contacts cp = new contacts("Mansi", "Atey", "NIA", "Maharashtra", "Mumbai", 400058, "8899332211");
            Console.WriteLine(cp.toString());
        }
    }
}
