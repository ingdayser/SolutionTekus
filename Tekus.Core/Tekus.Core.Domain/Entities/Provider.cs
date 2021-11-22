using System;
using System.Collections.Generic;



namespace Tekus.Core.Domain.Entities
{
    public  class Provider
    {
        public Provider()
        {
            CustomAttributes = new HashSet<CustomAttribute>();
            ServiceProviders = new HashSet<ServiceProvider>();
        }

        public Guid Id { get; set; }
        public string Nit { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public DateTime CreatedAt { get; set; }

        public virtual ICollection<CustomAttribute> CustomAttributes { get; set; }
        public virtual ICollection<ServiceProvider> ServiceProviders { get; set; }
    }
}
