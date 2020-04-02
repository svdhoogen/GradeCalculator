using Autofac;
using GradeCalculator.Enums;
using GradeCalculator.Interfaces;
using GradeCalculator.Structs;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GradeCalculator
{
    public partial class frmGradeCalculatorShoo : Form
    {
        #region Variable declarations

        /// <summary>Broken line formula for calculating grades.</summary>
        readonly IBrokenLineFormula brokenLineFormulaShoo = ClassContainer.Container.Resolve<IBrokenLineFormula>();
        /// <summary>Parabolic formula for calculating grades.</summary>
        readonly IParabolicFormula parabolicFormulaShoo = ClassContainer.Container.Resolve<IParabolicFormula>();
        /// <summary>Grade list pdf generator.</summary>
        readonly IGradeListPdf gradeListPdfShoo = ClassContainer.Container.Resolve<IGradeListPdf>();

        /// <summary>Grade calculation method, linear or parabolic.</summary>
        GradingMethodEnum gradingMethodShoo = GradingMethodEnum.Linear;
        /// <summary>Points needed for a perfect score.</summary>
        float maxPointsShoo = 10;
        /// <summary>Ceasura, minimum points to pass the test.</summary>
        float ceasuraShoo = 5.5F;

        /// <summary>Calculates grade at this amount of points.</summary>
        float pointAmountShoo = 10;

        #endregion

        #region Initialization logic

        public frmGradeCalculatorShoo()
        {
            InitializeComponent();

            RemakeFormulasShoo();
        }

        #endregion

        #region Grade calculation logic

        /// <summary>
        /// Remake Formulas Shoo.
        /// Remakes the formulas based on max points and ceasura.
        /// </summary>
        private void RemakeFormulasShoo()
        {
            Console.WriteLine($"Remaking formulas based on: Max points: { maxPointsShoo }, ceasura: { ceasuraShoo }, grading method: { gradingMethodShoo }");

            // Remake formulas
            brokenLineFormulaShoo.RemakeShoo(maxPointsShoo, ceasuraShoo);
            parabolicFormulaShoo.RemakeShoo(maxPointsShoo, ceasuraShoo);

            // Update grade
            UpdateGradeShoo();
        }

        /// <summary>
        /// Update Grade Shoo.
        /// Updates grade based on entered point amount.
        /// </summary>
        private void UpdateGradeShoo()
        {
            // Update points label
            lblPointsShoo.Text = pointAmountShoo.ToString();

            // New grade
            float gradeShoo;

            // Get grade from current grading method
            if (gradingMethodShoo == GradingMethodEnum.Linear)
                gradeShoo = brokenLineFormulaShoo.GetGradeShoo(pointAmountShoo);

            else
                gradeShoo = parabolicFormulaShoo.GetGradeShoo(pointAmountShoo);

            // Display new grade
            if (gradeShoo >= 0.95 && gradeShoo <= 10.05)
                lblGradeShoo.Text = gradeShoo.ToString("#.#");

            // Invalid grade
            else
                lblGradeShoo.Text = "Invalid formula!";
        }

        /// <summary>
        /// Generate Pdf Shoo.
        /// Generates and displays pdf based on current configuration.
        /// </summary>
        private void GeneratePdfShoo()
        {
            // Grade list
            List<GradeListItem> gradeListShoo;

            // Get grade list from current grading method
            if (gradingMethodShoo == GradingMethodEnum.Linear)
                gradeListShoo = brokenLineFormulaShoo.GetGradeListShoo();

            else
                gradeListShoo = parabolicFormulaShoo.GetGradeListShoo();

            // Log grade items in console
            foreach (GradeListItem gradeItem in gradeListShoo)
                Console.WriteLine($"{ gradeItem.Grade }, {gradeItem.Points}.");

            // Invalid grade list
            if (gradeListShoo.Count <= 0)
            {
                MessageBox.Show("Failed to generate grade list pdf! Make sure you've entered a valid formula!", "Whoops!");
                Console.WriteLine("Failed to generate grade list pdf! Grade list contains no items!");
                return;
            }

            // Create + display pdf from data
            gradeListPdfShoo.CreateShoo(gradeListShoo, maxPointsShoo, ceasuraShoo, gradingMethodShoo);
        }

        #endregion

        #region Input handling

        /// <summary>
        /// Tbx Max Points Shoo_Text Changed.
        /// Get max points and remake formulas.
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event args</param>
        private void tbxMaxPointsShoo_TextChanged(object sender, EventArgs e)
        {
            // Parse text box value
            float newMaxPointsShoo = ParseTextBoxFloatShoo((TextBox)sender);

            // Update max points
            maxPointsShoo = newMaxPointsShoo;

            // Remake formulas
            RemakeFormulasShoo();
        }

        /// <summary>
        /// Tbx Ceasura Shoo_Text Changed.
        /// Get ceasura and remake formulas.
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event sender</param>
        private void tbxCeasuraShoo_TextChanged(object sender, EventArgs e)
        {
            // Parse text box value
            float newCeasuraShoo = ParseTextBoxFloatShoo((TextBox)sender);

            // Update ceasura
            ceasuraShoo = newCeasuraShoo;

            // Remake formulas
            RemakeFormulasShoo();
        }

        /// <summary>
        /// Tbx Point Amount Shoo_Text Changed.
        /// Get point amount and update grade.
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event args</param>
        private void tbxPointAmountShoo_TextChanged(object sender, EventArgs e)
        {
            // Parse text box value
            float newPointAmountShoo = ParseTextBoxFloatShoo((TextBox)sender);

            // Update point amount
            pointAmountShoo = newPointAmountShoo;

            // Remake formula
            UpdateGradeShoo();
        }

        /// <summary>
        /// Tbx Max Points Shoo_Key Press.
        /// Ensure only numeric input into text box.
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Key press event args</param>
        private void tbxMaxPointsShoo_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidateNumericKeyPressShoo((TextBox)sender, e);
        }

        /// <summary>
        /// Tbx Ceasura Shoo_Key Press.
        /// Ensure only numeric input into text box.
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Key press event args</param>
        private void tbxCeasuraShoo_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidateNumericKeyPressShoo((TextBox)sender, e);
        }

        /// <summary>
        /// Tbx Point Amount Shoo_Key Press.
        /// Ensure only numeric input into text box.
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Key press event args</param>
        private void tbxPointAmountShoo_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidateNumericKeyPressShoo((TextBox)sender, e);
        }

        /// <summary>
        /// Rdb Linear Shoo_Checked Changed.
        /// Update grading method and remake formula.
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event args</param>
        private void rdbLinearShoo_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbLinearShoo.Checked)
            {
                gradingMethodShoo = GradingMethodEnum.Linear;
                RemakeFormulasShoo();
            }
        }

        /// <summary>
        /// Rdb Parabola Shoo_Checked Changed.
        /// Update grading method and remake formula.
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event args</param>
        private void rdbParabolaShoo_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbParabolaShoo.Checked)
            {
                gradingMethodShoo = GradingMethodEnum.Parabola;
                RemakeFormulasShoo();
            }
        }

        /// <summary>
        /// Btn Generate Pdf Shoo_Click.
        /// Generate and display grade list pdf.
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event args</param>
        private void btnGeneratePdfShoo_Click(object sender, EventArgs e)
        {
            GeneratePdfShoo();
        }

        #endregion

        #region Input handling helpers

        /// <summary>
        /// Validate Numeric Key Press Shoo.
        /// Prevents non-numeric characters in textbox and ensures only a single decimal point.
        /// </summary>
        /// <param name="textBoxShoo">Text box to validate</param>
        /// <param name="e">Key press event args</param>
        private void ValidateNumericKeyPressShoo(TextBox textBoxShoo, KeyPressEventArgs e)
        {
            // Allow numeric input
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
                e.Handled = true;

            // Allow single decimal point
            if ((e.KeyChar == '.') && (textBoxShoo.Text.IndexOf('.') > -1))
                e.Handled = true;
        }

        /// <summary>
        /// Parse Text Box Float Shoo.
        /// Formats and returns text box input, converted to float.
        /// </summary>
        /// <param name="textBoxShoo">Text box to parse</param>
        private float ParseTextBoxFloatShoo(TextBox textBoxShoo)
        {
            try
            {
                // Format text box
                FormatTextBoxFloatShoo(textBoxShoo);

                // Check if valid number
                if (string.IsNullOrWhiteSpace(textBoxShoo.Text) || textBoxShoo.Text == "0" || textBoxShoo.Text == ".")
                    return 0;

                // Parse text
                float.TryParse(textBoxShoo.Text, out float parsedFloatShoo);

                // Log error
                if (parsedFloatShoo == 0)
                    Console.WriteLine("Error: Tried to parse numeric text box float, but try parse returned 0!");

                // return float
                return parsedFloatShoo;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Critical error: Crashed unexpectedly while parsing textbox float input! " + ex);
                return 0;
            }
        }

        /// <summary>
        /// Format Text Box Float Shoo.
        /// Replaces empty text box with '0', trims leading 0's.
        /// </summary>
        /// <param name="textBoxShoo">Textbox to format</param>
        private void FormatTextBoxFloatShoo(TextBox textBoxShoo)
        {
            // Set to 0 and move caret to end if textbox is empty
            if (string.IsNullOrWhiteSpace(textBoxShoo.Text))
            {
                textBoxShoo.Text = "0";
                textBoxShoo.SelectionStart = 1;
                textBoxShoo.SelectionLength = 0;
            }
            // Trim all leading 0's
            else if (textBoxShoo.Text[0] == '0' && textBoxShoo.Text.Length > 1)
            {
                textBoxShoo.Text = textBoxShoo.Text.TrimStart('0');
                textBoxShoo.SelectionStart = textBoxShoo.Text.Length;
                textBoxShoo.SelectionLength = 0;
            }
        }

        #endregion
    }
}
