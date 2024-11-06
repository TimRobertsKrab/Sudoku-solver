using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver {
    class Cell {
        private byte value;
        private readonly bool isFixed;
        public Cell(byte value, bool isFixed){
            this.value = value;
            this.isFixed = isFixed;
        }
        public void IncrementValue() {
            if (this.isFixed)
            throw new Exception("Fixed cell can't be changed");
            value++;
        }
        public void SetValue(byte v) {
            value = v;
        }

        public byte GetValue() {
            return value;
        }

        public bool GetIsFixed() {
            return isFixed;
        }
    }
}
