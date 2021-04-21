using System;
using System.Collections.Generic;
using System.Text;

namespace UC21_ReadWriteWithJsonServer
{
   public class AddressBookModel
    {
        public int person_id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string phone_number { get; set; }
        public string email { get; set; }
        public int cityAndStateMappingId { get; set; }
        public int addressbook_type_id { get; set; }
        public int addressbook_name_id { get; set; }
        public string city_name { get; set; }
        public int zip { get; set; }
        public string state_name { get; set; }
        public string addressbook_type { get; set; }
        public string addressbook_name { get; set; }
        public DateTime date_added { get; set; }
    }
}
