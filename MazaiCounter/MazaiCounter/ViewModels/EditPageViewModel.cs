using MazaiCounter.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace MazaiCounter.ViewModels
{
    public class EditPageViewModel : ViewModelBase
    {
        private MazaiHolder _mazaiHolder;
        private MazaiNote _mazaiNote;
        public MazaiNote MazaiNote
        {
            get { return _mazaiNote; }
            set { SetProperty(ref _mazaiNote, value); }
        }

        public ReactiveProperty<ObservableCollection<MazaiNote>> MazaiNotes { get; }

        public DelegateCommand SaveCommand { get; }

        public EditPageViewModel(INavigationService navigationService, MazaiHolder mazaiHolder)
            : base(navigationService)
        {
            _mazaiHolder = mazaiHolder;
            MazaiNotes = _mazaiHolder.ToReactivePropertyAsSynchronized(x => x.MazaiNotes);

            MazaiNote = new MazaiNote()
            {
                Date = DateTime.Now,
                TimeSpan = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second)
            };

            SaveCommand = new DelegateCommand(ExecuteSave);
        }

        public override void OnNavigatingTo(NavigationParameters navigationParameters)
        {
            MazaiNote = new MazaiNote()
            {
                Date = DateTime.Now,
                TimeSpan = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second)
            };
        }

        private async void ExecuteSave()
        {
            MazaiNotes.Value.Add(MazaiNote);
            await _mazaiHolder.SaveAsync();
            await NavigationService.GoBackAsync();
        }
    }
}
