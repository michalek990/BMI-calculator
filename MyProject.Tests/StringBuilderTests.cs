using System.Text;
using Xunit;

namespace MyProject.Tests
{
    public class StringBuilderTests
    {
        [Fact]
        public void Append_ForTwoStrings_ReturnsConcatenatedString()
        {
            //arrange
            //czêœæ w której bedziemy inicjalizowac obiekty na ktorych bedziemy przeprowadzac testy

            StringBuilder sb = new StringBuilder();

            //act
            //sprawdzamy funckjonalnosc i przekazuje wynik testu do jakiejs zmiennej

            sb.Append("test")
                .Append("test2");

            string result = sb.ToString();


            //assert
            //tutaj sprawdzamy ostatecznie czy wynik naszego testu jest taki sam jak zakladalismy

            Assert.Equal("testtest2", result);
        }
    }
}