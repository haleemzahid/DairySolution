using DairySolution.Integrations.SolvewareAPI.Model;
using DairySolution.Integrations.SolvewareAPI.Services;
using SloveWare.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Linq;

namespace DairySolution
{
  


    /// <summary>
    /// Interaction logic for Diary.xaml
    /// </summary>
    public partial class Diary : UserControl, INotifyPropertyChanged

    {


        private ObservableCollection<DiaryDetailsModel> _AllPostedDiaries;

        public ObservableCollection<DiaryDetailsModel> AllPostedDiaries
        {
            get { return _AllPostedDiaries; }
            set { _AllPostedDiaries = value; OnPropertyChanged("AllPostedDiaries"); }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }


        private tblDiaryDetails diaryModel;

        public tblDiaryDetails DiaryModel
        {
            get { return diaryModel; }
            set { diaryModel = value; OnPropertyChanged("DiaryModel"); }
        }


        private tblDiary _SaveDiaryModel;

        public tblDiary SaveDiaryModel
        {
            get { return _SaveDiaryModel; }
            set { _SaveDiaryModel = value; OnPropertyChanged("SaveDiaryModel"); }
        }


        private async Task LoadEvent()
        {

            var events = await new EventService().GetAllEvent();
            if (events!=null) {
                Events = new ObservableCollection<tblEvent>(events);
            }

        }

        private async Task<ObservableCollection<tblDiaryDetails>> GetAllPostedDiaries(tblDiary diary)
        {

            var events = await new DiaryService().GetAllPostedDiaryAsync(diary);

            if (events == null) return null;
            

            return new ObservableCollection<tblDiaryDetails>(events);


        }




        private async Task LoadStatus()
        {

            var status = await new StatusService().GetAllStatusAsync();


            if (status == null) return;

            Statuses = new ObservableCollection<tblStatus>(status);

            //await GetAllPostedDiaries();
        }

        public void initDiaryModel()
        {
            DiaryModel = new tblDiaryDetails();
            
        }
        public Diary()
        {
            InitializeComponent();
            MainWindow.selectedDiary += new Action<tblDiary,bool>(UpdateUi);
            this.DataContext = this;
            
            
            Events = new ObservableCollection<tblEvent>();
            //Statuses = new ObservableCollection<tblStatus>();
           
            AllPostedDiaries = new ObservableCollection<DiaryDetailsModel>();
            initDiaryModel();


        }
        private ObservableCollection<tblEvent> tblEvents;

        public ObservableCollection<tblEvent> Events
        {
            get { return tblEvents; }
            set { tblEvents = value; OnPropertyChanged("Events"); }
        }

        private ObservableCollection<tblStatus> _Statuses;

        public ObservableCollection<tblStatus> Statuses
        {
            get { return _Statuses; }
            set { _Statuses = value; OnPropertyChanged("Statuses"); }
        }
        public bool ishandsOn { get; set; } = false;
        private async void UpdateUi(tblDiary obj,bool ishandson)
        {

            await LoadEvent();
            await LoadStatus();
            var pd=await GetAllPostedDiaries(obj);
            if (pd != null)
                if (pd.Count > 0 && pd.Any(x => x.tblDiaryId == obj.Id && x.IsHandsOn==ishandson))
                {
                    var PostedDiaries = new ObservableCollection<DiaryDetailsModel>();
                    var data= new ObservableCollection<tblDiaryDetails>(pd.Where(x => x.tblDiaryId == obj.Id && x.IsHandsOn == ishandson).ToList());
                    foreach (var item in data)
                    {
                        var p = new DiaryDetailsModel();
                        p.EventName = Events.Where(x => x.Id == item.tblEventId).FirstOrDefault().Name;
                        p.StatusName = Statuses.Where(x => x.Id == item.tblStatusId).FirstOrDefault().Name;
                        p.Particulars = item.Particulars;
                        p.Date = DateTime.Now.ToShortDateString();
                        p.Time = DateTime.Now.ToShortTimeString();
                        PostedDiaries.Add(p);
                    }
                    AllPostedDiaries = PostedDiaries;
                
                }
                else
                    AllPostedDiaries = new ObservableCollection<DiaryDetailsModel>();
            SaveDiaryModel = obj;
            ishandsOn = ishandson;
            

        }

        private async void Saved(object sender, RoutedEventArgs e)
        {
            
            DiaryModel.tblDiaryId = SaveDiaryModel.Id;
            DiaryModel.IsHandsOn = ishandsOn;
            await new DiaryService().InsertDiary(DiaryModel);

            if (AllPostedDiaries == null) AllPostedDiaries = new ObservableCollection<DiaryDetailsModel>();
                AllPostedDiaries.Add(new DiaryDetailsModel { EventName=Events.Where(x=>x.Id== DiaryModel.tblEventId).FirstOrDefault().Name, StatusName= Statuses.Where(x => x.Id == DiaryModel.tblStatusId).FirstOrDefault().Name,
                   Date=DateTime.Now.ToShortDateString(), Time=DateTime.Now.ToShortTimeString(),
                   Particulars=DiaryModel.Particulars
                
                });
            OnPropertyChanged("AllPostedDiaries");

            //  MainWindow.LoadTree(DiaryModel);
            OnPropertyChanged("SaveDiaryModel");
            //  SaveDiaryModel = diaryModel;
            diaryModel = new tblDiaryDetails();
            OnPropertyChanged("DiaryModel");
        }

        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            await LoadEvent();
            await LoadStatus();

        }
    }
}
