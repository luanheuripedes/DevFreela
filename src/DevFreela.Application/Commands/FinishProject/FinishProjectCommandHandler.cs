using DevFreela.Application.Services.Interfaces;
using DevFreela.Core.DTOs;
using DevFreela.Core.Enums;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Commands.FinishProject
{
    public class FinishProjectCommandHandler : IRequestHandler<FinishProjectCommand, Unit>
    {
        private readonly IProjectRepository _repository;
        private readonly IPaymentService _paymentService;

        public FinishProjectCommandHandler(IProjectRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(FinishProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await _repository.GetByIdAsync(request.Id);

            project.FinishProject();

            var paymentInfoDto = new PaymentInfoDTO(request.Id, request.CreditCardNumber, request.Cvv, request.ExpiresAt, request.FullName, request.Amount);

            var result = await _paymentService.ProcessPayment(paymentInfoDto);

            if (!result)
            {
                project.SetPaymentPending();
            }

            await _repository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
