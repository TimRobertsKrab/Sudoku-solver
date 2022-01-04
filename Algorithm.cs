using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver {
    static class Algorithm {
        
        public static void Run(Cell[,] cells) {
            bool backTrack = false;
            for (int i = 0; i < 9; i++) {
                for(int j = 0; j < 9; j++) {
                    if (backTrack) {
                        while (cells[i, j].GetIsFixed() || cells[i,j].GetValue() == 9) {
                            if (!cells[i, j].GetIsFixed()) {
                                cells[i, j].SetValue(0);
                            }
                            j--;
                            if (j < 0) {
                                i--;j = 8;
                            }                       
                        }
                        backTrack = false;
                    }
                    else if (cells[i, j].GetIsFixed()) {
                        continue;
                    }

                    if (cells[i, j].GetValue() < 9) {
                        cells[i, j].IncrementValue();
                    }
                    while (ViolationCheck(cells,i,j)) {
                        if (cells[i,j].GetValue() >= 9) {
                            cells[i, j].SetValue(0);
                            backTrack = true;
                            j -= 2;
                            if (j+1 < 0) {
                                i--;j = 7;
                            }
                            break;
                        }
                        cells[i, j].IncrementValue();
                    }
                }
            }
        }     

        private static bool ViolationCheck(Cell[,] cells,int y, int x) {
            //Check for row violation
            for (int j = 0; j < 9; j++) {
                if (j == x) {
                    continue;
                }
                if (cells[y,j].GetValue() == cells[y, x].GetValue()) {
                    return true;
                }
            }

            //Check for column violation
            for (int i = 0; i < 9; i++) {
                if (i == y) {
                    continue;
                }
                if (cells[i, x].GetValue() == cells[y, x].GetValue()) {
                    return true;
                }
            }

            //Check for square violation
            for (int i = (y/3) * 3, ylen = i + 3;i < ylen; i++) {
                for(int j = (x/3)*3,xlen = j + 3; j < xlen; j++) {
                    if (i == y || j == x) {
                        continue;
                    }
                    if (cells[i,j].GetValue() == cells[y, x].GetValue()) {
                        return true;                   
                    }
                }
            }

            return false;
        }
    }
}
