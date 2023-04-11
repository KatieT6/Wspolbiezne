using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic;

namespace PresentationModel
{
    internal class PresentationModel : AbstractModelAPI
    {
        public PresentationModel()
        {
        }

/*        tu jeszcze trzeba przemyśleć/dopracować
 *        private AbstractLogicAPI logicAPI = */

        public override void CreateScene(int quantity, int radious)
        {
            throw new NotImplementedException();
        }

        public override void Dispose()
        {
            throw new NotImplementedException();
        }

        public override void Start()
        {
            throw new NotImplementedException();
        }

        public override IDisposable Subscribe(IObserver<InterfaceBall> observer)
        {
            throw new NotImplementedException();
        }
    }
}
