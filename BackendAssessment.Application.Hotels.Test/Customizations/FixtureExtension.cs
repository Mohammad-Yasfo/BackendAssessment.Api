using AutoFixture;
using AutoMapper;
using NSubstitute;

namespace BackendAssessment.Application.Hotels.Test
{
    public static class FixtureExtension
    {
        public static T FreezeSubstitute<T>(this Fixture fixture) where T : class
        {
            var mock = Substitute.For<T>();
            fixture.Register(() => mock);
            return mock;
        }

        public static void FreezeMapper<T>(this Fixture fixture) where T : Profile, new()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile(new T()));
            fixture.Register<IMapper>(() => new Mapper(config));
        }
    }
}