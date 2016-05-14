using ASDF.ENETCare.InterventionManagement.Business;
using System.Collections.Generic;
using System.Linq;
using Bogus;

namespace ASDF.ENETCare.InterventionManagement.Data
{
    class DatabaseInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<MainContext>
    {
        protected override void Seed(MainContext context)
        {
            SeedClients(context);
            SeedInterventionTemplates(context);
        }

        private void SeedClients(MainContext context)
        {
            var clientFaker = new Faker<Client>("en_AU")
                            .RuleFor(c => c.Name, f => f.Name.FirstName() + " " + f.Name.LastName())
                            .RuleFor(c => c.Location, f => f.Address.StreetAddress())
                            .RuleFor(c => c.District, f => f.PickRandom<District>());
            #region previous data
            /*            var clients = new List<Client>
                        {
                            new Client{ Name="Family of Josiah and Ruth", Location="Blue tin shack, underneath wooden bridge", DistrictId=6 },
                            new Client{ Name="Bambang Bima", Location="1 Agung Road", DistrictId=1 },
                            new Client{ Name="Susilo Sinta", Location="25 Wira Street", DistrictId=1 },
                            new Client{ Name="Rodney McDonald", Location="100 Nelson Highway, Wagga Wagga", DistrictId=6 }
                        };*/
            #endregion
            var clients = clientFaker.Generate(20).ToList();
            clients.ForEach(s => context.Client.Add(s));
            context.SaveChanges();
        }

        private void SeedInterventionTemplates(MainContext context)
        {
            var interventionTemplates = new List<InterventionTemplate>
            {
                new InterventionTemplate{ InterventionTemplateId=1, Name="Supply and Install Portable Toilet", Hours=2, Cost=600.00M },
                new InterventionTemplate{ InterventionTemplateId=2, Name="Hepatitis Avoidance Training", Hours=3, Cost=0.00M },
                new InterventionTemplate{ InterventionTemplateId=3, Name="Supply and Install Storm-proof Home Kit", Hours=8, Cost=500.00M },
                new InterventionTemplate{ InterventionTemplateId=4, Name="Supply Mosquito Net", Hours=0, Cost=25.00M },
                new InterventionTemplate{ InterventionTemplateId=5, Name="Install Water Pump", Hours=80, Cost=1200.00M },
                new InterventionTemplate{ InterventionTemplateId=6, Name="Supply High-Volume Water Filter and Train Users", Hours=1, Cost=1.00M },
                new InterventionTemplate{ InterventionTemplateId=7, Name="Prepare Sewerage Trench", Hours=50, Cost=0.00M }
            };
            interventionTemplates.ForEach(s => context.InterventionTemplate.Add(s));
            context.SaveChanges();
        }

        // TODO
        private void SeedInterventions()
        {
            
        }
    }
}
