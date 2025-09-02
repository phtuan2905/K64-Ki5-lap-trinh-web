namespace LTW_Day03Lab_BTTL.Models
{
    public class Product
    {
        public string Name { get; set; }
        public string Image { get; set; }

        public List<Product> GetProductList()
        {
            List<Product> products = new List<Product>()
            {
                new Product()
                {
                    Name = "Nồi cơm điện cơ Nagakawa NAG0146 (1,8L)",
                    Image = "/images/products/noi_com.jpg",
                },
                new Product()
                {
                    Name = "Nồi cơm điện cơ Nagakawa NAG0146 (1,8L)",
                    Image = "/images/products/noi_com.jpg",
                },
                new Product()
                {
                    Name = "Nồi cơm điện cơ Nagakawa NAG0146 (1,8L)",
                    Image = "/images/products/noi_com.jpg",
                },
            };
            return products;
        }
    }
}
