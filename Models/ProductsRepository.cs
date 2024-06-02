namespace MVCMarketCourse.Models
{
    public class ProductsRepository
    {
        private static List<Product> _products = new List<Product>()
        {
            new Product{ProductId = 1, Name ="Iced Tea", CategoryId = 1, Quantity = 100, Price = 34 },
            new Product{ProductId = 2, Name ="Canada Dry", CategoryId = 1, Quantity = 100, Price = 314 },
            new Product{ProductId = 3, Name ="Whole Wheat Bread", CategoryId = 2, Quantity = 100, Price = 234 },
            new Product{ProductId = 4, Name ="White Bread", CategoryId = 2, Quantity = 100, Price = 3334 }
        };

        public static void AddProduct(Product product)
        {
            if(_products!=null && _products.Count>0)
            {
                var maxId = _products.Max(p => p.ProductId);
                product.ProductId = maxId + 1;
            }
            else { product.ProductId = 1; }
            if(_products == null) _products = new List<Product>();
            _products.Add(product);
        }

        public static List<Product>? GetProducts(bool loadCategory=false)
        {
            if (loadCategory == false)
            {
                return _products;
            }
            else
            {
                if (_products.Count() > 0 && _products != null)
                {
                    foreach (var product in _products)
                    {
                        if (product.CategoryId.HasValue)
                            product.Category = CategoriesRepository.GetCategoryById(product.CategoryId.Value);
                    }
                    return _products;
                }
                return new List<Product>();
            }
        }
       

        public static void UpdateProduct(int productId, Product product)
        {
            if (productId != product.ProductId) return;
            var productToUpdate = _products.FirstOrDefault(p => p.ProductId == productId);
            if (productToUpdate != null)
            {
                productToUpdate.Price = product.Price;
                productToUpdate.Name = product.Name;
                productToUpdate.CategoryId = product.CategoryId;
                productToUpdate.Quantity = product.Quantity;
            }
        }

        public static Product? GetProductById(int productId, bool loadCategory=false)
        {
            var product = _products.FirstOrDefault(p => p.ProductId == productId);
            if (product != null)
            {
                var prod = new Product { ProductId = product.ProductId, Name = product.Name, CategoryId = product.CategoryId, Price = product.Price, Quantity=product.Quantity };
                if (loadCategory == false)
                    return prod;
                else
                {
                    if (prod.CategoryId.HasValue)
                        prod.Category = CategoriesRepository.GetCategoryById(prod.CategoryId.Value);
                    return prod;
                }
            }
            return null;
        }


        public static void DeleteProduct(int productId)
        {
            var product = _products.FirstOrDefault(x => x.ProductId == productId);
            if (product != null)
            {
                _products.Remove(product);
            }
        }

        public static List<Product> GetProductsByCategoryId(int categoryId)
        {
            var products = _products.Where(x => x.CategoryId == categoryId);
            if (products!=null)
                return products.ToList();
            else
                return new List<Product>();
        }
    }
}
