using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Sudoku.Business.Models
{
    [Serializable()]
    [System.Xml.Serialization.XmlRoot("CellCollection")]
    public class CellCollection
    {
        [XmlArray("Cells")]
        [XmlArrayItem("Cell", typeof(Cell))]
        public Cell[] Cells { get; set; }
    }
}
