using System;
using System.Data;
using System.Windows.Forms;
using System.Data.OleDb;
using BelarusianDoor.Data;

namespace BelarusianDoor
{
    public partial class Form1 : Form
    {
        OleDbConnection connection = new OleDbConnection();
        OleDbDataAdapter dataAdapter = new OleDbDataAdapter();
        DataSet dataSet = new DataSet();

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Ошибка");
            }
        }

        public Form1()
        {
            try
            {
                InitializeComponent();

                connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\DOORS\BelarussianDoor.accdb; Persist Security Info = False; ";

                initializedb();

                AutoFillComboBox();

                LoadTables();
                CalculateDayBalance();

                TurnOffSortModeInDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Ошибка");
            }

        }

        private void initializedb()
        {
            using (MainContext db = new MainContext())
            {    
                Employee employee1 = new Employee() { EmployeeName = "Матвієнко О.М.", Status = true };
                Employee employee2 = new Employee() { EmployeeName = "Коваль О.С.", Status = true };
                Employee employee3 = new Employee() { EmployeeName = "Дроздова В.С.", Status = true };

                IncomeMoney incomeMoney1 = new IncomeMoney() { DateTimeIn = DateTime.Today.Date, CustomersName = "Мріщук", Summa = 50, EmployeeId = 1 };

                OutlayMoney outlay = new OutlayMoney() { DateTimeOut = DateTime.Today.Date, Summa = 20, WhereSpend = "Вода на салон", WhoReceiveMoney = "Дроздова" };

                Visitor visitor1 = new Visitor() { DateTime = DateTime.Today.Date, VisitorsCount = 3 };

                db.Visitors.Add(visitor1);
                db.Employee.Add(employee1);db.Employee.Add(employee2);db.Employee.Add(employee3);
                db.Income.Add(incomeMoney1);
                db.Outlay.Add(outlay);
            }
        }

        /// <summary>
        /// Вимикаємо здатність сортувати в datagridview
        /// </summary>
        private void TurnOffSortModeInDataGridView()
        {
            foreach (DataGridViewColumn col in dataGridView1.Columns)
                col.SortMode = DataGridViewColumnSortMode.NotSortable;

            foreach (DataGridViewColumn col in dataGridView2.Columns)
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
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
            LoadTables();

            CalculateDayBalance();

            ClearIncomeTextBoxes();
            ClearOutlayTextBoxes();
        }

        /// <summary>
        /// Очистити текстові поля повязані з таблицею Надходжень
        /// </summary>
        private void ClearIncomeTextBoxes()
        {
            // Income textboxes
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
            // Outlay textboxes
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
                newExcelFile.MakeExcelAndPdfFiles(/*BalanceYesterday()*/5, SetBalanceToday());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        #endregion Excel

        #region Таблиця НАдходжень

        /// <summary>
        /// Завантаження таблиці Income в datagridview
        /// </summary>
        private void LoadIncomeTableInGridView()
        {
            string query = "SELECT Income.Summa, Income.WhoGiveMoney, Income.EmployeeId, Employee.FullName, Income.Id FROM Income ";
            query += "INNER JOIN Employee ON Income.EmployeeId = Employee.Id WHERE DateIncome = @SelectedDate";

            dataAdapter.SelectCommand = new OleDbCommand(query, connection);

            dataAdapter.SelectCommand.Parameters.AddWithValue("@SelectedDate", dateTimePicker1.Value.Date);

            // Заповнюмо ds даними запроса і відображаємо в dgv
            if (dataSet.Tables["IncomeTableInnerEmployee"] != null)
                dataSet.Tables["IncomeTableInnerEmployee"].Clear();

            dataAdapter.Fill(dataSet, "IncomeTableInnerEmployee");
            dataGridView1.DataSource = dataSet.Tables["IncomeTableInnerEmployee"];

            dataGridView1.Columns["EmployeeId"].Visible = false;
            dataGridView1.AutoResizeColumns();

            dataGridView1.Columns["Summa"].HeaderText = "Сума";
            dataGridView1.Columns["WhoGiveMoney"].HeaderText = "Від кого поступили";
            dataGridView1.Columns["FullName"].HeaderText = "Хто отримав";
        }

        /// <summary>
        /// Зберегти дані в таблицю
        /// </summary>
        private void btn_SaveData_Click(object sender, EventArgs e)
        {
            if (!ValidateInputFieldsInIncome())
                return;

            dataAdapter.InsertCommand = new OleDbCommand();
            dataAdapter.InsertCommand.Connection = connection;
            dataAdapter.InsertCommand.CommandText =
                "INSERT INTO Income (DateIncome, Summa, WhoGiveMoney, EmployeeId) VALUES (@SelectedDate, @Summa, @WhoGiveMoney, @EmployeeId)";
            dataAdapter.InsertCommand.Parameters.Add("@SelectedDate", OleDbType.Date).Value = dateTimePicker1.Value.Date;
            dataAdapter.InsertCommand.Parameters.Add("@Summa", OleDbType.Double).Value = Convert.ToDouble(textBox_Summ1.Text);
            dataAdapter.InsertCommand.Parameters.Add("@WhoGiveMoney", OleDbType.VarChar).Value = textBox_WhoGive1.Text;
            dataAdapter.InsertCommand.Parameters.Add("@EmployeeId", OleDbType.UnsignedTinyInt).Value = comboBox_whoReceive1.SelectedIndex + 1;            
            
            try
            {
                connection.Open();
                dataAdapter.InsertCommand.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.ToString());
            }
            finally
            {
                if (connection.State != ConnectionState.Closed)
                    connection.Close();
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

            dataAdapter.UpdateCommand = new OleDbCommand();
            dataAdapter.UpdateCommand.Connection = connection;

            string query = "UPDATE Income SET DateIncome = @SelectedDate, Summa = @Summa, WhoGiveMoney = @WhoGiveMoney, EmployeeId = @EmployeeId WHERE Id=@Id";
            dataAdapter.UpdateCommand.CommandText = query;
            dataAdapter.UpdateCommand.Parameters.Add("@SelectedDate", OleDbType.Date).Value = dateTimePicker1.Value.Date;
            dataAdapter.UpdateCommand.Parameters.Add("@Summa", OleDbType.Double).Value = Convert.ToDouble(textBox_Summ1.Text);
            dataAdapter.UpdateCommand.Parameters.Add("@WhoGiveMoney", OleDbType.VarChar).Value = textBox_WhoGive1.Text;
            dataAdapter.UpdateCommand.Parameters.Add("@EmployeeId", OleDbType.UnsignedTinyInt).Value = comboBox_whoReceive1.SelectedIndex + 1;
            dataAdapter.UpdateCommand.Parameters.Add("@Id", OleDbType.Integer).Value = Convert.ToInt32(textBox_id1.Text);

            try
            {
                connection.Open();
                dataAdapter.UpdateCommand.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.ToString());
            }
            finally
            {
                if (connection.State != ConnectionState.Closed)
                    connection.Close();
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

            dataAdapter.DeleteCommand = new OleDbCommand();
            dataAdapter.DeleteCommand.Connection = connection;
            dataAdapter.DeleteCommand.CommandText = "DELETE FROM Income WHERE Id=@Id";
            dataAdapter.DeleteCommand.Parameters.Add("@Id", OleDbType.Numeric).Value = textBox_id1.Text;

            try
            {
                connection.Open();
                DialogResult dr;
                dr = MessageBox.Show("Ви впевнені, що хочете видалити даний запис", "Видалити запис?", MessageBoxButtons.OKCancel);
                if (dr == DialogResult.OK)
                    dataAdapter.DeleteCommand.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.ToString());
            }
            finally
            {
                if (connection.State != ConnectionState.Closed)
                    connection.Close();
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
        /// Заповнення комбобоксів даними з БД
        /// </summary>
        private void AutoFillComboBox()
        {
            try
            {
                string query = "SELECT FullName FROM Employee WHERE WorkStatus = true";
                dataAdapter.SelectCommand = new OleDbCommand(query, connection);

                dataAdapter.Fill(dataSet, "Employee_Table");
                for (int i = 0; i < dataSet.Tables["Employee_Table"].Rows.Count; i++)
                {
                    // Додаємо значення з колонки повного імені в комбобокс
                    comboBox_whoReceive1.Items.Add(dataSet.Tables["Employee_Table"].Rows[i]["FullName"]).ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.ToString());
            }
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

                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                textBox_id1.Text = dataSet.Tables["IncomeTableInnerEmployee"].Rows[e.RowIndex]["Id"].ToString();
                textBox_Summ1.Text = dataSet.Tables["IncomeTableInnerEmployee"].Rows[e.RowIndex]["Summa"].ToString();
                textBox_WhoGive1.Text = dataSet.Tables["IncomeTableInnerEmployee"].Rows[e.RowIndex]["WhoGiveMoney"].ToString();

                int num = Convert.ToInt32(dataSet.Tables["IncomeTableInnerEmployee"].Rows[e.RowIndex]["EmployeeId"]) - 1;
                comboBox_whoReceive1.SelectedIndex = num;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.ToString());
            }
        }

        #endregion Таблиця НАдходжень

        #region Окремі інформативні поля 

        /// <summary>
        /// Розрахунок суми, що залишилась ввечері минулого дня
        /// </summary>
        //double BalanceYesterday()
        //{
        //    // Значення суми
        //    double inputSumma = 0;
        //    double outlaySumma = 0;

        //    DateTime yesterday = dateTimePicker1.Value;
        //    yesterday = yesterday.Date.AddDays(-1);

        //    try
        //    {
        //        connection.Open();

        //        OleDbCommand command = new OleDbCommand();
        //        command.Connection = connection;
        //        command.CommandText = "SELECT SUM(Summa) FROM Income WHERE DateIncome = @SelectedDate";
        //        command.Parameters.AddWithValue("@SelectedDate", yesterday);
        //        var s = command.ExecuteScalar();
                
        //        if (!(s is DBNull))
        //            inputSumma = Convert.ToDouble(s);
                
        //        command.CommandText = "SELECT SUM(ValueMoney) FROM Outlay WHERE DateOutlay = @SelectedDate";
        //        command.Parameters.AddWithValue("@SelectedDate", yesterday);
        //        var s1 = command.ExecuteScalar();
        //        if (!(s1 is DBNull))
        //            outlaySumma = Convert.ToDouble(s1);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error " + ex.ToString());
        //    }
        //    finally
        //    {
        //        connection.Close();
        //    }

        //    return inputSumma - outlaySumma; 
        //}
        
        /// <summary>
        /// Розрахунок загальної суми внесених грошей за день
        /// </summary>
        internal double SetMoneyInputToday()
        {
            // Загальна сума внесених грошей
            double inputToday = 0;
            try
            {
                connection.Open();

                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;

                command.CommandText = "SELECT SUM(Summa) FROM Income WHERE DateIncome = @SelectedDate";
                command.Parameters.AddWithValue("@SelectedDate", dateTimePicker1.Value.Date);

                var s = command.ExecuteScalar();
                if (!(s is DBNull))
                    inputToday = Convert.ToDouble(s);                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.ToString());
            }
            finally
            {
                connection.Close();
            }
            return inputToday;
        }

        /// <summary>
        /// Розрахунок загальної суми витрачених грошей за день
        /// </summary>
        internal double SetMoneyOutlayToday()
        {
            // Сума витрачених грошей за день
            double outlayToday = 0;

            try
            {
                connection.Open();

                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;

                command.CommandText = "SELECT SUM(ValueMoney) FROM Outlay WHERE DateOutlay = @SelectedDate";
                command.Parameters.AddWithValue("@SelectedDate", dateTimePicker1.Value.Date);

                var s = command.ExecuteScalar();
                if (!(s is DBNull))
                    outlayToday = Convert.ToDouble(s);

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.ToString());
            }

            return outlayToday;
        }

        /// <summary>
        /// Розрахунок денного балансу
        /// </summary>
        internal double SetBalanceToday()
        {
            return /*BalanceYesterday() +*/ SetMoneyInputToday() - SetMoneyOutlayToday();
        }

        /// <summary>
        /// Розрахунок всіх інформативних полів
        /// </summary>
        private void CalculateDayBalance()
        {
            //BalanceYesterday();
            SetMoneyInputToday();
            SetMoneyOutlayToday();
            SetBalanceToday();

            SetInformationFields();
        }

        private void SetInformationFields()
        {
            textBox_summInputToday.Text = SetMoneyInputToday().ToString();
            textBox_summaOutlayToday.Text = SetMoneyOutlayToday().ToString();
            textBox_dayBalance.Text = SetBalanceToday().ToString();
            //textBox_moneyYesterdayEvening.Text = BalanceYesterday().ToString();
        }

        #endregion Окремі інформативні поля

        #region Таблиця ВИТРАТ
        /// <summary>
        /// Завантаження таблиці Outlay в datagridview
        /// </summary>
        private void LoadOutlayTableToGridView()
        {
            try
            {
                string query = "SELECT ValueMoney, WhereMoneyPut, WhomReceiveMoney, Id FROM Outlay WHERE DateOutlay = @SelectedDate";

                dataAdapter.SelectCommand = new OleDbCommand(query, connection);
                
                dataAdapter.SelectCommand.Parameters.AddWithValue("@SelectedDate", dateTimePicker1.Value.Date);

                // Заповнюмо ds даними запроса і відображаємо в dgv
                if (dataSet.Tables["OutlayTable"] != null)
                    dataSet.Tables["OutlayTable"].Clear();

                dataAdapter.Fill(dataSet, "OutlayTable");
                dataGridView2.DataSource = dataSet.Tables["OutlayTable"];

                // Змінюємо в datagridview заголовки колонок
                dataGridView2.Columns["ValueMoney"].HeaderText = "Сума";
                dataGridView2.Columns["WhereMoneyPut"].HeaderText = "Куди витрачено";
                dataGridView2.Columns["WhomReceiveMoney"].HeaderText = "Кому видано";

                dataGridView2.AutoResizeColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.ToString());
            }
        }

        /// <summary>
        /// Зберегти дані в таблицю Витрат
        /// </summary>
        private void btn_SaveDataToOutlayTable_Click(object sender, EventArgs e)
        {
            if (!ValidateInputFieldsInOutlay())
                return;

            dataAdapter.InsertCommand = new OleDbCommand();
            dataAdapter.InsertCommand.Connection = connection;
            dataAdapter.InsertCommand.CommandText =
                "INSERT INTO Outlay (DateOutlay, WhereMoneyPut, ValueMoney, WhomReceiveMoney) VALUES (@SelectedDate, @WhereMoneyPut, @ValueMoney, @WhomReceiveMoney)";

            dataAdapter.InsertCommand.Parameters.Add("@SelectedDate", OleDbType.Date).Value = dateTimePicker1.Value.Date;
            dataAdapter.InsertCommand.Parameters.Add("@WhereMoneyPut", OleDbType.VarChar).Value = textBox_WhereMoneyGoes.Text;
            dataAdapter.InsertCommand.Parameters.Add("@ValueMoney", OleDbType.Double).Value = Convert.ToDouble(textBox_SummaOutlay.Text);
            dataAdapter.InsertCommand.Parameters.Add("@WhomReceiveMoney", OleDbType.VarChar).Value = textBox_WhomeReceiveMoney.Text;

            try
            {
                connection.Open();
                dataAdapter.InsertCommand.ExecuteNonQuery();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.ToString());
            }
            finally
            {
                connection.Close();
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

            dataAdapter.UpdateCommand = new OleDbCommand();

            string query = "UPDATE Outlay SET DateOutlay = @SelectedDate, WhereMoneyPut = @WhereMoneyPut, ValueMoney = @ValueMoney, WhomReceiveMoney = @WhomReceiveMoney WHERE Id=@Id";

            dataAdapter.UpdateCommand.CommandText = query;

            dataAdapter.UpdateCommand.Parameters.Add("@SelectedDate", OleDbType.Date).Value = dateTimePicker1.Value.Date;
            dataAdapter.UpdateCommand.Parameters.Add("@WhereMoneyPut", OleDbType.VarChar).Value = textBox_WhereMoneyGoes.Text;
            dataAdapter.UpdateCommand.Parameters.Add("@ValueMoney", OleDbType.Double).Value = Convert.ToDouble(textBox_SummaOutlay.Text);
            dataAdapter.UpdateCommand.Parameters.Add("@WhomReceiveMoney", OleDbType.VarChar).Value = textBox_WhomeReceiveMoney.Text;
            dataAdapter.UpdateCommand.Parameters.Add("@Id", OleDbType.Integer).Value = Convert.ToInt32(textBox_idOutlay.Text);

            dataAdapter.UpdateCommand.Connection = connection;

            try
            {
                connection.Open();
                dataAdapter.UpdateCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.ToString());
            }
            finally
            {
                connection.Close();
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

            dataAdapter.DeleteCommand = new OleDbCommand();
            dataAdapter.DeleteCommand.Connection = connection;
            dataAdapter.DeleteCommand.CommandText = "DELETE FROM Outlay WHERE Id=@Id";
            dataAdapter.DeleteCommand.Parameters.Add("@Id", OleDbType.Numeric).Value = textBox_id1.Text;

            try
            {
                connection.Open();
                DialogResult dr;
                dr = MessageBox.Show("Ви впевнені, що хочете видалити даний запис", "Видалити запис?", MessageBoxButtons.OKCancel);
                if (dr == DialogResult.OK)
                    dataAdapter.DeleteCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.ToString());
            }
            finally
            {
                connection.Close();
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
                
                textBox_idOutlay.Text = dataSet.Tables["OutlayTable"].Rows[e.RowIndex]["Id"].ToString();
                textBox_WhereMoneyGoes.Text = dataSet.Tables["OutlayTable"].Rows[e.RowIndex]["WhereMoneyPut"].ToString();
                textBox_SummaOutlay.Text = dataSet.Tables["OutlayTable"].Rows[e.RowIndex]["ValueMoney"].ToString();
                textBox_WhomeReceiveMoney.Text = dataSet.Tables["OutlayTable"].Rows[e.RowIndex]["WhomReceiveMoney"].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.ToString());
            }
        }

        #endregion Таблиця ВИТРАТ

        #region Visitors

        private void LoadVisitors()
        {
            string count = "";
            try
            {
                connection.Open();

                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;

                string query = "SELECT CountOfVisitors FROM Visitors WHERE DateV = @SelectedDate";
                command.Parameters.AddWithValue("@SelectedDate", dateTimePicker1.Value.Date);

                command.CommandText = query;

                // Зчитуємо дані
                int count1 = Convert.ToInt32(command.ExecuteScalar());             
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.ToString());
            }
            finally
            {
                connection.Close();
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

        private void btn_AddVisitors_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();

                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;

                // Видаляємо існуюче значення
                command.CommandText = "DELETE FROM Visitors WHERE DateV = @SelectedDate";
                command.Parameters.AddWithValue("@SelectedDate", dateTimePicker1.Value.Date);
                command.ExecuteNonQuery();

                // Вставляємо нове значення
                command = new OleDbCommand();
                string query = "INSERT INTO Visitors (DateV, CountOfVisitors) VALUES (@SelectedDate, @CountOfVisitors)";
                command.Parameters.AddWithValue("@SelectedDate", dateTimePicker1.Value.Date);
                command.Parameters.AddWithValue("@CountOfVisitors", Convert.ToUInt32(textBox_Visitors.Text));
                command.CommandText = query;
                command.Connection = connection;
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.ToString());
            }
            finally
            {
                if (connection != null)
                    connection.Close();
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
