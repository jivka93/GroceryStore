using Models;
using System;
using System.Collections.Generic;

namespace DTO.Contracts
{
    public interface IOrderModel
    {
        int Id { get; set; }

        DateTime Date { get; set; }

        decimal Total { get; set; }

        string Status { get; set; }

        int UserId { get; set; }

        User User { get; set; }

        ICollection<ProductModel> Products { get; set; }
    }
}
