using AutoMapper;
using Company.AdvertisementApp.Business.Containe;
using Company.AdvertisementApp.Business.Interfaces;
using Company.AdvertisementApp.Common;
using Company.AdvertisementApp.DataAccess.UnitOfWork;
using Company.AdvertisementApp.Dto.Interfaces;
using Company.AdvertisementApp.Entities;
using FluentValidation;

namespace Company.AdvertisementApp.Business.Services;

public class Service<CreateDto, UpdateDto, ListDto, T> : IService<CreateDto, UpdateDto, ListDto, T>
    where CreateDto : class, IDto, new()
    where UpdateDto : class, IUpdateDto, new()
    where ListDto : class, IDto, new()
    where T : BaseEntity
{
    private readonly IMapper _mapper;
    private readonly IValidator<CreateDto> _createDtoValidator;
    private readonly IValidator<UpdateDto> _updateDtoValidator;
    private readonly IUow _uow;

    public Service(IMapper mapper, IValidator<CreateDto> createDtoValidator, IValidator<UpdateDto> updateDtoValidator,
        IUow uow)
    {
        _mapper = mapper;
        _createDtoValidator = createDtoValidator;
        _updateDtoValidator = updateDtoValidator;
        _uow = uow;
    }

    public async Task<IResponse<CreateDto>> CreateAsync(CreateDto dto)
    {
        var result = _createDtoValidator.Validate(dto);
        if (result.IsValid)
        {
            var createdEntity = _mapper.Map<T>(dto);
            await _uow.GetRepository<T>().CreateAsync(createdEntity);
            await _uow.SaveChangesAsync();
            return new Response<CreateDto>(ResponseType.Success, dto);
        }

        return new Response<CreateDto>(dto, result.ConvertToCustomValidationError());
    }

    public async Task<IResponse<List<ListDto>>> GetAllAsync()
    {
        var data = await _uow.GetRepository<T>().GetAllAsync();
        var dto = _mapper.Map<List<ListDto>>(data);
        return new Response<List<ListDto>>(ResponseType.Success, dto);
    }

    public async Task<IResponse<IDto>> GetByIdAsync(int id)
    {
        var data = await _uow.GetRepository<T>().GetByFilterAsync(x => x.Id == id);
        if (data == null)
            return new Response<IDto>(ResponseType.NotFound, $"Kayıt bulunamadı.ID:{id}");
        var dto = _mapper.Map<IDto>(data);
        return new Response<IDto>(ResponseType.Success, dto);
    }

    public async Task<IResponse> RemoveAsync(int id)
    {
        var data = await _uow.GetRepository<T>().FindAsync(id);
        if (data == null)
            return new Response(ResponseType.NotFound, $"Kayıt bulunamadı.ID:{id}");
        _uow.GetRepository<T>().Remove(data);
        await _uow.SaveChangesAsync();
        return new Response(ResponseType.Success);
    }

    public async Task<IResponse<UpdateDto>> UpdateAsync(UpdateDto dto)
    {
        var result = _updateDtoValidator.Validate(dto);
        if (result.IsValid)
        {
            var unChangedData = await _uow.GetRepository<T>().FindAsync(dto.Id);
            if (unChangedData == null)
                return new Response<UpdateDto>(ResponseType.NotFound, $"Kayıt bulunamadı.ID:{dto.Id}");
            var entity = _mapper.Map<T>(dto);
            _uow.GetRepository<T>().Update(entity, unChangedData);
            await _uow.SaveChangesAsync();
            return new Response<UpdateDto>(ResponseType.Success, dto);
        }

        return new Response<UpdateDto>(dto, result.ConvertToCustomValidationError());
    }
}