using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorDemo.Models
{
    public class Validation
    {
        [Required(ErrorMessage = "Field is required"), RegularExpression("^[0-9][0-9.]*$", ErrorMessage = "Field must be properly formatted. \n x.xx.xxx.xxxx")]
        public string Input { get; set; }
    
    }
}
