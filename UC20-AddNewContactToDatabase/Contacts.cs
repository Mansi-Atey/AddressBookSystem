using System;
using System.Collections.Generic;
using System.Text;

namespace UC20_AddNewContactToDatabase
{
   public class Contacts
    {
        public string first_name;
        public string last_name;
        public string address;
        public string city;
        public string state;
        public int zip;
        public long phone_number;
        public string email;

        public Contacts(string first_name, string last_name, string address, string city, string state, int zip, long phone_number, string email)
        {
            this.first_name = first_name;
            this.last_name = last_name;
            this.address = address;
            this.city = city;
            this.state = state;
            this.zip = zip;
            this.phone_number = phone_number;
            this.email = email;
        }

        public override string ToString()
        {

            return "\n--------------------------------------" + "\nPerson Details: \nFirst name:" + this.first_name + " \nLast name:" + this.last_name + " \nAddress:" + this.address + " \nCity:" + this.city + " \nState:"
                    + this.state + " \nZip:" + this.zip + " \nPhone Number:" + this.phone_number + " \nEmail:" + this.email + "\n--------------------------------------";
        }
    }
}
