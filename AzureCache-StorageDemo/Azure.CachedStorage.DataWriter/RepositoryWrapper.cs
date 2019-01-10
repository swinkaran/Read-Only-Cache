using Azure.CachedStorage.Entities.DataWriter.Interfaces;
using Azure.CachedStorage.Entities;

namespace Azure.CachedStorage.Entities.DataWriter
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private RepositoryContext _repoContext;
        private IExpenseRepository _Expense;
        //private IAccountRepository _account;

        public IExpenseRepository Expense
        {
            get
            {
                if (_Expense == null)
                {
                    _Expense = new ExpenseRepository(_repoContext);
                }

                return _Expense;
            }
        }

        //public IAccountRepository Account
        //{
        //    get
        //    {
        //        if (_account == null)
        //        {
        //            _account = new AccountRepository(_repoContext);
        //        }

        //        return _account;
        //    }
        //}

        public RepositoryWrapper(RepositoryContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }
    }
}
