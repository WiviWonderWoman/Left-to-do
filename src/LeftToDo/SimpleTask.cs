using System;

namespace LeftToDo
{
    /*=====================================CLASS==================================================
        Derives from Task
    ==============================================================================================*/
    public class SimpleTask : Tasks
    {
         public SimpleTask(string specification)
        {
            type = "S";
            description = specification;
            daysLeft = 0;
        }

        /*-----------------METHOD-----------------------
            Displaying simple tasks
        ------------------------------------------------*/
        internal static void ShowTask(Tasks task, int index)
        {
            var type = task.type;   
             if(task.done == null)
            {
                Console.WriteLine($"[ ]\t{index}\t{task.description}");
            }
            else
            {
                Console.WriteLine($"[{task.done}]\t{index}\t{task.description}");
            }  
        }
        /*-----------------METHOD--------------------------
            Overload, Displaying simple tasks in Checklist 
        ---------------------------------------------------*/
        internal static void ShowTask(Tasks task, int outer, int inner)
        {
            var type = task.type;   
             if(task.done == null)
            {
                    Console.WriteLine($"\t[ ]\t{outer} - {inner}\t{task.description}");

            }
            else
            {
                Console.WriteLine($"\t[{task.done}]\t{outer} - {inner}\t{task.description}");
            }
            
        }

        /*-----------------METHOD--------------------------
            Takes info from user
        ---------------------------------------------------*/
        internal override void Create()
        {
            Console.WriteLine("Ange uppgift:");
            description = Console.ReadLine();
        }

    }
}
