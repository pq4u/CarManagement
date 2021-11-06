using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CarManagement.Application.Contracts.Infrastructure;
using CarManagement.Application.Contracts.Persistence;
using CarManagement.Application.Models.Mail;
using CarManagement.Domain.Entities;
using MediatR;

namespace CarManagement.Application.Features.Brands.Commands.CreateBrand
{
    public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommand, CreateBrandCommandResponse>
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;

        public CreateBrandCommandHandler(IBrandRepository brandRepository, IMapper mapper, IEmailService emailService)
        {
            _brandRepository = brandRepository;
            _mapper = mapper;
            _emailService = emailService;
        }

        public async Task<CreateBrandCommandResponse> Handle(CreateBrandCommand request,
            CancellationToken cancellationToken)
        {
            var validator = new CreateBrandCommandValidator(_brandRepository);
            var validatorResult = await validator.ValidateAsync(request);

            if (!validatorResult.IsValid)
                return new CreateBrandCommandResponse(validatorResult);

            var brand = _mapper.Map<Brand>(request);
            brand = await _brandRepository.AddAsync(brand);

            var email = new Email()
            {
                To = "example@name.com",
                Body = $"A new brand has been created: {request}",
                Subject = $"New brand: {request}"
            };

            try
            {
                await _emailService.SendEmail(email);
            }
            catch (Exception ex)
            {

            }
            
            return new CreateBrandCommandResponse(brand.BrandId);
        }
    }
}