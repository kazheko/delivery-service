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

        public async Task<string> Handle(CreateCourierCommand cmd)
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

            return aggregate.Id;
        }

        public async Task Handle(DeleteCourierCommand cmd)
        {
            await repository.Delete(x => x.Id == cmd.Id);
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
