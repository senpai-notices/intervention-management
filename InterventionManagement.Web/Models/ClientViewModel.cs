﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ASDF.ENETCare.InterventionManagement.Web.Models
{
    public class ClientViewModel
    {

    }

    public class ClientDetailsViewModel
    {
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