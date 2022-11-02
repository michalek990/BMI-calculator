using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MyProject.Tests
{
    public class BmiDeterminatorTests
    {
        [Theory]
        [InlineData(10.0, BmiClassification.Underweight)]
        [InlineData(17.0, BmiClassification.Underweight)]
        [InlineData(8.0, BmiClassification.Underweight)]
        [InlineData(24.0, BmiClassification.Normal)]
        [InlineData(18.9, BmiClassification.Normal)]
        [InlineData(21.9, BmiClassification.Normal)]

        public void DetermineBmi_ForGivenBmi_ReturnsCorrectClassification(double bmi, BmiClassification classification)
        {
          

            BmiDeterminator bmiDeterminator = new BmiDeterminator();
            

            BmiClassification result = bmiDeterminator.DetermineBmi(bmi); 


            Assert.Equal(classification, result);


        }


        
    }
}
