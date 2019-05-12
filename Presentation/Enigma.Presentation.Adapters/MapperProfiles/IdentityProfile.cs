namespace Enigma.Presentation.Adapters.MapperProfiles
{
    using AutoMapper;

    using Models;
    using BusinessLogic.Models;
    using Domain.Model.Entities;

    public class IdentityProfile : Profile
    {
        public IdentityProfile()
        {
            CreateMap<CredentialsModel, CredentialsModelBL>();

            CreateMap<CredentialsModelBL, ApplicationUser>()
                .ForMember(x => x.UserName, y => y.MapFrom(z => z.Username));
        }
    }
}
