using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace FilghtsAPILayer
{
    
   public interface IFlightsAPILayer
    {
      DataSet GetAvailability(String xmlRequestData);
        // DataSet GetAvailability();
    }
}
