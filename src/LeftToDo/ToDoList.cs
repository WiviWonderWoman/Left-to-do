using System;
using System.Collections.Generic;

namespace LeftToDo
{
    /*=====================================CLASS==================================================
        ToDolist handels all lists and their methods
    ==============================================================================================*/
    public class ToDoList
    {
        public List<Tasks> ToDo
        {
            get;
            private set;
        }
        public List<Tasks> Archive
        {
            get;
            private set;
        }


        public ToDoList()
        {
            ToDo = new List<Tasks>();
            Archive = new List<Tasks>();
        }

        /*-----------------METHOD-----------------------
            Adds new tasks to ToDo
        ------------------------------------------------*/
        public void AddToDoList(Tasks task)
        {
            ToDo.Add(task);
        }

        /*-----------------METHOD-----------------------
            Adds tasks that should be archived to Arc
        ------------------------------------------------*/
        private void AddToArcList(Tasks task)
        {
            Archive.Add(task);
        }
        
        /*-----------------METHOD---------------------------
            Iterates tru ToDo to find done tasks to archive
        ----------------------------------------------------*/
        public void ArchiveTasks()
        {
            for (int i = 0; i <ToDo.Count; i++)
            {
                Tasks item = ToDo[i];
                if (item.done == "X")
                {
                    AddToArcList(item);
                    ToDo.Remove(item);
                    i--;
                } 
            }
            // ShowLeftToDo(ToDo);
        }

        /*-----------------METHOD-----------------------
            Display List of tasks 
        ------------------------------------------------*/
        internal void ShowLeftToDo(List<Tasks> ToDo)
        {
            Console.Clear();
            if (ToDo.Count < 1)
            {
                Console.WriteLine($"\n\nATT GÖRA LISTAN ÄR TOM!\n\n");
            }
            else
            {
                Console.WriteLine($"Status\tNr.\tUppgift\n");
 
                for (int i = 0; i < ToDo.Count; i++)
                {
                    Console.ResetColor();
                    var item = ToDo[i];
                    var index = i + 1;
                    
                    if (item.done == null)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    else if (item.done != null)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }

                    if (item.type == "S")
                    {
                        SimpleTask.ShowTask(item, index);   
                    }
                    else if (item.type == "C")
                    {
                        Checklist.ShowTask(item, index);
                        ShowSubTasks(item.subTasks, index);   
                    }
                    else if (item.type == "D")
                    {
                        Deadline.ShowTask(item, index);   
                    } 
                }
            }
            Console.ResetColor();
        }

        /*-----------------METHOD-----------------------
            Display Checklist tasks 
        ------------------------------------------------*/
        private void ShowSubTasks(List<SimpleTask> subList, int checkIndex)
        {
            for (int i = 0; i < subList.Count; i++)
            {
                Console.ResetColor();
                var taskIndex = i + 1;
                
                var item = subList[i];
                // item.type = "sub";

                if (item.done == null)
                {
                 Console.ForegroundColor = ConsoleColor.Red;
                }
                else if (item.done != null)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }

                SimpleTask.ShowTask(item, checkIndex, taskIndex);    
            }
            Console.ResetColor();
        }

        /*-----------------METHOD-----------------------
            Find task to mark as done / undone
        ------------------------------------------------*/
        internal void FindTaskToMark(ToDoList list)
        {
            Console.WriteLine("\nVilken uppgift vill du markera / avmarkera? Är det en under uppgift, ange först rubrikens nummer.\n");

            int index = ReadInt() - 1;
            
            for (int i = 0; i < list.ToDo.Count; i++)
            {
                var task = list.ToDo[i];

                if(i == index)
                {
                    if (task.type == "C")
                    {
                        Console.WriteLine("\nVilken underuppgift vill du markera / avmarkera?\n");
                        int subIndex = ReadInt() - 1;

                        var count = task.subTasks.Count;
                        var marked = 0;

                        for (int j = 0; j < count; j++)
                        {
                            var subTask = task.subTasks[j];
                            if(subTask.done == "X")
                            {
                                marked++;
                            }
                            if (j == subIndex)
                            {
                                subTask.MarkAsDone();
                                marked++;
                            }
                        }
                        if(count == marked)
                        {
                            task.MarkAsDone();
                        }
                    }
                    else 
                    {
                        task.MarkAsDone();
                    }
                } 
            }
            list.ShowLeftToDo(list.ToDo);
        }
        private static int ReadInt()
        {
            int number;
            while (int.TryParse(Console.ReadLine(), out number) == false)
            {
                Console.WriteLine("Du skrev inte in ett tal. Försök igen.");
            }
            return number;
        }

        /*-----------------METHOD-----------------------
            Display arcived tasks
        ------------------------------------------------*/
        internal void ShowArchive(List<Tasks> Arc)
        {
            Console.Clear();
            if(Arc.Count < 1 )
            {
                Console.WriteLine($"\n\nARKIVET ÄR TOMT.\n\n");
            }
            else
            {
                Console.WriteLine($"UTFÖRDA UPPGIFTER:\n");
                Console.WriteLine($"Status\tArkiv.\tUppgift\n");
                Console.ForegroundColor = ConsoleColor.Green;
                
                int amount = 0;
                for (int i = 0; i < Arc.Count; i++)
                {
                    var task = Arc[i];

                    if (task.type == "C")
                    {
                        Console.WriteLine($"[{task.done}]\t\t{task.description}\n");
                        amount++;
                        for (int j = 0; j < task.subTasks.Count; j++)
                        {
                            var subTask = task.subTasks[j];
                            Console.WriteLine($"\t\t[{subTask.done}]\t\t{subTask.description}\n");
                            amount++; 
                        }
                    }
                    else
                    {
                        Console.WriteLine($"[{task.done}]\t\t{task.description}\n");
                        amount++;
                    }
                }
                Console.ResetColor();    
                Console.WriteLine($"\nWOW! DU HAR UTFÖRT {amount} UPPGIFTER!");
                
            }
        }
    }
}
