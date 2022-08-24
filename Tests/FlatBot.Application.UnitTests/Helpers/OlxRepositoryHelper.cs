using FlatBot.Application.Persistance;
using FlatBot.Domain.Entities;
using Moq;

namespace FlatBot.Application.UnitTests.Mocks
{
    public static class OlxRepositoryHelper
    {
        private static List<OlxOfferEntity> data = new List<OlxOfferEntity>
            {
                new OlxOfferEntity()
                {
                    BatchId = "1",
                    CreattionDateUTC = DateTime.UtcNow,
                    Description = "Description1",
                    Id = "1",
                    Image = "ImgSrc1",
                    Link =  "Link1",
                    Price = 1,
                    UTCDate = DateTime.UtcNow
                },
                new OlxOfferEntity()
                {
                    BatchId = "1",
                    CreattionDateUTC = DateTime.UtcNow,
                    Description = "Description",
                    Id = "2",
                    Image = "ImgSrc2",
                    Link =  "Link2",
                    Price = 1,
                    UTCDate = DateTime.UtcNow
                }
            };

        public static Mock<IOlxRepository> GetOlxRepositoryMock()
        {
            var repository = new Mock<IOlxRepository>();

            repository.Setup(x => x.GetAsync()).ReturnsAsync(data);

            return repository;
        }
    }
}
