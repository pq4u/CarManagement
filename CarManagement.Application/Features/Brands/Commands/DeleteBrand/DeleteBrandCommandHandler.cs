using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CarManagement.Application.Contracts.Infrastructure;
using CarManagement.Application.Contracts.Persistence;
using CarManagement.Application.Models.Mail;
using MediatR;

namespace CarManagement.Application.Features.Brands.Commands.DeleteBrand
{
    public class DeleteBrandCommandHandler : IRequestHandler<DeleteBrandCommand>
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;

        public DeleteBrandCommandHandler(IMapper mapper, IBrandRepository brandRepository)
        {
            _mapper = mapper;
            _brandRepository = brandRepository;
        }


        public async Task<Unit> Handle(DeleteBrandCommand request, CancellationToken cancellationToken)
        {
            var brand = await _brandRepository.GetByIdAsync(request.BrandId);
            await _brandRepository.DeleteAsync(brand);
            
            var email = new Email()
            {
                To = "example@name.com",
                Body = $"A brand has been deleted: {request}",
                Subject = $"Deleted brand: {request}"
            };

            try
            {
                await _emailService.SendEmail(email);
            }
            catch (Exception ex)
            {

            }
            
            return Unit.Value;
        }
    }
}