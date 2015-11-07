using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ChurchWebsite.Models
{
   public class Leader
    {

       [Key]
       [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
       public int ID { get; set; }

       [Required(ErrorMessage="The Name is required")] 
       [MaxLength(20,ErrorMessage="The Maximum characters allowed is 20")]
       [MinLength(4,ErrorMessage="The Minimum charcaters allowed is 4")]
       public string Name { get; set; }

       [Required(ErrorMessage="Picture is required")]
       public byte[] Picture { get; set; }

       public int ImageSize { get; set; }

       [NotMapped]
       public HttpPostedFileBase File { get; set; }

       [Required(ErrorMessage="Enter the position")]
       public string Position { get; set; }

       public int MinistryID { get; set; }

       [ForeignKey("MinistryID")]
       public virtual Ministry Ministry { get; set; }
    }
}
