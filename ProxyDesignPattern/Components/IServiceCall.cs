using ProxyDesignPattern.Contracts;
using ProxyDesignPattern.Proxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyDesignPattern.Components
{
    public interface IServiceCall
    {
         ServiceRequest Request
        { get; set; }

        ServiceResponse Response
        {
            get;
        }

        event OnRequestCompleteEventHandler OnRequestComplete;

    }
}
