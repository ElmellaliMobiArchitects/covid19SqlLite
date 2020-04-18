using Android.App;
using Android.Content;
using covid19.DependencyService;
using covid19.Droid.DroidDependencyService;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

[assembly: Xamarin.Forms.Dependency(typeof(FileHelper))]
namespace covid19.Droid.DroidDependencyService
{
    public class FileHelper : IFileReadWrite
    {

        public void WriteData(string filename, string data)
        {
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var filePath = Path.Combine(documentsPath, filename);
            File.WriteAllText(filePath, data);

        }
        public async Task<string> ReadData(string filename)
        {
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var filePath = Path.Combine(documentsPath, filename);
            var listItems = await App.Database.GetItemsAsync();
            return File.ReadAllText(filePath);
        }
    }

}