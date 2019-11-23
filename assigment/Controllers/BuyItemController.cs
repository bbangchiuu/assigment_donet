using assigment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace assigment.Controllers
{
    public class BuyItemController : Controller
    {
        private MyDbContext db = new MyDbContext();
        BuyItem buyItem = new BuyItem();
        // GET: BuyItem
        public ActionResult Index()
        {
            ViewBag.list_pro = Session["buyItem"];
            return View();
        }

        public int AddItem(int pro_id, int quantity)
        {
            if(Session["buyItem"] == null)
            {
                Product product = db.Products.Find(pro_id);
                buyItem.AddProduct(product, quantity);
                Session["TotalQuantity"] = quantity;
                Session["TotalPrice"] = product.Price * quantity;
                Session["buyItem"] = buyItem.ListProducts;
            }
            else
            {
                buyItem.ListProducts = Session["buyItem"] as List<Product>;
                Boolean checkSP = true;
                for(int i = 0; i < buyItem.ListProducts.Count; i++)
                {
                    if(buyItem.ListProducts.ElementAt(i).ProductId == pro_id)
                    {
                        buyItem.ListProducts.ElementAt(i).Quantity += quantity;
                        checkSP = false;
                        break;
                    }
                }
                if (checkSP)
                {
                    Product product = db.Products.Find(pro_id);
                    buyItem.AddProduct(product, quantity);
                }

                var totalprice = 0;
                var totalQuantity = 0;
                foreach(var val in buyItem.ListProducts)
                {
                    totalprice += (int)val.Price * val.Quantity;
                    totalQuantity += val.Quantity;
                }

                Session["TotalQuantity"] = totalQuantity;
                Session["TotalPrice"] = totalprice;
                Session["buyItem"] = buyItem.ListProducts;
            }

            if(Session["TotalQuantity"] != null)
            {
                return (int) Session["TotalQuantity"];
            }

            return quantity;
        }

        public void Delete_order(int id)
        {
            for (int i = 0; i < buyItem.ListProducts.Count; i++)
            {
                if (buyItem.ListProducts.ElementAt(i).ProductId == id)
                {
                    buyItem.ListProducts.RemoveAt(i);
                }
            }

            if(buyItem.ListProducts.Count == 0)
            {
                Session["TotalQuantity"] = null;
                Session["TotalPrice"] = null;
                Session["buyItem"] = null;
            }
            else
            {
                var totalprice = 0;
                var totalQuantity = 0;
                foreach (var val in buyItem.ListProducts)
                {
                    totalprice += (int)val.Price * val.Quantity;
                    totalQuantity += val.Quantity;
                }
                Session["TotalQuantity"] = totalQuantity;
                Session["TotalPrice"] = totalprice;
                Session["buyItem"] = buyItem.ListProducts;
            }           

            Response.Redirect("/BuyItem/Index");
        }
    }  
}