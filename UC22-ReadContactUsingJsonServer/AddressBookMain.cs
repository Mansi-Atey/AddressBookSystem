using System;

namespace UC22_ReadContactUsingJsonServer
{
   public class AddressBookMain
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Address book System ! ");
            AddressBookDatabase database = new AddressBookDatabase();
            string isRepeate = "Yes";
            try
            {
                do
                {
                    Console.WriteLine("\nHow do you you like to continue ? \n1.Retrieve Contacts from Database \n2.Add New Contact to Database \n3.Update Contact \n4.Retrieve Contact Between Perticular Date Range \n5.Retrieve Contact By City Or State \n6.Continue Without Database \n7.Exit");
                    int choiceToContinue = Convert.ToInt32(Console.ReadLine());
                    switch (choiceToContinue)
                    {
                        case 1:
                            database.GetPersonDetailsfromDatabase();
                            break;
                        case 2:
                            AddressBookDatabase database1 = new AddressBookDatabase();
                            AddressBookModel bookModel = new AddressBookModel();
                            Console.WriteLine("Enter First Name");
                            string firstName = Console.ReadLine();
                            Console.WriteLine("Enter Last Name");
                            string lastName = Console.ReadLine();
                            Console.WriteLine("Enter Phone Number");
                            string phone_no = Console.ReadLine();
                            Console.WriteLine("Enter Email address");
                            string emailId = Console.ReadLine();
                            Console.WriteLine("Enter City and State Mapping id");
                            int mapId = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter Address Book Type Id");
                            int typeId = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter Address Book Name Id");
                            int nameId = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter Date of adding Contact");
                            DateTime dateAdded = Convert.ToDateTime(Console.ReadLine());
                            bookModel.first_name = firstName;
                            bookModel.last_name = lastName;
                            bookModel.phone_number = phone_no;
                            bookModel.email = emailId;
                            bookModel.cityAndStateMappingId = mapId;
                            bookModel.addressbook_type_id = typeId;
                            bookModel.addressbook_name_id = nameId;
                            bookModel.date_added = dateAdded;
                            database1.AddNewContact(bookModel);
                            break;
                        case 3:
                            AddressBookDatabase updateDB = new AddressBookDatabase();
                            Console.WriteLine("Enter first name to update contact");
                            string name = Console.ReadLine();
                            Console.WriteLine("Enter last name to update contact");
                            string last_name = Console.ReadLine();
                            Console.WriteLine("Enter phone number to update contact");
                            string phone = Console.ReadLine();
                            Console.WriteLine("Enter email to update contact");
                            string email = Console.ReadLine();
                            Console.WriteLine("Enter City and State mapping id");
                            int city_and_state_map_id = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter address book type id");
                            int type_id = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter address book name id");
                            int name_id = Convert.ToInt32(Console.ReadLine());
                            AddressBookModel updateModel = new AddressBookModel();
                            updateModel.first_name = name;
                            updateModel.last_name = last_name;
                            updateModel.phone_number = phone;
                            updateModel.email = email;
                            updateModel.cityAndStateMappingId = city_and_state_map_id;
                            updateModel.addressbook_type_id = type_id;
                            updateModel.addressbook_name_id = name_id;
                            updateDB.UpdateContact(updateModel);
                            break;
                        case 4:
                            AddressBookDatabase addressBook = new AddressBookDatabase();
                            AddressBookModel bookModel1 = new AddressBookModel();
                            Console.WriteLine("Enter Date from which you want to see contact add ");
                            DateTime date = Convert.ToDateTime(Console.ReadLine());
                            bookModel1.date_added = date;
                            addressBook.RetrievePerticularContact(bookModel1);
                            break;
                        case 5:
                            AddressBookModel bookModel3 = new AddressBookModel();
                            Console.WriteLine("Enter City Name");
                            string city = Console.ReadLine();
                            Console.WriteLine("Enter State Name");
                            string state = Console.ReadLine();
                            bookModel3.city_name = city;
                            bookModel3.state_name = state;
                            database.RetriveContactByCityOrState(bookModel3);
                            break;
                        case 6:
                            AddressBookCoreOperations.AddressBookCore();
                            break;
                        case 7:
                            isRepeate = "No";
                            break;
                        default:
                            Console.WriteLine("Please enter valid option...");
                            break;
                    }
                } while (isRepeate.Equals("Yes"));
            }
            catch
            {
                Console.WriteLine("Please enter integer option only.");
            }
        }
    }
}
