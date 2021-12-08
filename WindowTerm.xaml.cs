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
    /// Логика взаимодействия для WindowTerm.xaml
    /// </summary>
    public partial class WindowTerm : Window
    {
        public WindowTerm()
        {
            InitializeComponent();

            #region
            var items = new List<string>() { "item1", "item2" };
            try
            {
                listBoxTerm.ItemsSource = PgBase.GetListTerm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                listBoxTerm.ItemsSource = items;
            }
            #endregion
        }

        private void ClearMe()
        {
            #region
            textBoxDepartment.Text = "";
            textBoxTermial.Text = "";
            textBoxModel.Text = "";
            textBoxSerialNumber.Text = "";
            textBoxDateManufacture.Text = "";
            textBoxSoft.Text = "";
            textBoxProducer.Text = "";
            textBoxRneRro.Text = "";
            textBoxSealing.Text = "";
            textBoxFiscalNumber.Text = "";
            textBoxOroSerial.Text = "";
            textBoxOroNumber.Text = "";
            textBoxTicketSerial.Text = "";
            textBoxTicket1Sheet.Text = "";
            textBoxTicketNumber.Text = "";
            textBoxSending.Text = "";
            textBoxToRro.Text = "";
            textBoxOwnerRro.Text = "";
            textBoxRegister.Text = "";
            textBoxFinish.Text = "";

            textBoxFind.Text = "";
            //textBoxAddress.Text = "";
            #endregion
        }

        private void WinTermClear_Click(object sender, RoutedEventArgs e)
        {
            ClearMe();
        }

        private List<string> GetCurrentData()
        {
            #region
            List<string> vec = new List<string>()
                {
                    textBoxDepartment.Text,
                    textBoxTermial.Text,
                    textBoxModel.Text,
                    textBoxSerialNumber.Text,
                    textBoxDateManufacture.Text,
                    textBoxSoft.Text,
                    textBoxProducer.Text,
                    textBoxRneRro.Text,
                    textBoxSealing.Text,
                    textBoxFiscalNumber.Text,
                    textBoxOroSerial.Text,
                    textBoxOroNumber.Text,
                    textBoxTicketSerial.Text,
                    textBoxTicket1Sheet.Text,
                    textBoxTicketNumber.Text,
                    textBoxSending.Text,
                    "", //books_arhiv
                    "", //tickets_arhiv
                    textBoxToRro.Text,
                    textBoxOwnerRro.Text,
                    textBoxRegister.Text,
                    textBoxFinish.Text
                };
            return vec;
            #endregion
        }

        private void WinTermShowList_Click(object sender, RoutedEventArgs e)
        {
            #region
            string term = "";

            try { term = listBoxTerm.SelectedItem.ToString(); }
            catch { MessageBox.Show($"Выбери терминал из списка, term={term}"); }

            if (term != "")
            {
                try { Show(term); }
                //catch {  }
                catch { MessageBox.Show("выбери один терминал, балда"); }
            }
            //else { MessageBox.Show("Выбери отделение из списка"); }
            #endregion
        }

        private void WinTermFind_Click(object sender, RoutedEventArgs e)
        {
            #region
            string term = "";

            try { term = textBoxFind.Text; }
            catch { MessageBox.Show("Напиши терминал в окошко"); }

            if (term != "")
            {
                try { Show(term); }
                catch { MessageBox.Show("Напиши правильно терминал"); }
            }
            //else { MessageBox.Show("Напиши отделение в окошко"); }
            #endregion
        }

        private void Show(string term)
        {
            #region
            var data = PgBase.TermGetOne(term);
            ClearMe();
            textBoxDepartment.Text = data[0];
            textBoxTermial.Text = data[1];
            textBoxModel.Text = data[2];
            textBoxSerialNumber.Text = data[3];
            textBoxDateManufacture.Text = data[4];
            textBoxSoft.Text = data[5];
            textBoxProducer.Text = data[6];
            textBoxRneRro.Text = data[7];
            textBoxSealing.Text = data[8];
            textBoxFiscalNumber.Text = data[9];
            textBoxOroSerial.Text = data[10];
            textBoxOroNumber.Text = data[11];
            textBoxTicketSerial.Text = data[12];
            textBoxTicket1Sheet.Text = data[13];
            textBoxTicketNumber.Text = data[14];
            textBoxSending.Text = data[15];
            textBoxToRro.Text = data[18];
            textBoxOwnerRro.Text = data[19];
            textBoxRegister.Text = data[20];
            textBoxFinish.Text = data[21];

            textBoxAddress.Text = PgBase.DepGetAddress(data[0]);

            //catch (Exception ex) { MessageBox.Show(ex.Message); }

            #endregion
        }

        private void WinTermAdd_Click(object sender, RoutedEventArgs e)
        {
            #region
            List<string> vec = GetCurrentData();
            try
            {
                PgBase.TermAddOne(vec);
                labeInfo.Content = Papa.info;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

            var items = new List<string>() { "item1", "item2" };
            try
            {
                listBoxTerm.ItemsSource = PgBase.GetListTerm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                listBoxTerm.ItemsSource = items;
            }
            #endregion
        }

        private void WinTermDel_Click(object sender, RoutedEventArgs e)
        {
            #region
            bool flag = false;
            string term = "";
            if (textBoxTermial.Text != "" && textBoxFind.Text == "")
            {
                term = textBoxTermial.Text;
                flag = true;
            }
            if (textBoxTermial.Text == "" && textBoxFind.Text != "")
            {
                term = textBoxFind.Text;
                flag = true;
            }
            if (flag)
            {
                try { PgBase.TermDelOne(term); }
                catch (Exception ex) { MessageBox.Show(ex.Message); }

                var items = new List<string>() { "item1", "item2" };
                try
                {
                    listBoxTerm.ItemsSource = PgBase.GetListTerm();
                    labeInfo.Content = Papa.info;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    listBoxTerm.ItemsSource = items;
                }
            }
            else
            {
                MessageBox.Show("Выбери терминал, олух");
            }
            #endregion
        }

        private void WinTermUpdate_Click(object sender, RoutedEventArgs e)
        {
            bool flag = false;
            if (textBoxTermial.Text != "") { flag = true; }
            if (flag)
            {
                List<string> vec = GetCurrentData();
                try { PgBase.TermUpdateOne(vec); }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
                labeInfo.Content = Papa.info;
            }
        }

        private void WinTermForward_Click(object sender, RoutedEventArgs e)
        {
            #region
            string term = textBoxTermial.Text;
            string next = PgBase.NextTerm(term);
            Show(next);
            #endregion
        }

        private void WinTermBack_Click(object sender, RoutedEventArgs e)
        {
            #region
            try
            {
                string term = textBoxTermial.Text;
                string pred = PgBase.PredTerm(term);
                Show(pred);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            #endregion
        }

        private void WinTermActual_Click(object sender, RoutedEventArgs e)
        {
            #region
            string term = textBoxTermial.Text;
            try
            {
                PgBase.TermDelOneNew(term);
                labeInfo.Content = $"actual {term} send";
            }
            catch { }

            List<string> vec = GetCurrentData();
            try { PgBase.TermAddOneNew(vec); }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            #endregion
        }

        private void WinTermDeActual_Click(object sender, RoutedEventArgs e)
        {
            #region
            string term = textBoxTermial.Text;
            try
            {
                PgBase.TermDelOneNew(term);
                labeInfo.Content = $"deactual {term} delete";
            }
            catch { labeInfo.Content = $"no deactual {term} delete"; }
            #endregion
        }

    }
}
