using ServiceStack;
using SSTest.ServiceModel;
using System.Collections.Generic;

namespace SSTest.ServiceInterface
{
    public class MyServices : Service
    {
        public static Dictionary<string, SSTest.ServiceModel.Bill> Bills { get; set; }

        public MyServices()
        {
            Bills = new Dictionary<string, SSTest.ServiceModel.Bill>();

            var myBill = new SSTest.ServiceModel.Bill { BillID = "DF77F8AD-CAFA-4470-94DC-D5FD2331515F", BillNo = "1", Description = "Desktop Computer" };
            Bills.Add(myBill.BillID, myBill);

            myBill = new SSTest.ServiceModel.Bill { BillID = "1173DAB3-0DC9-4D28-AC68-75AF6581B6ED", BillNo = "2", Description = "Laptop Computer" };
            Bills.Add(myBill.BillID, myBill);
        }


        public SSTest.ServiceModel.Bill Get(SSTest.ServiceModel.BillGETRequest request)
        {
            return Bills[request.BillID];
        }

        public SSTest.ServiceModel.Bill Post(BillPOSTRequest request)
        {
            string newID = System.Guid.NewGuid().ToString();
            var myBill = new SSTest.ServiceModel.Bill { BillID = newID, BillNo = (Bills.Count + 1).ToString(), Description = request.Description };
            Bills.Add(myBill.BillID, myBill);

            return myBill;
        }
    }
}
