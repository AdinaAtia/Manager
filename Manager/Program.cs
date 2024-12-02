using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Manager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //string connectionString = "Data Source = SRV2\PUPILS; Initial Catalog = api_ado; Integrated Security = True; Trust Server Certificate = True";
            string connectionString = "data source=SRV2\\PUPILS;initial catalog=Product;Integrated Security=SSPI;Persist Security Info=False;TrustServerCertificate=true";
            DataAccess DataAccess = new DataAccess();
            DataAccess.AddCategory(connectionString);
            DataAccess.AddProuduct(connectionString);
            DataAccess.getAllProduct(connectionString);
            DataAccess.getAllCategory(connectionString);
        }
    }
}
