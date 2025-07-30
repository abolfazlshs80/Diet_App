using Diet.Domain.Contract.Commands.Order.Create;
using Diet.Domain.Contract.Queries.DurationAge.GetById;
using Diet.Domain.Contract.ViewModels.DurationAge;
using Mapster;

namespace Diet.Api.Mapping.DurationAge
{
    public class GetItemDurationAgeMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<GetDurationAgeViewModel, GetByIdDurationAgeQuery>()
                .Map(_ => _.Id, _ => _.D_Id);
        }
    }
}
