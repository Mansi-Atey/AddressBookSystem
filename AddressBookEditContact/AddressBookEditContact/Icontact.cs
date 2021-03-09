using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookEditContact
{
    interface Icontact
    {
        public void AddContact(string firstName, string lastName, string address, string city, string state, string email, int zip, long phoneNumber);
        public void EditContact(string name);
    }
}
