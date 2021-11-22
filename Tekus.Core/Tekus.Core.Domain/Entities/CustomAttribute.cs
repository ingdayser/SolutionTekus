using System;


namespace Tekus.Core.Domain.Entities
{
    public class CustomAttribute
    {
        public Guid Id { get; set; }
        public Guid Provider { get; set; }
        public string Name { get; set; }
        public int Type { get; set; }
        public string Value { get; set; }

        public virtual Provider ProviderNavigation { get; set; }
    }
}
