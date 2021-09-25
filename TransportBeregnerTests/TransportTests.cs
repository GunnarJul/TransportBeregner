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
                LengthLimit = 5,
                WeightLimit = 10,
                MinPrice = 0,
                PriceLessThanLengthLimit = 50,
                PriceLessThanWeightLimit = 75,
                PriceMax = 100
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
            var sut = new TransportBeregner(parameter);

            // Act
            var result = sut.TransportCalculator(transportInKm, weight);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(5, 10, 0, 50, 75, 100, 4, 9, 0)]
        [InlineData(5, 10, 0, 50, 75, 100, 14, 19, 100)]
        [InlineData(5, 10, 300, 50, 75, 1000, 100, 10, 1300)]  // start gebyr på 300
        [InlineData(0, 5, 100, 200, 300, 500, 100, 1000, 600)]  // start gebyr 100
        public void TransportPrice_is_Correct_When_Altering_Limits(int kmLimit,
                                                                   int weightLimit,
                                                                   int minPrice,
                                                                   int priceLessThanLengthLimit,
                                                                   int priceLessThanWeightLimit,
                                                                   int priceMax,
                                                                   int length,
                                                                   int weight,
                                                                   int expectedResult)
        {
            // Arrange
            var parameter = new TransportPriceParameter
            {
                LengthLimit = kmLimit,
                WeightLimit = weightLimit,
                MinPrice = minPrice,
                PriceLessThanLengthLimit = priceLessThanLengthLimit,
                PriceLessThanWeightLimit = priceLessThanWeightLimit,
                PriceMax = priceMax
            };
            var sut = new TransportBeregner(parameter);

            // Act
            var result = sut.TransportCalculator(length, weight);

            // Assert
            Assert.Equal(expectedResult, result);
        }

    }
}

