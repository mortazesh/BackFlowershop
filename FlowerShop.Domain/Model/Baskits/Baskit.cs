using FlowerShop.Domain.Model.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerShop.Domain.Model.Baskits
{
    public class Baskit
    {
        [Key]
        public int Id { get; set; }
        public string UserId { get; set; }
        private readonly List<BaskitItem> baskitItems = new List<BaskitItem>();
        public Baskit(string UserId)
        {
            this.UserId = UserId;
        }
        public void AddBaskitItem(string Name, int Amount, string Price, string UrlImage)
        {
            baskitItems.Add(new BaskitItem(Name, Amount, Price, UrlImage, Id));
        }
        #region Relations
        public virtual User User { get; private set; }
        public virtual ICollection<BaskitItem> BaskitItems => baskitItems;
        #endregion
    }
}
