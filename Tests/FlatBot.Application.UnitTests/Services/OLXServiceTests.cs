using FlatBot.Application.Mappers;
using FlatBot.Application.Persistance;
using FlatBot.Application.Scrapers;
using FlatBot.Application.UnitTests.Helpers;
using FlatBot.Application.UnitTests.Mocks;
using FlatBot.Domain.Entities;
using FlatBot.Infrastructure.Services;
using Moq;
using Xunit;

namespace FlatBot.Application.UnitTests.Services
{
    public class OLXServiceTests
    {
        private readonly Mock<IOlxRepository> _mockOlxRepository;
        private readonly Mock<IOLXScraper> _mockOLXScraper;
        private readonly Mock<IOLXMapper> _mockOLXMapper;

        public OLXServiceTests()
        {
            _mockOlxRepository = OlxRepositoryHelper.GetOlxRepositoryMock();
            _mockOLXScraper = OLXScraperHelper.GetOLXScraperMock();
            _mockOLXMapper = OlxMapperHelper.GetOlxMapperMockMock();

        }

        [Fact]
        public void GetOLXDataShouldReturnData()
        {

            Assert.NotNull()
        }
    }
}
