using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public abstract class AbstractLogicAPI
    {
        public static AbstractLogicAPI CreateAPI(AbstractLogicAPI abstractDataApi = null)
        {
            return new LogicAPI(abstractDataApi);
        }

        internal class LogicAPI : AbstractLogicAPI
        {
            public LogicAPI(AbstractLogicAPI abstractDataApi)
            {
                AbstractDataApi = abstractDataApi;
            }

            public AbstractLogicAPI AbstractDataApi { get; }
        }

    }
}
