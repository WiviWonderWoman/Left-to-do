
using System;
using System.Collections.Generic;

namespace LeftToDo
{
    /*=====================================CLASS==================================================
        Derives from Task
    ==============================================================================================*/
    public class Checklist : Tasks 
    {
        public Checklist(string specification)
        {
            type = "C";
            description = specification;
            subTasks = new List<SimpleTask>();
            daysLeft = 0;
        }
        /*-----------------METHOD-----------------------
            Takes info from user
        ------------------------------------------------*/
        internal override void Create()
        {
            
            Console.WriteLine("\nAnge Rubrik-uppgift:\n");
            description = Console.ReadLine().ToUpper();
            
            bool input = true;
            Console.WriteLine("\nAnge uppgifter, separerat med enter.\n\n[0] för att slutföra checklistan.\n");
            do 
            {
                var specification = Console.ReadLine();

                if (specification == "0")
                {
                    input = false;
                }
                else
                {
                    var newTask = new SimpleTask(specification);
                    newTask.type = "sub";
                    AddSubTask(newTask);
                }
                  
            } while (input);  
        }

        /*-----------------METHOD-----------------------
            Adding objects to subTasks
        ------------------------------------------------*/
        public void AddSubTask(SimpleTask task)
        {
            subTasks.Add(task);
        }

        /*-----------------METHOD-----------------------
            Displaying checklist "Header" tasks
        ------------------------------------------------*/
        public static void ShowTask(Tasks task, int index)
         {
            if(task.done == null)
            {   
                Console.WriteLine($" - \t{index}\t{task.description}"); 
            }
            else
            {
                Console.WriteLine($"[{task.done}]\t{index}\t{task.description}");
            } 
         }
    }
}
