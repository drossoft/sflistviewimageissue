using sflistviewimageissue.Contracts.Interfaces;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sflistviewimageissue.Model
{
    [Table("Accounts")]
    public class AccountItem : IModelBase
    {
        #region Database properties
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public int ImageIndex { get; set; }
        public double Balance { get; set; }
        #endregion

    }
}
