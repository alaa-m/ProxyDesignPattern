using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProxyDesignPattern.Contracts;
using System.Threading;
using ProxyDesignPattern.Proxy;

namespace ProxyDesignPattern.Components
{
    public class ServiceCall : IServiceCall
    {
        public ServiceRequest Request
        {
            get;set;
        }

        public ServiceResponse Response
        {
            get
            {
                return CallService(Request);
            }
        }

        public event OnRequestCompleteEventHandler OnRequestComplete;

        private ServiceResponse CallService(ServiceRequest request)
        {
            Thread.Sleep(5000);
            return new ServiceResponse() { AccountStatus = "Account is Activated." };
        }
    }
}
