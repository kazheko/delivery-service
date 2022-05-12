using GoodsDelivery.CourierWebApi.Core.Contracts;
using GoodsDelivery.CourierWebApi.Core.Domain;

namespace GoodsDelivery.CourierWebApi.Core.Application.Commands
{
    public class CourierCommandHandler
    {
        private readonly ICourierRepository repository;

        public CourierCommandHandler(ICourierRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IResult> Handle(CreateCourierCommand cmd)
        {
            var aggregate = new Courier
            (
                new FullName(cmd.FirstName, cmd.LastName),
                new Phone(cmd.PhoneNumber),
                cmd.Zones,
                cmd.CompanyName,
                cmd.IsActive
            );

            await repository.Create(aggregate);

            return Results.Created($"/couriers/{aggregate.Id}", aggregate);
        }

        public async Task<IResult> Handle(DeleteCourierCommand cmd)
        {
            await repository.Delete(x => x.Id == cmd.Id);

            return Results.NoContent();
        }

        public async Task Handle(UpdateCourierCommand cmd)
        {
            var aggregate = (await repository.Read(x => x.Id == cmd.Id)).SingleOrDefault();

            if (aggregate == null)
            {
                throw new ArgumentException("Courier does not exist");
            }

            aggregate = new Courier
            (
                cmd.Id,
                new FullName(cmd.FirstName, cmd.LastName),
                new Phone(cmd.PhoneNumber),
                cmd.Zones,
                cmd.CompanyName,
                cmd.IsActive
            );

            await repository.Update(x => x.Id == cmd.Id, aggregate);
        }
    }
}
