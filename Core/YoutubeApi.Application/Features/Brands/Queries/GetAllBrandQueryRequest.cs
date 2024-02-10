using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeApi.Application.Interfaces.RedisCache;

namespace YoutubeApi.Application.Features.Brands.Queries
{
    public class GetAllBrandQueryRequest : IRequest<IList<GetAllBrandQueryResponse>>, ICacheableQuery
    {
        public string CacheKey => "GetAllBrands";

        public double CacheTime => 5;//Minute
    }
}
