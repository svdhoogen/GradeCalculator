using System;
using System.Windows.Forms;

namespace GradeCalculator
{
    public partial class frmGradeCalculatorShoo : Form
    {
        #region Variable declarations

        ParabolicFormula parabolicFormulaShoo = new ParabolicFormula();
        LinearFormula linearFormulaShoo = new LinearFormula();

        GradingMethodEnum gradingMethodShoo = GradingMethodEnum.Linear;
        float maxPointsShoo = 10;
        float ceasuraShoo = 5.5F;

        #endregion

        #region Initialization logic

        public frmGradeCalculatorShoo()
        {
            InitializeComponent();
        }

        #endregion

        #region Grading method input

        private void tbxMaxPointsShoo_TextChanged(object sender, EventArgs e)
        {
            ValidateNumericTextChangedShoo(sender, e);
        }

        /// <summary>
        /// Tbx Max Points Shoo_Key Press.
        /// Prevent non-numeric keys from being entered into textbox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbxMaxPointsShoo_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidateNumericKeyPressShoo(sender, e);

            // On enter, attempt to calculate parabola
            if (e.KeyChar == '\r')
            {
                RemakeFormula();
            }
        }

        private void tbxCeasuraShoo_TextChanged(object sender, EventArgs e)
        {
            ValidateNumericTextChangedShoo(sender, e);
        }

        /// <summary>
        /// Tbx Ceasura Shoo_Key Press.
        /// Prevent non-numeric keys from being entered into textbox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbxCeasuraShoo_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidateNumericKeyPressShoo(sender, e);

            // On enter, attempt to calculate parabola
            if (e.KeyChar == '\r')
            {
                RemakeFormula();
            }
        }

        /// <summary>
        /// Rdb Linear Shoo_Checked Changed.
        /// When linear option is checked, set grading method to linear and re-calculate formula's.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rdbLinearShoo_CheckedChanged(object sender, EventArgs e)
        {
            if (!rdbLinearShoo.Checked)
            {
                gradingMethodShoo = GradingMethodEnum.Linear;
                RemakeFormula();
            }
        }

        /// <summary>
        /// Rdb Parabola Shoo_Checked Changed.
        /// When parabola option is checked, set grading method to parabola and re-calculate formula's.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rdbParabolaShoo_CheckedChanged(object sender, EventArgs e)
        {
            if (!rdbLinearShoo.Checked)
            {
                gradingMethodShoo = GradingMethodEnum.Parabola;
                RemakeFormula();
            }
        }

        #endregion

        #region Grading output input

        private void tbxCalculateGradeShoo_TextChanged(object sender, EventArgs e)
        {
            ValidateNumericTextChangedShoo(sender, e);
        }

        /// <summary>
        /// Tbx Ceasura Shoo_Key Press.
        /// Prevent non-numeric keys from being entered into textbox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbxCalculateGradeShoo_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidateNumericKeyPressShoo(sender, e);
        }

        private void btnGeneratePdfShoo_Click(object sender, EventArgs e)
        {

        }

        #endregion

        #region Misc

        /// <summary>
        /// Remake Formula Shoo.
        /// Remakes the formula based on max points, ceasura and grading method.
        /// </summary>
        private void RemakeFormulaShoo()
        {

        }

        /// <summary>
        /// Validate Numeric Text Changed Shoo.
        /// Replaces empty text box with '0', trims trailing 0's.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ValidateNumericTextChangedShoo(object sender, EventArgs e)
        {
            try
            {
                TextBox textBoxShoo = (TextBox)sender;

                // If textbox is empty, set it to 0 and move caret to end
                if (string.IsNullOrWhiteSpace(textBoxShoo.Text))
                {
                    textBoxShoo.Text = "0";
                    textBoxShoo.SelectionStart = 1;
                    textBoxShoo.SelectionLength = 0;
                }
                // Else if text has leading 0's and more than 1 character trim all leading 0's
                else if (textBoxShoo.Text[0] == '0' && textBoxShoo.Text.Length > 1)
                {
                    textBoxShoo.Text = textBoxShoo.Text.TrimStart('0');
                    textBoxShoo.SelectionStart = textBoxShoo.Text.Length;
                    textBoxShoo.SelectionLength = 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Critical error: Crashed unexpectedly while validating numeric textbox input! " + ex);
            }
        }

        /// <summary>
        /// Validate Numeric Key Press Shoo.
        /// Prevents non-numeric characters in textbox and ensures only a single decimal point.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ValidateNumericKeyPressShoo(object sender, KeyPressEventArgs e)
        {
            try
            {
                TextBox textBoxShoo = (TextBox)sender;

                // Only allow numeric input
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
                    e.Handled = true;

                // Only allow one decimal point
                if ((e.KeyChar == '.') && (textBoxShoo.Text.IndexOf('.') > -1))
                    e.Handled = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Critical error: Crashed unexpectedly while validating numeric textbox input! " + ex);
                e.Handled = true;
            }
        }

        #endregion
    }
}
