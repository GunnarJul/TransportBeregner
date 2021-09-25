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
            int sum = _limitValues.MinPrice;

            if (transportInKm < _limitValues.LengthLimit  && weight >= _limitValues.WeightLimit )
            {
                sum += _limitValues.PriceLessThanLengthLimit ;//50 
            }
            if (transportInKm >= _limitValues.LengthLimit && weight < _limitValues.WeightLimit)
            {
                sum += _limitValues.PriceLessThanWeightLimit;// 75; 
            }
            if (transportInKm >= _limitValues.LengthLimit && weight >= _limitValues.WeightLimit)
            {
                sum += _limitValues.PriceMax; // 100
            }

            return sum;
        }

    }


    public class TransportPriceParameter
    {
        public  int LengthLimit;
        public  int WeightLimit;

        public int MinPrice;
        public int PriceLessThanLengthLimit;
        public int PriceLessThanWeightLimit;
        public int PriceMax;

    }
}
