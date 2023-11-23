using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class RentalDetailDto : IDto
    {
        public int RentalId { get; set; }
        public int CarId { get; set; }
        public string ModelFullName { get; set; }
        public int CustomerId { get; set; }
        public string CustomerFullName { get; set; }
        public decimal DailyPrice { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public int PaymentId { get; set; }
        public DateTime PaymentDate { get; set; }
        public bool? DeliveryStatus { get; set; }
    }
}
