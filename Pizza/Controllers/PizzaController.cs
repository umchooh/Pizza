using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.Web.UI.WebControls;
using Microsoft.Ajax.Utilities;

namespace Pizza.Controllers
{
    public class PizzaController : Controller
    {
        // GET: /Pizza/Index
        public ActionResult Index()
        {
            return View();
        }

        // POST:/Pizza/OrderConfirm 
        public ActionResult OrderConfirm(string pizza_size, int pizza_crust, string[] Toppings)
        {
            Debug.WriteLine("The pizza size is " + pizza_size + " and the crust option is " + pizza_crust);
            //Debug.WriteLine("The total toppings is " + Toppings.Length + " They are " + string.Join(", ", Toppings));
            
            decimal size_cost = 0;
            if (pizza_size == "SM") size_cost = 6.00M;
            if (pizza_size == "MD") size_cost = 8.00M;
            if (pizza_size == "LG") size_cost = 11.00M;

            decimal crust_cost = 0;
            if (pizza_crust == 1) crust_cost = 7.00M;
            if (pizza_crust == 0) crust_cost = 6.00M;
            
            decimal toppings_cost = 0;
            for (int i = 1; i < Toppings.Length - 1; i++)
            {

                if ("cheese".Equals(Toppings) == true || "mushroom".Equals(Toppings) == true)
                {
                    toppings_cost = Toppings.Length*1.00M;
                }
            }

            decimal total_cost = size_cost + crust_cost + toppings_cost;
            ViewBag.Cost = total_cost;
            Debug.WriteLine("The total cost of your order is $" + total_cost );
            return View();
        }
    }
}