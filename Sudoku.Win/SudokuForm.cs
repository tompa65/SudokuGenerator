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
        const int cColWidth = 45;
        const int cRowHeigth = 45;
        const int cMaxCell = 4;
        const int cSidelength = cColWidth * cMaxCell + 2;
        DataGridView dataGW;
        BoardGenerator bg;
        //List<CellData> board;
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

        private void SetupGrid()
        {
            //This datagrid was found and "stolen" in a solution on the net...
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
            dataGW.Rows[0].Cells[0].Value = board[0].IsVisible ? board[0].Val.ToString() : String.Empty;
            dataGW.Rows[0].Cells[1].Value = board[1].IsVisible ? board[1].Val.ToString() : String.Empty;
            dataGW.Rows[0].Cells[2].Value = board[2].IsVisible ? board[2].Val.ToString() : String.Empty;
            dataGW.Rows[0].Cells[3].Value = board[3].IsVisible ? board[3].Val.ToString() : String.Empty;
            dataGW.Rows[1].Cells[0].Value = board[4].IsVisible ? board[4].Val.ToString() : String.Empty;
            dataGW.Rows[1].Cells[1].Value = board[5].IsVisible ? board[5].Val.ToString() : String.Empty;
            dataGW.Rows[1].Cells[2].Value = board[6].IsVisible ? board[6].Val.ToString() : String.Empty;
            dataGW.Rows[1].Cells[3].Value = board[7].IsVisible ? board[7].Val.ToString() : String.Empty;
            dataGW.Rows[2].Cells[0].Value = board[8].IsVisible ? board[8].Val.ToString() : String.Empty;
            dataGW.Rows[2].Cells[1].Value = board[9].IsVisible ? board[9].Val.ToString() : String.Empty;
            dataGW.Rows[2].Cells[2].Value = board[10].IsVisible ? board[10].Val.ToString() : String.Empty;
            dataGW.Rows[2].Cells[3].Value = board[11].IsVisible ? board[11].Val.ToString() : String.Empty;
            dataGW.Rows[3].Cells[0].Value = board[12].IsVisible ? board[12].Val.ToString() : String.Empty;
            dataGW.Rows[3].Cells[1].Value = board[13].IsVisible ? board[13].Val.ToString() : String.Empty;
            dataGW.Rows[3].Cells[2].Value = board[14].IsVisible ? board[14].Val.ToString() : String.Empty;
            dataGW.Rows[3].Cells[3].Value = board[15].IsVisible ? board[15].Val.ToString() : String.Empty;
        }

        private void ResetBoard()
        {
            dataGW.Rows[0].Cells[0].Value = String.Empty;
            dataGW.Rows[0].Cells[1].Value = String.Empty;
            dataGW.Rows[0].Cells[2].Value = String.Empty;
            dataGW.Rows[0].Cells[3].Value = String.Empty;
            dataGW.Rows[1].Cells[0].Value = String.Empty;
            dataGW.Rows[1].Cells[1].Value = String.Empty;
            dataGW.Rows[1].Cells[2].Value = String.Empty;
            dataGW.Rows[1].Cells[3].Value = String.Empty;
            dataGW.Rows[2].Cells[0].Value = String.Empty;
            dataGW.Rows[2].Cells[1].Value = String.Empty;
            dataGW.Rows[2].Cells[2].Value = String.Empty;
            dataGW.Rows[2].Cells[3].Value = String.Empty;
            dataGW.Rows[3].Cells[0].Value = String.Empty;
            dataGW.Rows[3].Cells[1].Value = String.Empty;
            dataGW.Rows[3].Cells[2].Value = String.Empty;
            dataGW.Rows[3].Cells[3].Value = String.Empty;
        }

        private void ShowSolution()
        {
            dataGW.Rows[0].Cells[0].Value = board[0].Val;
            dataGW.Rows[0].Cells[1].Value = board[1].Val;
            dataGW.Rows[0].Cells[2].Value = board[2].Val;
            dataGW.Rows[0].Cells[3].Value = board[3].Val;
            dataGW.Rows[1].Cells[0].Value = board[4].Val;
            dataGW.Rows[1].Cells[1].Value = board[5].Val;
            dataGW.Rows[1].Cells[2].Value = board[6].Val;
            dataGW.Rows[1].Cells[3].Value = board[7].Val;
            dataGW.Rows[2].Cells[0].Value = board[8].Val;
            dataGW.Rows[2].Cells[1].Value = board[9].Val;
            dataGW.Rows[2].Cells[2].Value = board[10].Val;
            dataGW.Rows[2].Cells[3].Value = board[11].Val;
            dataGW.Rows[3].Cells[0].Value = board[12].Val;
            dataGW.Rows[3].Cells[1].Value = board[13].Val;
            dataGW.Rows[3].Cells[2].Value = board[14].Val;
            dataGW.Rows[3].Cells[3].Value = board[15].Val;
        }
    }
}
