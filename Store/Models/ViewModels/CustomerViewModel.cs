using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Store.Models.ViewModels
{
    public class CustomerViewModel
    {
        public int Id { get; set; }
        public string SSN { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }
    }
}