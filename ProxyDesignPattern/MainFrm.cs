using ProxyDesignPattern.Components;
using ProxyDesignPattern.Contracts;
using ProxyDesignPattern.Proxy;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProxyDesignPattern
{
    public partial class MainFrm : Form
    {
        IServiceCall serviceProxy;
        public MainFrm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //declate service proxy.
            serviceProxy = new ServiceCallProxy();
            //subscribe to on complete event to show the response.
            serviceProxy.OnRequestComplete += ServiceProxy_OnRequestComplete;
            //initiate the request.
            serviceProxy.Request = new ServiceRequest() { UserName = "admin", Password = "1234" };
            //show place holding response.
            resultLBL.Text = serviceProxy.Response.AccountStatus;

            
            callServiceBTN.Enabled = false;
            refreshBTN.Enabled = true;
        }

        private void ServiceProxy_OnRequestComplete(object sender, EventArgs e)
        {
            //access label from a different thread.
            if (this.resultLBL.InvokeRequired)
            {
                this.resultLBL.BeginInvoke((MethodInvoker)delegate () { this.resultLBL.Text = serviceProxy.Response.AccountStatus; ; });
            }
            else
            {
                //show real response.
                this.resultLBL.Text = serviceProxy.Response.AccountStatus ;
            }
        }

        private void refreshBTN_Click(object sender, EventArgs e)
        {
            resultLBL.Text = serviceProxy.Response.AccountStatus;
        }
    }
}
