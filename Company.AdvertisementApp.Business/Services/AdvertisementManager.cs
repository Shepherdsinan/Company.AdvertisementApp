using AutoMapper;
using Company.AdvertisementApp.Business.Interfaces;
using Company.AdvertisementApp.Common;
using Company.AdvertisementApp.DataAccess.UnitOfWork;
using Company.AdvertisementApp.Dto;
using Company.AdvertisementApp.Entities;
using FluentValidation;

namespace Company.AdvertisementApp.Business.Services;

public class AdvertisementManager :
    Service<AdvertisementCreateDto, AdvertisementUpdateDto, AdvertisementListDto, Advertisement>, IAdvertisementManager
{
    private readonly IMapper _mapper;
    private readonly IUow _uow;

    public AdvertisementManager(IMapper mapper, IValidator<AdvertisementCreateDto> createDtoValidator,
        IValidator<AdvertisementUpdateDto> updateDtoValidator, IUow uow) : base(mapper, createDtoValidator,
        updateDtoValidator, uow)
    {
        _mapper = mapper;
        _uow = uow;
    }

    public async Task<IResponse<List<AdvertisementListDto>>> GetActiveAsync()
    {
        var data = await _uow.GetRepository<Advertisement>()
            .GetAllAsync(x => x.Status, x => x.CreatedDate, Common.Enums.OrderByType.DESC);
        var dto = _mapper.Map<List<AdvertisementListDto>>(data);
        return new Response<List<AdvertisementListDto>>(ResponseType.Success, dto);
    }
}