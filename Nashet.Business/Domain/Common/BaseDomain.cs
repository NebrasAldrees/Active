using Nashet.Data.Models;
using Nashet.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nashet.Business.Domain.Common
{
    public class BaseDomain
    {
        private NashetContext context;

        internal NashetContext _context
        {
            get
            {
                if (context == null)
                {
                    context = new NashetContext();
                    return context;
                }
                else
                    return context;
            }
        }

    }
}
