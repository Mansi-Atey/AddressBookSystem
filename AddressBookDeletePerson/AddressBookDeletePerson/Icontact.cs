using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookDeletePerson
{
    interface Icontact
    {
        public void AddContact(string firstName, string lastName, string address, string city, string state, string email, int zip, long phoneNumber);
        public void ViewContact(string name);
        public void EditContact(string name);
        public void DeleteContact(string name);
    }
}
