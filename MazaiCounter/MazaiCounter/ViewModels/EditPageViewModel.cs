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
        // プロパティ
        public ReactiveProperty<ObservableCollection<MazaiNote>> MazaiNotes { get; }

        public ReactiveProperty<MazaiNote> MazaiNote { get; } = new ReactiveProperty<MazaiNote>();

        // パブリック関数
        public override void OnNavigatingTo(NavigationParameters navigationParameters)
        {
            MazaiNote.Value = new MazaiNote()
            {
                Date = DateTime.Now,
                TimeSpan = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second)
            };
        }

        // デリゲートコマンド
        private DelegateCommand _saveCommand;
        public DelegateCommand SaveCommand =>
            _saveCommand ?? (_saveCommand = new DelegateCommand(ExecuteSaveCommand));

        // DI注入を受ける変数
        private MazaiHolder _mazaiHolder;

        // コンストラクタ
        public EditPageViewModel(INavigationService navigationService, MazaiHolder mazaiHolder)
            : base(navigationService)
        {
            _mazaiHolder = mazaiHolder;
            MazaiNotes = _mazaiHolder.ToReactivePropertyAsSynchronized(x => x.MazaiNotes);

            MazaiNote.Value = new MazaiNote()
            {
                Date = DateTime.Now,
                TimeSpan = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second)
            };
        }

        // プライベート関数
        private async void ExecuteSaveCommand()
        {
            MazaiNotes.Value.Add(MazaiNote.Value);
            await _mazaiHolder.SaveAsync();
            await NavigationService.GoBackAsync();
        }
    }
}
