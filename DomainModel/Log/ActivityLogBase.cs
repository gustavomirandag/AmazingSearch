using DomainModel.Base;
using DomainModel.Entities;
using Nest;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.Log
{
    public abstract class ActivityLogBase : EntityBase
    {
        public DateTime EventDateTime { get; set; }

        public ActivityLogBase()
        {
            EventDateTime = DateTime.Now;
        }
    }
}
