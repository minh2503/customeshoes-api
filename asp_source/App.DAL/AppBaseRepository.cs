using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using System.Data;
using TFU.DAL;
using TFU.EntityFramework;

namespace App.DAL
{
    public class AppBaseRepository : BaseRepository
    {
        IDbContextTransaction _transaction;
        private bool _existedTransaction;
        public ApplicationDbContext _dbAppContext;
        public AppBaseRepository(IConfiguration config, TFUDbContext dbTFUContext, ApplicationDbContext dbAppContext) : base(config, dbTFUContext)
        {
            _dbAppContext = dbAppContext;
            _transaction = dbAppContext.Database.CurrentTransaction;
        }
        public IDbTransaction Transaction
        {
            get
            {
                if ((_transaction = _dbAppContext.Database.CurrentTransaction) != null)
                {
                    return _transaction.GetDbTransaction();
                }
                return null;
            }
        }
        protected override IDbConnection Connection
        {
            get
            {
                if (_transaction != null)
                    return _transaction.GetDbTransaction().Connection;
                else if ((_transaction = _dbAppContext.Database.CurrentTransaction) != null)
                {
                    return _transaction.GetDbTransaction().Connection;
                }
                return base.Connection;
            }
        }
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            _transaction?.Dispose();
        }

        /// <summary>
        /// begin the transaction
        /// </summary>
        protected void BeginTransaction()
        {
            _transaction = _dbAppContext.Database.CurrentTransaction;
            _existedTransaction = _transaction != null;
            if (!_existedTransaction)
                _transaction = _dbAppContext.Database.BeginTransaction();
        }
        /// <summary>
        /// End the transaction
        /// </summary>
        protected void EndTransaction()
        {
            if (!_existedTransaction)
            {
                _transaction.Commit();
                _transaction.Dispose();
                _transaction = null;
            }
        }
        /// <summary>
        /// Rollback data while having error in the transaction
        /// </summary>
        protected void CancelTransaction()
        {
            if (!_existedTransaction)
                _transaction.Rollback();
        }

        /// <summary>
        /// Save all changes in the context
        /// </summary>
        protected async Task<bool> SaveAsync()
        {
            return await _dbAppContext.SaveChangesAsync() > 0;
        }
    }
}
