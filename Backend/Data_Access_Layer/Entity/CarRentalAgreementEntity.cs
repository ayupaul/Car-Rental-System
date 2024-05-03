using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Entity
{
    public class CarRentalAgreementEntity
    {
        [Key]
        public int AgreementId { get; set; }
        public int UserId { get; set; }
        public int CarId { get; set; }
        public int TotalCost { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public bool IsRequestedForReturn { get; set; }

    }
}
