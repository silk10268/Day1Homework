using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Product
{
    public class HomeWorkSample
    {
        private List<Product> _products;
        
        public List<Product> ProductCollection
        {
            get { return _products; }
            set { _products = value; }
        }
                /// <summary>
        /// Constructor
        /// </summary>
        public HomeWorkSample()
        {
            _products = new List<Product>
            {
                new Product { Id=1, Cost=1,Revenue=11,SellPrice=21},
                new Product { Id=2, Cost=2,Revenue=12,SellPrice=22},
                new Product { Id=3, Cost=3,Revenue=13,SellPrice=23},
                new Product { Id=4, Cost=4,Revenue=14,SellPrice=24},
                new Product { Id=5, Cost=5,Revenue=15,SellPrice=25},
                new Product { Id=6, Cost=6,Revenue=16,SellPrice=26},
                new Product { Id=7, Cost=7,Revenue=17,SellPrice=27},
                new Product { Id=8, Cost=8,Revenue=18,SellPrice=28},
                new Product { Id=9, Cost=9,Revenue=19,SellPrice=29},
                new Product { Id=10, Cost=10,Revenue=20,SellPrice=30},
                new Product { Id=11, Cost=11,Revenue=21,SellPrice=31}
            };
        }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="products"></param>
        public HomeWorkSample(List<Product> products)
        {
            _products = products;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="count"></param>
        /// <param name="field"></param>
        /// <returns></returns>
        public List<int> GetProductGroup(int count,string field)
        {
            if (count == 0 || count > _products.Count)
            {
                Console.WriteLine(string.Format("請傳入數字[1-{0}]",_products.Count));
                return null;
            }
            
            PropertyInfo prop = typeof(Product).GetProperties().Where(x => x.Name == field).First();
            if (prop == null)
            {
                Console.WriteLine("請傳入Product任一Property");
                return null;
            }
            var target = _products.Select((x) => prop.GetValue(x));

            List<int> result = new List<int>();
            int subSum = 0;
            for (int i = 0; i < _products.Count; i++)
            {
                subSum += Convert.ToInt32(target.ToList()[i]);
                if ((i+1) % count == 0)
                {
                    result.Add(subSum);
                    subSum = 0;
                }
                else if(i == _products.Count - 1)
                {
                    result.Add(subSum);
                    subSum = 0;
                }
            }
            return result;
        }

    }
}
