using System;

namespace UC19_CountContactByCityOrState
{
   public class AddressBookMain
    {
       public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Address book System ! ");
            AddressBookDatabase database = new AddressBookDatabase();
            AddressBookModel bookModel = new AddressBookModel();
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
                            AddressBookModel model = new AddressBookModel()
                            {
                                first_name = "Sagar",
                                last_name = "Dandge",
                                phone_number = "7535345545",
                                email = "sagar1234@gmail.com",
                            };
                            database1.AddNewContact(model);
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
                            Console.WriteLine("Enter Date from which you want to see contact add ");
                            DateTime date = Convert.ToDateTime(Console.ReadLine());
                            bookModel.date_added = date;
                            addressBook.RetrievePerticularContact(bookModel);
                            break;
                        case 5:
                            Console.WriteLine("Enter City \nRecently DB has Contacts from Mumbai, Pune, Jaipur, Jodhapur ");
                            string city = Console.ReadLine();
                            Console.WriteLine("Enter State Name \nRecently DB has Contacts from Two States Only i.e. Maharashtra and Rajasthan");
                            string state = Console.ReadLine();
                            bookModel.city_name = city;
                            bookModel.state_name = state;
                            database.RetriveContactByCityOrState(bookModel);
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
