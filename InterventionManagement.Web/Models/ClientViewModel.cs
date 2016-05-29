using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASDF.ENETCare.InterventionManagement.Business;

namespace ASDF.ENETCare.InterventionManagement.Web.Models
{
    public class ClientViewModel
    {

    }

    public class ClientListsViewModel
    {
        public IEnumerable<Client> Clients { get; set; }
    }

    public class ClientDetailsViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Location { get; set; }
    }

    public class CreateClientViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Location { get; set; }        
    }

    public class EditClientsDetails : ClientDetailsViewModel
    {
    }
}