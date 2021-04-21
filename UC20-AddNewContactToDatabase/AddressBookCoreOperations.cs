using System;
using System.Collections.Generic;
using System.Text;

namespace UC20_AddNewContactToDatabase
{
   public class AddressBookCoreOperations
    {
        public static void AddressBookCore()
        {
            Dictionary<string, AddressBook> addressBookDict = new Dictionary<string, AddressBook>();
            string isRepeat = "yes";
            bool reLoop = false;
            do
            {
                try
                {
                    Console.WriteLine("\n\nHow many address Book you want to create ? ");
                    int numAddressBook = Convert.ToInt32(Console.ReadLine());

                    for (int i = 1; i <= numAddressBook; i++)
                    {
                        Console.WriteLine("Enter the name of address book " + i + ": ");
                        string addressBookName = Console.ReadLine();
                        AddressBook addressBook = new AddressBook();
                        addressBookDict.Add(addressBookName, addressBook);
                    }
                    reLoop = true;
                }
                catch (Exception)
                {
                    Console.WriteLine("\n\nPlease enter only integer number of count of address book that you want to create, String not allowded here.\nAnd Make Sure you enter unique name for book, No duplicate name is allowded");

                }
            } while (reLoop != true);

            do
            {
                try
                {
                    Console.WriteLine("You have created following Address Books");
                    foreach (string k in addressBookDict.Keys)
                    {
                        Console.WriteLine(k);
                    }
                    Console.WriteLine("Choose option to procced further \n1.Add Contact \n2.Edit Contact \n3.Delete Contact  \n4.Display Contacts \n5.Search Persons \n6.View Persons \n7.Count Persons \n8.Sort Contacts By First Name \n9.File Operations \n10.Exit");
                    int choice = Convert.ToInt32(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("Enter Address Book name where you want to add contacts");
                            string addContactInAddressBook = Console.ReadLine();
                            if (addressBookDict.ContainsKey(addContactInAddressBook))
                            {
                                Console.WriteLine("Enter how many contacts you want to add");
                                int numberOfContacts = Convert.ToInt32(Console.ReadLine());
                                for (int i = 1; i <= numberOfContacts; i++)
                                {
                                    takeInput(addressBookDict[addContactInAddressBook]);
                                }
                                addressBookDict[addContactInAddressBook].DisplayContacts();
                            }
                            else
                            {
                                Console.WriteLine("No AddressBook exist with name {0}", addContactInAddressBook);
                            }
                            break;
                        case 2:
                            Console.WriteLine("Enter Address Book name where you want to edit contact");
                            string editContactInAddressBook = Console.ReadLine();
                            if (addressBookDict.ContainsKey(editContactInAddressBook))
                            {
                                Console.WriteLine("Enter FirstName of Contact to be edited");
                                string firstNameOfContactToBeEdited = Console.ReadLine();
                                addressBookDict[editContactInAddressBook].EditContact(firstNameOfContactToBeEdited);
                                addressBookDict[editContactInAddressBook].DisplayContacts();
                            }
                            else
                            {
                                Console.WriteLine("No Address book exist with name {0} ", editContactInAddressBook);
                            }
                            break;
                        case 3:
                            Console.WriteLine("Enter Address Book name where you want to delete contact");
                            string deleteContactInAddressBook = Console.ReadLine();
                            if (addressBookDict.ContainsKey(deleteContactInAddressBook))
                            {
                                Console.WriteLine("Enter FirstName of Contact to be deleted");
                                string firstNameOfContactToBeDeleted = Console.ReadLine();
                                addressBookDict[deleteContactInAddressBook].DeleteContact(firstNameOfContactToBeDeleted);
                                addressBookDict[deleteContactInAddressBook].DisplayContacts();
                            }
                            else
                            {
                                Console.WriteLine("No Address book exist with name {0} ", deleteContactInAddressBook);
                            }
                            break;
                        case 4:
                            Console.WriteLine("Enter Address Book name to display contacts");
                            string displayContactInAddressBook = Console.ReadLine();
                            addressBookDict[displayContactInAddressBook].DisplayContacts();
                            break;
                        case 5:
                            Console.WriteLine("Enter City OR State ");
                            string findPersonFromPlace = Console.ReadLine();
                            foreach (var dict in addressBookDict)
                            {
                                List<string> listOfPerson = new List<string>();
                                listOfPerson = dict.Value.findPerson(findPersonFromPlace);
                                foreach (var element in listOfPerson)
                                {
                                    Console.WriteLine("'" + element + "'" + " belongs to '{0}'", findPersonFromPlace);
                                }
                            }
                            break;
                        case 6:
                            string shouldRepeat = "true";
                            do
                            {
                                Console.WriteLine("How you want to view Prson ? \n1.View By City \n2.View By State \n3.Exit");
                                int chooseViewPerson = Convert.ToInt32(Console.ReadLine());
                                switch (chooseViewPerson)
                                {
                                    case 1:
                                        Console.WriteLine("Enter City name whose residents name you want to see");
                                        string findPersonInCity = Console.ReadLine();
                                        foreach (var dict in addressBookDict)
                                        {
                                            List<String> listOfPersonsinCity = new List<string>();
                                            listOfPersonsinCity = dict.Value.FindPersonsInCity(findPersonInCity);
                                            foreach (var name in listOfPersonsinCity)
                                            {
                                                Console.WriteLine("'{0}' belongs to city '{1}'", name, findPersonInCity);
                                            }
                                        }
                                        break;
                                    case 2:
                                        Console.WriteLine("Enter State name whose residents name you want to see");
                                        string findPersonInState = Console.ReadLine();
                                        foreach (var dict in addressBookDict)
                                        {
                                            List<String> listOfPersonsinState = new List<string>();
                                            listOfPersonsinState = dict.Value.FindPersonsInState(findPersonInState);
                                            foreach (var name in listOfPersonsinState)
                                            {
                                                Console.WriteLine("'{0}' belongs to state '{1}'", name, findPersonInState);
                                            }
                                        }
                                        break;
                                    case 3:
                                        shouldRepeat = "false";
                                        break;
                                    default:
                                        Console.WriteLine("Please enter valid option only");
                                        break;
                                }
                            } while (shouldRepeat.Equals("true"));
                            break;
                        case 7:
                            string shouldCountRepeat = "true";
                            do
                            {
                                Console.WriteLine("How you want to count Prson ? \n1.Count By City \n2.Count By State \n3.Exit");
                                int chooseCountPerson = Convert.ToInt32(Console.ReadLine());
                                switch (chooseCountPerson)
                                {
                                    case 1:
                                        Console.WriteLine("Enter City name whose resident's Count name you want to see");
                                        string findPersonInCity = Console.ReadLine();
                                        int cityCount = 0;
                                        foreach (var dict in addressBookDict)
                                        {
                                            List<String> listOfPersonsinCity = new List<string>();
                                            listOfPersonsinCity = dict.Value.FindPersonsInCity(findPersonInCity);
                                            foreach (var name in listOfPersonsinCity)
                                            {
                                                cityCount++;
                                            }
                                        }
                                        Console.WriteLine("There is/are {0} number of people belongs to city {1}", cityCount, findPersonInCity);
                                        break;
                                    case 2:
                                        Console.WriteLine("Enter State name whose resident's Count name you want to see");
                                        string findPersonInState = Console.ReadLine();
                                        int stateCount = 0;
                                        foreach (var dict in addressBookDict)
                                        {
                                            List<String> listOfPersonsinState = new List<string>();
                                            listOfPersonsinState = dict.Value.FindPersonsInState(findPersonInState);

                                            foreach (var name in listOfPersonsinState)
                                            {
                                                stateCount++;
                                            }
                                        }
                                        Console.WriteLine("There is/are {0} number of people belongs to state {1}", stateCount, findPersonInState);
                                        break;
                                    case 3:
                                        shouldCountRepeat = "false";
                                        break;
                                    default:
                                        Console.WriteLine("Please enter valid option only");
                                        break;
                                }
                            } while (shouldCountRepeat.Equals("true"));
                            break;
                        case 8:
                            string isSortRepeat = "true";
                            do
                            {
                                Console.WriteLine("How you want to Sort Person's Details ? \n1.Sort By First Name \n2.Sort By City \n3.Sort By State \n4.Sort By Zip \n5.Exit");
                                int chooseSortOption = Convert.ToInt32(Console.ReadLine());
                                switch (chooseSortOption)
                                {
                                    case 1:
                                        Console.WriteLine("Enter Address Book name to sort contacts based on First Name");
                                        string sortContactInAddressBook = Console.ReadLine();
                                        if (addressBookDict.ContainsKey(sortContactInAddressBook))
                                        {
                                            Console.WriteLine("\nFollowing are the Sorted Contacts based on First Name");
                                            addressBookDict[sortContactInAddressBook].SortContactsInAddressBookByFirstName();
                                        }
                                        else
                                        {
                                            Console.WriteLine("No Address book exist with name {0} ", sortContactInAddressBook);
                                        }
                                        break;
                                    case 2:
                                        Console.WriteLine("Enter Address Book name to sort contacts based on City Name");
                                        string sortContactByCity = Console.ReadLine();
                                        if (addressBookDict.ContainsKey(sortContactByCity))
                                        {
                                            Console.WriteLine("\nFollowing are the Sorted Contacts based on City Name");
                                            addressBookDict[sortContactByCity].SortContactsInAddressBookByCity();
                                        }
                                        else
                                        {
                                            Console.WriteLine("No Address book exist with name {0} ", sortContactByCity);
                                        }
                                        break;
                                    case 3:
                                        Console.WriteLine("Enter Address Book name to sort contacts based on State Name");
                                        string sortContactByState = Console.ReadLine();
                                        if (addressBookDict.ContainsKey(sortContactByState))
                                        {
                                            Console.WriteLine("\nFollowing are the Sorted Contacts based on State Name");
                                            addressBookDict[sortContactByState].SortContactsInAddressBookByState();
                                        }
                                        else
                                        {
                                            Console.WriteLine("No Address book exist with name {0} ", sortContactByState);
                                        }
                                        break;
                                    case 4:
                                        Console.WriteLine("Enter Address Book name to sort contacts based on Zip");
                                        string sortContactByZip = Console.ReadLine();
                                        if (addressBookDict.ContainsKey(sortContactByZip))
                                        {
                                            Console.WriteLine("\nFollowing are the Sorted Contacts based on Zip");
                                            addressBookDict[sortContactByZip].SortContactsInAddressBookByZip();
                                        }
                                        else
                                        {
                                            Console.WriteLine("No Address book exist with name {0} ", sortContactByZip);
                                        }
                                        break;
                                    case 5:
                                        isSortRepeat = "false";
                                        break;
                                    default:
                                        Console.WriteLine("Please enter valid option only");
                                        break;
                                }

                            } while (isSortRepeat.Equals("true"));
                            break;
                        case 9:
                            string isTextFileOperationsRepeat = "true";
                            do
                            {
                                Console.WriteLine("\nWhich Operation do you want to Perform ? \n1.Write Contacts in Text file \n2.Read Contacts from Text File  \n3.Write Contacts in CSV file \n4.Read Contacts from CSV file \n5.Write Contacts in JSON file \n6.Read Contacts from JSon File \n7.Exit");
                                int chooseTextFileOperationOption = Convert.ToInt32(Console.ReadLine());
                                switch (chooseTextFileOperationOption)
                                {
                                    case 1:
                                        Console.WriteLine("Enter Address Book name where you want to write contact details");
                                        string WriteContacts = Console.ReadLine();
                                        if (addressBookDict.ContainsKey(WriteContacts))
                                        {
                                            addressBookDict[WriteContacts].WriteContactsInTxtFile();
                                        }
                                        else
                                        {
                                            Console.WriteLine("No Address book exist with name {0} ", WriteContacts);
                                        }
                                        break;
                                    case 2:
                                        Console.WriteLine("Enter Address Book name from which you want to Read Contact details");
                                        string ReadContacts = Console.ReadLine();
                                        if (addressBookDict.ContainsKey(ReadContacts))
                                        {
                                            addressBookDict[ReadContacts].ReadContactsInTxtFile();
                                        }
                                        else
                                        {
                                            Console.WriteLine("No Address book exist with name {0} ", ReadContacts);
                                        }
                                        break;
                                    case 3:
                                        Console.WriteLine("Enter Address Book name where you want to write contact details in csv file");
                                        string WriteContactsInCSV = Console.ReadLine();
                                        if (addressBookDict.ContainsKey(WriteContactsInCSV))
                                        {
                                            addressBookDict[WriteContactsInCSV].WriteContactsInCSV();
                                        }
                                        else
                                        {
                                            Console.WriteLine("No Address book exist with name {0} ", WriteContactsInCSV);
                                        }
                                        break;
                                    case 4:
                                        Console.WriteLine("Enter Address Book name from which you want to Read Contact details in csv file");
                                        string ReadContactsFromCSVFile = Console.ReadLine();
                                        if (addressBookDict.ContainsKey(ReadContactsFromCSVFile))
                                        {
                                            addressBookDict[ReadContactsFromCSVFile].ReadContactsFromCSV();
                                        }
                                        else
                                        {
                                            Console.WriteLine("No Address book exist with name {0} ", ReadContactsFromCSVFile);
                                        }
                                        break;
                                    case 5:
                                        Console.WriteLine("Enter Address Book name where you want to write contact details in json file");
                                        string WriteContactsInJSON = Console.ReadLine();
                                        if (addressBookDict.ContainsKey(WriteContactsInJSON))
                                        {
                                            addressBookDict[WriteContactsInJSON].WriteContactsInJSONFile();
                                        }
                                        else
                                        {
                                            Console.WriteLine("No Address book exist with name {0} ", WriteContactsInJSON);
                                        }
                                        break;
                                    case 6:
                                        Console.WriteLine("Enter Address Book name from which you want to Read Contact details in json file");
                                        string ReadContactsFromJSONFile = Console.ReadLine();
                                        if (addressBookDict.ContainsKey(ReadContactsFromJSONFile))
                                        {
                                            addressBookDict[ReadContactsFromJSONFile].ReadContactsFronJSON();
                                        }
                                        else
                                        {
                                            Console.WriteLine("No Address book exist with name {0} ", ReadContactsFromJSONFile);
                                        }
                                        break;
                                    case 7:
                                        isTextFileOperationsRepeat = "false";
                                        break;
                                    default:
                                        Console.WriteLine("Please enter valid option only");
                                        break;
                                }
                            } while (isTextFileOperationsRepeat.Equals("true"));
                            break;
                        case 10:
                            isRepeat = "no";
                            break;
                        default:
                            Console.WriteLine("Please enter valid option");
                            break;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Please enter integer options only");
                }
            } while (isRepeat.Equals("yes"));
        }

        public static void takeInput(AddressBook addressBook)
        {
            try
            {
                Console.WriteLine("Enter First Name : ");
                string firstName = Console.ReadLine();
                Console.WriteLine("Enter Last Name : ");
                string lastName = Console.ReadLine();
                Console.WriteLine("Enter Address : ");
                string address = Console.ReadLine();
                Console.WriteLine("Enter City : ");
                string city = Console.ReadLine();
                Console.WriteLine("Enter State : ");
                string state = Console.ReadLine();
                Console.WriteLine("Enter Zip : ");
                int zip = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Phone Number : ");
                long phoneNumber = Convert.ToInt64(Console.ReadLine());
                Console.WriteLine("Enter Email id :");
                string email = Console.ReadLine();
                addressBook.AddContact(firstName, lastName, address, city, state, zip, phoneNumber, email);
            }
            catch (Exception)
            {
                Console.WriteLine("Zip and Phone number must be integers only");
            }
        }
    }
}
