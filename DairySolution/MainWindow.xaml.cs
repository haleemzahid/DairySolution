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



        public static Action<DiaryModel> selectedDiary;
        
        
        
        
        
        
        
        
        
        
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
            
        }
        public class DiaryTitle
        {
            public DiaryModel dairyData { get; set; }
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
            selectedDiary += new Action<DiaryModel>(updateDiary);
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
            LoadTree += new Action<DiaryModel>(updateTree);

        }

        private async void updateTree(DiaryModel model)
        {
           await LoadTreeData();
        }

        private void updateDiary(DiaryModel obj)
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
        public static Action<DiaryModel> LoadTree;
        private void DiaryName_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var data = sender as dynamic;
            mainFrame.Navigate(new Diary());
            var dataContext = data.DataContext as DiaryItemTemplate;

            selectedDiary(dataContext.DiaryTitle.dairyData);
        }

        private void DiaryTypes(object sender, MouseButtonEventArgs e)
        {

        }

        private async void loaded(object sender, RoutedEventArgs e)
        {
            await LoadTreeData();
        }

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
                di.DiaryTitle.DiaryName = "Diary " + counter;
                di.DiaryTitle.dairyData = item;
                var dtype = new List<DiaryType>();
                dtype.Add(new DiaryType { DiaryTypeName = "Hand on Diary" });
                dtype.Add(new DiaryType { DiaryTypeName = "Take Over Diary" });
                di.DiaryType = dtype;

                dairy.AllDiaries.Add(di);
                counter++;
            }
            DiaryTemplates.Add(dairy);
            OnPropertyChanged("DiaryTemplates");
        }

        private void TreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            DiaryName_MouseDown(null,null);
        }
    }
}
