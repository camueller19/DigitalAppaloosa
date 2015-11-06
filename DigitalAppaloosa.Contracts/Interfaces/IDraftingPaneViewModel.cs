using System.Collections.Generic;
using System.Windows;

namespace DigitalAppaloosa.Contracts.Interfaces
{
    public interface IDraftingPaneViewModel
    {
        ICollection<FrameworkElement> Items { get; }
    }
}