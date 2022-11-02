using FluentAssertions;
using Moq;
using Xunit;

namespace MyProject.Service.Tests
{

    public class ResultServiceTests
    {
       

        [Fact()]
        public void SetRecentOverweightResult_ForOverweightResult_UpdatesProperty()
        {
            var result = new BmiResult() { BmiClassification = BmiClassification.Overweight };
            var resultService = new ResultService(new ResultRepository());
            

            //act
            resultService.SetRecentOverweightResult(result);

            resultService.RecentOverweightResult.Should().Be(result);
        }

        [Fact()]
        public void SetRecentOverweightResult_ForOverweightResult_DoesntUpdatesProperty()
        {
            var result = new BmiResult() { BmiClassification = BmiClassification.Obesity };
            var resultService = new ResultService(new ResultRepository());


            //act
            resultService.SetRecentOverweightResult(result);

            resultService.RecentOverweightResult.Should().BeNull();
        }


        [Fact]
        public async Task SaveUnderweightResultAsync_ForUnderweightResult_InvokesSaveResultAsync()
        {
            var result = new BmiResult() { BmiClassification = BmiClassification.Underweight };
            var repoMock = new Mock<IResultRepository>();

            var resultService = new ResultService(repoMock.Object);


            //act
           await resultService.SaveUnderweightResultAsync(result);

           //assert
           repoMock.Verify(mock => mock.SaveResultAsync(result), Times.Once);
        }

        [Fact]
        public async Task SaveUnderweightResultAsync_ForNonUnderweightResult_DoesntInvokesSaveResultAsync()
        {
            var result = new BmiResult() { BmiClassification = BmiClassification.Normal };
            var repoMock = new Mock<IResultRepository>();

            var resultService = new ResultService(repoMock.Object);


            //act
            await resultService.SaveUnderweightResultAsync(result);

            //assert
            repoMock.Verify(mock => mock.SaveResultAsync(result), Times.Never);
        }
    }
}