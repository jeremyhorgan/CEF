using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CefHost.Models
{
    internal class SimbaWrapper
    {
        private SIMBA.IWModel _model;

        public SimbaWrapper(SIMBA.IWModel model)
        {
            _model = model;
        }

        public string Title
        {
            get { return _model.Title; }
        }
    }
}
