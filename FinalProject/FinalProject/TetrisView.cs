using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace FinalProject
{
    public partial class TetrisView : Form
    {
        private TetrisModel tm;
        private TetrisController tc;
        private bool finish_flag;
        private Blocks nowBlock, nextBlock;
        protected int nowTime = 0;
        private int nowskin = 0;//0 = 39, 1 = 38, 2 = 40, 3 = 36, 4 = 16
        PictureBox[] initialCubesOnShow, initialCubesOnNext;
        private String[] Type = { "T", "Z", "l", "Lightning", "L", "J", "O" };
        

        public TetrisView()
        {
            InitializeComponent();
            //System.Console.WriteLine(allCubesOnShow[0, 0].BackColor.Name.ToString());
            ViewSetting();
            System.Console.WriteLine(allCubesOnShow[0, 0].BackColor.Name.ToString());
            this.tm = new TetrisModel(this);
            this.tc = new TetrisController(this);
            finish_flag = false;
            nowBlock = null;
            nextBlock = null;
            initialCubesOnShow = new System.Windows.Forms.PictureBox[12];
            initialCubesOnShow = GetWantedBlockOnShow();
            System.Console.WriteLine(allCubesOnShow[0, 0].BackColor.Name.ToString());
            initialCubesOnNext = new System.Windows.Forms.PictureBox[12];
            initialCubesOnNext = GetWantedBlockOnNext();
            System.Console.WriteLine(allCubesOnShow[0, 0].BackColor.Name.ToString());
            tc.start();
        }

        public ref Blocks GetNowBlock()
        {
            return ref(this.nowBlock);
        }

        public void SetNowBlock(Blocks nowblock)
        {
            this.nowBlock = nowblock;
        }

        public ref Blocks GetNextBlock()
        {
            return ref (this.nextBlock);
        }

        public void SetNextBlock(Blocks nextBlock)
        {
            this.nextBlock = nextBlock;
        }

        public ref PictureBox[,] GetAllBlocks()
        {
            return ref(this.allCubesOnShow);
        }

        public void SetAllBlocks(PictureBox[,] allblocks)
        {
            this.allCubesOnShow = allblocks;
        }
        // change the view of program, in the program.cs, it will explain how program start
        public void ChangeGameView()
        {
            //may made a tetrisView array, and random choose one to show

            if (nowskin == 1)
            {
                //set view to B10415038 & set nowskin to 1
                this.SuspendLayout();
                // 
                // label1
                // 
                this.label1.Font = new System.Drawing.Font("微軟正黑體", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
                this.label1.Location = new System.Drawing.Point(1, 650);
                this.label1.ForeColor = System.Drawing.SystemColors.Desktop;
                // 
                // panel1
                // 
                this.panel1.BackColor = System.Drawing.Color.BlanchedAlmond;
                // 
                // panel2
                // 
                this.panel2.BackColor = System.Drawing.Color.BlanchedAlmond;
                // 
                // label2
                // 
                this.label2.Font = new System.Drawing.Font("微軟正黑體", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
                this.label2.Location = new System.Drawing.Point(510, 650);
                this.label2.ForeColor = System.Drawing.SystemColors.Desktop;
                // 
                // button1
                // 
                this.button1.BackColor = System.Drawing.Color.Cyan;
                this.button1.Font = new System.Drawing.Font("Consolas", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.button1.ForeColor = System.Drawing.SystemColors.Desktop;
                this.button1.Location = new System.Drawing.Point(1, 550);
                this.button1.UseVisualStyleBackColor = false;
                // 
                // button2
                // 
                this.button2.BackColor = System.Drawing.Color.Cyan;
                this.button2.Font = new System.Drawing.Font("Consolas", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.button2.ForeColor = System.Drawing.SystemColors.Desktop;
                this.button2.Location = new System.Drawing.Point(170, 550);
                this.button2.UseVisualStyleBackColor = false;
                // 
                // button3
                // 
                this.button3.BackColor = System.Drawing.Color.Cyan;
                this.button3.Font = new System.Drawing.Font("Consolas", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.button3.ForeColor = System.Drawing.SystemColors.Desktop;
                this.button3.Location = new System.Drawing.Point(340, 550);
                this.button3.UseVisualStyleBackColor = false;
                // 
                // timer1
                // 
                this.timer1.Enabled = true;
                // 
                // button4
                // 
                this.button4.BackColor = System.Drawing.Color.Cyan;
                this.button4.Font = new System.Drawing.Font("Consolas", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.button4.ForeColor = System.Drawing.SystemColors.Desktop;
                this.button4.Location = new System.Drawing.Point(510, 550);
                this.button4.UseVisualStyleBackColor = false;
                // 
                // B10415038_view
                // 
                this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
                this.ClientSize = new System.Drawing.Size(700, 700);
                this.Name = "B10415038_view";
                this.Controls.SetChildIndex(this.panel1, 0);
                this.Controls.SetChildIndex(this.panel2, 0);
                this.Controls.SetChildIndex(this.label1, 0);
                this.Controls.SetChildIndex(this.label2, 0);
                this.Controls.SetChildIndex(this.button1, 0);
                this.Controls.SetChildIndex(this.button2, 0);
                this.Controls.SetChildIndex(this.button3, 0);
                this.Controls.SetChildIndex(this.button4, 0);
                this.ResumeLayout(false);

                nowskin = 0;
            }
            else if (nowskin == 0)
            {
                //set view to B10415039 & set nowskin to 2
                this.SuspendLayout();
                // 
                // label1
                // 
                this.label1.Font = new System.Drawing.Font("微軟正黑體 Light", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
                this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
                this.label1.Location = new System.Drawing.Point(12, 186);
                // 
                // panel1
                // 
                this.panel1.BackColor = System.Drawing.Color.Black;
                this.panel1.Location = new System.Drawing.Point(183, 12);
                // 
                // panel2
                // 
                this.panel2.BackColor = System.Drawing.Color.Black;
                this.panel2.Location = new System.Drawing.Point(12, 12);
                // 
                // label2
                // 
                this.label2.Font = new System.Drawing.Font("微軟正黑體 Light", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
                this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
                this.label2.Location = new System.Drawing.Point(7, 236);
                // 
                // button1
                // 
                this.button1.BackColor = System.Drawing.Color.IndianRed;
                this.button1.Font = new System.Drawing.Font("Consolas", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.button1.Location = new System.Drawing.Point(12, 288);
                this.button1.ForeColor = System.Drawing.SystemColors.Desktop;
                this.button1.UseVisualStyleBackColor = false;
                // 
                // button2
                // 
                this.button2.BackColor = System.Drawing.Color.IndianRed;
                this.button2.Font = new System.Drawing.Font("Consolas", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.button2.Location = new System.Drawing.Point(12, 349);
                this.button2.ForeColor = System.Drawing.SystemColors.Desktop;
                this.button2.UseVisualStyleBackColor = false;
                // 
                // button3
                // 
                this.button3.BackColor = System.Drawing.Color.IndianRed;
                this.button3.Font = new System.Drawing.Font("Consolas", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.button3.Location = new System.Drawing.Point(12, 410);
                this.button3.ForeColor = System.Drawing.SystemColors.Desktop;
                this.button3.UseVisualStyleBackColor = false;
                // 
                // button4
                // 
                this.button4.BackColor = System.Drawing.Color.IndianRed;
                this.button4.Font = new System.Drawing.Font("Consolas", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.button4.Location = new System.Drawing.Point(12, 471);
                this.button4.Size = new System.Drawing.Size(160, 61);
                this.button4.ForeColor = System.Drawing.SystemColors.Desktop;
                this.button4.UseVisualStyleBackColor = false;
                // 
                // B10415039_view
                // 
                this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                this.BackColor = System.Drawing.SystemColors.ActiveCaption;
                this.ClientSize = new System.Drawing.Size(555, 547);
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

                nowskin = 2;
            }
            else if (nowskin == 2)
            {
                //set view to B10415040 & set nowskin to 3
                this.SuspendLayout();
                // 
                // label1
                // 
                this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
                this.label1.Location = new System.Drawing.Point(7, 175);
                this.label1.Size = new System.Drawing.Size(165, 37);
                // 
                // panel1
                // 
                this.panel1.BackColor = System.Drawing.Color.Black;
                this.panel1.Location = new System.Drawing.Point(183, 12);
                // 
                // panel2
                // 
                this.panel2.BackColor = System.Drawing.Color.Black;
                this.panel2.Location = new System.Drawing.Point(12, 12);
                // 
                // label2
                // 
                this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
                this.label2.Location = new System.Drawing.Point(7, 212);
                this.label2.Size = new System.Drawing.Size(165, 49);
                // 
                // button1
                // 
                this.button1.BackColor = System.Drawing.Color.Black;
                this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.button1.ForeColor = System.Drawing.Color.Yellow;
                this.button1.Location = new System.Drawing.Point(12, 253);
                this.button1.UseVisualStyleBackColor = false;
                // 
                // button2
                // 
                this.button2.BackColor = System.Drawing.Color.Black;
                this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.button2.ForeColor = System.Drawing.Color.Yellow;
                this.button2.Location = new System.Drawing.Point(12, 314);
                this.button2.UseVisualStyleBackColor = false;
                // 
                // button3
                // 
                this.button3.BackColor = System.Drawing.Color.Black;
                this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.button3.ForeColor = System.Drawing.Color.Yellow;
                this.button3.Location = new System.Drawing.Point(12, 375);
                this.button3.UseVisualStyleBackColor = false;
                // 
                // button4
                // 
                this.button4.BackColor = System.Drawing.Color.Black;
                this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.button4.ForeColor = System.Drawing.Color.Yellow;
                this.button4.Location = new System.Drawing.Point(13, 436);
                this.button4.Size = new System.Drawing.Size(160, 96);
                this.button4.Text = "Change\r\nView";
                this.button4.UseVisualStyleBackColor = false;
                // 
                // B10415040_view
                // 
                this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                this.BackColor = System.Drawing.Color.Yellow;
                this.ClientSize = new System.Drawing.Size(555, 547);
                this.Name = "B10415040_view";
                this.Controls.SetChildIndex(this.panel1, 0);
                this.Controls.SetChildIndex(this.panel2, 0);
                this.Controls.SetChildIndex(this.label1, 0);
                this.Controls.SetChildIndex(this.label2, 0);
                this.Controls.SetChildIndex(this.button1, 0);
                this.Controls.SetChildIndex(this.button2, 0);
                this.Controls.SetChildIndex(this.button3, 0);
                this.Controls.SetChildIndex(this.button4, 0);
                this.ResumeLayout(false);

                nowskin = 3;
            }
            else if (nowskin == 3)
            {
                //set view to B10332036 & set nowskin to 4
                this.SuspendLayout();

                // panel1
                this.panel1.BackColor = System.Drawing.Color.Blue;
                this.panel1.Location = new System.Drawing.Point(5, 5);

                // panel2
                this.panel2.BackColor = System.Drawing.Color.Blue;
                this.panel2.Location = new System.Drawing.Point(370, 5);

                //label1
                this.label1.Location = new System.Drawing.Point(370, 180);
                label1.ForeColor = Color.Red;

                //label2
                this.label2.Location = new System.Drawing.Point(370, 220);
                label2.ForeColor = Color.Green;

                //button1
                this.button1.BackColor = System.Drawing.Color.Gold;
                this.button1.Location = new System.Drawing.Point(370, 280);
                this.button1.Font = new System.Drawing.Font("Consolas", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.button1.ForeColor = System.Drawing.SystemColors.Desktop;

                //button2
                this.button2.BackColor = System.Drawing.Color.Gold;
                this.button2.Location = new System.Drawing.Point(370, 340);
                this.button2.Font = new System.Drawing.Font("Consolas", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.button2.ForeColor = System.Drawing.SystemColors.Desktop;

                //button3
                this.button3.BackColor = System.Drawing.Color.Gold;
                this.button3.Location = new System.Drawing.Point(370, 400);
                this.button3.Font = new System.Drawing.Font("Consolas", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.button3.ForeColor = System.Drawing.SystemColors.Desktop;

                //button4
                this.button4.BackColor = System.Drawing.Color.Gold;
                this.button4.Location = new System.Drawing.Point(370, 460);
                this.button4.Font = new System.Drawing.Font("Consolas", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.button4.ForeColor = System.Drawing.SystemColors.Desktop;
                this.button4.Size = new System.Drawing.Size(160, 65);

                // 
                // B10332036_view
                // 
                this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                this.BackColor = System.Drawing.SystemColors.ActiveCaption;
                this.ClientSize = new System.Drawing.Size(535, 530);
                this.Name = "B10332036_view";

                this.ResumeLayout(false);

                nowskin = 4;
            }
            else if (nowskin == 4)
            {
                //set view to B10415016 & set nowskin to 0
                this.SuspendLayout();
                // 
                // label1
                // 
                this.label1.Font = new System.Drawing.Font("微軟正黑體", 16F);
                this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
                // 
                // panel1
                // 
                this.panel1.BackColor = System.Drawing.Color.BlanchedAlmond;
                // 
                // panel2
                // 
                this.panel2.BackColor = System.Drawing.Color.BlanchedAlmond;
                // 
                // label2
                // 
                this.label2.Font = new System.Drawing.Font("微軟正黑體", 16F);
                this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
                // 
                // button1
                // 
                this.button1.BackColor = System.Drawing.SystemColors.Control;
                this.button1.Font = new System.Drawing.Font("Consolas", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.button1.UseVisualStyleBackColor = false;
                // 
                // button2
                // 
                this.button2.BackColor = System.Drawing.SystemColors.Control;
                this.button2.Font = new System.Drawing.Font("Consolas", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.button2.UseVisualStyleBackColor = false;
                // 
                // button3
                // 
                this.button3.BackColor = System.Drawing.SystemColors.Control;
                this.button3.Font = new System.Drawing.Font("Consolas", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.button3.UseVisualStyleBackColor = false;
                // 
                // timer1
                // 
                this.timer1.Enabled = true;
                // 
                // button4
                // 
                this.button4.BackColor = System.Drawing.SystemColors.Control;
                this.button4.Font = new System.Drawing.Font("Consolas", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.button4.Location = new System.Drawing.Point(370, 462);
                this.button4.Size = new System.Drawing.Size(160, 63);
                this.button4.UseVisualStyleBackColor = false;
                // 
                // B10415016_view
                // 
                this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                this.BackColor = System.Drawing.SystemColors.Control;
                this.ClientSize = new System.Drawing.Size(535, 530);
                this.Name = "B10415016_view";
                this.Controls.SetChildIndex(this.panel1, 0);
                this.Controls.SetChildIndex(this.panel2, 0);
                this.Controls.SetChildIndex(this.label1, 0);
                this.Controls.SetChildIndex(this.label2, 0);
                this.Controls.SetChildIndex(this.button1, 0);
                this.Controls.SetChildIndex(this.button2, 0);
                this.Controls.SetChildIndex(this.button3, 0);
                this.Controls.SetChildIndex(this.button4, 0);
                this.ResumeLayout(false);

                nowskin = 1;
            }

        }
        // be inform the state is changed, then modify the model to new model
        public void stateHasChanged(TetrisModel model)
        {
            tm = model;
        }
        // inform whether game is finished
        public bool finish()
        {
            return finish_flag;
        }
        // set finish flag
        public void SetFinish(bool state) {
            this.finish_flag = state;
        }
        // get key code
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Left || keyData == Keys.Right || keyData == Keys.Up || keyData == Keys.Space)
            {
                switch (keyData)
                {
                    case Keys.Left:
                        tc.userHasInput("left");
                        break;
                    case Keys.Right:
                        tc.userHasInput("right");
                        break;
                    case Keys.Space:
                        tc.userHasInput("down_f");
                        break;
                    case Keys.Up:
                        tc.userHasInput("rotate");
                        break;
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        // geneate the position of new block on show panel
        private PictureBox[] GetWantedBlockOnShow()
        {
            PictureBox[] result = new PictureBox[12];
            result[0] = allCubesOnShow[0, 3];
            result[1] = allCubesOnShow[0, 4];
            result[2] = allCubesOnShow[0, 5];
            result[3] = allCubesOnShow[1, 3];
            result[4] = allCubesOnShow[1, 4];
            result[5] = allCubesOnShow[1, 5];
            result[6] = allCubesOnShow[2, 3];
            result[7] = allCubesOnShow[2, 4];
            result[8] = allCubesOnShow[2, 5];
            result[9] = allCubesOnShow[3, 3];
            result[10] = allCubesOnShow[3, 4];
            result[11] = allCubesOnShow[3, 5];
            return result;
        }
        // geneate the position of new block on nect panel
        private PictureBox[] GetWantedBlockOnNext()
        {
            PictureBox[] result = new PictureBox[12];
            result[0] = allCubesOnNext[0, 1];
            result[1] = allCubesOnNext[0, 2];
            result[2] = allCubesOnNext[0, 3];
            result[3] = allCubesOnNext[1, 1];
            result[4] = allCubesOnNext[1, 2];
            result[5] = allCubesOnNext[1, 3];
            result[6] = allCubesOnNext[2, 1];
            result[7] = allCubesOnNext[2, 2];
            result[8] = allCubesOnNext[2, 3];
            result[9] = allCubesOnNext[3, 1];
            result[10] = allCubesOnNext[3, 2];
            result[11] = allCubesOnNext[3, 3];
            return result;
        }
        // change color of every picturebox in matrix to background color
        private void ClearNextPanel() {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    allCubesOnNext[i, j].BackColor = Color.Transparent;
                }
            }
        }
        // setting the apparent, you will not modify the code here
        public virtual void ViewSetting() {
            this.InitializeComponent();
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
        // when the inteval of timer1 is arrive
        private void timer1_Tick(object sender, EventArgs e)
        {
            //record the time of game played
            nowTime++;
            label1.Text = "時間: " + nowTime.ToString() + "s";
        }
        // when button1 is clicked
        private void button1_Click(object sender, EventArgs e)
        {
            //start
            timer1.Enabled = true;
            timer2.Enabled = true;
        }
        // when button2 is clicked
        private void button2_Click(object sender, EventArgs e)
        {
            //pause
            timer1.Enabled = false;
            timer2.Enabled = false;
        }
        // when the inteval of timer2 is arrive, the program need to generate new block
        private void timer2_Tick(object sender, EventArgs e)
        {
            // generate random seed
            Random rnd = new Random(Guid.NewGuid().GetHashCode());
            // set random range
            int randomIndex = rnd.Next(0, Type.Length);
            if (!tm.GameOver())
            {
                if (this.nowBlock == null)
                {
                    if (this.nextBlock == null)
                    {
                        nowBlock = tm.SetShape(initialCubesOnShow, this.Type[randomIndex]);

                        randomIndex = rnd.Next(0, Type.Length);
                        this.ClearNextPanel();
                        nextBlock = tm.SetShape(initialCubesOnNext, this.Type[randomIndex]);
                    }
                    else
                    {
                        nowBlock = tm.SetShape(initialCubesOnShow, this.nextBlock.GetBlocksType());

                        randomIndex = rnd.Next(0, Type.Length);
                        this.ClearNextPanel();
                        nextBlock = tm.SetShape(initialCubesOnNext, this.Type[randomIndex]);
                    }
                }
                else
                {
                    //if it doesn't need to generate new block, then move the block down slow
                    if (tm.getState() == tm.IdleState)
                    {
                        tc.userHasInput("down_s");
                    }
                }
            }
            else
            {
                // if the game is over, then pause game
                timer1.Enabled = false;
                timer2.Enabled = false;
            }
        }
        // exit the game
        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        // change the game view
        private void button4_Click(object sender, EventArgs e)
        {
            this.ChangeGameView();
        }

        public Panel GetPanel1() {
            return this.panel1;
        }

        public Panel GetPanel2()
        {
            return this.panel2;
        }

        public Label GetLabel1() {
            return this.label1;
        }
        public Label GetLabel2()
        {
            return this.label2;
        }
    }
}
