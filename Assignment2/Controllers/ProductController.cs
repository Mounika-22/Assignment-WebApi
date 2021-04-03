using Assignment2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Assignment2.Controllers
{
    public class ProductController : ApiController
    {
        static List<Product> _productList = null;
        void Initialize()
        {
            _productList = new List<Product>()
           {
               new Product() { ProductId=1, Name="Books" , QtyInStock=50, Description="Available", Supplier="Amazon"},
            };

        }
        public ProductController()
        {
            if (_productList == null)
            {
                Initialize();
            }
        }
        public IHttpActionResult Get()
        {
            return Ok(_productList);
            
        }
        public IHttpActionResult Get(int id)
        {
            Product product = _productList.FirstOrDefault(x => x.ProductId == id);
            if (product == null)
            {
                return NotFound();
                
            }
            else
            {
                return Ok(product);
               
            }


        }
        public IHttpActionResult Post(Product product)
        {
            if (product != null)
            {
                _productList.Add(product);
            }
            return Content(HttpStatusCode.Created, "Record Created");
           
        }
        public IHttpActionResult Put(int id, Product objProduct)
        {
            Product product = _productList.Where(x => x.ProductId == id).FirstOrDefault();
            if (product == null)
            {
                return NotFound();
                
            }
            else
            {
                if (product != null)
                {
                    foreach (Product temp in _productList)
                    {
                        if (temp.ProductId == id)
                        {
                            temp.Name = objProduct.Name;
                            temp.QtyInStock = objProduct.QtyInStock;
                            temp.Description = objProduct.Description;
                            temp.Supplier = objProduct.Supplier;
                        }
                    }

                }
                return Content(HttpStatusCode.OK, "Record Modified");
               
            }
        }

        public IHttpActionResult Delete(int? id)
        {
            if (id != null)
            {
                Product product = _productList.FirstOrDefault(x => x.ProductId == id);
                if (product == null)
                {
                    return NotFound();
                      }

                else
                {

                    _productList.Remove(product);
                    return Content(HttpStatusCode.OK, "Record deleted");
                        }
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, "Please provide ID");
                  }
        }



    }
}