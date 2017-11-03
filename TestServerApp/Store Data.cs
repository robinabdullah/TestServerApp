using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.ObjectModel;
using System.Net.NetworkInformation;
using System.Security.AccessControl;
using System.Security.Principal;
namespace TestServerApp.Controllers
{
    
    class DB
    {
        public static POSNew12Entities db = new POSNew12Entities();
        public static void resetConnString()
        {
            db.Dispose();
            db = new POSNew12Entities();
        }
        public static void DBSubmitChanges()
        {
            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.StackTrace);
            }
        }
    }
   
    class ProductTableData : DB
    {
        public static IQueryable<Product> getAllProducts()
        {
            try
            {
                var te = from e in db.Products
                         orderby e.Unique_Barcode.StartsWith("Y")
                         select e;

                return te;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
      
        public static IQueryable<string> getAllProductTypes()
        {
            try
            {
                //var txts = File.ReadAllLines(ProductTypePath).ToList();
                var txts = DB.db.Products
                           .Select(c => new { c.Type, c.Unique_Barcode })
                           .Distinct()
                           .OrderByDescending(x => x.Unique_Barcode)
                           .Select(x => x.Type);


                return txts;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
       
      
    }
    
}