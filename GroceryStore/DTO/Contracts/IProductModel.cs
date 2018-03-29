namespace DTO.Contracts
{
    public interface IProductModel
    {
        int Id { get; set; }

        string Name { get; set; }

        string Category { get; set; }

        decimal Price { get; set; }

        string Picture { get; set; }
    }
}
