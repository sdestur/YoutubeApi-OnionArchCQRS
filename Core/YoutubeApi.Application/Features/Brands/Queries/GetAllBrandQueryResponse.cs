using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace YoutubeApi.Application.Features.Brands.Queries
{
    public class GetAllBrandQueryResponse 
    {
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
    }
}
