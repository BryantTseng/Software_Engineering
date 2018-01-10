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
        PictureBox[] initialCubesOnShow, initialCubesOnNext;
        private String[] Type = { "T", "Z", "l", "Lightning", "L", "J", "O" };
        

        public TetrisView()
        {
            InitializeComponent();
            ViewSetting();
            this.tm = new TetrisModel(this);
            this.tc = new TetrisController(this);
            finish_flag = false;
            nowBlock = null;
            nextBlock = null;
            initialCubesOnShow = new System.Windows.Forms.PictureBox[12];
            initialCubesOnShow = GetWantedBlockOnShow();
            initialCubesOnNext = new System.Windows.Forms.PictureBox[12];
            initialCubesOnNext = GetWantedBlockOnNext();
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

            Random Number = new Random();

            switch (Number.Next() % 2)
            {
                //case 0 is B10415039_view
                case 0:
                    this.SuspendLayout();
                    // 
                    // label1
                    // 
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
                    this.label2.Location = new System.Drawing.Point(7, 236);
                    // 
                    // button1
                    // 
                    this.button1.BackColor = System.Drawing.Color.IndianRed;
                    this.button1.Location = new System.Drawing.Point(12, 288);
                    this.button1.UseVisualStyleBackColor = false;
                    // 
                    // button2
                    // 
                    this.button2.BackColor = System.Drawing.Color.IndianRed;
                    this.button2.Location = new System.Drawing.Point(12, 349);
                    this.button2.UseVisualStyleBackColor = false;
                    // 
                    // button3
                    // 
                    this.button3.BackColor = System.Drawing.Color.IndianRed;
                    this.button3.Location = new System.Drawing.Point(12, 410);
                    this.button3.UseVisualStyleBackColor = false;
                    // 
                    // button4
                    // 
                    this.button4.BackColor = System.Drawing.Color.IndianRed;
                    this.button4.Location = new System.Drawing.Point(12, 471);
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
                    break;

                //case 0 is B10332036_view
                case 1:
                    this.SuspendLayout();

                    // panel1
                    this.panel1.BackColor = System.Drawing.Color.Green;
                    this.panel1.Location = new System.Drawing.Point(5, 5);

                    // panel2
                    this.panel2.BackColor = System.Drawing.Color.Gold;
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

                    //button2
                    this.button2.BackColor = System.Drawing.Color.Gold;
                    this.button2.Location = new System.Drawing.Point(370, 340);

                    //button3
                    this.button3.BackColor = System.Drawing.Color.Gold;
                    this.button3.Location = new System.Drawing.Point(370, 350);

                    //button4
                    this.button3.BackColor = System.Drawing.Color.Gold;
                    this.button3.Location = new System.Drawing.Point(370, 400);

                    // 
                    // B10332036_view
                    // 
                    this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
                    this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                    this.BackColor = System.Drawing.SystemColors.ActiveCaption;
                    this.ClientSize = new System.Drawing.Size(535, 530);
                    this.Name = "B10332036_view";

                    this.ResumeLayout(false);
                    break;
                //case 2:
                //case 3:
                //case 4:
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
                    allCubesOnNext[i, j].BackColor = panel2.BackColor;
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
    }
}
