using System.Windows.Forms;

namespace BelarusianDoor
{
    static class InputOnlyNumber
    {
        /// <summary>
        /// Метод, который запрещает вводить что-либо кроме цифр в текстовом поле и только один знак точки
        /// </summary>
        public static void inputOnlyNumber(object sender, KeyPressEventArgs e)
        {
            // можно вводить цифры, Enter, Backspace, Delete, ',', '.'
            if ((e.KeyChar < 48 | e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 127
                                                  && e.KeyChar != 46 && e.KeyChar != 44)
                e.Handled = true;

            // заменяем точку запятой
            if (e.KeyChar == '.')
                e.KeyChar = ',';

            // Приводим sender'a к типу TextBox или ComboBox
            Control txt = null;
            string typeOfSender = sender.GetType().Name;
            if (typeOfSender == "TextBox")
                txt = (TextBox) sender;
            else if (typeOfSender == "ComboBox")
                txt = (ComboBox) sender;

            // Возможность ввести только одну запятую в поле
            if (txt != null && e.KeyChar == ',')
                if (txt.Text.LastIndexOf(',') != -1)
                    e.Handled = true;
        }
    }
}
