using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
using Moq;

namespace MyProject.Tests
{
    public class BmiCalculateorFacadeTests
    {
        private const string OVERWEIGHT_SUMMARY = "You are a bit overweight";
        private const string NORMAL_SUMMARY = "Your weight is normal, keep it up";

        [Theory]
        [InlineData(BmiClassification.Overweight, OVERWEIGHT_SUMMARY)]
        [InlineData(BmiClassification.Normal, NORMAL_SUMMARY)]
        public void GetResult_ForValuidInputs_ReturnsCorrectSummary(BmiClassification bmiClassification, string expectedResult)
        {
            //utworzenie obiektu przez mocka
            var bmiDetermianteMock = new Mock<IBmiDeterminator>();


            //jego konfiguracja
            bmiDetermianteMock.Setup(m => m.DetermineBmi(It.IsAny<double>()))
                .Returns(bmiClassification);
                


            //odniesienie sie do tego obiektu
            BmiCalculatorFacade bmiCalculatorFacade = new BmiCalculatorFacade(UnitSystem.Metric, bmiDetermianteMock.Object);



            //act

            BmiResult result = bmiCalculatorFacade.GetResult(1,1);

            result.Summary.Should().Be(expectedResult);
        }
    }
}
