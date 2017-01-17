using ProxyDesignPattern.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProxyDesignPattern.Contracts;

namespace ProxyDesignPattern.Proxy
{
    public delegate void OnRequestCompleteEventHandler(object sender, EventArgs e);

    public class ServiceCallProxy : IServiceCall
    {
        private ServiceResponse _response;
        private ServiceCall _serviceCall;

        private bool _isProcessing;
        private bool _isComplete;

        public ServiceRequest Request
        {
            get; set;
        }
        public event OnRequestCompleteEventHandler OnRequestComplete;
        public ServiceResponse Response
        {
            get
            {
                if (_isComplete)
                {
                    return _response;
                }
                else if (_isProcessing)
                {
                    return new ServiceResponse() { AccountStatus = "Processing Request..." };
                }
                else
                {
                    _isProcessing = true;
                    var serviceCallTask = Task<ServiceResponse>.Factory.StartNew(
                        () =>
                        {
                            return CallServicePlaceHolder(Request);
                        }
                        ).ContinueWith(
                        (r) =>
                        {
                            _isComplete = true;
                            _response = r.Result;
                            OnRequestComplete(this, new EventArgs());
                        }
                        );

                    return new ServiceResponse() { AccountStatus = "Processing Request..." };
                    
                }
            }
        }

        private ServiceResponse CallServicePlaceHolder(ServiceRequest request)
        {
            _serviceCall = new ServiceCall() { Request = request };
            return _serviceCall.Response;

        }
    }
}
