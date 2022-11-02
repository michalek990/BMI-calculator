using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MyProject.Tests
{
    public class MetricBmiCalculatorTest
    {
        [Theory]
        [InlineData(100.0,170.0, 34.6)]
        [InlineData(57.0, 170.0, 19.72)]
        [InlineData(70.0, 170.0, 24.22)]
        public void CalculateBmi_ForGivenWeightAndHeight_ReturnsCorrectBmi(double weight, double height, double bmiResult)
        {
            //arrange
            MetricBmiCalculator metricBmi = new MetricBmiCalculator();

            //act
            double result = metricBmi.CalculateBmi(weight, height);

            //assert
            Assert.Equal(bmiResult, result);
        }

        [Theory]
        [InlineData(0.0, 170.0)]
        [InlineData(57.0, 0.0)]
        [InlineData(70.0, -170.0)]
        public void CalculateBmi_ForInvalidArgumetns_ThrowExceptions(double weight, double height)
        {
            //arrange
            MetricBmiCalculator metricBmi = new MetricBmiCalculator();

            //act
            Action action = () => metricBmi.CalculateBmi(weight, height);

            //assert
            Assert.Throws<ArgumentException>(action);
        }
    }
}
