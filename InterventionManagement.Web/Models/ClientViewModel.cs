using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using ASDF.ENETCare.InterventionManagement.Business;

namespace ASDF.ENETCare.InterventionManagement.Web.Models
{
    public class ClientViewModel
    {

    }

    public class CreateClientViewModel
    {
        [Required]
        [DisplayName("Client Name")]
        public string Name { get; set; }

        [Required]
        [DisplayName("Client location")]
        public string Location { get; set; }

        [DisplayName("Interventions")]
        public IEnumerable<Intervention> ClientInterventions { get; set; }
    }

    public class ClientDetailsViewModel:CreateClientViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
    }

    public class ClientListViewModel:ClientDetailsViewModel
    {
        public IEnumerable<Client> Clients { get; set; }
    }

    public class EditClientsDetails : ClientDetailsViewModel
    {
    }
}