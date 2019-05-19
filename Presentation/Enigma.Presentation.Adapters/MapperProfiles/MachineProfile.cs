namespace Enigma.Presentation.Adapters.MapperProfiles
{
    using AutoMapper;

    using System;
    using System.Linq;

    using Models;
    using BusinessLogic.Models;
    using Domain.Model.Entities;
    using Machine.Integration.Models;

    public class MachineProfile : Profile
    {
        public MachineProfile()
        {
            Func<string, char> getRotorLetter = (rotorLetter) => string.IsNullOrEmpty(rotorLetter)
                ? 'A'
                : rotorLetter.ToUpper().First();

            CreateMap<EnigmaMachineConfigurationModel, EnigmaMachineConfigurationModelBL>()
                .ReverseMap();

            CreateMap<EnigmaMachineConfigurationModelBL, RotorsConfigurationSetup>()
                .ForMember(x => x.FastRotor, y => y.MapFrom(z => new RotorInfo(z.ThirdRotor, 'A', 'A')))
                .ForMember(x => x.MiddleRotor, y => y.MapFrom(z => new RotorInfo(z.SecondRotor, 'A', 'A')))
                .ForMember(x => x.SlowRotor, y => y.MapFrom(z => new RotorInfo(z.FirstRotor, 'A', 'A')));

            CreateMap<EnigmaMachineConfigurationModelBL, EnigmaConfiguration>()
                .ReverseMap();

            CreateMap<EnigmaMachineRotorsConfigurationModel, EnigmaMachineRotorsConfigurationModelBL>()
                .ForMember(x => x.FirstLetter, y => y.MapFrom(z => getRotorLetter(z.FirstLetter)))
                .ForMember(x => x.SecondLetter, y => y.MapFrom(z => getRotorLetter(z.SecondLetter)))
                .ForMember(x => x.ThirdLetter, y => y.MapFrom(z => getRotorLetter(z.ThirdLetter)))
                .ReverseMap()
                .ForMember(x => x.FirstLetter, y => y.MapFrom(z => z.FirstLetter.ToString()))
                .ForMember(x => x.SecondLetter, y => y.MapFrom(z => z.SecondLetter.ToString()))
                .ForMember(x => x.ThirdLetter, y => y.MapFrom(z => z.ThirdLetter.ToString()));

            CreateMap<EnigmaMachineRotorsConfigurationModelBL, RotorsConfiguration>()
                .ReverseMap();
        }
    }
}
