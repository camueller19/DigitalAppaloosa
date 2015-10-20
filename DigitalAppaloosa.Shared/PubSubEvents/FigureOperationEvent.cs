using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Events;

namespace DigitalAppaloosa.Shared.PubSubEvents
{
    public class FigureOperationEvent : PubSubEvent<FigureOperation>
    {
    }

    public enum FigureOperation
    {
        Rectangle
        //TODO add more
    }
}
