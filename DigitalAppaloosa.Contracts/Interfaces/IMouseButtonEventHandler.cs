using System;
using System.Windows;

namespace DigitalAppaloosa.Contracts.Interfaces
{
    public interface IMouseButtonEventHandler
    {
        void HandlePreviewMouseLeftButtonDownEvent(IMouseButtonEventDataTransferObject mouseEventData);

        void HandlePreviewMouseLeftButtonUpEvent(IMouseButtonEventDataTransferObject mouseEventData);

        void HandlePreviewMouseMove(IMouseButtonEventDataTransferObject mouseEventData);
    }

    public interface IMouseButtonEventDataTransferObject
    {
        Func<IInputElement, Point> GetPosition { get; }
    }
}