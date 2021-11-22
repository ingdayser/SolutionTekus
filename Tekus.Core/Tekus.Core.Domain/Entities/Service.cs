using System;
using System.Collections.Generic;



namespace Tekus.Core.Domain.Entities
{
    public class Service
    {
        public Service()
        {
            ServiceProviders = new HashSet<ServiceProvider>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Value { get; set; }
        public DateTime CreaterAt { get; set; }

        public virtual ICollection<ServiceProvider> ServiceProviders { get; set; }
    }
}
