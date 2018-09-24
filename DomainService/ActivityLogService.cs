using DomainModel.Interfaces.Repository.Log;
using DomainModel.Log;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainService
{
    public class ActivityLogService<T> where T : ActivityLogBase
    {
        IActivityLogRepository<T> _activityLogRepository;

        public ActivityLogService(IActivityLogRepository<T> activityLogRepository)
        {
            _activityLogRepository = activityLogRepository;
        }

        public void RegisterActivity(T activity)
        {
            _activityLogRepository.Create(activity);
        }
    }
}
