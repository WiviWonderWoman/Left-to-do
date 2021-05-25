using System;
using System.Collections.Generic;
using Xunit;

namespace LeftToDo
{
    public class ListTests
    {
        //Testing adding tasks to list with ToDoList.AddToDoList(Task task)
        [Fact]
        public void AddingToList()
        {
            //arrenge
            var testList = new ToDoList();

            var testSimple = new SimpleTask("");
            testList.AddToDoList(testSimple);

            var testChecklist = new Checklist("");
            testList.AddToDoList(testChecklist);

            var testDeadline = new Deadline("", 2);
            testList.AddToDoList(testDeadline);

            var expected = 3;

            //act
            var result = testList.ToDo.Count;
            
            //assert
            Assert.Equal(expected, result);
        }

        //Testing if a task get marked as done with Tasks.MarkAsDone()
        [Fact]
        public void MarkTaskAsDone()
        {
            //arrenge 
            var testSimple = new SimpleTask("");
            var testChecklist = new Checklist("");
            var testDeadline = new Deadline("", 0);
            
            //act
            testChecklist.MarkAsDone();
            testDeadline.MarkAsDone();

            //assert
            Assert.Null(testSimple.done);

            Assert.Equal(testDeadline.done, testChecklist.done);
        }

        //Testing if tasks marked as done adds to Arc and removes from ToDo with ToDoList.ArchiveTasks()
        [Fact]
        public void ArchivingTasks()
        {
            //arrenge
            var testList = new ToDoList();

            var testSimple1 = new SimpleTask("");
            testList.AddToDoList(testSimple1);   

            var testSimple2 = new SimpleTask("");
            testList.AddToDoList(testSimple2);

            //act
            testSimple1.MarkAsDone();
            testList.ArchiveTasks();
            int expected = testList.ToDo.Count;
            int actual = testList.Archive.Count;

            //assert
            Assert.Equal(expected, actual);
            
        }

        //Testing computing days until deadline with Deadline.ComputeDaysLeft()
        [Fact]
        public void DayUntilDue()
        {
            //arrenge
            var expected = 366;

            //act
            int actual = Deadline.GetDaysLeft();

            //assert
            Assert.Equal(expected, actual);
        }

        //Testing adding sub-tasks to Checklist with Cecklist.AddSubTask(SimpleTask task)
        [Fact]
        public void AddingToSubList()
        {
            //arrenge
            var testList = new ToDoList();

            var testChecklist = new Checklist("");
            testList.AddToDoList(testChecklist);

            var testSubList = testChecklist.subTasks;

            var testTask1 = new SimpleTask("");
            testChecklist.AddSubTask(testTask1);

            var testTask2 = new SimpleTask("");
            testChecklist.AddSubTask(testTask2);

            var expected = 2;

            //act
            var result = testSubList.Count;
            
            //assert
            Assert.Equal(expected, result);
        }
    }
}
