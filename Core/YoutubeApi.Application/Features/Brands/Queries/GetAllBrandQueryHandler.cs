using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeApi.Application.Bases;
using YoutubeApi.Application.Interfaces.AutoMapper;
using YoutubeApi.Application.Interfaces.UnitOfWorks;
using YoutubeApi.Domain.Entities;

namespace YoutubeApi.Application.Features.Brands.Queries
{
    public class GetAllBrandQueryHandler : BaseHandler ,IRequestHandler<GetAllBrandQueryRequest, IList<GetAllBrandQueryResponse>>
    {
        public GetAllBrandQueryHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
        {
        }

        public async Task<IList<GetAllBrandQueryResponse>> Handle(GetAllBrandQueryRequest request, CancellationToken cancellationToken)
        {
            var brands = await unitOfWork.GetReadRepository<Brand>().GetAllAsync();
            return mapper.Map<GetAllBrandQueryResponse, Brand>(brands);

        }

       
    }
}
