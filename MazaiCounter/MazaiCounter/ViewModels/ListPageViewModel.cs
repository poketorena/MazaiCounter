using MazaiCounter.Models;
using MazaiCounter.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace MazaiCounter.ViewModels
{
    public class ListPageViewModel : ViewModelBase
    {
        // プロパティ
        public ReactiveProperty<ObservableCollection<MazaiNote>> MazaiNotes { get; }

        // パブリック関数

        // デリゲートコマンド
        public DelegateCommand NavigateMazaiInfoCommand { get; }

        // DI注入を受ける変数
        private MazaiHolder _mazaiHolder;

        // コンストラクタ
        public ListPageViewModel(INavigationService navigationService, MazaiHolder mazaiHolder)
            : base(navigationService)
        {
            _mazaiHolder = mazaiHolder;

            MazaiNotes = _mazaiHolder.ToReactivePropertyAsSynchronized(x => x.MazaiNotes);

            NavigateMazaiInfoCommand = new DelegateCommand(() =>
            {
                NavigationService.NavigateAsync(nameof(EditPage));
            });
        }
    }
}