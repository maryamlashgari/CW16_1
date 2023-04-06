using CW16_1.Models;

namespace CW16_1.Repository
{
    public interface IProdcutRepository
    {
        void DeleteProduct(int id);
        List<Product> GetListOfProducts();
        Product GetProductById(int id);
        void InsertProduct(Product product);
        void UpdateProduct(Product product);
    }
}