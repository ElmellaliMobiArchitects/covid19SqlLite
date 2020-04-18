using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using covid19.Data;
using Plugin.Toast;
using Bogus;
using covid19.Models;
using Newtonsoft.Json;
using covid19.TablesSql;
using Database = covid19.Data.Database;

namespace covid19
{
    public partial class App : Application
    {

        private static Page page;

        private static Database database;

        public static Database Database
        {
            get
            {
                return database ?? (database = new Database(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "covid.db3")));
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override async void OnStart()
        {

            var dataFaker = new Faker<FakeData>()
                 .StrictMode(true)
                 .RuleFor(o => o.latitude, f => f.Random.Double(33.600000, 33.600600))
                 .RuleFor(o => o.longitude, f => f.Random.Double(-7.600000, -7.600000))
                 .RuleFor(o => o.deviceId, f => "66d565z54545Az5")
                 .RuleFor(o => o.date, f => f.Date.Between(DateTime.Parse("01/01/2019 10:00"), DateTime.Parse("01/01/2019 11:00")));


            var listUser1 = dataFaker.Generate(9000);

            //foreach (var item in listUser1)
            //{
            //    var result = JsonConvert.SerializeObject(item);
            //    var TableData = new TableResultatModel();

            //    TableData.Data = result;

            //    var test = await App.Database.SaveItemAsync(TableData);

            //}


            //var startTimeSpan = TimeSpan.Zero;
            //var periodTimeSpan = TimeSpan.FromMinutes(1);

            //var timer = new System.Threading.Timer(async (e) =>
            //{
            //    CrossToastPopUp.Current.ShowToastMessage("Message");

            //}, null, startTimeSpan, periodTimeSpan);
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
