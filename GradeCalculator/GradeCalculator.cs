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

        /// <summary>The parabolic formula for calculating grades.</summary>
        readonly IParabolicFormula parabolicFormulaShoo = ClassContainer.Container.Resolve<IParabolicFormula>();
        /// <summary>The linear formula for calculating grades.</summary>
        readonly IBrokenLineFormula brokenLineFormulaShoo = ClassContainer.Container.Resolve<IBrokenLineFormula>();

        /// <summary>Currently selected grading method, linear or parabolic.</summary>
        GradingMethodEnum gradingMethodShoo = GradingMethodEnum.Linear;
        /// <summary>Maximum points to use for formula.</summary>
        float maxPointsShoo = 10;
        /// <summary>Ceasura, this amount of points means you passed the test.</summary>
        float ceasuraShoo = 5.5F;

        /// <summary>The amount of points to calculate a grade for, based on current grading method.</summary>
        float pointAmountShoo = 10;

        #endregion

        #region Initialization logic

        public frmGradeCalculatorShoo()
        {
            InitializeComponent();
        }

        #endregion

        #region UI Input events

        /// <summary>
        /// Tbx Max Points Shoo_Text Changed.
        /// When max points changes, try getting new max points and remaking formula.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbxMaxPointsShoo_TextChanged(object sender, EventArgs e)
        {
            // Parse text box value
            float newMaxPointsShoo = ParseTextBoxFloatShoo((TextBox)sender);

            // Check if valid
            if (newMaxPointsShoo == 0)
                return;

            // Update max points
            maxPointsShoo = newMaxPointsShoo;

            // Remake formula
            RemakeFormulasShoo();
        }

        /// <summary>
        /// Tbx Ceasura Points Shoo_Text Changed.
        /// When ceasura changes, try getting new ceasura and remaking formula.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbxCeasuraShoo_TextChanged(object sender, EventArgs e)
        {
            // Parse text box value
            float newCeasuraShoo = ParseTextBoxFloatShoo((TextBox)sender);

            // Check if valid
            if (newCeasuraShoo == 0)
                return;

            // Update ceasura
            ceasuraShoo = newCeasuraShoo;

            // Remake formula
            RemakeFormulasShoo();
        }

        /// <summary>
        /// Tbx Point Amount Shoo_Text Changed.
        /// When point amount changes, try getting new point amount and remaking formula.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbxPointAmountShoo_TextChanged(object sender, EventArgs e)
        {
            // Parse text box value
            float newPointAmountShoo = ParseTextBoxFloatShoo((TextBox)sender);

            // Check if valid
            if (newPointAmountShoo == 0)
                return;

            // Update point amount
            pointAmountShoo = newPointAmountShoo;

            // Remake formula
            UpdateGradeShoo();
        }

        /// <summary>
        /// Rdb Linear Shoo_Checked Changed.
        /// Update grading method and remake formula if checked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// Update grading method and remake formula if checked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rdbParabolaShoo_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbParabolaShoo.Checked)
            {
                gradingMethodShoo = GradingMethodEnum.Parabola;
                RemakeFormulasShoo();
            }
        }

        private void btnGeneratePdfShoo_Click(object sender, EventArgs e)
        {
            List<GradeListItem> gradeListShoo = brokenLineFormulaShoo.GetGradeListShoo();

            foreach (GradeListItem gradeItem in gradeListShoo)
                Console.WriteLine($"{ gradeItem.Grade }, {gradeItem.Points}.");
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

        #region Misc

        /// <summary>
        /// Remake Formulas Shoo.
        /// Remakes the formulas based on max points and ceasura.
        /// </summary>
        private void RemakeFormulasShoo()
        {
            Console.WriteLine($"Remaking formulas based on: Max points: { maxPointsShoo }, ceasura: { ceasuraShoo }, grading method: { gradingMethodShoo }");

            //parabolicFormulaShoo.RemakeShoo(maxPointsShoo, ceasuraShoo);
            brokenLineFormulaShoo.RemakeShoo(maxPointsShoo, ceasuraShoo);

            // Update grade
            UpdateGradeShoo();
        }

        /// <summary>
        /// Update Grade Shoo.
        /// Updates grade based on point amount.
        /// </summary>
        private void UpdateGradeShoo()
        {
            // Update points label
            lblPointsShoo.Text = pointAmountShoo.ToString();

            float gradeShoo;

            // Get grade from linear formula
            if (gradingMethodShoo == GradingMethodEnum.Linear)
                gradeShoo = brokenLineFormulaShoo.GetGradeShoo(pointAmountShoo);

            // Get grade form parabolic formula
            else
                gradeShoo = parabolicFormulaShoo.GetGradeShoo(pointAmountShoo);

            // Set grade
            if (gradeShoo >= 0.95 && gradeShoo <= 10.05)
                lblGradeShoo.Text = gradeShoo.ToString("#.#");

            // Invalid grade
            else
                lblGradeShoo.Text = "Invalid formula!";
        }

        /// <summary>
        /// Parse Text Box Float Shoo.
        /// Replaces empty text box with '0', trims trailing 0's.
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
                Console.WriteLine("Critical error: Crashed unexpectedly while validating numeric textbox input! " + ex);
                return 0;
            }
        }

        /// <summary>
        /// Format Text Box Float Shoo.
        /// Replaces empty text box with '0', trims leading 0's.
        /// </summary>
        /// <param name="textBoxShoo"></param>
        private void FormatTextBoxFloatShoo(TextBox textBoxShoo)
        {
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

        #endregion
    }
}
