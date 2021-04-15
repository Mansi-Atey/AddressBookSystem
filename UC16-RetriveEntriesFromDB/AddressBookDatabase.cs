using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace UC16_RetriveEntriesFromDB
{
    public class AddressBookDatabase
    {
        string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=AddressBookService;Integrated Security=True";

        public int GetPersonDetailsfromDatabase()
        {
            int Count = 0;
            try
            {
                AddressBookModel addressBookModel = new AddressBookModel();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string retrieveQuery = @"select * from PersonContactDetails p inner join CityAndStateMapping c
                                    on p.city_state_mapping_id = c.mapping_id inner join City c1 
                                    on c.city_id = c1.city_id inner join State s on
                                    c.state_id = s.state_id inner join AddressBookType a 
                                    on p.addressbook_type_id = a.addressbook_type_id inner join AddressBookName a1
                                    on p.addressboon_name_id = a1.addressbook_name_id";
                    SqlCommand sqlCommand = new SqlCommand(retrieveQuery, connection);
                    connection.Open();
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.HasRows)
                    {
                        Console.WriteLine("Address Book Services Database has following Contact details right now");
                        while (sqlDataReader.Read())
                        {
                            addressBookModel.person_id = sqlDataReader.GetInt32(0);
                            addressBookModel.first_name = sqlDataReader.GetString(1);
                            addressBookModel.last_name = sqlDataReader.GetString(2);
                            addressBookModel.phone_number = sqlDataReader.GetString(3);
                            addressBookModel.email = sqlDataReader.GetString(4);
                            addressBookModel.cityAndStateMappingId = sqlDataReader.GetInt32(5);
                            addressBookModel.addressbook_type_id = sqlDataReader.GetInt32(6);
                            addressBookModel.addressbook_name_id = sqlDataReader.GetInt32(7);
                            addressBookModel.city_name = sqlDataReader.GetString(12);
                            addressBookModel.zip = sqlDataReader.GetInt32(13);
                            addressBookModel.state_name = sqlDataReader.GetString(15);
                            addressBookModel.addressbook_type = sqlDataReader.GetString(17);
                            addressBookModel.addressbook_name = sqlDataReader.GetString(19);
                            Count++;
                            Console.WriteLine("{0}, {1}, {2}, {4}, {5}, {6}, {7}, {8}, {9}", addressBookModel.person_id, addressBookModel.first_name, addressBookModel.last_name,
                                addressBookModel.phone_number, addressBookModel.email, addressBookModel.city_name, addressBookModel.zip, addressBookModel.state_name, addressBookModel.addressbook_type, addressBookModel.addressbook_name);
                        }
                        Console.WriteLine("New Contact Added Successfully");
                        sqlDataReader.Close();
                    }
                    connection.Close();
                }
                return Count;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool AddNewContact(AddressBookModel model)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("AddNewContact", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@first_name", model.first_name);
                    command.Parameters.AddWithValue("@last_name", model.last_name);
                    command.Parameters.AddWithValue("@phone_number", model.phone_number);
                    command.Parameters.AddWithValue("@email", model.email);
                    command.Parameters.AddWithValue("@city_state_mapping_id", model.cityAndStateMappingId);
                    command.Parameters.AddWithValue("@addressbook_type_id", model.addressbook_type_id);
                    command.Parameters.AddWithValue("@addressboon_name_id", model.addressbook_name_id);

                    connection.Open();
                    var result = command.ExecuteNonQuery();
                    connection.Close();
                    if (result == 0)
                    {
                        return false;
                    }
                    return true;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool UpdateContact(AddressBookModel model)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("UpdateContact", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@last_name", model.last_name);
                    command.Parameters.AddWithValue("@phone_number", model.phone_number);
                    command.Parameters.AddWithValue("@email", model.email);
                    connection.Open();
                    var result = command.ExecuteNonQuery();
                    Console.WriteLine("Contact Updated Successfully !");
                    connection.Close();
                    if (result == 0)
                    {
                        return false;
                    }
                    return true;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool DeleteCotact(AddressBookModel model)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("DeleteContact", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@first_name", model.first_name);
                    connection.Open();
                    var result = command.ExecuteNonQuery();
                    Console.WriteLine("Contact Deleted Successfully !");
                    connection.Close();
                    if (result == 0)
                    {
                        return false;
                    }
                    return true;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
