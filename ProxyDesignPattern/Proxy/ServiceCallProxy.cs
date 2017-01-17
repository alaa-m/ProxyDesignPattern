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


    //The Proxy which will hold the request in place until the request complete.
    public class ServiceCallProxy : IServiceCall
    {
        private ServiceResponse _response;
        private ServiceCall _serviceCall;

        //indicators to get the status of the requests.
        private bool _isProcessing;
        private bool _isComplete;

        public ServiceRequest Request
        {
            get; set;
        }

        //event which triggered when the request complete.
        public event OnRequestCompleteEventHandler OnRequestComplete;

        //a lazy loading Respones which call the service on the first use of it 
        //and trigger the event when the request complete.
        public ServiceResponse Response
        {
            get
            {
                //the request is already completed.
                if (_isComplete)
                {
                    return _response;
                }
                //the request is on progress so return a place holding result.
                else if (_isProcessing)
                {
                    return new ServiceResponse() { AccountStatus = "Processing Request..." };
                }
                
                else
                {
                    //this is the first use of the Response so should set isProgress to true and call the real service client
                    _isProcessing = true;
                    //call the real service client in different thread.
                    var serviceCallTask = Task<ServiceResponse>.Factory.StartNew(
                        () =>
                        {
                            return CallServicePlaceHolder(Request);
                        }
                        ).ContinueWith(
                        (r) =>
                        {
                            //when the request is complete raise the event and set IsComplete to true.
                            _isComplete = true;
                            _response = r.Result;
                            OnRequestComplete(this, new EventArgs());
                        }
                        );
                    //first use of Response and the request is not completed yet so should return a place holding result also.
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
