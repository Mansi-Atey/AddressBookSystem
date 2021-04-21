using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using UC22_ReadContactUsingJsonServer;

namespace UC22_Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GivenQuery_WhenRetrieve_ShouldReturnNumberOfRowsRetrieved()
        {
            int expectedResult = 3;
            AddressBookDatabase database = new AddressBookDatabase();
            int result = database.GetPersonDetailsfromDatabase();
            Assert.AreEqual(expectedResult, result);
        }

        /// <summary>
        /// UC16 Refactor : Ability to insert new Contact to database
        /// </summary>
        [TestMethod]
        public void GivenQuery_WhenInsert_ShouldInsertContactToDB()
        {
            bool expectedResult = true;
            AddressBookDatabase database = new AddressBookDatabase();
            AddressBookModel model = new AddressBookModel()
            {
                first_name = "Ranjeet",
                last_name = "Lohar",
                phone_number = "7666345545",
                email = "ranjeet234@gmail.com",
                cityAndStateMappingId = 6,
                addressbook_type_id = 3,
                addressbook_name_id = 3
            };
            bool result = database.AddNewContact(model);
            Assert.AreEqual(expectedResult, result);
        }

        /// <summary>
        /// UC16 Refactor : Abilite to insert same Contact to another address book type
        /// </summary>
        [TestMethod]
        public void GivenQuery_WhenInsert_ShouldAddSameContactToAnotherAddressbookType()
        {
            bool expectedResult = true;
            AddressBookDatabase database = new AddressBookDatabase();
            AddressBookModel model = new AddressBookModel()
            {
                first_name = "Ranjeet",
                last_name = "Lohar",
                phone_number = "7666345545",
                email = "ranjeet234@gmail.com",
                cityAndStateMappingId = 6,
                addressbook_type_id = 2,
                addressbook_name_id = 2
            };
            bool result = database.AddNewContact(model);
            Assert.AreEqual(expectedResult, result);
        }

        /// <summary>
        /// UC16 Refactor : Update Contact using's person first name
        /// </summary>
        [TestMethod]
        public void GivenQuery_whenUpdate_ShouldUpdateContactInDB()
        {
            bool expectedResult = true;
            AddressBookDatabase database = new AddressBookDatabase();
            AddressBookModel model = new AddressBookModel()
            {
                first_name = "Rama",
                last_name = "Mortule",
                phone_number = "9866345545",
                email = "motule@gmail.com",
                cityAndStateMappingId = 6,
                addressbook_type_id = 2,
                addressbook_name_id = 2
            };
            bool result = database.UpdateContact(model);
            Assert.AreEqual(expectedResult, result);
        }

        /// <summary>
        /// UC16 Refactor : Detele Contact using person's first name
        /// </summary>
        [TestMethod]
        public void GivenQuery_WhenDeteleByName_ShouldDeleteContactWithThatName()
        {
            bool expectedResult = true;
            AddressBookDatabase database = new AddressBookDatabase();
            AddressBookModel model = new AddressBookModel()
            {
                first_name = "Arti",
            };
            bool result = database.DeleteCotact(model);
            Assert.AreEqual(expectedResult, result);
        }

        /// <summary>
        /// Retrive Contacts from perticular date to today
        /// </summary>
        [TestMethod]
        public void GivenQuery_WhenRetrieveInPerticulatDateRange_ShouldRetrievContactAndReturnNoOfCounts()
        {
            int expectedResult = 6;
            AddressBookDatabase database = new AddressBookDatabase();
            AddressBookModel model = new AddressBookModel()
            {
                date_added = new DateTime(2016, 01, 01)
            };
            int result = database.RetrievePerticularContact(model);
            Assert.AreEqual(expectedResult, result);
        }

        /// <summary>
        /// Retrive Contacts from DB By City Or State
        /// </summary>
        [TestMethod]
        public void GivenQuery_WhenRetrieveByCityOrState_ShouldRetrievContactAndReturnNoOfCounts()
        {
            int expectedResult = 4;
            AddressBookDatabase database = new AddressBookDatabase();
            AddressBookModel model = new AddressBookModel()
            {
                city_name = "Pune",
                state_name = "Maharashtra"
            };
            int result = database.RetriveContactByCityOrState(model);
            Assert.AreEqual(expectedResult, result);
        }

        /// <summary>
        ///Ability to Insert new Contact to the database
        /// </summary>
        [TestMethod]
        public void GivenQuery_WhenInsert_ShouldAddNewContactToDB()
        {
            bool expectedResult = true;
            AddressBookDatabase database = new AddressBookDatabase();
            AddressBookModel model = new AddressBookModel()
            {
                first_name = "Snehal",
                last_name = "Chaudhari",
                phone_number = "8666345545",
                email = "shenal234@gmail.com",
                cityAndStateMappingId = 8,
                addressbook_type_id = 2,
                addressbook_name_id = 2,
                date_added = new DateTime(2018, 12, 22)
            };
            bool result = database.AddNewContact(model);
            Assert.AreEqual(expectedResult, result);
        }

        /// <summary>
        ///Ability to Insert new Contact to the database and compute time required for insertion
        /// </summary>
        [TestMethod]
        public void GivenQuery_WhenInsert_ShouldAddNewContactToDBAndComputeTimeRequired()
        {
            AddressBookDatabase database = new AddressBookDatabase();
            AddressBookModel model = new AddressBookModel()
            {
                first_name = "Meera",
                last_name = "Chaudhari",
                phone_number = "7666345545",
                email = "meera@gmail.com",
                cityAndStateMappingId = 5,
                addressbook_type_id = 3,
                addressbook_name_id = 3,
                date_added = new DateTime(2019, 04, 20)
            };
            DateTime startTime = DateTime.Now;
            database.AddNewContact(model);
            DateTime stopTime = DateTime.Now;
            Console.WriteLine("Duration taken for insertion is {0}", (stopTime - startTime));
        }
    }
    
}
