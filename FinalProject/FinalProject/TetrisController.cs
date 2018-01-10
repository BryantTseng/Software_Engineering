using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProject
{
    public class TetrisController
    {
        private TetrisModel tm;
        private TetrisView tv;
        public String MoveLeftCommand = "left";
        public String MoveRightCommand = "right";
        public String MoveDownFastCommand = "down_f";
        public String MoveDownSlowCommand = "down_s";
        public String RotateCommand = "rotate";

        public TetrisController(TetrisView tv)
        {
            this.tv = tv;
            this.tm = new TetrisModel(tv);
        }
        // if user has inputed, then do the responding work
        public void userHasInput(string userInput)
        {
            
        }
        // let game start
        public void start()
        {
            tm.setState(tm.IdleState);
        }
    }
}
