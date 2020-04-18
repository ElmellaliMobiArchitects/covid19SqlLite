using covid19.TablesSql;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace covid19.Data
{
    public class Database
    {
        readonly SQLiteAsyncConnection database;

        public Database(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<TableResultatModel>().Wait();
        }

        public Task<List<TableResultatModel>> GetItemsAsync()
        {
            return database.Table<TableResultatModel>().ToListAsync();
        }

        public Task<List<TableResultatModel>> GetItemsNotDoneAsync()
        {
            return database.QueryAsync<TableResultatModel>("SELECT * FROM [TableResultatModel]");
        }

        public Task<TableResultatModel> GetItemAsync(int id)
        {
            return database.Table<TableResultatModel>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(TableResultatModel item)
        {
            if (item.Id != 0)
            {
                return database.UpdateAsync(item);
            }
            else
            {
                return database.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemAsync(TableResultatModel item)
        {
            return database.DeleteAsync(item);
        }
    }
}