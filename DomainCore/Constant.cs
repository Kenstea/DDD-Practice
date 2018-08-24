namespace DomainCore
{
    public class Constant
    {
        /// <summary>
        /// Server status
        /// </summary>
        public enum ServerStatusType
        {
            /// <summary>
            /// The not available
            /// </summary>
            NotAvailable = 0,

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
    }
}