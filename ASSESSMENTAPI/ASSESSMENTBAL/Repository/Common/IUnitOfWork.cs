using ASSESSMENTBAL.Repository;

namespace TECHINICALBAL.Repository.Common
{
    public interface IUnitOfWork
    {
        ICommonRepository CommonRepository { get; }
        IBookRepository BookRepository { get; }
    }
}
