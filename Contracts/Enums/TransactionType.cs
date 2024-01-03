using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace sflistviewimageissue.Contracts.Enums
{
    public enum TransactionType
    {
        [Description("Income")]
        Income,
        [Description("Expense")]
        Expense,
        [Description("Transfer")]
        Transfer,
        [Description("LoanPayment")]
        Loan,
        [Description("LoanAmortization")]
        LoanAmortization,
        [Description("All")]
        All
    }
}
