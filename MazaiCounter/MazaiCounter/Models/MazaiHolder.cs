using Newtonsoft.Json;
using PCLStorage;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace MazaiCounter.Models
{
    public class MazaiHolder : BindableBase
    {
        private ObservableCollection<MazaiNote> _mazaiNotes;
        public ObservableCollection<MazaiNote> MazaiNotes
        {
            get { return _mazaiNotes; }
            set { SetProperty(ref _mazaiNotes, value); }
        }

        public MazaiHolder()
        {
            LoadAsync();
        }

        public async Task SaveAsync()
        {
            var jsonString = JsonConvert.SerializeObject(MazaiNotes);

            var rootFolder = FileSystem.Current.LocalStorage;
            var file = await rootFolder.CreateFileAsync("MazaiNotes.json", CreationCollisionOption.ReplaceExisting);
            await file.WriteAllTextAsync(jsonString);
        }

        public async Task LoadAsync()
        {
            var rootFolder = FileSystem.Current.LocalStorage;
            var file = await rootFolder.CreateFileAsync("MazaiNotes.json", CreationCollisionOption.OpenIfExists);
            var jsonString = await file.ReadAllTextAsync();

            MazaiNotes = JsonConvert.DeserializeObject<ObservableCollection<MazaiNote>>(jsonString) ?? new ObservableCollection<MazaiNote>();
        }
    }
}
