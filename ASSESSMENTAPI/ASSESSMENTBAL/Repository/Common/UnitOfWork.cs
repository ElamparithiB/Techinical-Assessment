using ASSESSMENTBAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TECHINICALBAL.Repository.Common
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(ICommonRepository commonRepository, IBookRepository bookRepository)
        {
            this.CommonRepository = commonRepository;
            this.BookRepository = bookRepository;
        }

        public ICommonRepository CommonRepository { get; }
        public IBookRepository BookRepository { get; }
    }
}
