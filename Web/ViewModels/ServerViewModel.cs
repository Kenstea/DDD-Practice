using Gnnovation.SIMS.Constants;

namespace Gnnovation.SIMS.ViewModels
{
    public class ServerViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int StatusId { get; set; }
        
        public Constant.ServerStatusType StatusType => (Constant.ServerStatusType)StatusId;
    }
}