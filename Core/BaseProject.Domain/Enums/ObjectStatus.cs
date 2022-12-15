using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseProject.Domain.Enums
{
    public enum ObjectStatus
    {
        [Display(Name = "Silindi")]
        Deleted = 0,
        [Display(Name = "Silinmedi")]
        NonDeleted = 1
    }
}
