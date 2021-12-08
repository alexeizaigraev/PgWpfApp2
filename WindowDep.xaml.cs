using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace PgWpfApp2
{
    /// <summary>
    /// Логика взаимодействия для WindowDep.xaml
    /// </summary>
    public partial class WindowDep : Window
    {

        public WindowDep()
        {
            InitializeComponent();
            #region
            var items = new List<string>() { "item1", "item2" };
            try
            {
                listBox1.ItemsSource = PgBase.GetListDep();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                listBox1.ItemsSource = items;
            }
            #endregion

        }

        private List<string> GetCurrentData()
        {
            #region
            List<string> vec = new List<string>()
                {
                    textBoxDepartment.Text,
                    textBoxRegion.Text,
                    textBoxDistrictRegion.Text,
                    textBoxDistrCity.Text,
                    textBoxCityType.Text,
                    textBoxCity.Text,
                    textBoxStreet.Text,
                    textBoxStreetType.Text,
                    textBoxHous.Text,
                    textBoxPostIndex.Text,
                    textBoxPartner.Text,
                    textBoxStatus.Text,
                    textBoxRegister.Text,
                    textBoxEdrpou.Text,
                    textBoxAddress.Text,
                    textBoxPartnerName.Text,
                    textBoxIdTerminal.Text,
                    textBoxKoatu.Text,
                    textBoxTaxid.Text,
                    textBoxKoatu2.Text
                };
            return vec;
            #endregion
        }

        private void ClearMe()
        {
            #region
            textBoxDepartment.Text = "";
            textBoxRegion.Text = "";
            textBoxDistrictRegion.Text = "";
            textBoxDistrCity.Text = "";
            textBoxCityType.Text = "";
            textBoxCity.Text = "";
            textBoxStreet.Text = "";
            textBoxStreetType.Text = "";
            textBoxHous.Text = "";
            textBoxPostIndex.Text = "";
            textBoxPartner.Text = "";
            textBoxStatus.Text = "";
            textBoxRegister.Text = "";
            textBoxEdrpou.Text = "";
            textBoxAddress.Text = "";
            textBoxPartnerName.Text = "";
            textBoxIdTerminal.Text = "";
            textBoxKoatu.Text = "";
            textBoxTaxid.Text = "";
            textBoxKoatu2.Text = "";

            textBoxFind.Text = "";
            labeInfo.Content = "";
            #endregion
        }

        private void WinDepShowList_Click(object sender, RoutedEventArgs e)
        {
            #region
            string dep = "";

            try { dep = listBox1.SelectedItem.ToString(); }
            catch { MessageBox.Show("Выбери отделение из списка"); }

            if (dep != "")
            {
                try { Show(dep); }
                catch { MessageBox.Show("выбери одно отделение, балда"); }
            }
            //else { MessageBox.Show("Выбери отделение из списка"); }
            #endregion
        }

        private void WinDepFind_Click(object sender, RoutedEventArgs e)
        {
            #region
            string dep = "";

            try { dep = textBoxFind.Text; }
            catch { MessageBox.Show("Напиши отделение в окошко"); }

            if (dep != "")
            {
                try { Show(dep); }
                catch { MessageBox.Show("Напиши правильно отделение"); }
            }
            //else { MessageBox.Show("Напиши отделение в окошко"); }
            #endregion
        }

        private void Show(string dep)
        {
            #region
            var data = PgBase.DepGetOne(dep);
            ClearMe();
            textBoxDepartment.Text = data[0];
            textBoxRegion.Text = data[1];
            textBoxDistrictRegion.Text = data[2];
            textBoxDistrCity.Text = data[3];
            textBoxCityType.Text = data[4];
            textBoxCity.Text = data[5];
            textBoxStreet.Text = data[6];
            textBoxStreetType.Text = data[7];
            textBoxHous.Text = data[8];
            textBoxPostIndex.Text = data[9];
            textBoxPartner.Text = data[10];
            textBoxStatus.Text = data[11];
            textBoxRegister.Text = data[12];
            textBoxEdrpou.Text = data[13];
            textBoxAddress.Text = data[14];
            textBoxPartnerName.Text = data[15];
            textBoxIdTerminal.Text = data[16];
            textBoxKoatu.Text = data[17];
            textBoxTaxid.Text = data[18];
            textBoxKoatu2.Text = data[19];
            #endregion
        }

        private void WinDepClear_Click(object sender, RoutedEventArgs e)
        {
            ClearMe();
        }




        private void WinDepAdd_Click(object sender, RoutedEventArgs e)
        {
            #region
            List<string> vec = GetCurrentData();
            try
            {
                PgBase.DepAddOne(vec);
                labeInfo.Content = Papa.info;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

            var items = new List<string>() { "item1", "item2" };
            try
            {
                listBox1.ItemsSource = PgBase.GetListDep();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                listBox1.ItemsSource = items;
            }

            #endregion
        }

        private void WinDepDel_Click(object sender, RoutedEventArgs e)
        {
            bool flag = false;
            string dep = "";
            if (textBoxDepartment.Text != "" && textBoxFind.Text == "")
            {
                dep = textBoxDepartment.Text;
                flag = true;
            }
            if (textBoxDepartment.Text == "" && textBoxFind.Text != "")
            {
                dep = textBoxFind.Text;
                flag = true;
            }
            if (flag)
            {
                try { PgBase.DepDelOne(dep); }
                catch (Exception ex) { MessageBox.Show(ex.Message); }

                var items = new List<string>() { "item1", "item2" };
                try
                {
                    listBox1.ItemsSource = PgBase.GetListDep();
                    labeInfo.Content = Papa.info;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    listBox1.ItemsSource = items;
                }
            }
            else
            {
                MessageBox.Show("Выбери отделение, олух");
            }

        }

        private void WinDepUpdate_Click(object sender, RoutedEventArgs e)
        {
            bool flag = false;
            if (textBoxDepartment.Text != "") { flag = true; }
            if (flag)
            {
                List<string> vec = GetCurrentData();
                try { PgBase.DepUpdateOne(vec); }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
                labeInfo.Content = Papa.info;
            }
        }

        private void WinDepForward_Click(object sender, RoutedEventArgs e)
        {
            #region
            string dep = textBoxDepartment.Text;
            string nextDep = PgBase.NextDep(dep);
            Show(nextDep);
            #endregion
        }

        private void WinDepBack_Click(object sender, RoutedEventArgs e)
        {
            #region
            try
            {
                string dep = textBoxDepartment.Text;
                string nextDep = PgBase.PredDep(dep);
                Show(nextDep);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            #endregion
        }

        private void WinDepActual_Click(object sender, RoutedEventArgs e)
        {
            #region
            string dep = textBoxDepartment.Text;
            try
            {
                PgBase.DepDelOneNew(dep);
                labeInfo.Content = $"actual {dep} send";
            }
            catch { }

            List<string> vec = GetCurrentData();
            try { PgBase.DepAddOneNew(vec); }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            #endregion
        }

        private void WinDepDeActual_Click(object sender, RoutedEventArgs e)
        {
            #region
            string dep = textBoxDepartment.Text;
            try
            {
                PgBase.DepDelOneNew(dep);
                labeInfo.Content = $"deactual {dep} delete";
            }
            catch { labeInfo.Content = $"no deactual {dep} delete"; }
            #endregion
        }
    }
}
