using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerShop.Domain.Model.Baskits
{
    public class BaskitItem
    {
        [Key]
        public int Id { get; private set; }
        public string Name { get; private set; }
        public int Amount { get; private set; }
        public string Price { get; private set; }
        public string UrlImage { get; private set; }
        public int BaskitId { get; private set; }
        public BaskitItem(string Name, int Amount, string Price, string UrlImage,int BaskitId)
        {
            this.Name = Name;
            this.Amount = Amount;
            this.Price = Price;
            this.UrlImage = UrlImage;
            this.BaskitId = BaskitId;
        }
        #region Relations
        public virtual Baskit Baskit { get; private set; }
        #endregion
    }
}
