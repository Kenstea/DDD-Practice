namespace Gnnovation.SIMS.Models
{
    public enum Status
    {
        /// <summary>
        /// The good
        /// </summary>
        Good = 1,

        /// <summary>
        /// The warning
        /// </summary>
        Warning = 2,

        /// <summary>
        /// The critical
        /// </summary>
        Critical = 3
    }

    public class EnterpriseViewModel
    {
        public EnterpriseViewModel(string name, Status status)
        {
            Name = name;
            Status = status;
        }

        public int ID { get; set; }

        public string Name { get; set; }

        public Status Status { get; set; }

        public string ShortName { get; set; }

        public string FullName { get; set; }

        public string Address { get; set; }
    }
}