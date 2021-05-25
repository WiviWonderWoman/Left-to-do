using System.Collections.Generic;

namespace LeftToDo
{
    /*=====================================CLASS==================================================
        Abstract super class, handels all types of Tasks
    ==============================================================================================*/
    public abstract class Tasks
    {
        public string type
        {
            get;
            set;
        }
        public string description
        {
            get;
            set;
        }
        public string done
        {
            get;
            set;
        }
        public int daysLeft
        {
            get;
            set;
        }
        
        public List<SimpleTask> subTasks;

        /*-----------------METHOD-----------------------
            Marks task as Done
        ------------------------------------------------*/
        public void MarkAsDone()
        {
            if(done == null)
            {
                done = "X";
            }
            else if(done == "X")
            {
                done = null;
            }
            
        }

        /*-----------------METHOD--------------------------
            Takes info from user, overrides in each subclass
        ---------------------------------------------------*/
        internal abstract void Create();
    }
}
