using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sudoku.Business;
using Sudoku.Business.Models;

namespace Sudoku.Win
{
    public partial class SudokuForm : Form
    {
        //Datagrid constants
        const int cColWidth = 45;
        const int cRowHeigth = 45;
        const int cMaxCell = 4;
        const int cSidelength = cColWidth * cMaxCell + 2;

        DataGridView dataGW;
        BoardGenerator bg;
        List<Cell> board;

        public SudokuForm()
        {
            InitializeComponent();
        }

        private void SudokuForm_Load(object sender, EventArgs e)
        {
            SetupGrid();
            bg = new BoardGenerator();
            DisplayBoard();
        }

        private void btnNewBoard_Click(object sender, EventArgs e)
        {
            DisplayBoard();
        }

        private void btnShowSolution_Click(object sender, EventArgs e)
        {
            ShowSolution();
        }

        private void DisplayBoard()
        {
            //Get a valid board to fill the datagrid view with
            board = bg.CreateBoard();

            //Display the new board
            ResetBoard();
            NewBoard();
        }

        private void NewBoard()
        {
            int index = 0;

            foreach (DataGridViewRow row in dataGW.Rows)
            {
                for (int i = 0; i < dataGW.Columns.Count; i++)
                {
                    row.Cells[i].Value = board[index].IsVisible ? board[index].Val.ToString() : String.Empty;
                    index++;
                }
            }
        }

        private void ResetBoard()
        {
            foreach (DataGridViewRow row in dataGW.Rows)
            {
                for (int i = 0; i < dataGW.Columns.Count; i++)
                {
                    row.Cells[i].Value = String.Empty;
                }
            }
        }

        private void ShowSolution()
        {
            int index = 0;

            foreach (DataGridViewRow row in dataGW.Rows)
            {
                for (int i = 0; i < dataGW.Columns.Count; i++)
                {
                    row.Cells[i].Value = board[index].Val;
                    index++;
                }
            }
        }

        private void SetupGrid()
        {
            //This datagrid setup was found and "borrowed" in another solution on the net...
            //In some parts reconfigured to suit a 4x4 sudoku.

            dataGW = new DataGridView();
            dataGW.Name = "DGV";
            dataGW.AllowUserToResizeColumns = false;
            dataGW.AllowUserToResizeRows = false;
            dataGW.AllowUserToAddRows = false;
            dataGW.RowHeadersVisible = false;
            dataGW.ColumnHeadersVisible = false;
            dataGW.GridColor = Color.DarkBlue;
            dataGW.DefaultCellStyle.BackColor = Color.AliceBlue;
            dataGW.ScrollBars = ScrollBars.None;
            dataGW.Size = new Size(cSidelength, cSidelength);
            dataGW.Location = new Point(75, 75);
            dataGW.Font = new System.Drawing.Font("Calibri", 16.2F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            dataGW.ForeColor = Color.DarkBlue;
            dataGW.SelectionMode = DataGridViewSelectionMode.CellSelect;
            // add 16 cells
            for (int i = 0; i < cMaxCell; i++)
            {
                DataGridViewTextBoxColumn TxCol = new DataGridViewTextBoxColumn();
                TxCol.MaxInputLength = 1;   // only one digit allowed in a cell
                dataGW.Columns.Add(TxCol);
                dataGW.Columns[i].Name = "Col " + (i + 1).ToString();
                dataGW.Columns[i].Width = cColWidth;
                dataGW.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                DataGridViewRow row = new DataGridViewRow();
                row.Height = cRowHeigth;
                dataGW.Rows.Add(row);
            }
            // mark the 4 square areas consisting of 4 cells
            dataGW.Columns[1].DividerWidth = 2;
            dataGW.Rows[1].DividerHeight = 2;

            Controls.Add(dataGW);
        }
    }
}
