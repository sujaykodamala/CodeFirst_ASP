using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChurchWebsite.Models
{
  public  class UserInfo
    {
      [Key]
      [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
      public int ID { get; set; }

      [Required(ErrorMessage="User Name is required")]
      [Display(Name="User Name")]
      [MaxLength(20, ErrorMessage = "The Maximum length allowed is 20 characters")]
      [MinLength(4, ErrorMessage = "The Minimum length is 3 characters")]
      public string Name { get; set; }

      [Required(ErrorMessage = "Enter your role")]
      [MaxLength(20, ErrorMessage = "The Maximum length of the role is less than 20 Characters ")]
      public string Role { get; set; }

      [Required(ErrorMessage = "Email is required")]
      [EmailAddress(ErrorMessage = "Enter a proper email address")]
      [MaxLength(30, ErrorMessage = "Maximum length allowed for an email is 30 characters")]
      public string Email { get; set; }

      [Required(ErrorMessage = "Password is required")]
      [Display(Name = "Password")]
      [DataType(DataType.Password)]
      public string Pass { get; set; }

      [Required(ErrorMessage = "Confirm your password")]
      [Display(Name = "Confirm Password")]
      [Compare("Pass", ErrorMessage = "Passwords should match")]
      [DataType(DataType.Password)]
      [NotMapped]
      public string Confirm { get; set; }

      
    }
}
