using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace KMSCreator
{
    class Program
    {

        static void Main(string[] args)
        {
            var kmdFiles = Directory.GetFiles("Data", "*.json");
            foreach (var kmdFile in kmdFiles)
            {
                var creator = new KmdCreator(kmdFile, "Templates", "../../../../Kurento.NET");
                creator.Execute();
            }
        }

    }



}
