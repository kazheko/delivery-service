using GoodsDelivery.CourierWebApi.Core.Contracts;

namespace GoodsDelivery.CourierWebApi.Core.Application.Queries
{
    public class CourierQueryService
    {
        private readonly ICourierRepository repository;

        public CourierQueryService(ICourierRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<CourierViewModel>> GetAllCouriers()
        {
            var couriers = await repository.Read(_ => true);

            return couriers.Select(x=>new CourierViewModel
            {
                Id = x.Id,
                CompanyName = x.CompanyName,
                FullName = x.Name.FormattedName,
                IsActive = x.IsActive,
                PhoneNumber = x.PhoneNumber.Number,
                Zones = x.Zones
            });
        }

        public async Task<CourierViewModel> GetCourierDetails(string id)
        {
            var couriers = await repository.Read(x => x.Id == id);

            return couriers.Select(x => new CourierViewModel
            {
                Id = x.Id,
                CompanyName = x.CompanyName,
                FullName = x.Name.FormattedName,
                IsActive = x.IsActive,
                PhoneNumber = x.PhoneNumber.Number,
                Zones = x.Zones
            }).Single();
        }
    }
}
