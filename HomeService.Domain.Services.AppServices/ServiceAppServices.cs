using HomeService.Domain.Core.Contracts.AppServices;
using HomeService.Domain.Core.Contracts.Services;
using HomeService.Domain.Core.DTOs.ServiceDTO;
using HomeService.Domain.Core.Entities;
using Microsoft.AspNetCore.Http;

namespace HomeService.Domain.Services.AppServices;

public class ServiceAppServices : IServiceAppServices
{
    private readonly IServiceServices _serviceServices;
    private readonly IBaseSevices _baseSevices;

    public ServiceAppServices(IServiceServices serviceServices, IBaseSevices baseSevices)
    {
        _serviceServices = serviceServices;
        _baseSevices = baseSevices;
    }

    public async Task<bool> Create(ServiceCreateDto serviceCreateDto, CancellationToken cancellationToken,IFormFile image)
    {
        var imageAddress= _baseSevices.UploadImage(image);
        serviceCreateDto.Image =await imageAddress;
       return await _serviceServices.Create(serviceCreateDto, cancellationToken);
    }

    public async Task<bool> Delete(int serviceId, CancellationToken cancellationToken)
       => await _serviceServices.Delete(serviceId, cancellationToken);

    public async Task<List<GetServiceDto>> GetAll(CancellationToken cancellationToken)
      => await _serviceServices.GetAll(cancellationToken);

    public async Task<Service> GetById(int serviceId, CancellationToken cancellationToken)
      => await _serviceServices.GetById(serviceId, cancellationToken);

    public async Task<List<ServicesNameDto>> GetServicesName(CancellationToken cancellationToken)
      =>await _serviceServices.GetServicesName(cancellationToken);

    public async Task<bool> Update(ServiceUpdateDto serviceUpdateDto, CancellationToken cancellationToken)
      => await _serviceServices.Update(serviceUpdateDto, cancellationToken);
}
