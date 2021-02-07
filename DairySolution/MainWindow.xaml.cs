using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
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
using DairySolution.Integrations.SolvewareAPI.Model;
using DairySolution.Integrations.SolvewareAPI.Services;
using MahApps.Metro.Controls;
using SloveWare.Entities;

namespace DairySolution
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow, INotifyPropertyChanged

    {




        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }



        public static Action<tblDiary,bool> selectedDiary;





       


        private ObservableCollection<tblDiaryDetails> _AllPostedDiaries;

        public ObservableCollection<tblDiaryDetails> AllPostedDiaries
        {
            get { return _AllPostedDiaries; }
            set { _AllPostedDiaries = value; OnPropertyChanged("AllPostedDiaries"); }
        }


        private ObservableCollection<tblDiaryDetails> _SelectedPostedDiaries;

        public ObservableCollection<tblDiaryDetails> SelectedPostedDiaries
        {
            get { return _SelectedPostedDiaries; }
            set { _SelectedPostedDiaries = value; OnPropertyChanged("SelectedPostedDiaries"); }
        }




        private tblDiary _SelectedDiary;

        public tblDiary SelectedDiary
        {
            get { return _SelectedDiary; }
            set { _SelectedDiary = value; OnPropertyChanged("_SelectedDiary"); }
        }




        private ObservableCollection<DiaryTemplate> _DiaryTemplates;






        public ObservableCollection<DiaryTemplate> DiaryTemplates
        {
            get
            {
                return _DiaryTemplates;
            }
            set
            {
                _DiaryTemplates = value;
                OnPropertyChanged("DiaryTemplates");
            }
        }
        public class DiaryType
        {
            public string DiaryTypeName { get; set; }
            public tblDiary dairyData { get; set; }
        }
        public class DiaryTitle
        {
            public tblDiary dairyData { get; set; }
            public string DiaryName { get; set; }
        }
        public class DiaryItemTemplate
        {
            private List<DiaryType> _DiaryType;



            public List<DiaryType> DiaryType
            {
                get
                {
                    return _DiaryType;
                }
                set
                {
                    _DiaryType = value;
                    ;
                }
            }
            public DiaryItemTemplate()
            {
                DiaryType = new List<DiaryType>();
                DiaryTitle = new DiaryTitle();
            }

            public DiaryTitle DiaryTitle { get; set; }

        }



        public class DiaryTemplate
        {
            private List<DiaryItemTemplate> _AllDiaries;

            public DiaryTemplate(string dname = "Diary")
            {
                Name = dname;

                AllDiaries = new List<DiaryItemTemplate>();
            }
            public List<DiaryItemTemplate> AllDiaries
            {
                get
                {
                    return _AllDiaries;
                }
                set
                {
                    _AllDiaries = value;

                }
            }
            public string Name
            {
                get;
                set;
            } = "Diary";
        }

        public static Frame mainFrame = new Frame();
        public MainWindow()
        {
            InitializeComponent();
            selectedDiary += new Action<tblDiary,bool>(updateDiary);
            this.DataContext = this;
            mainFrame = MainContentFrame;
            mainFrame.Navigate(new Diary_Page());
            DiaryTemplates = new ObservableCollection<DiaryTemplate>();
            //var dairy = new DiaryTemplate();
            //dairy.Name = "Diary";
            
            //DiaryItemTemplate di = new DiaryItemTemplate();
            //di.DiaryTitle.DiaryName = "DiaryOne";
            //var dtype = new List<DiaryType>();
            //dtype.Add(new DiaryType { DiaryTypeName="Hand on Diary" });
            //dtype.Add(new DiaryType { DiaryTypeName = "Take Over Diary" });
            //di.DiaryType = dtype;
            //dairy.AllDiaries.Add(di);

            // di = new DiaryItemTemplate();
            //di.DiaryTitle.DiaryName = "Diarytwo";
            // dtype = new List<DiaryType>();
            //dtype.Add(new DiaryType { DiaryTypeName = "Hand on Diary" });
            //dtype.Add(new DiaryType { DiaryTypeName = "Take Over Diary" });
            //di.DiaryType = dtype;
            //dairy.AllDiaries.Add(di);

            //DiaryTemplates.Add(dairy);
            LoadTree += new Action<tblDiaryDetails>(updateTree);

        }

        private async void updateTree(tblDiaryDetails model)
        {
           await LoadTreeData();
        }

        private void updateDiary(tblDiary obj,bool ishandson)
        {
            
        }

        private void SubMenu1Radio_Unchecked(object sender, RoutedEventArgs e)
        {
          //  DiaryRadioBtn.IsChecked = false;
        }
        private void SubMenu1Radio_Checked(object sender, RoutedEventArgs e)
        {
            //DiaryRadioBtn.IsChecked = true;
        }

        private void FeedbackRadioBtn_Checked(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new FeedBack());
        }

        private void DashboardRadioBtn_Checked(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new Diary_Page());

        }

        private void MetroWindow_Initialized(object sender, EventArgs e)
        {

        }

        private void reportradiobutton(object sender, RoutedEventArgs e)
        {

        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            
        }
        
        private void MainTreeView_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            
            mainFrame.Navigate(new Diary());
            //selectedDiary(new DiaryModel());
        }
        public static Action<tblDiaryDetails> LoadTree;
        private void DiaryName_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var data = sender as dynamic;
            mainFrame.Navigate(new Diary());
            var dataContext = data.DataContext as DiaryItemTemplate;
           
            selectedDiary(dataContext.DiaryTitle.dairyData,false);
        }

        private void DiaryTypes(object sender, MouseButtonEventArgs e)
        {
            var data = sender as dynamic;
            mainFrame.Navigate(new Diary());
            var dataContext = data.DataContext as DiaryType;
            bool ishands = false;
            if (dataContext.DiaryTypeName== "Hand on Diary")
            {
                ishands = true;
            }
            selectedDiary(dataContext.dairyData, ishands);

        }

        private async void loaded(object sender, RoutedEventArgs e)
        {
            await LoadTreeData();
        }
        #region Api Calling Region
        private async Task LoadTreeData()
        {
            var dairy = new DiaryTemplate();
            dairy.Name = "Diary";
            int counter = 1;
            if (DiaryTemplates == null)
            {
                DiaryTemplates = new ObservableCollection<DiaryTemplate>();
            }
            else
            {
                DiaryTemplates.Clear();
            }
            var data = await new DiaryService().GetAllDiaryAsync();
            foreach (var item in data)
            {


                DiaryItemTemplate di = new DiaryItemTemplate();
                di.DiaryTitle.DiaryName =item.Name;
                di.DiaryTitle.dairyData = item;
                var dtype = new List<DiaryType>();
                dtype.Add(new DiaryType { DiaryTypeName = "Hand on Diary", dairyData=item });
                dtype.Add(new DiaryType { DiaryTypeName = "Take Over Diary", dairyData = item });
                di.DiaryType = dtype;

                dairy.AllDiaries.Add(di);
                counter++;
            }
            DiaryTemplates.Add(dairy);
            OnPropertyChanged("DiaryTemplates");
        }

       


        #endregion
        private void TreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            
        }
    }
}
