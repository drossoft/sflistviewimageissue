using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sflistviewimageissue.Contracts.Enums
{
    public enum AccountType
    {
        [Description("BankAccount")]
        Bank,
        [Description("CreditCard")]
        CreditCard,
        [Description("Savings")]
        Savings,
        [Description("Wallet")]
        Wallet,
        [Description("All")]
        All
    }
}
