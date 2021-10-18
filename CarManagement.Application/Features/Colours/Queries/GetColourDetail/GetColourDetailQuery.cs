﻿using CarManagement.Application.Features.Colours.Queries.GetColoursList;
using MediatR;

namespace CarManagement.Application.Features.Colours.Queries.GetColourDetail
{
    public class GetColourDetailQuery : IRequest<ColourInListViewModel>, IRequest<ColourDetailViewModel>
    {
        public int Id { get; set; }
    }
}