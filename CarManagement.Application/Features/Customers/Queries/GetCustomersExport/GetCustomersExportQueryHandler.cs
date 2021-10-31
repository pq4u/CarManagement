using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using AutoMapper;
using CarManagement.Application.Contracts.Infrastructure;
using CarManagement.Application.Contracts.Persistence;
using CarManagement.Domain.Entities;
using MediatR;

namespace CarManagement.Application.Features.Customers.Queries.GetCustomersExport
{
    public class GetCustomersExportQueryHandler : IRequestHandler<GetCustomersExportQuery, CustomerExportFileVm>
    {
        private readonly IAsyncRepository<Customer> _customerRepository;
        private readonly IMapper _mapper;
        private readonly ICsvExporter _csvExporter;

        public GetCustomersExportQueryHandler(IMapper mapper, IAsyncRepository<Customer> customerRepository, ICsvExporter csvExporter)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
            _csvExporter = csvExporter;
        }

        public async Task<CustomerExportFileVm> Handle(GetCustomersExportQuery request, CancellationToken cancellationToken)
        {
            var allCustomers = _mapper.Map<List<CustomerExportDto>>((await _customerRepository.GetAllAsync()));

            var fileData = _csvExporter.ExportCustomersToCsv(allCustomers);

            var customerExportFileDto = new CustomerExportFileVm() { ContentType = "text/csv", Data = fileData, CustomerExportFileName = $"{Guid.NewGuid()}.csv" };

            return customerExportFileDto;
        }
    }
}