using ServiceStack;
using System;

namespace SSTest.ServiceModel
{
    public class Bill
    {
        virtual public string BillID { get; set; }
        virtual public string BillNo { get; set; }
        virtual public string Description { get; set; }
        virtual public Nullable<bool> IsEnabled { get; set; }
        virtual public Nullable<decimal> MaximumProductionCapability { get; set; }
        virtual public Nullable<System.DateTime> LastSavedDateTime { get; set; }
        virtual public byte[] RowHash { get; set; }
        virtual public ProductionLine ProductionLine { get; set; } = new ProductionLine();
    }

    public class ProductionLine
    {
        virtual public string ProductionLineID { get; set; }
        virtual public string Name { get; set; }
        virtual public string Description { get; set; }
        virtual public Nullable<bool> IsEnabled { get; set; }
    }

    public class BillGETRequest : IReturn<Bill>
    {
        public string BillID { get; set; }
    }

    public class BillPOSTRequest : Bill, IReturn<Bill>
    {
        [Input(Disabled = true)]
        public override string BillID { get; set; }
    }
}
