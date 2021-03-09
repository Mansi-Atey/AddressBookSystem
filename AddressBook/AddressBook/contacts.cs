using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBook
{
    class contacts
    {
        public string firstName;
        public string lastName;
        public string address;
        public string state;
        public string city;
        public int zipcode;
        public string contactNumber;
    public contacts(string firstName, string lastName, string address, string state, string city, int zipcode, string contactNumber)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.address = address;
            this.state = state;
            this.city = city;
            this.zipcode = zipcode;
            this.contactNumber = contactNumber;
        }
        public string toString()
        {
            return "First Name:" + firstName + "\nLast Name:" + lastName + "\nAddress:" + address + "\nState:" + state + "\nCity:" + city + "\nZipCode:" + zipcode + "\nContactNumber:" + contactNumber;
        }
}
}

