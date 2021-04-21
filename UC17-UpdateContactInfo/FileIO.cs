using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace UC17_UpdateContactInfo
{
   public class FileIO
    {
        static String TextFilePath = @"C:\Users\HP\source\repos\AddressBookSystemUsingCSharp\AddressBookSystemUsingCSharp\File\TextFile.txt";
        static String CSVFilePath = @"C:\Users\HP\source\repos\AddressBookSystemUsingCSharp\AddressBookSystemUsingCSharp\File\CSVFile.csv";
        static String JSONFilePath = @"C:\Users\HP\source\repos\AddressBookSystemUsingCSharp\AddressBookSystemUsingCSharp\File\JSONFile.json";
        public static void WriteContactsInTxtFile(List<Contacts> contacts)
        {
            if (File.Exists(TextFilePath))
            {
                using (StreamWriter streamWriter = File.AppendText(TextFilePath))
                {
                    foreach (Contacts contact in contacts)
                    {
                        streamWriter.WriteLine(contact);
                    }
                    streamWriter.Close();
                }
                Console.WriteLine("Writting Contacts to the Text file is Complete !");
            }
            else
            {
                Console.WriteLine("No such file exists");
            }
        }

        public static void ReadContactsInTxtFile()
        {
            if (File.Exists(TextFilePath))
            {
                using (StreamReader streamReader = File.OpenText(TextFilePath))
                {
                    String contactDetails = "";
                    while ((contactDetails = streamReader.ReadLine()) != null)
                        Console.WriteLine((contactDetails));
                }
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("No such file exists");
            }
        }

        public static void WriteContactsInCSVFile(List<Contacts> contacts)
        {
            if (File.Exists(CSVFilePath))
            {
                using (StreamWriter streamWriter = File.AppendText(CSVFilePath))
                {
                    foreach (Contacts contact in contacts)
                    {
                        streamWriter.WriteLine(contact.first_name + "," + contact.last_name + "," + "," + contact.address + "," + contact.city + "," + contact.state + "," + contact.zip + "," + contact.phone_number + "," + contact.email);
                    }
                    streamWriter.Close();
                }
                Console.WriteLine("Writting Contacts to the CSV file is Complete !");
            }
            else
            {
                Console.WriteLine("No such file exists");
            }
        }

        public static void ReadContactsInCSVFile()
        {
            if (File.Exists(CSVFilePath))
            {
                string[] csv = File.ReadAllLines(CSVFilePath);
                foreach (string csValues in csv)
                {
                    string[] column = csValues.Split(",");
                    foreach (string CSValues in column)
                    {
                        Console.WriteLine(CSValues);
                    }
                }
            }
            else
            {
                Console.WriteLine("No such file exists");
            }
        }

        public static void WriteContactsInJSONFile(List<Contacts> contacts)
        {
            if (File.Exists(JSONFilePath))
            {
                Newtonsoft.Json.JsonSerializer jsonSerializer = new Newtonsoft.Json.JsonSerializer();
                using (StreamWriter streamWriter = new StreamWriter(JSONFilePath))
                using (JsonWriter writer = new JsonTextWriter(streamWriter))
                {
                    jsonSerializer.Serialize(writer, contacts);
                }
                Console.WriteLine("Writting Contacts to the JSON file is Complete !");
            }
            else
            {
                Console.WriteLine("No such file exists");
            }
        }

        public static void ReadContactsFromJSONFile()
        {
            if (File.Exists(JSONFilePath))
            {
                IList<Contacts> contactsRead = JsonConvert.DeserializeObject<IList<Contacts>>(File.ReadAllText(JSONFilePath));
                foreach (Contacts contact in contactsRead)
                {
                    Console.Write(contact.ToString());
                }
            }
            else
            {
                Console.WriteLine("No such file exists");
            }
        }
    }
}
