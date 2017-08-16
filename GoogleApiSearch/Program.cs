using System;
using System.Linq;
using Google.Apis.Services;

namespace GoogleApiSearch
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Search Custom API Ejemplo");
            Console.WriteLine("====================");
            try
            {
                RunService();
            }
            catch (AggregateException ex)
            {
                foreach (var e in ex.InnerExceptions)
                {
                    Console.WriteLine("ERROR: " + e.Message);
                }
            }
            Console.WriteLine("Salir!");
            Console.ReadKey();
        }

        private static void RunService()
        {
            // Creacion de la instancia al servicio
            var service = new Google.Apis.Customsearch.v1.CustomsearchService(new BaseClientService.Initializer()
            {
                ApplicationName = "Foca",
                ApiKey = "AIzaSyDh9ps5jddxvrJLf_-_sU37bIPN0FWPB3w"
            });

            Google.Apis.Customsearch.v1.CseResource.ListRequest listRequest = service.Cse.List("Chema Alonso");

            listRequest.Cx = "007045288069262594000:2pxc-78isyw";
            Google.Apis.Customsearch.v1.Data.Search search = listRequest.Execute();

            var count = search.Items.Count(); // Cantidad de Items resultos.
            var listItems = search.Items;     // Lista con los items obtenidos.
        }
    }
}
