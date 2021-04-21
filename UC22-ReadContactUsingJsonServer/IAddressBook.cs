using System;
using System.Collections.Generic;
using System.Text;

namespace UC22_ReadContactUsingJsonServer
{
    public interface IAddressBook
    {
        public void AddContact(string first_name, string LastName, string address, string city, string state, int zip, long phone_number, string email);
        public void EditContact(string first_name);
        public void DeleteContact(string first_name);
        public void DisplayContacts();
        public List<string> findPerson(string place);
        public List<String> FindPersonsInCity(string isCity);
        public List<String> FindPersonsInState(string isState);
    }
}
