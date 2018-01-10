using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProject
{
    public class B10415039_view : TetrisView
    {
        public override void ViewSetting() {
            this.InitializeComponent();
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel2.BackColor = System.Drawing.Color.Black;

            allCubesOnShow = new PictureBox[13, 9];
            allCubesOnNext = new PictureBox[4, 4];
            //
            // allCubesOnShow
            //
            for (int i = 0; i < 13; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    allCubesOnShow[i, j] = new System.Windows.Forms.PictureBox();
                    allCubesOnShow[i, j].Name = "pictureBox" + i.ToString() + j.ToString();
                    allCubesOnShow[i, j].BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                    allCubesOnShow[i, j].Location = new System.Drawing.Point(j * 40, i * 40);
                    allCubesOnShow[i, j].Size = new System.Drawing.Size(40, 40);
                    allCubesOnShow[i, j].TabIndex = 111;
                    allCubesOnShow[i, j].TabStop = false;
                    ((System.ComponentModel.ISupportInitialize)(this.allCubesOnShow[i, j])).BeginInit();
                }
            }
            for (int i = 0; i < 13; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    this.panel1.Controls.Add(this.allCubesOnShow[i, j]);
                }
            }
            //
            // allCubesOnNext
            //
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    allCubesOnNext[i, j] = new System.Windows.Forms.PictureBox();
                    allCubesOnNext[i, j].Name = "pictureBox" + i.ToString() + j.ToString();
                    allCubesOnNext[i, j].BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                    allCubesOnNext[i, j].Location = new System.Drawing.Point(j * 40, i * 40);
                    allCubesOnNext[i, j].Size = new System.Drawing.Size(40, 40);
                    allCubesOnNext[i, j].TabIndex = 111;
                    allCubesOnNext[i, j].TabStop = false;
                    ((System.ComponentModel.ISupportInitialize)(this.allCubesOnNext[i, j])).BeginInit();
                }
            }
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    this.panel2.Controls.Add(this.allCubesOnNext[i, j]);
                }
            }

            for (int i = 0; i < 13; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    ((System.ComponentModel.ISupportInitialize)(this.allCubesOnShow[i, j])).EndInit();
                }
            }

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    ((System.ComponentModel.ISupportInitialize)(this.allCubesOnNext[i, j])).EndInit();
                }
            }
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Text = "GameOver";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Black;
            // 
            // B10415039_view
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(535, 530);
            this.Name = "B10415039_view";
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.button1, 0);
            this.Controls.SetChildIndex(this.button2, 0);
            this.Controls.SetChildIndex(this.button3, 0);
            this.Controls.SetChildIndex(this.button4, 0);
            this.ResumeLayout(false);

        }
    }
}
