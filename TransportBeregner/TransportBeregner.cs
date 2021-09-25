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
            
            int sum = _limitValues.MinPrice;

            if (transportInKm < _limitValues.LimitLength  && weight >= _limitValues.LimitWeight )
            {
                sum += _limitValues.LimitLengthPrice ;  
            }
            if (transportInKm >= _limitValues.LimitLength && weight < _limitValues.LimitWeight)
            {
                sum += _limitValues.LimitWeigntPrice; ; 
            }
            if (transportInKm >= _limitValues.LimitLength && weight >= _limitValues.LimitWeight)
            {
                sum += _limitValues.MaxPrice;  
            }

            return sum;
        }

    }
}
