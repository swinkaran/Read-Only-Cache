using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.CachedStorage.Entities.DataWriter.Interfaces
{
    public interface IRepositoryWrapper
    {
        IExpenseRepository Expense { get; }
        
    }
}
