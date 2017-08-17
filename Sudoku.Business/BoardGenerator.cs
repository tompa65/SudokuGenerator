using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sudoku.Business.Models;
using System.Xml.Serialization;
using System.IO;

namespace Sudoku.Business
{
    public class BoardGenerator
    {
        private CellCollection cellCollection = null;

        public BoardGenerator()
        {
            InitBoard();          
        }

        /// <summary>
        /// This function creates a valid board reading from a XML file
        /// </summary>
        private void InitBoard()
        {
            cellCollection = new CellCollection();
            string path = System.AppDomain.CurrentDomain.BaseDirectory + "ValidBoard.xml";

            XmlSerializer serializer = new XmlSerializer(typeof(CellCollection));

            StreamReader reader = new StreamReader(path);
            cellCollection = (CellCollection)serializer.Deserialize(reader);
            reader.Close();
        }

        public List<Cell> CreateBoard()
        {
            //Shuffle board randomly first
            SwitchNumbers();

            //Set visibility for the numbers
            SetVisibility();

            return cellCollection.Cells.OrderBy(r => r.Order).ToList();
        }

        private void SwitchNumbers()
        {
            Random rnd = new Random();
            int firstNumber = rnd.Next(1, 5); // Between 1 and 4
            int secondNumber = rnd.Next(1, 5);

            if (firstNumber == secondNumber)
            {
                secondNumber = firstNumber > 1 ? firstNumber - 1 : firstNumber + 1;
            }

            foreach (Cell c in cellCollection.Cells)
            {
                if(c.Val == firstNumber)
                {
                    c.Val = 0; //set temporary to zero
                }
            }

            foreach (Cell c in cellCollection.Cells)
            {
                if (c.Val == secondNumber)
                {
                    c.Val = firstNumber;
                }
            }

            foreach (Cell c in cellCollection.Cells)
            {
                if (c.Val == 0)
                {
                    c.Val = secondNumber;
                }
            }
        }

        private void SetVisibility()
        {
            Random rnd = new Random();
            int numberOfVisibleNumbers = rnd.Next(5, 8); // Between 5 and 7
            int numberOfNumbersSet = 0;
            int randomNumber = 0;

            //Reset visibility first
            for(int i = 0; i < cellCollection.Cells.Length; i++)
            {
                cellCollection.Cells[i].IsVisible = false;
            }

            while(numberOfNumbersSet < numberOfVisibleNumbers)
            {
                randomNumber = rnd.Next(0, 16);

                if (cellCollection.Cells[randomNumber].IsVisible == false)
                {
                    cellCollection.Cells[randomNumber].IsVisible = true;
                    numberOfNumbersSet++;
                }
            }
        }
        
    }
}
