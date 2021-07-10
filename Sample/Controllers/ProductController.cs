using DocumentFormat.OpenXml.Office2010.Excel;
using Sample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sample.Controllers
{
    public class ProductController : Controller
    {
        private ProductsDataContext context;

        public ProductController()
        {
            this.context = new ProductsDataContext();
        }


        // GET: Product
        public ActionResult Index()
        {
            return View();                     
        }
        [HttpGet]
        public ActionResult GetAllProducts()
        {
            try
            {
                IList<ProductModel> productList = new List<ProductModel>();
                var query = from product in context.tblProducts select product;
                var products = query.ToList();

                foreach (var eachProduct in products)
                {
                    productList.Add(new ProductModel()
                    {
                        id = eachProduct.Id,
                        name = eachProduct.Name,
                        price = eachProduct.Price
                    });
                }
                return this.Json(productList, JsonRequestBehavior.AllowGet);
            }catch (Exception e)
            {
                return this.Json(e.Message + "--" + e.InnerException, JsonRequestBehavior.AllowGet);
            }
            
        }
    }
}