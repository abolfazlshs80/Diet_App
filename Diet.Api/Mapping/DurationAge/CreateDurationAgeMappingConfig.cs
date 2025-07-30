using Diet.Domain.Contract.Commands.Order.Create;
using Diet.Domain.Contract.ViewModels.DurationAge;
using Mapster;

namespace Diet.Api.Mapping.DurationAge
{
    public class CreateDurationAgeMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<CreateDurationAgeViewModel, CreateDurationAgeCommand>()
                .Map(_ => _.MinAge, _ => _.D_MinAge)
                .Map(_ => _.MaxAge, _ => _.D_MaxAge)
                .Map(_ => _.Title, _ => _.D_Title);
        }
    }
}
