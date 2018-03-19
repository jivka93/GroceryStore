using Common.Mapping;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class BankCardModel: IMapFrom<BankCard>
    {
        public string Number { get; set; }

        public DateTime ExpirationDate { get; set; }

        public string Name { get; set; }

        //do we need this ?
        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}
