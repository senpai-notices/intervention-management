using System.ComponentModel.DataAnnotations;

namespace ASDF.ENETCare.InterventionManagement.Business
{
    public enum District
    {
        [Display(Name = "Urban Indonesia")]
        UrbanIndonesia = 1,
        [Display(Name = "Rural Indonesia")]
        RuralIndonesia,
        [Display(Name = "Urban Papua New Guinea")]
        UrbanPapuaNewGuinea,
        [Display(Name = "Rural Papua New Guinea")]
        RuralPapuaNewGuinea,
        [Display(Name = "Sydney")]
        Sydney,
        [Display(Name = "Rural New South Wales")]
        RuralNewSouthWales
    }
}
