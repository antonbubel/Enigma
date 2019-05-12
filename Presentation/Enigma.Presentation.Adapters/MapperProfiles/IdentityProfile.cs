namespace Enigma.Presentation.Adapters.MapperProfiles
{
    using AutoMapper;

    using Models;
    using BusinessLogic.Models;

    public class IdentityProfile : Profile
    {
        public IdentityProfile()
        {
            CreateMap<CredentialsModel, CredentialsModelBL>()
                .ReverseMap();
        }
    }
}
