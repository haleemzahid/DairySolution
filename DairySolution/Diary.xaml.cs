using DairySolution.Integrations.SolvewareAPI.Model;
using DairySolution.Integrations.SolvewareAPI.Services;
using System;
using System.Collections.Generic;
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
    public partial class Diary : UserControl
    {

        private DiaryModel diaryModel;

        public DiaryModel DiaryModel
        {
            get { return diaryModel; }
            set { diaryModel = value; }
        }




        public Diary()
        {
            InitializeComponent();
            this.DataContext = this;
            date.Text = DateTime.Now.ToShortDateString();
            time.Text = DateTime.Now.ToShortTimeString();
            diaryModel = new DiaryModel();




        }

        private async void Saved(object sender, RoutedEventArgs e)
        {
           await new DiaryService().InsertDiary(DiaryModel);
        }
    }
}
