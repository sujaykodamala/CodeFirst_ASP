using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChurchWebsite.Models
{
    public class Email
    { 
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required(ErrorMessage = "The Name is Required")]
        [StringLength(20, ErrorMessage = "The maximum length of the name should be 20 Characters")]
        [Display(Name = "Your Name")]
        public string Name { get; set; }

        [Column("Email")]
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Enter a proper email address")]
        [MaxLength(30, ErrorMessage = "Maximum length allowed for an email is 30 characters")]
        [Display(Name = "Email Address")]
        public string Email1 { get; set; }

        [Required(ErrorMessage = "Please print your request")]
        [StringLength(200, ErrorMessage = "Maximum Characters allowed Are 200")]
        [Display(Name = "Prayer Request")]
        [DataType(DataType.MultilineText)]
        public string Request { get; set; }
    }
}
