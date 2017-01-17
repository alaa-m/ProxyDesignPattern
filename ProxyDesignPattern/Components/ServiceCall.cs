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
    //real service client
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

        //this method simulate a time consuming service operation calling or any other time consuming operation.
        private ServiceResponse CallService(ServiceRequest request)
        {
            //for consume some time...
            Thread.Sleep(5000);

            return new ServiceResponse() { AccountStatus = "Account is Activated." };
        }
    }
}
