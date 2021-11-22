using System;



namespace Tekus.Core.Domain.Entities
{
    public class ServiceProvider
    {
        public Guid Id { get; set; }
        public Guid Provider { get; set; }
        public Guid Service { get; set; }
        public string Country { get; set; }
        public DateTime CreaterAt { get; set; }

        public virtual Provider ProviderNavigation { get; set; }
        public virtual Service ServiceNavigation { get; set; }
    }
}
