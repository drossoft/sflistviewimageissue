using Microsoft.Maui.Controls;
using Microsoft.Maui.Platform;
using sflistviewimageissue.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace sflistviewimageissue.Services
{
    public class DatabaseService
    {

        private const string DatabaseName = "sample_sqlite.db";
        private string _databasePath;

        #region Fields

        private SQLiteAsyncConnection _dbConnection;

        #endregion

        #region Public Methods

        public async Task InitializeAsync()
        {
            _databasePath = Path.Combine(FileSystem.AppDataDirectory, DatabaseName);

            _dbConnection = new SQLiteAsyncConnection(_databasePath, false);

            await _dbConnection.CreateTableAsync<AccountItem>();
            await _dbConnection.CreateTableAsync<ImageItem>();

            if (await _dbConnection.Table<AccountItem>().CountAsync() == 0)
            {
                await InsertTestDataAsync();
            }
        }

        private async Task InsertTestDataAsync()
        {
            Random rnd = new Random();

            //Insert images
            //Apple
            ImageItem image = new ImageItem();
            image.ImageIndex = 3;
            image.ImageData = ImageSourceToByteArrayAsync("apple.png");
            await _dbConnection.InsertAsync(image);

            //Xbox
            ImageItem image2 = new ImageItem();
            image2.ImageIndex = 4;
            image2.ImageData = ImageSourceToByteArrayAsync("xbox.png");
            await _dbConnection.InsertAsync(image2);

            //Insert accounts
            for (int i=1; i<=100; i++)
            {
                AccountItem account = new AccountItem();
                account.Id = i;
                account.Name = $"Account {i}";
                account.ImageIndex = rnd.Next(4) + 1;

                await _dbConnection.InsertAsync(account);
            }

        }

        public byte[] ImageSourceToByteArrayAsync(string fileName)
        {

            var assem = Assembly.GetExecutingAssembly();
            using var stream = assem.GetManifestResourceStream($"sflistviewimageissue.Resources.Images.{fileName}");
            byte[] bytesAvailable = new byte[stream.Length];
            stream.Read(bytesAvailable, 0, bytesAvailable.Length);
            return bytesAvailable;
        }

        public async Task<List<AccountItem>> GetAccounts()
        {
            var accounts = await _dbConnection.Table<AccountItem>().ToListAsync();

            return accounts;
        }

        internal ImageItem GetImageItem(int imageIndex)
        {
            var item = _dbConnection.Table<ImageItem>().FirstOrDefaultAsync(i => i.ImageIndex == imageIndex);

            if (item == null)
                return null;
            return item.Result;
        }

        #endregion

        #region Image methods

        #endregion
    }
}
