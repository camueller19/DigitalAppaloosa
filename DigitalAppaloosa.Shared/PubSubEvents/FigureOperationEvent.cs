using Prism.Events;

namespace DigitalAppaloosa.Shared.PubSubEvents
{
    public class FigureOperationEvent : PubSubEvent<FigureOperation>
    {
    }

    public enum FigureOperation
    {
        None,
        Rectangle,
        Circle
        //TODO add more
    }
}