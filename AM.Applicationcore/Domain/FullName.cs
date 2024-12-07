using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Applicationcore.Domain;

public class FullName
//Struct have a default constructor
//No impact on the Database
{
    [MinLength(3, ErrorMessage = "min length must be GT 3 ! "), MaxLength(25, ErrorMessage = "max length must be LT 25 ! ")]
    public string FirstName { get; set; }
    public string LastName { get; set; }
}
