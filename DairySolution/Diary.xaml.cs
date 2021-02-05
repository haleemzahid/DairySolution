using DairySolution.Integrations.SolvewareAPI.Model;
using DairySolution.Integrations.SolvewareAPI.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DairySolution
{
  


    /// <summary>
    /// Interaction logic for Diary.xaml
    /// </summary>
    public partial class Diary : UserControl, INotifyPropertyChanged

    {




        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }


        private DiaryModel diaryModel;

        public DiaryModel DiaryModel
        {
            get { return diaryModel; }
            set { diaryModel = value; OnPropertyChanged("DiaryModel"); }
        }


        private DiaryModel _SaveDiaryModel;

        public DiaryModel SaveDiaryModel
        {
            get { return _SaveDiaryModel; }
            set { _SaveDiaryModel = value; OnPropertyChanged("SaveDiaryModel"); }
        }




        public Diary()
        {
            InitializeComponent();
            MainWindow.selectedDiary += new Action<DiaryModel>(UpdateUi);
            this.DataContext = this;
            date.Text = DateTime.Now.ToShortDateString();
            time.Text = DateTime.Now.ToShortTimeString();
            diaryModel = new DiaryModel();




        }

        private void UpdateUi(DiaryModel obj)
        {
            SaveDiaryModel = obj;
        }

        private async void Saved(object sender, RoutedEventArgs e)
        {
           await new DiaryService().InsertDiary(DiaryModel);
            MainWindow.LoadTree(DiaryModel);
            OnPropertyChanged("SaveDiaryModel");
            SaveDiaryModel = diaryModel;
            diaryModel = new DiaryModel();
        }
    }
}
