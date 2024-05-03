using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness_Layer.Model
{
    public class CarRentalAgreementModel
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
