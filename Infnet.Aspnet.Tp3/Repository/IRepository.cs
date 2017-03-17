using Infnet.Aspnet.Tp3.Entities;
using System.Collections.Generic;

namespace Infnet.Aspnet.Tp3.Repository
{
    public interface IRepository
    {
        TObject GetData<TObject>(int id) where TObject : BaseEntity, new();
        List<TObject> GetListData<TObject>() where TObject : BaseEntity, new();
        bool UpdateData(int id);
        bool DeleteData(int id);
        bool InsertData(object data);
    }
}
