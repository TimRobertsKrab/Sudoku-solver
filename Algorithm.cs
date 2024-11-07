using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver {
    static class Algorithm {
        static int iterations = 0;
        public static bool Run(Cell[,] cells ,int y, int x){
            if (iterations >= 100000){
                return false;
            }
            int newx = x+1;
            int newy = y;
            if (newx>8){
                newx = 0;
                newy++;
            }

            if (!cells[y,x].GetIsFixed()){
                cells[y,x].SetValue(1);
            }
            else{
                if (newy > 8){
                    return true;
                }
                return Run(cells,newy,newx);
            }
            
            while (cells[y,x].GetValue() <= 9){
                if (!ViolationCheck(cells,y,x)){
                    
                    if (newy > 8){
                        return true;
                    }
                    
                    if (Run(cells,newy,newx)){
                        return true;
                    }
                }
                cells[y,x].IncrementValue();
            }
            ++iterations;
            cells[y,x].SetValue(0);
            return false;
        } 

        public static bool ViolationCheck(Cell[,] cells,int y, int x) {
            byte value = cells[y,x].GetValue();
            //Check for row violation
            for (int j = 0; j < 9; j++) {
                if (j == x) {
                    continue;
                }
                if (cells[y,j].GetValue() == value) {
                    return true;
                }
            }

            //Check for column violation
            for (int i = 0; i < 9; i++) {
                if (i == y) {
                    continue;
                }
                if (cells[i, x].GetValue() == value) {
                    return true;
                }
            }

            //Check for square violation
            for (int i = (y/3) * 3, ylen = i + 3;i < ylen; i++) {
                for(int j = (x/3)*3,xlen = j + 3; j < xlen; j++) {
                    // Ignore the same column or row as value as it was already checked
                    if (i == y || j == x) {
                        continue;
                    }
                    if (cells[i,j].GetValue() == value) {
                        return true;                   
                    }
                }
            }

            return false;
        }
    }
}
