using System;
using Transport;
using Xunit;

namespace TransportBeregnerTests
{
    public class TransportBeregnerPrisTest
    {
        private  TransportBeregner Setup()
        {
            var parameter = new TransportPriceParameter
            {
                LimitLength = 5,
                LimitWeight = 10,

                LimitLengthPrice = 50,
                LimitWeigntPrice = 75,

                MinPrice = 0,
                MaxPrice = 100,

            };
            return new TransportBeregner(parameter);
        }

        private  TransportBeregner SetupMinPrice(int minPrice)
        {
            var parameter = new TransportPriceParameter
            {
                LimitLength = 5,
                LimitWeight = 10,

                LimitLengthPrice = 50,
                LimitWeigntPrice = 75,

                MinPrice = minPrice,
                MaxPrice = 100,

            };
            return new TransportBeregner(parameter);
        }

        private TransportBeregner SetupLengtAndMaxPrice(int lengthPrice, int maxPrice)
        {
            var parameter = new TransportPriceParameter
            {
                LimitLength = 5,
                LimitWeight = 10,

                LimitLengthPrice = lengthPrice,
                LimitWeigntPrice =  75,

                MinPrice = 0,
                MaxPrice = maxPrice,

            };
            return new TransportBeregner(parameter);
        }



        [Theory]
        [InlineData(4, 9,    0)]
        [InlineData(4, 10,  50)]
        [InlineData(4, 11,  50)]
        [InlineData(5, 9,   75)]
        [InlineData(5, 10, 100)]
        [InlineData(5, 11, 100)]
        [InlineData(6,  9,  75)]
        [InlineData(6, 10, 100)]
        [InlineData(6, 11, 100)]
        public void TransportPrice_is_Correct(int transportInKm, int weight, int expectedResult)
        {
            // Arrange
            var sut =  Setup();

            // Act
            var result = sut.TransportCalculator(transportInKm, weight);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(100, 1000, 4, 9, 0)]
        [InlineData(100, 1000, 4, 10, 100)]
        [InlineData(100, 1000, 4, 11, 100)]
        [InlineData(100, 1000, 5, 9, 75)]
        [InlineData(100, 1000, 5, 10, 1000)]
        [InlineData(100, 1000, 5, 11, 1000)]
        [InlineData(100, 1000, 6, 9, 75)]
        [InlineData(100, 1000, 6, 10, 1000)]
        [InlineData(100, 1000, 6, 11, 1000)]
        public void TransportPrice_is_Correct_When_Length_And_Price_Is_Altered(int lengthPrice,int maxPrice, int transportInKm, int weight, int expectedResult)
        {
            // Arrange
            var sut = SetupLengtAndMaxPrice(lengthPrice, maxPrice);
            
            // Act
            var result = sut.TransportCalculator(transportInKm, weight);

            // Assert
            Assert.Equal(expectedResult, result);
        }

    }
}
