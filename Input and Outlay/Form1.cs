using System;
using System.Data;
using System.Windows.Forms;
using System.Data.OleDb;
using BelarusianDoor.Data;
using System.Linq;

namespace BelarusianDoor
{
    public partial class Form1 : Form
    {
        string logErrorFile;

        public Form1()
        {
            try
            {
                InitializeComponent();

                AutoFillComboBox();
                LoadTables();
                CalculateDayBalance();

                logErrorFile = Application.StartupPath + @"\errorlog.txt";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Ошибка");
                WriteLogErrorFile.WriteInLog(logErrorFile, ex.ToString());
            }
        }

        /// <summary>
        /// Завантаження таблиць надходжень і витрат
        /// </summary>
        private void LoadTables()
        {
            LoadIncomeTableInGridView();
            LoadOutlayTableToGridView();
            LoadVisitors();
        }

        /// <summary>
        /// Вибір іншої дати на календарі
        /// </summary>
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                LoadTables();

                CalculateDayBalance();

                ClearIncomeTextBoxes();
                ClearOutlayTextBoxes();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                WriteLogErrorFile.WriteInLog(logErrorFile, ex.ToString());
            }
        }

        /// <summary>
        /// Очистити текстові поля повязані з таблицею Надходжень
        /// </summary>
        private void ClearIncomeTextBoxes()
        {
            textBox_Summ1.Clear();
            textBox_WhoGive1.Clear();
            comboBox_whoReceive1.SelectedIndex = -1;
            textBox_id1.Clear();
        }

        /// <summary>
        /// Очистити текстові поля повязані з таблицею Витрат
        /// </summary>
        private void ClearOutlayTextBoxes()
        {
            textBox_SummaOutlay.Clear();
            textBox_WhereMoneyGoes.Clear();
            textBox_WhomeReceiveMoney.Clear();
            textBox_idOutlay.Clear();
        }

        #region Excel
        /// <summary>
        /// Збереження результатів в excel & pdf файл
        /// </summary
        private void btn_SaveInExcelFile_Click(object sender, EventArgs e)
        {
            model_SaveExcelAndPdfFiles();
        }

        /// <summary>
        /// Зберігаємо файли в форматі pdf и excel
        /// </summary>
        private void model_SaveExcelAndPdfFiles()
        {
            try
            {
                CreateExcelFile newExcelFile = new CreateExcelFile(dateTimePicker1.Value, dataGridView1, dataGridView2);
                newExcelFile.MakeExcelFile(
                    Convert.ToDecimal(textBox_moneyYesterdayEvening.Text),
                    Convert.ToDecimal(textBox_dayBalance.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                WriteLogErrorFile.WriteInLog(logErrorFile, ex.ToString());
            }
        }

        #endregion Excel

        /// <summary>
        /// Розрахунок всіх інформативних полів
        /// </summary>
        private void CalculateDayBalance()
        {
            decimal summaInput, summaOut, moneyInTheMorning, moneyInTheEvening;

            using (DoorsEntities db = new DoorsEntities())
            {
                var queryFromIn = db.IncomeMoneys.Where(p => p.DateIn == dateTimePicker1.Value.Date)
                                            .Sum(p => p.Summa)
                                            .GetValueOrDefault(0);
                summaInput = queryFromIn;

                var queryFromOut = db.OutlayMoneys.Where(p => p.DateOut == dateTimePicker1.Value.Date)
                          .Sum(p => p.Summa)
                          .GetValueOrDefault(0);
                summaOut = queryFromOut;

                var queryInTheMorning = db.Balances.Where(p => p.Date == dateTimePicker1.Value.Date).FirstOrDefault();
                moneyInTheMorning = queryInTheMorning == null ? 0 : queryInTheMorning.SummaInTheMorning;

                var queryInTheEvening = db.Balances.Where(p => p.Date == dateTimePicker1.Value.Date).FirstOrDefault();
                moneyInTheEvening = queryInTheEvening == null ? 0 : queryInTheEvening.SummaInTheEvening;
            }

            textBox_summInputToday.Text = summaInput.ToString();
            textBox_summaOutlayToday.Text = summaOut.ToString();
            textBox_dayBalance.Text = moneyInTheEvening.ToString();
            textBox_moneyYesterdayEvening.Text = moneyInTheMorning.ToString();
        }

        #region Таблиця НАдходжень

        /// <summary>
        /// Завантаження таблиці Income в datagridview
        /// </summary>
        private void LoadIncomeTableInGridView()
        {
            using (var db = new DoorsEntities())
            {
                var query = from s in db.IncomeMoneys
                            where s.DateIn == dateTimePicker1.Value.Date
                            join prod in db.Employees on s.EmployeeId equals prod.Id                            
                            select new
                            { Summa = s.Summa, Customer = s.Customer, Employee=prod.Name, Id=s.Id, EmployeeId=s.EmployeeId, DateIn=s.DateIn };

                if (query == null)
                    return;

                var notices = query.ToList();

                dataGridView1.DataSource = notices;
            }

            dataGridView1.Columns["DateIn"].Visible = false;
            dataGridView1.Columns["EmployeeId"].Visible = false;
            dataGridView1.Columns["Summa"].HeaderText = "Сума";
            dataGridView1.Columns["Customer"].HeaderText = "Від кого поступили";
            dataGridView1.Columns["Employee"].HeaderText = "Хто отримав";
            dataGridView1.AutoResizeColumns();
        }

        /// <summary>
        /// Заповнення комбобоксів даними з БД
        /// </summary>
        private void AutoFillComboBox()
        {
            using (DoorsEntities db = new DoorsEntities())
            {
                var query = from s in db.Employees
                            where s.Status == true
                            select s.Name;

                foreach (var item in query)
                {
                    comboBox_whoReceive1.Items.Add(item.ToString());
                }
            }
        }

        /// <summary>
        /// Зберегти дані в таблицю
        /// </summary>
        private void btn_SaveData_Click(object sender, EventArgs e)
        {
            if (!ValidateInputFieldsInIncome())
                return;

            IncomeMoney notice = new IncomeMoney()
            {
                DateIn = dateTimePicker1.Value.Date,
                Summa = Convert.ToDecimal(textBox_Summ1.Text),
                Customer = textBox_WhoGive1.Text,
                EmployeeId = (short) (comboBox_whoReceive1.SelectedIndex + 1)
            };

            using (DoorsEntities db = new DoorsEntities())
            {
                try
                {
                    db.IncomeMoneys.Add(notice);    // додаємо запис
                    db.SaveChanges();               // зберігаємо таблицю
                }
                catch (System.Data.Entity.Infrastructure.DbUpdateException)
                {
                    MessageBox.Show("Переконайтесь, що Ви відобразили всі необхідні записи за попередні дні " +
                                     "або переконайтесь, що вибрана Вами дата вірна.", "Помилка при веденні журналу обліку",
                                     MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    WriteLogErrorFile.WriteInLog(logErrorFile, ex.ToString());
                }

            }

            // Оновлюємо view
            LoadIncomeTableInGridView();
            CalculateDayBalance();
        }

        /// <summary>
        /// Редагувати дані в таблиці
        /// </summary>
        private void btn_EditData_Click(object sender, EventArgs e)
        {
            if (!ValidateInputFieldsInIncome() || textBox_id1.Text == "")
                return;

            uint id = Convert.ToUInt32(textBox_id1.Text);

            using (DoorsEntities db = new DoorsEntities())
            {
                var notice = db.IncomeMoneys.FirstOrDefault(n => n.Id == id);

                if (notice != null)
                {
                    notice.DateIn = dateTimePicker1.Value.Date;
                    notice.Summa = Convert.ToDecimal(textBox_Summ1.Text);
                    notice.Customer = textBox_WhoGive1.Text;
                    notice.EmployeeId = (short) (comboBox_whoReceive1.SelectedIndex + 1);
                    db.SaveChanges();
                }
            }

            // Refresh view
            LoadIncomeTableInGridView();
            CalculateDayBalance();
        }

        /// <summary>
        /// Видалити дані з таблиці по ід
        /// </summary>
        private void btn_deleteData_Click(object sender, EventArgs e)
        {
            if (textBox_id1.Text == "")
                return;

            int idToDel = Convert.ToInt32(textBox_id1.Text);

            using (var db = new DoorsEntities())
            {
                IncomeMoney notice = db.IncomeMoneys
                                    .Where(p => p.Id == idToDel)
                                    .FirstOrDefault();

                db.IncomeMoneys.Remove(notice);

                DialogResult dr;
                dr = MessageBox.Show("Ви впевнені, що хочете видалити даний запис", "Видалити запис?", MessageBoxButtons.OKCancel);
                if (dr == DialogResult.OK)
                    db.SaveChanges();
            }

            // Refresh view
            LoadIncomeTableInGridView();
            CalculateDayBalance();
        }

        /// <summary>
        /// Перевірка валідності введених полей
        /// </summary>
        private bool ValidateInputFieldsInIncome()
        {
            if (textBox_Summ1.Text == "")
            {
                textBox_Summ1.Focus();
                return false;
            }
            if (textBox_WhoGive1.Text == "")
            {
                textBox_WhoGive1.Focus();
                return false;
            }
            if (comboBox_whoReceive1.SelectedIndex == -1)
            {
                comboBox_whoReceive1.Focus();
                return false;
            }
            return true;
        }

        /// <summary>
        /// Відображення значень відповідної виділеної стрічки в відповідних TextBox'ax таблиці Надходжень
        /// </summary>
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Якщо натискати на назву колонки
                if (e.RowIndex == -1)
                    return;

                textBox_id1.Text = dataGridView1["Id", e.RowIndex].Value.ToString();
                textBox_WhoGive1.Text = dataGridView1["Customer", e.RowIndex].Value.ToString();
                textBox_Summ1.Text = dataGridView1["Summa", e.RowIndex].Value.ToString();

                int num = Convert.ToInt32(dataGridView1["EmployeeId", e.RowIndex].Value) - 1;
                comboBox_whoReceive1.SelectedIndex = num;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.ToString());
                WriteLogErrorFile.WriteInLog(logErrorFile, ex.ToString());
            }
        }

        #endregion Таблиця НАдходжень

        #region Таблиця ВИТРАТ
        /// <summary>
        /// Завантаження таблиці Outlay в datagridview
        /// </summary>
        private void LoadOutlayTableToGridView()
        {
            using (var db = new DoorsEntities())
            {
                var query = from s in db.OutlayMoneys
                            where s.DateOut == dateTimePicker1.Value.Date
                            select s;

                if (query == null)
                    return;

                var notices = query.ToList();

                dataGridView2.DataSource = notices;
            }

            dataGridView2.Columns["DateOut"].Visible = false;
            dataGridView2.Columns["Summa"].HeaderText = "Сума";
            dataGridView2.Columns["WhereSpend"].HeaderText = "Куди витрачено";
            dataGridView2.Columns["WhoReceive"].HeaderText = "Кому видано";
            dataGridView2.AutoResizeColumns();
        }

        /// <summary>
        /// Зберегти дані в таблицю Витрат
        /// </summary>
        private void btn_SaveDataToOutlayTable_Click(object sender, EventArgs e)
        {
            if (!ValidateInputFieldsInOutlay())
                return;

            OutlayMoney notice = new OutlayMoney()
            {
                DateOut = dateTimePicker1.Value.Date,
                Summa = Convert.ToDecimal(textBox_SummaOutlay.Text),                 
                WhereSpend = textBox_WhereMoneyGoes.Text,
                WhoReceive = textBox_WhomeReceiveMoney.Text
            };

            using (DoorsEntities db = new DoorsEntities())
            {
                try
                {
                    db.OutlayMoneys.Add(notice);
                    db.SaveChanges();
                }
                catch (System.Data.Entity.Infrastructure.DbUpdateException)
                {
                    MessageBox.Show("Переконайтесь, що Ви відобразили всі необхідні записи за попередні дні " +
                                     "або переконайтесь, що вибрана Вами дата вірна.", "Помилка при веденні журналу обліку", 
                                     MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    WriteLogErrorFile.WriteInLog(logErrorFile, ex.ToString());
                }                  
            }

            // Оновлюємо таблицю gridview і перераховуємо денний баланс грошей
            LoadOutlayTableToGridView();
            CalculateDayBalance();
        }

        /// <summary>
        /// Редагувати дані в таблиці Витрат
        /// </summary>
        private void btn_EditDataToOutlay_Click(object sender, EventArgs e)
        {
            if (!ValidateInputFieldsInOutlay() || textBox_idOutlay.Text == "")
                return;

            uint id = Convert.ToUInt32(textBox_idOutlay.Text);

            using (DoorsEntities db = new DoorsEntities())
            {
                var notice = db.OutlayMoneys.FirstOrDefault(n => n.Id == id);

                if (notice != null)
                {
                    notice.DateOut = dateTimePicker1.Value.Date;
                    notice.Summa = Convert.ToDecimal(textBox_SummaOutlay.Text);
                    notice.WhereSpend = textBox_WhereMoneyGoes.Text;
                    notice.WhoReceive = textBox_WhomeReceiveMoney.Text;
                    db.SaveChanges();
                }
            }

            // Refresh view
            LoadOutlayTableToGridView();
            CalculateDayBalance();
        }

        /// <summary>
        /// Видалити дані з таблиці Витрат по id
        /// </summary>
        private void btn_deleteDataFromOutlay_Click(object sender, EventArgs e)
        {
            if (textBox_idOutlay.Text == "")
                return;

            // ID позиції для видалення
            uint id = Convert.ToUInt32(textBox_idOutlay.Text);

            using (var db = new DoorsEntities())
            {
                OutlayMoney notice = db.OutlayMoneys
                                    .Where(p => p.Id == id)
                                    .FirstOrDefault();

                db.OutlayMoneys.Remove(notice);

                DialogResult dr;
                dr = MessageBox.Show("Ви впевнені, що хочете видалити даний запис", "Видалити запис?", MessageBoxButtons.OKCancel);
                if (dr == DialogResult.OK)
                    db.SaveChanges();
            }

            // Оновлюємо таблицю gridview і перераховуємо денний баланс грошей
            LoadOutlayTableToGridView();
            CalculateDayBalance();
        }

        /// <summary>
        /// Перевірка валідності введених полей
        /// </summary>
        private bool ValidateInputFieldsInOutlay()
        {
            if (textBox_WhereMoneyGoes.Text == "")
            {
                textBox_WhereMoneyGoes.Focus();
                return false;
            }
            if (textBox_SummaOutlay.Text == "")
            {
                textBox_SummaOutlay.Focus();
                return false;
            }
            if (textBox_WhomeReceiveMoney.Text == "")
            {
                textBox_WhomeReceiveMoney.Focus();
                return false;
            }
            return true;
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Якщо натискати на назву колонки
                if (e.RowIndex == -1)
                    return;

                textBox_idOutlay.Text = dataGridView2["Id", e.RowIndex].Value.ToString();
                textBox_WhereMoneyGoes.Text = dataGridView2["WhereSpend", e.RowIndex].Value.ToString();
                textBox_SummaOutlay.Text = dataGridView2["Summa", e.RowIndex].Value.ToString();
                textBox_WhomeReceiveMoney.Text = dataGridView2["WhoReceive", e.RowIndex].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.ToString());
                WriteLogErrorFile.WriteInLog(logErrorFile, ex.ToString());
            }
        }

        #endregion Таблиця ВИТРАТ

        #region Visitors

        /// <summary>
        /// Відображення кількості відвідувачів за день
        /// </summary>
        private void LoadVisitors()
        {
            string count = "";

            using (DoorsEntities db = new DoorsEntities())
            {                
                var query = db.Visitors.Find(dateTimePicker1.Value.Date);
                if (query != null)
                    count = query.VisitorsCount.ToString();
            }

            // Якщо немає даних в БД, то дозволяємо вводити дані
            // Якщо дані існують, то закриваємо поле для редагування
            if (count != "")
            {
                textBox_Visitors.ReadOnly = true;
                textBox_Visitors.Text = count;
            }
            else
            {
                textBox_Visitors.ReadOnly = false;
                textBox_Visitors.Text = count;
            }
        }

        /// <summary>
        /// Додаємо відвідувачів
        /// </summary>
        private void btn_AddVisitors_Click(object sender, EventArgs e)
        {
            if (textBox_Visitors.Text == "")
                return;

            using (DoorsEntities db = new DoorsEntities())
            {
                var note = db.Visitors.FirstOrDefault(v => v.DateTime == dateTimePicker1.Value.Date);

                if (note != null)
                {
                    // Якщо запис існує змінюємо кількість відвідувачів
                    note.VisitorsCount = Convert.ToInt32(textBox_Visitors.Text);
                }                    
                else
                {
                    // Якщо записа не існує створюємо нову
                    var newnote = new Visitor()
                    {
                        DateTime = dateTimePicker1.Value.Date,
                        VisitorsCount = Convert.ToInt32(textBox_Visitors.Text)
                    };
                    db.Visitors.Add(newnote);
                }
                db.SaveChanges();
            }
            textBox_Visitors.ReadOnly = true;
        }

        private void btn_EditVisitors_Click(object sender, EventArgs e)
        {
            textBox_Visitors.ReadOnly = false;
        }
        #endregion

        /// <summary>
        /// Можливість ввести лише числа і один знак коми
        /// </summary>
        private void textBox_Summ1_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputOnlyNumber.inputOnlyNumber(sender, e);
        }
    }
}
