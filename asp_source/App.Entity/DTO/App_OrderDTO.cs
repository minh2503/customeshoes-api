using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Entity.DTO
{
	public class App_OrderDTO
	{
        public long Id { get; set; }
        public long UserId { get; set; }
        public int? Status { get; set; }
        public string? Note { get; set; }
        public double? Amount { get; set; }
        public string? ShipAddress { get; set; }
        public DateTime? ShipedDate { get; set; }
        public DateTime? DeliveredDate { get; set; }
        public int? PaymentMethod { get; set; }
        public DateTime? PaymentDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? OrderCode { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string? ModifiedBy { get; set; }
    }
}
