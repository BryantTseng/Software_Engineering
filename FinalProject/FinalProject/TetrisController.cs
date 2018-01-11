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
            string nowState = tm.getState();

            if (userInput != "" && userInput.Length != 0)
            {
                if (userInput == MoveLeftCommand)
                {
                    tm.setState(tm.MoveLeftState);
                    try
                    {
                        tm.MoveLeft(tv.GetNowBlock());
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.GetType()+": Move left");
                    }
                tm.setState(tm.IdleState);
                }
                else if (userInput == MoveRightCommand)
                {
                    tm.setState(tm.MoveRightState);
                    try
                    {
                        tm.MoveRight(tv.GetNowBlock(), tv.GetAllBlocks());
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.GetType()+": Move right");
                    }
                    tm.setState(tm.IdleState);
                }
                else if (userInput == RotateCommand)
                {
                    tm.setState(tm.RotateState);
                    try
                    {
                        tm.Rotate(tv.GetNowBlock(), tv.GetAllBlocks());
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine(e.GetType()+": Rotate");
                    }
                    tm.setState(tm.IdleState);
                }
                else if (userInput == MoveDownFastCommand)
                {
                    tm.setState(tm.MoveDownFastState);
                    try
                    {
                        tm.DropDownFast(tv.GetNowBlock(), tv.GetAllBlocks());
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.GetType()+": Dropdown fast");
                    }
                    tm.RemoveLine(tv.GetAllBlocks());
                    tm.setState(tm.IdleState);
                }
                else if (userInput == MoveDownSlowCommand)
                {
                    tm.setState(tm.MoveDownSlowState);
                    try
                    {
                        tm.DropDownSlow(tv.GetNowBlock(), tv.GetAllBlocks());
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.GetType()+": Dropdown slow");
                    }
                    tm.RemoveLine(tv.GetAllBlocks());
                    tm.setState(tm.IdleState);
                }
            }
        }
        // let game start
        public void start()
        {
            tm.setState(tm.IdleState);
        }
    }
}
