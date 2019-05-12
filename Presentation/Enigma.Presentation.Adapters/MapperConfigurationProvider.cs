namespace Enigma.Presentation.Adapters
{
    using AutoMapper;
    using System.Reflection;

    public static class MapperConfigurationProvider
    {
        public static MapperConfiguration CreateConfiguration()
        {
            var executingAssembly = Assembly.GetExecutingAssembly();
            var mapperConfiguration = new MapperConfiguration(config => config.AddMaps(executingAssembly));

            return mapperConfiguration;
        } 
    }
}
