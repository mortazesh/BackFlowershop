using FlowerShop.Domain.Model.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerShop.Domain.Model.Orders
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; private set; }
        public string MobilNumber { get; private set; }
        public int TotalPrice { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string ZipCode { get; private set; }
        public string DesAddress { get; private set; }
        public DateTime CreatedDate { get; private set; }
        public string UserId { get; private set; }
        public Order(string Name, string MobilNumber, int TotalPrice, string City, string State, string ZipCode, string DesAddress,string UserId)
        {
            this.Name = Name;
            this.MobilNumber = MobilNumber;
            this.TotalPrice = TotalPrice;
            this.City = City;
            this.State = State;
            this.ZipCode = ZipCode;
            this.DesAddress = DesAddress;
            this.CreatedDate = DateTime.Now;
            this.UserId = UserId;
        }
        #region Relations
        public virtual User User { get; private set; }
        #endregion
    }
}
