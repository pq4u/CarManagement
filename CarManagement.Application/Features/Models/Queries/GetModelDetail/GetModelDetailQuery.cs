﻿using CarManagement.Application.Features.Models.Queries.GetModelsList;
using MediatR;

namespace CarManagement.Application.Features.Models.Queries.GetModelDetail
{
    public class GetModelDetailQuery : IRequest<CarModelDetailViewModel>
    {
        public int Id { get; set; }
    }
}