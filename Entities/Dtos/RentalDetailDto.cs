using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class RentalDetailDto :IDto
    {
        public string UserName { get; set; }
        public string CompanyName { get; set; }
        public string CarName { get; set; }
        public DateTime? RentDate { get; set; }
        public DateTime? ReturnDate { get; set; }


    }
}
