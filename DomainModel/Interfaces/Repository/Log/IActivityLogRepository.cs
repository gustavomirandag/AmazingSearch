using DomainModel.Log;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.Interfaces.Repository.Log
{
    public interface IActivityLogRepository<T> : IRepository<T> where T : ActivityLogBase
    {
    }
}
