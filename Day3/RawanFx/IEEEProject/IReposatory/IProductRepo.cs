using Azure;
using IEEEProject.DTO;
using IEEEProject.Entity;
using IEEEProject.Result;

namespace IEEEProject.IReposatory
{
    public interface IProductRepo
    {
        List<Product> GetAllProduct();
        Product GetProductWithId(int id);
        bool AddProduct(ProductDTO product);
        bool Update(int id,ProductDTO oldProduct);
        bool Delete(int id);
    };
}
