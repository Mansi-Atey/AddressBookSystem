using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UC19_CountContactByCityOrState
{
    class AddressBook : IAddressBook
    {
        List<Contacts> contactList;
        public static int personsCountInCity = 0;
        public static int personsCountInState = 0;
        public AddressBook()
        {
            this.contactList = new List<Contacts>();
        }

        public void AddContact(string first_name, string LastName, string address, string city, string state, int zip, long phone_number, string email)
        {
            bool duplicate = equals(first_name);
            if (duplicate)
            {
                Console.WriteLine("Can not add Contact with duplicate first name. '{0}' is already exit in this address book", first_name);
            }
            else
            {
                Contacts contact = new Contacts(first_name, LastName, address, city, state, zip, phone_number, email);
                contactList.Add(contact);
                Console.WriteLine("Contact added Successfully !");

            }

        }

        public bool equals(string first_name)
        {
            if (this.contactList.Any(e => e.first_name == first_name))
                return true;
            else
                return false;
        }

        public void EditContact(string first_name)
        {
            if (contactList.Count() > 0)
            {
                int thereExist = 1;
                foreach (Contacts contact in contactList)
                {
                    if (first_name.Equals(contact.first_name))
                    {
                        thereExist = 0;
                        Console.WriteLine("Enter Last Name : ");
                        contact.last_name = Console.ReadLine();
                        Console.WriteLine("Enter Address: ");
                        contact.address = Console.ReadLine();
                        Console.WriteLine("Enter City : ");
                        contact.city = Console.ReadLine();
                        Console.WriteLine("Enter State : ");
                        contact.state = Console.ReadLine();
                        Console.WriteLine("Enter Zip code : ");
                        contact.zip = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter Phone Number : ");
                        contact.phone_number = Convert.ToInt64(Console.ReadLine());
                        Console.WriteLine("Enter Email : ");
                        contact.email = Console.ReadLine();
                        Console.WriteLine("Contact Updated Successfully !");
                    }
                }
                if (thereExist == 1)
                {
                    Console.WriteLine("Contact not found with first name '{0}'!", first_name);
                }
            }
            else
            {
                Console.WriteLine("This contact address book is empty. First add contact then try Editing");
            }
        }

        public void DeleteContact(string first_name)
        {
            if (contactList.Count() > 0)
            {
                int thereExist = 1;
                foreach (Contacts contact in contactList)
                {
                    if (first_name.Equals(contact.first_name))
                    {
                        thereExist = 0;
                        contactList.Remove(contact);
                        Console.WriteLine("Contact Deleted Successfully !");
                        break;
                    }
                }
                if (thereExist == 1)
                {
                    Console.WriteLine("Contact not foundwith first name '{0}'!", first_name);
                }
            }
            else
            {
                Console.WriteLine("This contact address book is empty. First add contact then try Deleting");
            }
        }

        public void DisplayContacts()
        {
            if (contactList.Count() > 0)
            {
                Console.WriteLine("\n--------------------------------------");
                foreach (Contacts contact in contactList)
                {
                    Console.WriteLine("First Name : " + contact.first_name);
                    Console.WriteLine("Last Name : " + contact.last_name);
                    Console.WriteLine("Address : " + contact.address);
                    Console.WriteLine("City : " + contact.city);
                    Console.WriteLine("State : " + contact.state);
                    Console.WriteLine("Zip : " + contact.zip);
                    Console.WriteLine("Phone Number : " + contact.phone_number);
                    Console.WriteLine("Email : " + contact.email);
                }
                Console.WriteLine("\n--------------------------------------");
            }
            else
            {
                Console.WriteLine("This contact address book is empty. First add contact then try Displaying");
            }
        }

        public List<string> findPerson(string place)
        {
            bool placeExits = isPlaceExist(place);
            List<string> personFounded = new List<string>();
            if (placeExits.Equals(true))
            {
                foreach (Contacts contact in contactList.FindAll(x => (x.city.Equals(place))).ToList())
                {
                    string name = contact.first_name + " " + contact.last_name;
                    personFounded.Add(name);
                }
                if (personFounded.Count == 0)
                {
                    foreach (Contacts contact in contactList.FindAll(x => (x.state.Equals(place))).ToList())
                    {
                        string name = contact.first_name + " " + contact.last_name;
                        personFounded.Add(name);
                    }
                }
                return personFounded;
            }
            else
            {
                Console.WriteLine("No such city or state exist across any address book with name '{0}'", place);
                return personFounded;
            }
        }

        public bool isPlaceExist(string place)
        {
            if (contactList.Any(x => x.city == place) || contactList.Any(x => x.state == place))
                return true;
            else
                return false;
        }

        public List<String> FindPersonsInCity(string isCity)
        {
            List<String> personsFounded = new List<string>();
            foreach (Contacts contact in contactList.FindAll(e => (e.city.Equals(isCity))).ToList())
            {
                string name = contact.first_name + " " + contact.last_name;
                personsFounded.Add(name);
            }
            return personsFounded;
        }

        public List<String> FindPersonsInState(string isState)
        {
            List<String> personsFounded = new List<string>();
            int personCount = personsFounded.Count;

            foreach (Contacts contact in contactList.FindAll(e => (e.state.Equals(isState))).ToList())
            {
                string name = contact.first_name + " " + contact.last_name;
                personsFounded.Add(name);
            }
            return personsFounded;
        }

        public void SortContactsInAddressBookByFirstName()
        {
            contactList.Sort(new Comparison<Contacts>((x, y) => string.Compare(x.first_name, y.first_name)));
            foreach (Contacts contact in contactList)
            {
                Console.WriteLine(contact.ToString());
            }
        }

        public void SortContactsInAddressBookByCity()
        {
            contactList.Sort(new Comparison<Contacts>((x, y) => string.Compare(x.city, y.city)));
            foreach (Contacts contact in contactList)
            {
                Console.WriteLine(contact.ToString());
            }
        }

        public void SortContactsInAddressBookByState()
        {
            contactList.Sort(new Comparison<Contacts>((x, y) => string.Compare(x.state, y.state)));
            foreach (Contacts contact in contactList)
            {
                Console.WriteLine(contact.ToString());
            }
        }

        public void SortContactsInAddressBookByZip()
        {
            contactList.Sort(new Comparison<Contacts>((x, y) => x.zip.CompareTo(y.zip)));
            foreach (Contacts contact in contactList)
            {
                Console.WriteLine(contact.ToString());
            }
        }

        public void WriteContactsInTxtFile()
        {
            FileIO.WriteContactsInTxtFile(contactList);
        }

        public void ReadContactsInTxtFile()
        {
            FileIO.ReadContactsInTxtFile();
        }

        public void WriteContactsInCSV()
        {
            FileIO.WriteContactsInCSVFile(contactList);
        }

        public void ReadContactsFromCSV()
        {
            FileIO.ReadContactsInCSVFile();
        }

        public void WriteContactsInJSONFile()
        {
            FileIO.WriteContactsInJSONFile(contactList);
        }

        public void ReadContactsFronJSON()
        {
            FileIO.ReadContactsFromJSONFile();
        }
    }
}
