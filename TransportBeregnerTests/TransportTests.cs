using System;
using Transport;

using Xunit;

namespace TransportTests
{
    public class TransportTests
    {
        private TransportPriceParameter Setup()
        {
            return new TransportPriceParameter
            {
                _kmLimit = 5,
                _weightLimit = 10,
                _minPrice = 0,
                _priceLessThanKmLimit = 50,
                _priceLessThanWeightLimit = 75,
                _priceMax = 100
            };
        }



        [Theory]
        [InlineData(4, 9, 0)]
        [InlineData(4, 11, 50)]
        [InlineData(5, 9, 75)]
        [InlineData(6, 11, 100)]
        public void TransportPrice_is_Correct(int transportInKm, int weight, int expectedResult)
        {
            // Arrange
            var parameter = Setup();
            var sut = new TransportBeregner(parameter );

            // Act
            var result = sut.TransportCalculator(transportInKm, weight);

            // Assert
            Assert.Equal(expectedResult, result);
        }

     

    }
}

