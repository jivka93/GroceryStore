using Models;
using System;

namespace DTO.Contracts
{
    public interface IBankCardModel
    {
        int Id { get; set; }

        string Number { get; set; }

        DateTime? ExpirationDate { get; set; }

        string Name { get; set; }

        int UserId { get; set; }

        User User { get; set; }

        string ExpDateAsString { get; }
    }
}
