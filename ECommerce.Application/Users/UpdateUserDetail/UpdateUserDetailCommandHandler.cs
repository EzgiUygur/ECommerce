using ECommerce.Application.Responses;
using ECommerce.Core.MessagingAdapter.Commands;
using ECommerce.Domain.Context;
using ECommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Application.Users.UpdateUserDetail
{
    public class UpdateUserDetailCommandHandler : BaseCommandHandler<UpdateUserDetailCommand, GenericIdDto>
    {
        private readonly ApplicationDbContext _context;

        public UpdateUserDetailCommandHandler(ApplicationDbContext context)
        {
            this._context = context;
        }

        public override async Task<GenericIdDto> Handle(UpdateUserDetailCommand request, CancellationToken cancellationToken)
        {
            var user = await this._context.Set<User>()
                .FirstOrDefaultAsync(x =>
                    x.Id == request.UserId, cancellationToken)
                ?? throw new KeyNotFoundException("İlgili kullanıcı bulunamadı.");

            var userDetail = new UserDetail
            {
                PhoneNumber = request.PhoneNumber,
                WorkPhoneNumber = request.WorkPhoneNumber,
                Gender = request.Gender,
                Address = request.Address,
                BirthDate = request.BirthDate,
                UserId = request.UserId
            };

            this._context.Update(userDetail);
            await this._context.SaveChangesAsync(cancellationToken);

            return new GenericIdDto(userDetail.Id);
        }
    }
}
