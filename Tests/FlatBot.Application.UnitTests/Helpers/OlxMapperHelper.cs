using FlatBot.Application.Mappers;
using FlatBot.Domain.Entities;
using Moq;

namespace FlatBot.Application.UnitTests.Mocks
{
    public static class OlxMapperHelper
    {
        

        public static Mock<IOLXMapper> GetOlxMapperMockMock()
        {
            var mapper = new Mock<IOLXMapper>();

            //mapper.Setup(x => x.Map(new List<RawOlxOffer>())).Returns(new List<OlxOfferEntity>());

            return mapper;
        }

        
    }
}
