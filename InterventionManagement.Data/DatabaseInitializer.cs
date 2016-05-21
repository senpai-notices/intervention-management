using ASDF.ENETCare.InterventionManagement.Business;
using System.Collections.Generic;

namespace ASDF.ENETCare.InterventionManagement.Data
{
    class DatabaseInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<MainContext>
    {
        protected override void Seed(MainContext context)
        {
            SeedDistricts(context);
            SeedClients(context);
            
            SeedInterventionTemplates(context);
            SeedInterventionStates(context);
        }

        private void SeedClients(MainContext context)
        {
            var clients = new List<Client>
            {
                new Client{ ClientId=1, Name="Family of Josiah and Ruth", Location="Blue tin shack, underneath wooden bridge", DistrictId = 1},
                new Client{ ClientId=2, Name="Bambang Bima", Location="1 Agung Road", DistrictId = 2  },
                new Client{ ClientId=3, Name="Susilo Sinta", Location="25 Wira Street", DistrictId = 3 },
                new Client{ ClientId=4, Name="Rodney McDonald", Location="100 Nelson Highway, Wagga Wagga", DistrictId = 4 }
            };
            clients.ForEach(s => context.Client.Add(s));
            context.SaveChanges();
        }

        private void SeedDistricts(MainContext context)
        {
            var districts = new List<District>
            {
                new District{ Name="Urban Indonesia" },
                new District{ Name="Rural Indonesia" },
                new District{ Name="Urban Papua New Guinea" },
                new District{ Name="Rural Papua New Guinea" },
                new District{ Name="Sydney" },
                new District{ Name="Rural New South Wales" }
            };
            districts.ForEach(s => context.District.Add(s));
            context.SaveChanges();
        }

        private void SeedInterventionStates(MainContext context)
        {
            var interventionStates = new List<InterventionState>
            {
                new InterventionState{ InterventionStateId=1, Name="Proposed" },
                new InterventionState{ InterventionStateId=2, Name="Approved" },
                new InterventionState{ InterventionStateId=3, Name="Cancelled" },
                new InterventionState{ InterventionStateId=4, Name="Completed" }
            };
            interventionStates.ForEach(s => context.InterventionState.Add(s));
            context.SaveChanges();
        }

        private void SeedInterventionTemplates(MainContext context)
        {
            var interventionTemplates = new List<InterventionTemplate>
            {
                new InterventionTemplate{ InterventionTemplateId=1, Name="Supply Mosquito Net", Hours=1, Cost=60.00M },
                new InterventionTemplate{ InterventionTemplateId=1, Name="Supply and Install Storm-proof Home Kit", Hours=40, Cost=1000.00M },
                new InterventionTemplate{ InterventionTemplateId=1, Name="Supply and Install Portable Toilet", Hours=4, Cost=150.00M },
                new InterventionTemplate{ InterventionTemplateId=1, Name="Hepatitis Avoidance Training", Hours=3, Cost=80.00M }
            };
            interventionTemplates.ForEach(s => context.InterventionTemplate.Add(s));
            context.SaveChanges();
        }

        private void SeedInterventions()
        {
            
        }
    }
}
