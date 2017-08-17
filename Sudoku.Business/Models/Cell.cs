using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku.Business.Models
{
    [System.Xml.Serialization.XmlRoot("Cells")]
    public class Cell
    {
        public int Val { get; set; }
        public Boolean IsVisible { get; set; }
        public int Order { get; set; } //Could be either 1 to 16 (ordered from top left corner board cell to last one on the bottom right corner)

       
        //These could be used for swapping rows or columns
        //Not used though in this version
        //public int BlockRow { get; set; } //Could be either 1 or 2 (where 1 is top block row)
        //public int BlockColumn { get; set; } //Could be either 1 or 2 (where 1 is left block column)
        //public int BoardRow { get; set; } //Could be either 1 or 2 (where 1 is top board row)
        //public int BoardColumn { get; set; } //Could be either 1 or 2 (where 1 is left board column)    
    }
}
