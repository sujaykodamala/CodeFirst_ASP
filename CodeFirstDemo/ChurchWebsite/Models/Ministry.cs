using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace ChurchWebsite.Models
{
    public class Ministry
    {
        public Ministry()
        {
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MinistryID { get; set; }

        [Required(ErrorMessage="Ministry Name is required")]
        [MaxLength(20,ErrorMessage="The Maximum length allowed is 20 characters")]
        [MinLength(4,ErrorMessage="The Minimum length is 3 characters")]
        [Display(Name="Ministry")]
        public string MinistryName { get; set; }
        public List<Leader> Leader { get; set; }

    }
}
