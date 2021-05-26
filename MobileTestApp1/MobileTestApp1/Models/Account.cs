namespace MobileTestApp1.Models
{
    class Account
    {
        public int CustomerID { get; set; }
        public int Mobile_or_Landline_Number_ { get; set; }
        public string Account_Password_ { get; set; }
        public decimal Credit_Balance_ { get; set; }
        public int Minutes_Balance { get; set; }
        public int Data_Balance_In_MB { get; set; }
        public bool Allow_Credit_transfer_request { get; set; }
        public bool On_contract { get; set; }
        public bool Allow_Notifications { get; set; }
        public int Current_Notification_Count { get; set; }
        public bool Is_Transfer_Verified { get; set; }
    }
}
