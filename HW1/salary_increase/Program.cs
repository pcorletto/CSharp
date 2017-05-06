using System;
using System.Collections;
using System.Collections.Generic;

// Peter R. Corletto. May 6, 2017
// CS50XMiami, Cohort 6, C# track. 
// HW # 1, Exercise 4

// Program for a HR system that has a function that 
// takes a list of salaries and increases them by 10% (line 96).
// It returns a new list of increased salaries (line 102).

namespace salary_increase
{
    
    public class Salary
    {
        public string Employee_name {get; set;}
        public double Annual_salary {get; set;}  
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            
            // Make a list that will hold the old salaries (before increase)
            List<Salary> oldSalariesList = new List<Salary>();

            // Create some old salaries
            Salary firstOldSalary = new Salary();
            firstOldSalary.Employee_name = "John C. Murphy";
            firstOldSalary.Annual_salary = 30000;

            Salary secondOldSalary = new Salary();
            secondOldSalary.Employee_name = "Peter Smith";
            secondOldSalary.Annual_salary = 42500;

            // Add the salaries to the old salary list
            oldSalariesList.Add(firstOldSalary);
            oldSalariesList.Add(secondOldSalary);

            // Display the list of old salaries

            foreach(Salary salary in oldSalariesList)
            {

                Console.Write("Employee Name: " + salary.Employee_name + "\t" + "|\t");

                // I researched how to display currency format in C# at:
                // http://stackoverflow.com/questions/890100/how-do-i-format-a-double-to-currency-rounded-to-the-nearst-dollar
                Console.Write("Old Salary: " + String.Format("{0:C}", Convert.ToInt32(salary.Annual_salary)) + "\n");

            }
           
            Console.WriteLine("--------------------------------------------------------------");

            // Generate a list of new salaries, using the IncreaseSalaries function
            // that I wrote.

            // My function call takes two params, the old salary list and the percent
            // of increase. In the example below I pass in 10 for 10%. 
            // It returns a list of new salaries, increased by 10%
            List<Salary> newSalariesList = IncreaseSalaries(oldSalariesList, 10);
                       
            // Display the list of new salaries

            foreach(Salary salary in newSalariesList)
            {

                Console.Write("Employee Name: " + salary.Employee_name + "\t"+"|\t");
                
                // I researched how to display currency format in C# at:
                // http://stackoverflow.com/questions/890100/how-do-i-format-a-double-to-currency-rounded-to-the-nearst-dollar
                Console.Write("New Salary: " + String.Format("{0:C}", Convert.ToInt32(salary.Annual_salary)) + "\n");


            }

            // My IncreaseSalary function definition
            List<Salary> IncreaseSalaries(List<Salary> oldSalaries, double percent_increase)
            {

                List<Salary> newList = new List<Salary>();

                foreach(Salary salary in oldSalaries)
                {

                    Salary NewSalary = new Salary();
                    NewSalary.Employee_name = salary.Employee_name;

                    // The next line calculates the new salary, by adding the old salary
                    // plus that salary multiplied by the percent of increase. I divide by
                    // 100 because this is a percent I am working with.

                    NewSalary.Annual_salary = salary.Annual_salary + ((percent_increase*salary.Annual_salary)/100);
                
                    newList.Add(NewSalary);

                }

                return newList;

            }         

        }
    }
}
