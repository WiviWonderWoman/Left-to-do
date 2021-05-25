using System;
namespace LeftToDo
{
    /*=====================================CLASS==================================================
        Derives from Task
    ==============================================================================================*/
    public class Deadline : Tasks
    {
        
        public Deadline(string specification, int daysToSet)
        {
            type = "D";
            description = specification;
            daysLeft = daysToSet;
        }

        /*-----------------METHOD-----------------------
            Calculates days left
        ------------------------------------------------*/
        private static int ComputeDaysLeft()
        {
            //var today = DateTime.Today;
            var today = new DateTime(2020, 01, 01);
            var dueDay = new DateTime(2021, 01, 01);

            TimeSpan interval = dueDay - today;

            var daysLeft = interval.Days;

            return daysLeft;
        }
        public static int GetDaysLeft()
        {
            int days = ComputeDaysLeft();
            return days;
        }
        internal static void ShowTask(Tasks task, int index)
        {
            if(task.done == null)
            {
                Console.WriteLine($"[ ]\t{index}\t{task.description}\tDeadline om {task.daysLeft} dagar");
            }
            else
            {
                Console.WriteLine($"[{task.done}]\t{index}\t{task.description}");
            } 
        }

        internal override void Create()
        {
            Console.WriteLine("Ange uppgift:");
            description = Console.ReadLine();

            Console.WriteLine("Ange dagar till deadline:");
            daysLeft = ReadInt();
        }
         private static int ReadInt()
        {
            int days;
            while (int.TryParse(Console.ReadLine(), out days) == false)
            {
                Console.WriteLine("Du skrev inte in ett tal. Försök igen.");
            }
            return days;
        }
    }
}
