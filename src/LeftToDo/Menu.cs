using System;

namespace LeftToDo
{
    /*=====================================CLASS==================================================
        ToDolist handels out- / input 
    ==============================================================================================*/
    abstract class Menu
    {
        /*-----------------METHOD---------------------------
            Iinstructions to user
        ----------------------------------------------------*/
        private static void ShowIntro()
        {
            Console.WriteLine("Välj i menyn nedan, ange siffran inom [] och tryck enter.\n");
        }

        /*-----------------METHOD---------------------------
            Mainmenu, handel user input with switch statment
        ----------------------------------------------------*/
        internal static void ShowMain(ToDoList list)
        {
            Console.Clear();
            ShowIntro();
            Console.WriteLine("HUVUDMENY\n");
            Console.WriteLine("[1] Visa Att-göra uppgifter\n");
            Console.WriteLine("[2] Visa Arkiverade uppgifter\n");
            Console.WriteLine("[0] Avsluta");

            var menu = Console.ReadLine();

            switch (menu)
            {
                case "1":
                    list.ShowLeftToDo(list.ToDo);
                    ShowToDoMenu(list);
                break;
                case "2":
                    list.ShowArchive(list.Archive);
                    ShowArcMenu(list);
                break;
                case "0":
                    ShowFarewell();
                break;
                default:
                    ShowError();
                    ShowMain(list);
                break;
            }
        }

        /*-----------------METHOD---------------------------
            List menu, handel user input with switch statment
        ----------------------------------------------------*/
        private static void ShowToDoMenu(ToDoList list)
        {
            ShowIntro();
            Console.WriteLine("\nUNDERMENY. Vad vill du göra?\n");
            Console.WriteLine("[1] Lägg till uppgift \n");
            Console.WriteLine("[2] Markera / avmarkera uppgift\n");
            Console.WriteLine("[3] Arkivera utförda uppgifter\n");
            Console.WriteLine("[0] HUVUDMENY\n\n");

            var menu = Console.ReadLine();

            switch (menu)
            {
                case "1":
                    ShowTaskMenu(list);
                break;

                case "2":
                    list.FindTaskToMark(list);
                    ShowToDoMenu(list);
                break;

                case "3":
                    list.ArchiveTasks();
                    list.ShowLeftToDo(list.ToDo);
                    ShowToDoMenu(list);
                break;

                case "0":
                    Console.Clear();
                    ShowMain(list);
                break;
                
                default:
                    ShowError();
                    // ShowToDoMenu(list);
                break;
            }
        }

        /*-----------------METHOD---------------------------
            Task menu, handel user input with switch statment
        ----------------------------------------------------*/
        private static void ShowTaskMenu(ToDoList list)
        {
            list.ShowLeftToDo(list.ToDo);
            ShowIntro();
            Console.WriteLine("\n\nUPPGIFTSMENY. Välj typ av uppgift:\n");
            Console.WriteLine("[1] Enkel uppgift\n");
            Console.WriteLine("[2] Deadline\n");
            Console.WriteLine("[3] Checklista\n");
            Console.WriteLine("[0] HUVUDMENY\n\n");
            
            var menu = Console.ReadLine();

            switch (menu)
            {
                case "1":
                    var simpelTask = new SimpleTask("");
                    simpelTask.Create();
                    list.AddToDoList(simpelTask);
                    list.ShowLeftToDo(list.ToDo);
                    ShowToDoMenu(list);
                break;

                case "2":
                    var deadline = new Deadline("", 0);
                    deadline.Create();
                    list.AddToDoList(deadline);
                    list.ShowLeftToDo(list.ToDo);
                    ShowToDoMenu(list);
                break;

                case "3":
                    var checklist = new Checklist("");
                    checklist.Create();
                    list.AddToDoList(checklist);
                    list.ShowLeftToDo(list.ToDo);
                    ShowToDoMenu(list);
                break;
                
                case "0":
                    Console.Clear();
                    ShowMain(list);
                break;
                
                default:
                    ShowError();
                break;
            }
            
        }

        /*-----------------METHOD---------------------------
            Archive menu, lets user return to Mainmenu
        ----------------------------------------------------*/
        private static void ShowArcMenu(ToDoList list)
        {
            Console.WriteLine("\n[0] HUVUDMENY\n\n");
            var input = Console.ReadLine();
            if (input == "0")
            {
                Console.Clear();
                ShowMain(list);
            }
        }
        
        /*-----------------METHOD---------------------------
            Farewell message
        ----------------------------------------------------*/
        private static void ShowFarewell()
        {
            Console.WriteLine("Tack för besöket och välkommen åter!");
            return;
        }

        /*-----------------METHOD---------------------------
            Error message
        ----------------------------------------------------*/
        private static void ShowError()
        {
            Console.WriteLine("\nOgiltligt val. Vargod försök igen!");
        }
    }
}
