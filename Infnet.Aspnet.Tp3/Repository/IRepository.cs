using System.Collections.Generic;

namespace Infnet.Aspnet.Tp3.Repository
{
    public interface IRepository<T>
    {
        T GetData(int id);
        List<T> GetListData();
        bool UpdateData(int id);
        bool DeleteData(int id);
        bool InsertData(T data);
    }
}
