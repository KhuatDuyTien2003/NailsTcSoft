using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace NailTcSoft.Data
{
    public class Account:IdentityUser
    {
        public int StaffId { get; set; }
      
    }
}
