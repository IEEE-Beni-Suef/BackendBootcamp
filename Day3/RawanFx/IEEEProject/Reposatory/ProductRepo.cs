using Azure;
using IEEEProject.Context;
using IEEEProject.DTO;
using IEEEProject.Entity;
using IEEEProject.IReposatory;
using IEEEProject.Result;

namespace IEEEProject.Reposatory
{
    public class ProductRepo:IProductRepo
    {
        private readonly AppDbContext context;
        public ProductRepo (AppDbContext context)
        {
            this.context = context;
        }

        public bool AddProduct(ProductDTO product)
        {
            Product p = new Product()
            {
                count = product.count,
                description = product.description,
                name = product.name
            };
            try
            {
                context.Product.Add(p);
                context.SaveChanges();
                return true;
            }
            catch { return false; }
           
        }

        public bool Delete(int id)
        {
            Product product = GetProductWithId(id);
            if (product == null)
                return false;
            context.Product.Remove(product);
            context.SaveChanges();
            return true;
        }

        public List<Product> GetAllProduct()
        {
            return context.Product.ToList();
        }

        public Product GetProductWithId(int id)
        {
          return  context.Product.Where(x => x.id == id).FirstOrDefault();
        }

        public bool Update(int id, ProductDTO dto)
        {
            Product existingProduct = GetProductWithId(id);
            if (existingProduct == null)
                return false;
            existingProduct.name = dto.name;
            existingProduct.count = dto.count;
            existingProduct.description = dto.description;

            context.SaveChanges();
            return true;

        }
    }
}
