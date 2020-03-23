using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Exercise2.Models
{
    public class Friend
    {
      
        public long Id { set; get; }
      

        [Required]
        public long FriendId{set;get;}
        [StringLength(100,MinimumLength =1,ErrorMessage = " Friend Name Empty Not Allowed.")]
       
        public string FriendName { set; get; }
        [StringLength(25)]
        public string Place { get; set; }
    }
}
