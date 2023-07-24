using System.ComponentModel.DataAnnotations;

namespace WebApiFroms.Model
{
    public class FormModel
    {
        [Key]
        public int  Id { get; set; }

        [Required]
       public string? firstname { get; set; }
        [Required]
        public string? lasttname { get; set; }
       
        [Required]
        [DataType(DataType.EmailAddress)]
        public string? email { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        public int phone { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string? address { get; set; }

        [Required]
        public string? city { get; set; }

        [Required]
        public string? state { get; set; }

        [Required]
        public string? country { get; set; }

        [Required]
        [DataType(DataType.PostalCode)]
        public int postcode { get; set; }

    }
}
