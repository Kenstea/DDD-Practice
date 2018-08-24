namespace DomainCore.Models
{
    public class ServerViewModel : BusinessModelBase<int>
    {  
        public string Name { get; set; }

        public string Description { get; set; }

        public int StatusId { get; set; }

        public int EnterpriseId { get; set; }

        public Constant.ServerStatusType StatusType => (Constant.ServerStatusType)StatusId;
    }
}