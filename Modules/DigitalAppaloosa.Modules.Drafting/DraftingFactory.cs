using System.Collections.ObjectModel;
using System.Windows;
using DigitalAppaloosa.Contracts.Interfaces;
using DigitalAppaloosa.Modules.Drafting.Handlers;
using DigitalAppaloosa.Modules.Drafting.ViewModels;
using DigitalAppaloosa.Modules.Drafting.Views;
using DigitalAppaloosa.Windows.Handlers;

namespace DigitalAppaloosa.Modules.Drafting
{
    internal static class DraftingFactory
    {
        internal static FrameworkElement CreateDraftingViewWithViewModel()
        {
            var draftingView = new HeadDraftingPaneView();
            var draftingVM = new HeadDraftingPaneViewModel();

            var draftingHandler = new DraftingHandler(draftingVM, draftingView);
            var dragDropHandler = new DragDropHandler();
            var handlersCollection = new ObservableCollection<IMouseButtonEventHandler> {
                draftingHandler, dragDropHandler };
            draftingVM.MouseButtonEventHandlers = handlersCollection;
            DraftingController.Instance.RegisterViewModel(draftingVM);
            DraftingController.Instance.RegisterDraftingHandler(draftingHandler);
            draftingView.DataContext = draftingVM;

            return draftingView;
        }
    }
}