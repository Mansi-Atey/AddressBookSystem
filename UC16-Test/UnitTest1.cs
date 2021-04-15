using Microsoft.VisualStudio.TestTools.UnitTesting;
using UC16_RetriveEntriesFromDB;

namespace UC16_Test
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
                first_name = "Ranjeet",
                last_name = "Mortule",
                phone_number = "9866345545",
                email = "motule@gmail.com",
                cityAndStateMappingId = 6,
                addressbook_type_id = 2,
                addressbook_name_id = 2
            };
            bool result = database.AddNewContact(model);
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

    }
    }

