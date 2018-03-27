using Common.Mapping;
using Models;
using System;

namespace DTO
{
    public class BankCardModel: IMapFrom<BankCard>
    {
        public int Id { get; set; }

        public string Number { get; set; }

        public DateTime? ExpirationDate { get; set; }

        public string Name { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }

        public string ExpDateAsString
        {
            get
            {
                if (this.ExpirationDate == null)
                {
                    return string.Empty;
                }
                else
                {
                    var date = (DateTime)this.ExpirationDate;
                    return date.ToString("MM/yy");
                }
            }
        }
    }
}
