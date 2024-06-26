﻿using HomeService.Domain.Core.Entities;

namespace HomeService.Domain.Core.Contracts.Repositories;

public interface ICityRepository
{
    Task<City> GetById(int cityId, CancellationToken cancellationToken);
    Task<List<City>> GetAll(CancellationToken cancellationToken);
}
