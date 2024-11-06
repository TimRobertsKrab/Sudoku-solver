using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SudokuSolver {
    public partial class Form1 : Form {

        private Cell[,] cells;
        private List<System.Windows.Forms.TextBox> textBoxes = new List<System.Windows.Forms.TextBox>();
        
        public Form1() {
            InitializeComponent();
            textBoxes.Add(textBox1); textBoxes.Add(textBox2); textBoxes.Add(textBox3); textBoxes.Add(textBox4);
            textBoxes.Add(textBox5); textBoxes.Add(textBox6); textBoxes.Add(textBox7); textBoxes.Add(textBox8);
            textBoxes.Add(textBox9); textBoxes.Add(textBox10); textBoxes.Add(textBox11); textBoxes.Add(textBox12);
            textBoxes.Add(textBox13); textBoxes.Add(textBox14); textBoxes.Add(textBox15); textBoxes.Add(textBox16);
            textBoxes.Add(textBox17); textBoxes.Add(textBox18); textBoxes.Add(textBox19); textBoxes.Add(textBox20);
            textBoxes.Add(textBox21); textBoxes.Add(textBox22); textBoxes.Add(textBox23); textBoxes.Add(textBox24);
            textBoxes.Add(textBox25); textBoxes.Add(textBox26); textBoxes.Add(textBox27); textBoxes.Add(textBox28);
            textBoxes.Add(textBox29); textBoxes.Add(textBox30); textBoxes.Add(textBox31); textBoxes.Add(textBox32);
            textBoxes.Add(textBox33); textBoxes.Add(textBox34); textBoxes.Add(textBox35); textBoxes.Add(textBox36);
            textBoxes.Add(textBox37); textBoxes.Add(textBox38); textBoxes.Add(textBox39); textBoxes.Add(textBox40);
            textBoxes.Add(textBox41); textBoxes.Add(textBox42); textBoxes.Add(textBox43); textBoxes.Add(textBox44);
            textBoxes.Add(textBox45); textBoxes.Add(textBox46); textBoxes.Add(textBox47); textBoxes.Add(textBox48);
            textBoxes.Add(textBox49); textBoxes.Add(textBox50); textBoxes.Add(textBox51); textBoxes.Add(textBox52);
            textBoxes.Add(textBox53); textBoxes.Add(textBox54); textBoxes.Add(textBox55); textBoxes.Add(textBox56);
            textBoxes.Add(textBox57); textBoxes.Add(textBox58); textBoxes.Add(textBox59); textBoxes.Add(textBox60);
            textBoxes.Add(textBox61); textBoxes.Add(textBox62); textBoxes.Add(textBox63); textBoxes.Add(textBox64);
            textBoxes.Add(textBox65); textBoxes.Add(textBox66); textBoxes.Add(textBox67); textBoxes.Add(textBox68);
            textBoxes.Add(textBox69); textBoxes.Add(textBox70); textBoxes.Add(textBox71); textBoxes.Add(textBox72);
            textBoxes.Add(textBox73); textBoxes.Add(textBox74); textBoxes.Add(textBox75); textBoxes.Add(textBox76);
            textBoxes.Add(textBox77); textBoxes.Add(textBox78); textBoxes.Add(textBox79); textBoxes.Add(textBox80);
            textBoxes.Add(textBox81);
        }

        private void InitialiseCells() {
            cells = new Cell[9, 9];
            for (int i = 0; i < 9; i++) {
                for (int j = 0; j < 9; j++) {
                    if (textBoxes[i * 9 + j].Text == "") {
                        cells[i, j] = new Cell(0, false);
                    }
                    else {
                        cells[i, j] = new Cell(Convert.ToByte(textBoxes[i * 9 + j].Text), true);
                    }
                }
            }
        }
        
        private void SolveButton_Click(object sender, EventArgs e) { 
            InitialiseCells();
            if (Algorithm.Run(cells,0,0)){
                for (int i = 0; i < 9; i++) {
                    for (int j = 0; j < 9; j++) {
                        if (!cells[i, j].GetIsFixed()) {
                            textBoxes[i * 9 + j].Text = Convert.ToString(cells[i, j].GetValue());
                        }
                        textBoxes[i * 9 + j].Enabled = false;
                    }
                }
            }
            else{
                for (int i = 0; i < 9; i++) {
                    for (int j = 0; j < 9; j++) {
                        textBoxes[i * 9 + j].Text = "0";
                        textBoxes[i * 9 + j].Enabled = false;
                    }
                }
            }
        }

        private void ResetButton_Click(object sender, EventArgs e) {
            for (int i = 0; i < 81; i++) {
                textBoxes[i].Enabled = true;
                textBoxes[i].Text = "";
            }
        }
    }
}
