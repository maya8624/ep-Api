using ep.Contract.Constraints;
using ep.Contract.Extensions;
using ep.Contract.RequestModels;
using ep.Contract.ViewModels;
using ep.Data.Wrappers;
using ep.Service.Interfaces;

namespace ep.Service.Services
{
    public class BusinessService : IBusinessService
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryWrapper _repository;

        public BusinessService(IMapper mapper, IRepositoryWrapper repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<ResponseView<IEnumerable<BusinessView>>> GetBusinessesAsync(BusinessSearchRequest request)
        {
            var businesses = await _repository
                .Business
                .GetBusinessesAsync(request.Skip ?? BusinessConstant.Skip, request.Take ?? BusinessConstant.Take);

            var totalCount = businesses.Count;
            var data = _mapper.Map<IEnumerable<Business>, IEnumerable<BusinessView>>(businesses);
            
            var response = data.ToResponse(totalCount);
            return response;
        }

        public async Task SaveBusinessAsync(BusinessRequest request)
        {
            var business = _mapper.Map<Business>(request);
            await _repository.Business.CreateAsync(business);
            await _repository.UnitOfWork.CompleteAsync();
        }
    }
}
