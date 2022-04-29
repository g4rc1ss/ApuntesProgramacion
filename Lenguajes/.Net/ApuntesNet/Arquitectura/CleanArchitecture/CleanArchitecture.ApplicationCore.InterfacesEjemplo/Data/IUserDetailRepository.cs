﻿using System.Threading.Tasks;
using CleanArchitecture.Domain.Database.ModelEntity;
using CleanArchitecture.Domain.Negocio.Filtros.UserDetail;

namespace CleanArchitecture.ApplicationCore.InterfacesEjemplo.Data
{
    public interface IUserDetailRepository
    {
        Task<UserModelEntity> GetUser(FiltroUser filtro);
    }
}