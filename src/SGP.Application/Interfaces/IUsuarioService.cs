﻿using SGP.Application.Requests;
using SGP.Application.Requests.UsuarioRequests;
using SGP.Application.Responses;
using SGP.Shared.Messages;
using SGP.Shared.Results;
using System.Threading.Tasks;

namespace SGP.Application.Interfaces
{
    public interface IUsuarioService
    {
        Task<IResult<CreatedResponse>> AddAsync(AddUsuarioRequest request);
        Task<IResult<UsuarioResponse>> GetByIdAsync(GetByIdRequest request);
    }
}
