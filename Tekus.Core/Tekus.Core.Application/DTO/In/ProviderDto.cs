using System;
using System.Collections.Generic;



namespace Tekus.Core.Application.DTO.In
{
    public  class ProviderDto
    {
  

        public Guid Identifier { get; set; }
        public string Nit { get; set; }
        public string NameProvider { get; set; }
        public string EmailProvider { get; set; }
        public string AddressProvider { get; set; }
        public string PhoneProvider { get; set; }       

        public List<AttributeDto> AttributesProvider { get; set; }
        
    }
}
