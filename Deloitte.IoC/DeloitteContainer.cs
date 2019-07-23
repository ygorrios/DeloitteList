using Deloitte.Business.Business;
using Deloitte.Business.Interface;
using Deloitte.Repository;
using Deloitte.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace Deloitte.IoC
{
    public static class DeloitteContainer
    {
        public static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<IUserBusiness, UserBusiness>();
            container.RegisterType<ITaskBusiness, TaskBusiness>();

            container.RegisterType<IUserRepository, UserRepository>();
            container.RegisterType<ITaskRepository, TaskRepository>();
        }
    }
}
