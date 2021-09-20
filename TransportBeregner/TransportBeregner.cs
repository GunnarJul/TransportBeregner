using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transport
{
    public  class TransportBeregner
    {
        private readonly TransportPriceParameter _limitValues;
        public TransportBeregner(TransportPriceParameter limitValues)
        {
            _limitValues = limitValues;
        }

        public int TransportCalculator(int transportInKm, int weight)
        {
            // Sætter transport summen til at være 0,- kr default for km < 5 og vægt < 10
            int sum = _limitValues._minPrice;

            if (transportInKm < _limitValues._kmLimit  && weight >= _limitValues._weightLimit )
            {
                sum = _limitValues._priceLessThanKmLimit ;//50 
            }
            if (transportInKm >= _limitValues._kmLimit && weight < _limitValues._weightLimit)
            {
                sum = _limitValues._priceLessThanWeightLimit;// 75; 
            }
            if (transportInKm >= _limitValues._kmLimit && weight >= _limitValues._weightLimit)
            {
                sum = _limitValues._priceMax; // 100
            }

            return sum;
        }

    }


    public class TransportPriceParameter
    {
        public  int _kmLimit;
        public  int _weightLimit;

        public int _minPrice;
        public int _priceLessThanKmLimit;
        public int _priceLessThanWeightLimit;
        public int _priceMax;

    }
}
