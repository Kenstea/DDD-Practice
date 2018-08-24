using System.Collections.Generic;
using System.Linq;

namespace DomainCore.Models
{
    public class EnterpriseViewModel: BusinessModelBase<int>
    {   
        public string ShortName { get; set; }

        public string FullName { get; set; }

        public string Address { get; set; }

        public ICollection<ServerViewModel> Servers { get; set; }
      
        public Constant.ServerStatusType ServerStatus
        {
            get
            {
                var serverStatuses = Servers != null && Servers.Count > 0
                    ? Servers.OrderByDescending(e => e.StatusId).Select(e => e.StatusType)
                        .FirstOrDefault()
                    : Constant.ServerStatusType.NotAvailable;
                return serverStatuses;
            }
        }
    }
}