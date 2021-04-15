using System;

namespace UC16_RetriveEntriesFromDB
{
    class AddressBookMain
    {
        static void Main(string[] args)
        {
            Console.WriteLine("WELCOME TO ADDRESS BOOK WITH ADO.NET!");
            string isRepeate = "Yes";
            try
            {
                do
                {
                    Console.WriteLine("\nHow do you you like to continue ? \n1.Retrieve Contacts from Database \n2.Add New Contact to Database \n3.Continue Without Database \n4.Exit");
                    int choiceToContinue = Convert.ToInt32(Console.ReadLine());
                    switch (choiceToContinue)
                    {
                        case 1:
                            AddressBookDatabase database = new AddressBookDatabase();
                            database.GetPersonDetailsfromDatabase();
                            break;
                        case 2:
                            AddressBookDatabase database1 = new AddressBookDatabase();
                            AddressBookModel model = new AddressBookModel()
                            {
                                first_name = "Mansi",
                                last_name = "Atey",
                                phone_number = "7535345545",
                                email = "manu1234@gmail.com",
                                cityAndStateMappingId = 4,
                                addressbook_type_id = 1,
                                addressbook_name_id = 1
                            };
                            database1.AddNewContact(model);
                            break;
                        case 3:
                            AddressBookCoreOperations.AddressBookCore();
                            break;
                        case 4:
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
