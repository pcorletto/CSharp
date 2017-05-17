using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;

// Peter R. Corletto. May 17, 2017
// CS50XMiami, Cohort 6, C# track. 
// HW # 2, Big Bank Inc.

// Program to help Big Bank Inc. to perfom some basic customer account management.


namespace BigBank
{
    
    public abstract class Account
    {
               
        public int AccountNumber;

        // Each account should have a customer. Associate account with a customer ID

        public string AccountType;

        public int CustomerId;

        public double OpeningBalance;

        public double EndingBalance;
        
        public double InterestRate; 

        public double Interest;

        public DateTime DateOpened;

        public double Years;

        public abstract void GenerateInterest();

    }
    
    public class CheckingAccount : Account
    {

        public override void GenerateInterest()
        {
             
            AccountType = "Checking";
            
            InterestRate = 0;

            this.Years = (DateTime.Now.Year - this.DateOpened.Year);

            // If the month number Now is less than the month number
            // when the account was opened, one full year has not passed.
            // In that case, subtract one to the years.

            if(DateTime.Now.Month < this.DateOpened.Month)
            {
                this.Years -= 1;                
            }

            // If the month number Now and the month number when the account
            // was opened are the same, but the day Now is less than the 
            // day when the account was opened, one full year has not passed.
            // In that case, subtract one to the years.

            if((DateTime.Now.Month == this.DateOpened.Month)&&(DateTime.Now.Day < this.DateOpened.Day))
            {
                this.Years -= 1;
            }

            // Checking accounts generally do not earn any interest

            Interest = 0;

            this.EndingBalance = this.OpeningBalance;

        }

    }

    public class SavingsAccount : Account
    {

        public override void GenerateInterest()
        {
            
            AccountType = "Savings ";

            InterestRate = 0.015;  

            this.Years = (DateTime.Now.Year - this.DateOpened.Year);

            // If the month number Now is less than the month number
            // when the account was opened, one full year has not passed.
            // In that case, subtract one to the years.

            if(DateTime.Now.Month < this.DateOpened.Month)
            {
                this.Years -= 1;                
            }

            // If the month number Now and the month number when the account
            // was opened are the same, but the day Now is less than the 
            // day when the account was opened, one full year has not passed.
            // In that case, subtract one to the years.

            if((DateTime.Now.Month == this.DateOpened.Month)&&(DateTime.Now.Day < this.DateOpened.Day))
            {
                this.Years -= 1;
            }

            // Interest I = Prt

            Interest = this.OpeningBalance * InterestRate * this.Years;   

            this.EndingBalance = this.OpeningBalance + Interest;      

        }

    }

    public abstract class Deposit
    {
               
        public int DepositId;

        public string DepositType;

        public int AccountNumber;

        public double DepositAmount;

        public double DepositPlusInterest;
        
        public double InterestRate; 

        public double Interest;

        public DateTime DepositDate;

        public double Years;

        public abstract void GenerateInterest();

    }
    
    public class CheckingDeposit : Deposit
    {

        public override void GenerateInterest()
        {
             
            DepositType = "Checking";
            
            InterestRate = 0;

            this.Years = (DateTime.Now.Year - this.DepositDate.Year);

            // If the month number Now is less than the month number
            // when the deposit was made, one full year has not passed.
            // In that case, subtract one to the years.

            if(DateTime.Now.Month < this.DepositDate.Month)
            {
                this.Years -= 1;                
            }

            // If the month number Now and the month number when the deposit
            // was made are the same, but the day Now is less than the 
            // day when the deposit was made, one full year has not passed.
            // In that case, subtract one to the years.

            if((DateTime.Now.Month == this.DepositDate.Month)&&(DateTime.Now.Day < this.DepositDate.Day))
            {
                this.Years -= 1;
            }

            // Checking accounts generally do not earn any interest

            Interest = 0;

            this.DepositPlusInterest = this.DepositAmount;

        }

    }

    public class SavingsDeposit : Deposit
    {

        public override void GenerateInterest()
        {
            
            DepositType = "Savings ";

            InterestRate = 0.015;  

            this.Years = (DateTime.Now.Year - this.DepositDate.Year);

            // If the month number Now is less than the month number
            // when the deposit was made, one full year has not passed.
            // In that case, subtract one to the years.

            if(DateTime.Now.Month < this.DepositDate.Month)
            {
                this.Years -= 1;                
            }

            // If the month number Now and the month number when the deposit
            // was made are the same, but the day Now is less than the 
            // day when the deposit was made, one full year has not passed.
            // In that case, subtract one to the years.

            if((DateTime.Now.Month == this.DepositDate.Month)&&(DateTime.Now.Day < this.DepositDate.Day))
            {
                this.Years -= 1;
            }

            // Interest I = Prt

            Interest = this.DepositAmount * InterestRate * this.Years;   

            this.DepositPlusInterest = this.DepositAmount + Interest;      

        }

    }

    
    class Program
    {
        static void Main(string[] args)
        { 

            // The first thing to do, is to create a list of accounts that will
            // hold any account the user creates, whether it is savings or checking

            List<Account> accountList = new List<Account>();   

            // Also, create a list of deposits

            List<Deposit> depositList = new List<Deposit>();   
            
            Start:
                                           
                Console.WriteLine("\nWelcome to Big Bank Inc\n");

                Console.WriteLine("What would you like to do today?\n");

                Console.WriteLine("1. Create an account");

                Console.WriteLine("2. Remove an account");

                Console.WriteLine("3. Make a deposit");

                Console.WriteLine("4. Withdraw Funds");

                Console.WriteLine("5. Display Total Accounts Balance");

                Console.WriteLine("6. View Account Details of a Selected Account");

                Console.WriteLine("7. Quit\n");

                // I consulted the documentation on how to capture user's input from the console at:
                // https://msdn.microsoft.com/en-us/library/system.console.readline(v=vs.110).aspx
                
                // Also checked:
                // http://openeschool.com/magazine/article/41/c-sharp-how-to-read-integer-input-from-user-in-console-program?AspxAutoDetectCookieSupport=1

                // The menu choice needs to be an integer between 1 and 7. 
                // Validate user input, in case it is not.
                
                int Choice=0;

                while(Choice<1||Choice>7)
                {
                    
                    string UserInput = Console.ReadLine();
                  
                    if(!string.IsNullOrEmpty(UserInput))
                    {                
                        char firstChar = UserInput[0];
                        bool isNumber = Char.IsDigit(firstChar);
                        
                        if(!isNumber)
                        {
                            Console.Clear();
                            goto Start;
                        }

                        Choice = Convert.ToInt32(UserInput);
                    }
                    else
                    {
                        Console.Clear();
                        goto Start;
                    }
                }

                // If the user inputs a choice between 1 and 7, inclusive, proceed with the program ...
                                    
                switch(Choice)
                {
                    case 1:

                        Console.Clear();

                        Console.WriteLine("Create New Account\n");

                        Console.WriteLine("Enter:\n");

                        Console.WriteLine("1. For checking account\n");

                        Console.WriteLine("2. For savings account\n");

                        int AccountType = 0;
                        
                        while(AccountType<1||AccountType>2)
                        {

                            string UserInput = Console.ReadLine();

                            if(!string.IsNullOrEmpty(UserInput))
                            {                
                                
                                char firstChar = UserInput[0];
                                bool isNumber = Char.IsDigit(firstChar);
                        
                                if(!isNumber)
                                {
                                    Console.Clear();
                                    goto case 1;
                                }
                                                                
                                AccountType = Convert.ToInt32(UserInput);
                            }
                            else
                            {
                                Console.Clear();
                                goto case 1;
                            }
                          
                            // If the user inputs 1 or 2, inclusive, proceed with the program ...
                                                
                            switch(AccountType)
                            {
                                case 1: 
                                    
                                    // Create a new checking account object

                                    CheckingAccount CheckingOne = new CheckingAccount();
                                                                
                                    Console.Clear();
                                    Console.WriteLine("Create New Checking Account\n");

                                    Console.WriteLine("Enter:\n");

                                    Console.Write("Your customer ID: ");

                                    string CheckingCustomerIdInput;

                                    CheckingCustomerIdInput = Console.ReadLine();
                                    
                                    int CheckingCustomerId;
                                    
                                    if(!string.IsNullOrEmpty(CheckingCustomerIdInput))
                                    {                
                                        char firstChar = CheckingCustomerIdInput[0];
                                        bool isNumber = Char.IsDigit(firstChar);
                                        
                                        if(!isNumber)
                                        {
                                            Console.Clear();
                                            goto case 1;
                                        }
                                        
                                        CheckingCustomerId = Convert.ToInt32(CheckingCustomerIdInput);
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        goto case 1;
                                    }                              

                                    CheckingOne.CustomerId = CheckingCustomerId;

                                    choosechkaccno:

                                    Console.Clear();
                                    
                                    Console.Write("Choose a checking account number: "); 

                                    int CheckingAccountNumber;

                                    string CheckingAccountNumberString;

                                    CheckingAccountNumberString = Console.ReadLine();

                                    if(!string.IsNullOrEmpty(CheckingAccountNumberString))
                                    {                
                                        char firstChar = CheckingAccountNumberString[0];
                                        bool isNumber = Char.IsDigit(firstChar);
                                        
                                        if(!isNumber)
                                        {
                                            Console.Clear();
                                            goto choosechkaccno;
                                        }
                                        
                                        CheckingAccountNumber = Convert.ToInt32(CheckingAccountNumberString);

                                    }
                                    else
                                    {
                                        Console.Clear();
                                        goto choosechkaccno;
                                    }             
                                    
                                    CheckingOne.AccountNumber = CheckingAccountNumber;

                                    initialbalance:
                                    
                                    Console.Clear();
                                    
                                    Console.Write("An initial balance you wish to deposit: ");      

                                    double CheckingBalance;

                                    string CheckingBalanceString;

                                    CheckingBalanceString = Console.ReadLine();

                                    if(!string.IsNullOrEmpty(CheckingBalanceString))
                                    {                
                                        char firstChar = CheckingBalanceString[0];
                                        bool isNumber = Char.IsDigit(firstChar);
                                        
                                        if(!isNumber)
                                        {
                                            Console.Clear();
                                            goto initialbalance;
                                        }
                                        
                                        CheckingBalance = Convert.ToInt32(CheckingBalanceString);

                                    }
                                    else
                                    {
                                        Console.Clear();
                                        goto initialbalance;
                                    }     

                                    CheckingOne.OpeningBalance = CheckingBalance;   

                                    // Ask user to enter the date the checking account was opened.
                                    
                                    // But, before anything, make sure that the date the user enters
                                    // follows a certain format and is validated.

                                    bool CheckingValidDate = false;

                                    while(!CheckingValidDate)
                                    {

                                        Console.Write("\nEnter the date this checking account was opened in format MM/DD/YYYY: ");

                                        string DateInput = Console.ReadLine();

                                        CheckingValidDate = ValidateDate(DateInput); 

                                        if(CheckingValidDate)
                                        {
                                        
                                            CheckingOne.DateOpened = Convert.ToDateTime(DateInput);
                                        }
                                    }                                                           
                                    
                                    CheckingOne.GenerateInterest(); 

                                    // Checking account created!
                                    
                                    // Now, add this account to the list of accounts...

                                    accountList.Add(CheckingOne);                                    
                                    
                                    break;

                                case 2:                
                                    
                                    // Create a new savings account object

                                    SavingsAccount SavingsOne = new SavingsAccount();
                                                                
                                    customerid:
                                    Console.Clear();
                                    Console.WriteLine("Create New Savings Account\n");

                                    Console.WriteLine("Enter:\n");

                                    Console.Write("Your customer ID: ");

                                    int SavingsCustomerId;

                                    string SavingsCustomerIdString;

                                    SavingsCustomerIdString = Console.ReadLine();

                                    if(!string.IsNullOrEmpty(SavingsCustomerIdString))
                                    {                
                                        char firstChar = SavingsCustomerIdString[0];
                                        bool isNumber = Char.IsDigit(firstChar);
                                        
                                        if(!isNumber)
                                        {
                                            Console.Clear();
                                            goto customerid;
                                        }
                                        
                                        SavingsCustomerId = Convert.ToInt32(SavingsCustomerIdString);

                                    }
                                    else
                                    {
                                        Console.Clear();
                                        goto customerid;
                                    }     

                                    SavingsOne.CustomerId = SavingsCustomerId;

                                    Console.Clear();

                                    savaccno:
                                    
                                    Console.Write("Choose a savings account number: "); 

                                    int SavingsAccountNumber;

                                    string SavingsAccountNumberString;

                                    SavingsAccountNumberString = Console.ReadLine();

                                    if(!string.IsNullOrEmpty(SavingsAccountNumberString))
                                    {                
                                        char firstChar = SavingsAccountNumberString[0];
                                        bool isNumber = Char.IsDigit(firstChar);
                                        
                                        if(!isNumber)
                                        {
                                            Console.Clear();
                                            goto savaccno;
                                        }
                                        
                                        SavingsAccountNumber = Convert.ToInt32(SavingsAccountNumberString);

                                    }
                                    else
                                    {
                                        Console.Clear();
                                        goto savaccno;
                                    }     
                                    
                                    SavingsOne.AccountNumber = SavingsAccountNumber;

                                    savinitialbalance:

                                    Console.Clear();
                                    
                                    Console.Write("An initial balance you wish to deposit: ");      

                                    double SavingsBalance;

                                    string SavingsBalanceString;

                                    SavingsBalanceString = Console.ReadLine();

                                    if(!string.IsNullOrEmpty(SavingsBalanceString))
                                    {                
                                        char firstChar = SavingsBalanceString[0];
                                        bool isNumber = Char.IsDigit(firstChar);
                                        
                                        if(!isNumber)
                                        {
                                            Console.Clear();
                                            goto savinitialbalance;
                                        }
                                        
                                        SavingsBalance = Convert.ToDouble(SavingsBalanceString);

                                    }
                                    else
                                    {
                                        Console.Clear();
                                        goto savinitialbalance;
                                    }     
                                    
                                    SavingsOne.OpeningBalance = SavingsBalance;

                                    // Ask user to enter the date the savings account was opened.
                                    // I will use this date to keep track of interest

                                    // But, before anything, make sure that the date the user enters
                                    // follows a certain format and is validated.

                                    bool SavingsValidDate = false;

                                    while(!SavingsValidDate)
                                    {

                                        Console.Write("\nEnter the date this savings account was opened in format MM/DD/YYYY: ");

                                        string DateInput = Console.ReadLine();

                                        SavingsValidDate = ValidateDate(DateInput); 

                                        if(SavingsValidDate)
                                        {
                                        
                                            SavingsOne.DateOpened = Convert.ToDateTime(DateInput);
                                        }
                                    }

                                    SavingsOne.GenerateInterest(); 

                                    // Savings account created!
                                    
                                    // Now, add this account to the list of accounts...

                                    accountList.Add(SavingsOne);
                                  
                                    break;

                            }
                            
                        }

                        goto Start;

                    case 2:

                        Console.Clear();
                        
                        Console.WriteLine("\nRemove an Account\n");
                                                
                        // Ask the user to enter his/her customer ID first
                        // This way, we will be able to display only the accounts
                        // in the account list whose customer ID matches the one
                        // entered by the user

                        Console.Write("Enter your Customer ID: ");

                        int CustId;
                        
                        string CustIdInput = Console.ReadLine();

                        if(!string.IsNullOrEmpty(CustIdInput))
                        {                
                            char firstChar = CustIdInput[0];
                            bool isNumber = Char.IsDigit(firstChar);
                            
                            if(!isNumber)
                            {
                                Console.Clear();
                                goto case 2;
                            }
                            
                            CustId = Convert.ToInt32(CustIdInput);

                        }
                        else
                        {
                            Console.Clear();
                            goto case 2;
                        }     
                       

                        Console.Write("\nYou have the following accounts open at Big Bank Inc.\n");

                        // Header output
                        Console.Write("\nACCOUNT NUMBER\tTYPE\t\t\tBALANCE\n");
                      
                        foreach(Account account in accountList)
                        {

                            // Only display the accounts whose customer ID matches the one
                            // entered by the customer
                            
                            if(account.CustomerId == CustId)
                            {
                                
                                account.GenerateInterest();
                                
                                Console.Write("\n" + account.AccountNumber + "\t\t" + account.AccountType + "\t\t" + String.Format("{0:C}", Convert.ToDouble(account.EndingBalance)) + "\n");
                                
                            }                        
                                                        
                        }

                        accremove:
                                                
                        // Ask the user to enter the account number he/she wishes
                        // to remove
                        
                        Console.Write("\nEnter the Account Number You Wish to Remove: ");

                        int RemoveNo;
                        
                        string RemoveNoInput = Console.ReadLine();

                        if(!string.IsNullOrEmpty(RemoveNoInput))
                        {                
                            char firstChar = RemoveNoInput[0];
                            bool isNumber = Char.IsDigit(firstChar);
                            
                            if(!isNumber)
                            {
                                goto accremove;
                            }
                            
                            RemoveNo = Convert.ToInt32(RemoveNoInput);

                        }
                        else
                        {
                            
                            goto accremove;
                        }     

                        // Display contents of object

                        Console.Clear(); 

                        int i=0;

                        int PositionToDelete=0;

                        foreach(Account removeAcct in accountList)
                        {

                            // Only display the accounts whose customer ID matches the one
                            // entered by the customer
                            
                            if(removeAcct.AccountNumber == RemoveNo)
                            {
                                
                                PositionToDelete = i;
                                                                
                            }

                            i++;                        
                                                        
                        }

                        Console.Clear();
                        accountList.RemoveAt(PositionToDelete);                                  
                        goto Start;

                    case 3:

                        Console.Clear();

                        Console.WriteLine("Make a Deposit\n");

                        Console.WriteLine("Enter:\n");

                        Console.WriteLine("1. To deposit to checking\n");

                        Console.WriteLine("2. To deposit to savings\n");

                        int DepositType = 0;
                        
                        while(DepositType<1||DepositType>2)
                        {

                            string UserDepInput = Console.ReadLine();

                            if(!string.IsNullOrEmpty(UserDepInput))
                            {                
                                char firstChar = UserDepInput[0];
                                bool isNumber = Char.IsDigit(firstChar);
                                
                                if(!isNumber)
                                {
                                    Console.Clear();
                                    goto case 3;
                                }
                                
                                DepositType = Convert.ToInt32(UserDepInput);

                            }
                            else
                            {
                                Console.Clear();
                                goto case 3;
                            }     
                                                                              
                            // If the user inputs 1 or 2, inclusive, proceed with the program ...
                                                
                            switch(DepositType)
                            {
                                case 1: 
                                    
                                    // Create a new checking deposit object

                                    CheckingDeposit CheckingDepOne = new CheckingDeposit();
                                                                
                                    Console.Clear();
                                    Console.WriteLine("Deposit Into a Checking Account\n");

                                    Console.WriteLine("Enter:\n");

                                    Console.Write("Checking Account Number: ");

                                    int CheckingAccNo;

                                    string CheckingAccNoString;

                                    CheckingAccNoString = Console.ReadLine();

                                    if(!string.IsNullOrEmpty(CheckingAccNoString))
                                    {                
                                        char firstChar = CheckingAccNoString[0];
                                        bool isNumber = Char.IsDigit(firstChar);
                                        
                                        if(!isNumber)
                                        {
                                            Console.Clear();
                                            goto case 1;
                                        }
                                        
                                        CheckingAccNo = Convert.ToInt32(CheckingAccNoString);

                                    }
                                    else
                                    {
                                        Console.Clear();
                                        goto case 1;
                                    }     
                                                                       
                                    // Verify that this account number is for a checking
                                    // account and not for a savings account

                                    foreach(Account account in accountList)
                                    {
                                        if((account.AccountNumber == CheckingAccNo)&&(account.AccountType=="Savings "))
                                        {
                                            Console.Write("\nYou are trying to make a checking deposit to a savings account! Please choose account type again!");
                                            goto Start;
                                        }
                                    }

                                    CheckingDepOne.AccountNumber = CheckingAccNo;
                                    
                                    depid:
                                    
                                    Console.Clear();
                                    
                                    Console.Write("Enter Deposit ID: "); 

                                    int CheckingDepId;

                                    string CheckingDepIdString;

                                    CheckingDepIdString = Console.ReadLine();

                                    if(!string.IsNullOrEmpty(CheckingDepIdString))
                                    {                
                                        char firstChar = CheckingDepIdString[0];
                                        bool isNumber = Char.IsDigit(firstChar);
                                        
                                        if(!isNumber)
                                        {
                                            Console.Clear();
                                            goto depid;
                                        }
                                        
                                        CheckingDepId = Convert.ToInt32(CheckingDepIdString);

                                    }
                                    else
                                    {
                                        Console.Clear();
                                        goto depid;
                                    }     

                                    CheckingDepOne.DepositId = CheckingDepId;

                                    depamount:

                                    Console.Clear();
                                    
                                    Console.Write("A deposit amount: ");      

                                    double DepositAmount;

                                    string DepositAmountString;

                                    DepositAmountString = Console.ReadLine();

                                    if(!string.IsNullOrEmpty(DepositAmountString))
                                    {                
                                        char firstChar = DepositAmountString[0];
                                        bool isNumber = Char.IsDigit(firstChar);
                                        
                                        if(!isNumber)
                                        {
                                            Console.Clear();
                                            goto depamount;
                                        }
                                        
                                        DepositAmount = Convert.ToDouble(DepositAmountString);

                                    }
                                    else
                                    {
                                        Console.Clear();
                                        goto depamount;
                                    }     

                                    CheckingDepOne.DepositAmount = DepositAmount;   

                                    // Ask user to enter the date the deposit was made.
                                    
                                    // But, before anything, make sure that the date the user enters
                                    // follows a certain format and is validated.

                                    bool CheckingDepValidDate = false;

                                    while(!CheckingDepValidDate)
                                    {

                                        Console.Write("\nEnter the date of this checking deposit in format MM/DD/YYYY: ");

                                        string DateChkDepInput = Console.ReadLine();

                                        CheckingDepValidDate = ValidateDate(DateChkDepInput); 

                                        if(CheckingDepValidDate)
                                        {
                                                                                                                           
                                            // A deposit date must be AFTER the date the account was opened
                                            // never before.

                                            // Check for this.

                                            foreach(Account account in accountList)
                                            {

                                                if(Convert.ToDateTime(DateChkDepInput).Year < account.DateOpened.Year)
                                                {
                                                    Console.WriteLine("\nYou opened this account in " + account.DateOpened.Year + "\n");
                                                    Console.WriteLine("\nYour deposit year must be after the year the account was opened. Please check and try again.\n");
                                                    goto Start;
                                                } 

                                                if((Convert.ToDateTime(DateChkDepInput).Year == account.DateOpened.Year)&&(Convert.ToDateTime(DateChkDepInput).Month < account.DateOpened.Month))
                                                {
                                                    Console.WriteLine("\nYour deposit month must be after the month the account was opened that year. Please check and try again.\n");
                                                    goto Start;
                                                } 

                                                if((Convert.ToDateTime(DateChkDepInput).Year == account.DateOpened.Year)&&(Convert.ToDateTime(DateChkDepInput).Month == account.DateOpened.Month)&&(Convert.ToDateTime(DateChkDepInput).Day < account.DateOpened.Day))
                                                {
                                                    Console.WriteLine("\nYour deposit day must be after the day the account was opened that month and year. Please check and try again.\n");
                                                    goto Start;
                                                }
                                            }

                                            CheckingDepOne.DepositDate = Convert.ToDateTime(DateChkDepInput);
                                        
                                        }
                                    }                                                           
                                    
                                    CheckingDepOne.GenerateInterest(); 

                                    // Checking Deposit made!
                                    
                                    // Now, add this deposit to the list of deposits...

                                    depositList.Add(CheckingDepOne);                                    
                                    
                                    break;

                                case 2:                
                                    
                                    // Create a new savings deposit object

                                    SavingsDeposit SavingsDepOne = new SavingsDeposit();
                                                                
                                    Console.Clear();
                                    Console.WriteLine("Deposit Into a Savings Account\n");

                                    Console.WriteLine("Enter:\n");

                                    Console.Write("Savings Account Number: ");

                                    int SavingsAccNo;

                                    string SavingsAccNoString;

                                    SavingsAccNoString = Console.ReadLine();

                                    if(!string.IsNullOrEmpty(SavingsAccNoString))
                                    {                
                                        char firstChar = SavingsAccNoString[0];
                                        bool isNumber = Char.IsDigit(firstChar);
                                        
                                        if(!isNumber)
                                        {
                                            Console.Clear();
                                            goto case 2;
                                        }
                                        
                                        SavingsAccNo = Convert.ToInt32(SavingsAccNoString);

                                    }
                                    else
                                    {
                                        Console.Clear();
                                        goto case 2;
                                    }     

                                 
                                    // Verify that this account number is for a savings
                                    // account and not for a checking account

                                    foreach(Account account in accountList)
                                    {
                                        if((account.AccountNumber == SavingsAccNo)&&(account.AccountType=="Checking"))
                                        {
                                            Console.Write("\nYou are trying to make a savings deposit to a checking account! Please choose account type again!");
                                            goto Start;
                                        }
                                    }

                                    SavingsDepOne.AccountNumber = SavingsAccNo;

                                    enterdepid:
                                    
                                    Console.Clear();
                                    
                                    Console.Write("Enter Deposit ID: "); 

                                    int SavingsDepId;

                                    string SavingsDepIdString;

                                    SavingsDepIdString = Console.ReadLine();

                                    if(!string.IsNullOrEmpty(SavingsDepIdString))
                                    {                
                                        char firstChar = SavingsDepIdString[0];
                                        bool isNumber = Char.IsDigit(firstChar);
                                        
                                        if(!isNumber)
                                        {
                                            Console.Clear();
                                            goto enterdepid;
                                        }
                                        
                                        SavingsDepId = Convert.ToInt32(SavingsDepIdString);

                                    }
                                    else
                                    {
                                        Console.Clear();
                                        goto enterdepid;
                                    }     

                                    SavingsDepOne.DepositId = SavingsDepId;

                                    savdepamount:
                                    
                                    Console.Clear();
                                    
                                    Console.Write("A deposit amount: ");      

                                    double SavDepositAmount;

                                    string SavDepositAmountString;

                                    SavDepositAmountString = Console.ReadLine();

                                    if(!string.IsNullOrEmpty(SavDepositAmountString))
                                    {                
                                        char firstChar = SavDepositAmountString[0];
                                        bool isNumber = Char.IsDigit(firstChar);
                                        
                                        if(!isNumber)
                                        {
                                            Console.Clear();
                                            goto savdepamount;
                                        }
                                        
                                        SavDepositAmount = Convert.ToDouble(SavDepositAmountString);

                                    }
                                    else
                                    {
                                        Console.Clear();
                                        goto savdepamount;
                                    }     

                                    SavingsDepOne.DepositAmount = SavDepositAmount;   

                                    // Ask user to enter the date the deposit was made.
                                    
                                    // But, before anything, make sure that the date the user enters
                                    // follows a certain format and is validated.

                                    bool SavingsDepValidDate = false;

                                    while(!SavingsDepValidDate)
                                    {

                                        Console.Write("\nEnter the date of this savings deposit in format MM/DD/YYYY: ");

                                        string DateSavDepInput = Console.ReadLine();

                                        SavingsDepValidDate = ValidateDate(DateSavDepInput); 

                                        if(SavingsDepValidDate)
                                        {
                                        
                                            // A deposit date must be AFTER the date the account was opened
                                            // never before.

                                            // Check for this.

                                            foreach(Account account in accountList)
                                            {

                                                if(Convert.ToDateTime(DateSavDepInput).Year < account.DateOpened.Year)
                                                {
                                                    Console.WriteLine("\nYou opened this account in " + account.DateOpened.Year + "\n");
                                                    Console.WriteLine("\nYour deposit year must be after the year the account was opened. Please check and try again.\n");
                                                    goto Start;
                                                } 

                                                if((Convert.ToDateTime(DateSavDepInput).Year == account.DateOpened.Year)&&(Convert.ToDateTime(DateSavDepInput).Month < account.DateOpened.Month))
                                                {
                                                    Console.WriteLine("\nYour deposit month must be after the month the account was opened that year. Please check and try again.\n");
                                                    goto Start;
                                                } 

                                                if((Convert.ToDateTime(DateSavDepInput).Year == account.DateOpened.Year)&&(Convert.ToDateTime(DateSavDepInput).Month == account.DateOpened.Month)&&(Convert.ToDateTime(DateSavDepInput).Day < account.DateOpened.Day))
                                                {
                                                    Console.WriteLine("\nYour deposit day must be after the day the account was opened that month and year. Please check and try again.\n");
                                                    goto Start;
                                                }

                                            }

                                            SavingsDepOne.DepositDate = Convert.ToDateTime(DateSavDepInput);

                                        }
                                    }                                                           
                                    
                                    SavingsDepOne.GenerateInterest(); 

                                    // Savings Deposit made!
                                    
                                    // Now, add this deposit to the list of deposits...

                                    depositList.Add(SavingsDepOne);                                    
                                    
                                    break;

                            }
                            
                        }

                        goto Start;

                    case 4:

                        // A withdrawal is very similar to a deposit, except that 
                        // we are depositing a negative amount, and we are not
                        // generating interest for a withdrawal.

                        Console.Clear();

                        Console.WriteLine("\nWithdraw Funds\n");

                        Console.WriteLine("Enter:\n");

                        Console.WriteLine("1. Withdraw from checking\n");

                        Console.WriteLine("2. Withdraw from savings\n");

                        DepositType = 0;
                        
                        while(DepositType<1||DepositType>2)
                        {

                            string UserDepInput = Console.ReadLine();

                            if(!string.IsNullOrEmpty(UserDepInput))
                            {                
                                char firstChar = UserDepInput[0];
                                bool isNumber = Char.IsDigit(firstChar);
                                
                                if(!isNumber)
                                {
                                    Console.Clear();
                                    goto case 4;
                                }
                                
                                DepositType = Convert.ToInt32(UserDepInput);

                            }
                            else
                            {
                                Console.Clear();
                                goto case 4;
                            }     
                                                                              
                            // If the user inputs 1 or 2, inclusive, proceed with the program ...
                                                
                            switch(DepositType)
                            {
                                case 1: 
                                    
                                    // Create a new checking deposit object

                                    CheckingDeposit CheckingDepOne = new CheckingDeposit();
                                                                
                                    Console.Clear();
                                    Console.WriteLine("Withdraw from a Checking Account\n");

                                    Console.WriteLine("Enter:\n");

                                    Console.Write("Checking Account Number: ");

                                    int CheckingAccNo;

                                    string CheckingAccNoString;

                                    CheckingAccNoString = Console.ReadLine();

                                    if(!string.IsNullOrEmpty(CheckingAccNoString))
                                    {                
                                        char firstChar = CheckingAccNoString[0];
                                        bool isNumber = Char.IsDigit(firstChar);
                                        
                                        if(!isNumber)
                                        {
                                            Console.Clear();
                                            goto case 1;
                                        }
                                        
                                        CheckingAccNo = Convert.ToInt32(CheckingAccNoString);

                                    }
                                    else
                                    {
                                        Console.Clear();
                                        goto case 1;
                                    }     
                                                                       
                                    // Verify that this account number is for a checking
                                    // account and not for a savings account

                                    foreach(Account account in accountList)
                                    {
                                        if((account.AccountNumber == CheckingAccNo)&&(account.AccountType=="Savings "))
                                        {
                                            Console.Write("\nYou are trying to make a checking withdrawal from a savings account! Please choose account type again!");
                                            goto Start;
                                        }
                                    }

                                    CheckingDepOne.AccountNumber = CheckingAccNo;
                                    
                                    depid:
                                    
                                    Console.Clear();
                                    
                                    Console.Write("Enter Withdrawal ID: "); 

                                    int CheckingDepId;

                                    string CheckingDepIdString;

                                    CheckingDepIdString = Console.ReadLine();

                                    if(!string.IsNullOrEmpty(CheckingDepIdString))
                                    {                
                                        char firstChar = CheckingDepIdString[0];
                                        bool isNumber = Char.IsDigit(firstChar);
                                        
                                        if(!isNumber)
                                        {
                                            Console.Clear();
                                            goto depid;
                                        }
                                        
                                        CheckingDepId = Convert.ToInt32(CheckingDepIdString);

                                    }
                                    else
                                    {
                                        Console.Clear();
                                        goto depid;
                                    }     

                                    CheckingDepOne.DepositId = CheckingDepId;

                                    depamount:

                                    Console.Clear();
                                    
                                    Console.Write("A withdrawal amount: ");      

                                    double DepositAmount;

                                    string DepositAmountString;

                                    DepositAmountString = Console.ReadLine();

                                    if(!string.IsNullOrEmpty(DepositAmountString))
                                    {                
                                        char firstChar = DepositAmountString[0];
                                        bool isNumber = Char.IsDigit(firstChar);
                                        
                                        if(!isNumber)
                                        {
                                            Console.Clear();
                                            goto depamount;
                                        }
                                        
                                        DepositAmount = Convert.ToDouble(DepositAmountString);

                                    }
                                    else
                                    {
                                        Console.Clear();
                                        goto depamount;
                                    }     

                                    // Multiply deposit amount by -1, to turn it into a withdrawal (negative)
                                    CheckingDepOne.DepositAmount = DepositAmount * -1;   

                                    // Ask user to enter the date the withdrawal was made.
                                    
                                    // But, before anything, make sure that the date the user enters
                                    // follows a certain format and is validated.

                                    bool CheckingDepValidDate = false;

                                    while(!CheckingDepValidDate)
                                    {

                                        Console.Write("\nEnter the date of this checking withdrawal in format MM/DD/YYYY: ");

                                        string DateChkDepInput = Console.ReadLine();

                                        CheckingDepValidDate = ValidateDate(DateChkDepInput); 

                                        if(CheckingDepValidDate)
                                        {
                                                                                                                           
                                            // A deposit date must be AFTER the date the account was opened
                                            // never before.

                                            // Check for this.

                                            foreach(Account account in accountList)
                                            {

                                                if(Convert.ToDateTime(DateChkDepInput).Year < account.DateOpened.Year)
                                                {
                                                    Console.WriteLine("\nYou opened this account in " + account.DateOpened.Year + "\n");
                                                    Console.WriteLine("\nYour deposit year must be after the year the account was opened. Please check and try again.\n");
                                                    goto Start;
                                                } 

                                                if((Convert.ToDateTime(DateChkDepInput).Year == account.DateOpened.Year)&&(Convert.ToDateTime(DateChkDepInput).Month < account.DateOpened.Month))
                                                {
                                                    Console.WriteLine("\nYour deposit month must be after the month the account was opened that year. Please check and try again.\n");
                                                    goto Start;
                                                } 

                                                if((Convert.ToDateTime(DateChkDepInput).Year == account.DateOpened.Year)&&(Convert.ToDateTime(DateChkDepInput).Month == account.DateOpened.Month)&&(Convert.ToDateTime(DateChkDepInput).Day < account.DateOpened.Day))
                                                {
                                                    Console.WriteLine("\nYour deposit day must be after the day the account was opened that month and year. Please check and try again.\n");
                                                    goto Start;
                                                }
                                            }

                                            CheckingDepOne.DepositDate = Convert.ToDateTime(DateChkDepInput);
                                        
                                        }
                                    }                                                           
                                    
                                    // Comment out the Generate Interest, because this is a withdrawal

                                    //CheckingDepOne.GenerateInterest(); 

                                    // Checking Withdrawal made!
                                    
                                    // Now, add this deposit to the list of deposits...

                                    depositList.Add(CheckingDepOne);                                    
                                    
                                    break;

                                case 2:                
                                    
                                    // Create a new savings deposit object

                                    SavingsDeposit SavingsDepOne = new SavingsDeposit();
                                                                
                                    Console.Clear();
                                    Console.WriteLine("Withdraw from a Savings Account\n");

                                    Console.WriteLine("Enter:\n");

                                    Console.Write("Savings Account Number: ");

                                    int SavingsAccNo;

                                    string SavingsAccNoString;

                                    SavingsAccNoString = Console.ReadLine();

                                    if(!string.IsNullOrEmpty(SavingsAccNoString))
                                    {                
                                        char firstChar = SavingsAccNoString[0];
                                        bool isNumber = Char.IsDigit(firstChar);
                                        
                                        if(!isNumber)
                                        {
                                            Console.Clear();
                                            goto case 2;
                                        }
                                        
                                        SavingsAccNo = Convert.ToInt32(SavingsAccNoString);

                                    }
                                    else
                                    {
                                        Console.Clear();
                                        goto case 2;
                                    }     

                                 
                                    // Verify that this account number is for a savings
                                    // account and not for a checking account

                                    foreach(Account account in accountList)
                                    {
                                        if((account.AccountNumber == SavingsAccNo)&&(account.AccountType=="Checking"))
                                        {
                                            Console.Write("\nYou are trying to make a savings withdrawal from a checking account! Please choose account type again!");
                                            goto Start;
                                        }
                                    }

                                    SavingsDepOne.AccountNumber = SavingsAccNo;

                                    enterdepid:
                                    
                                    Console.Clear();
                                    
                                    Console.Write("Enter Withdrawal ID: "); 

                                    int SavingsDepId;

                                    string SavingsDepIdString;

                                    SavingsDepIdString = Console.ReadLine();

                                    if(!string.IsNullOrEmpty(SavingsDepIdString))
                                    {                
                                        char firstChar = SavingsDepIdString[0];
                                        bool isNumber = Char.IsDigit(firstChar);
                                        
                                        if(!isNumber)
                                        {
                                            Console.Clear();
                                            goto enterdepid;
                                        }
                                        
                                        SavingsDepId = Convert.ToInt32(SavingsDepIdString);

                                    }
                                    else
                                    {
                                        Console.Clear();
                                        goto enterdepid;
                                    }     

                                    SavingsDepOne.DepositId = SavingsDepId;

                                    savdepamount:
                                    
                                    Console.Clear();
                                    
                                    Console.Write("A withdrawal amount: ");      

                                    double SavDepositAmount;

                                    string SavDepositAmountString;

                                    SavDepositAmountString = Console.ReadLine();

                                    if(!string.IsNullOrEmpty(SavDepositAmountString))
                                    {                
                                        char firstChar = SavDepositAmountString[0];
                                        bool isNumber = Char.IsDigit(firstChar);
                                        
                                        if(!isNumber)
                                        {
                                            Console.Clear();
                                            goto savdepamount;
                                        }
                                        
                                        SavDepositAmount = Convert.ToDouble(SavDepositAmountString);

                                    }
                                    else
                                    {
                                        Console.Clear();
                                        goto savdepamount;
                                    }     

                                    
                                    // Multiply the SavDepositAmount by -1, to turn it into a withdrawal (negative)
                                    SavingsDepOne.DepositAmount = SavDepositAmount * -1;   

                                    // Ask user to enter the date the withdrawal was made.
                                    
                                    // But, before anything, make sure that the date the user enters
                                    // follows a certain format and is validated.

                                    bool SavingsDepValidDate = false;

                                    while(!SavingsDepValidDate)
                                    {

                                        Console.Write("\nEnter the date of this savings withdrawal in format MM/DD/YYYY: ");

                                        string DateSavDepInput = Console.ReadLine();

                                        SavingsDepValidDate = ValidateDate(DateSavDepInput); 

                                        if(SavingsDepValidDate)
                                        {
                                        
                                            // A deposit date must be AFTER the date the account was opened
                                            // never before.

                                            // Check for this.

                                            foreach(Account account in accountList)
                                            {

                                                if(Convert.ToDateTime(DateSavDepInput).Year < account.DateOpened.Year)
                                                {
                                                    Console.WriteLine("\nYou opened this account in " + account.DateOpened.Year + "\n");
                                                    Console.WriteLine("\nYour deposit year must be after the year the account was opened. Please check and try again.\n");
                                                    goto Start;
                                                } 

                                                if((Convert.ToDateTime(DateSavDepInput).Year == account.DateOpened.Year)&&(Convert.ToDateTime(DateSavDepInput).Month < account.DateOpened.Month))
                                                {
                                                    Console.WriteLine("\nYour deposit month must be after the month the account was opened that year. Please check and try again.\n");
                                                    goto Start;
                                                } 

                                                if((Convert.ToDateTime(DateSavDepInput).Year == account.DateOpened.Year)&&(Convert.ToDateTime(DateSavDepInput).Month == account.DateOpened.Month)&&(Convert.ToDateTime(DateSavDepInput).Day < account.DateOpened.Day))
                                                {
                                                    Console.WriteLine("\nYour deposit day must be after the day the account was opened that month and year. Please check and try again.\n");
                                                    goto Start;
                                                }

                                            }

                                            SavingsDepOne.DepositDate = Convert.ToDateTime(DateSavDepInput);

                                        }
                                    }                                                           
                                    
                                    // Comment out GenerateInterest, this is a withdrawal
                                    //SavingsDepOne.GenerateInterest(); 

                                    // Savings Withdrawal made!
                                    
                                    // Now, add this deposit to the list of deposits...

                                    depositList.Add(SavingsDepOne);                                    
                                    
                                    break;

                            }
                            
                        }

                        goto Start;


                    case 5:

                        Console.Clear();

                        Console.WriteLine("\nDisplay Total Accounts Balance\n");

                        // Ask the user to enter his/her customer ID first
                        // This way, we will be able to display only the accounts
                        // in the account list whose customer ID matches the one
                        // entered by the user

                        Console.Write("Enter your Customer ID: ");

                        int CustomerId;

                        string CustomerIdInput = Console.ReadLine();

                        if(!string.IsNullOrEmpty(CustomerIdInput))
                        {                
                            char firstChar = CustomerIdInput[0];
                            bool isNumber = Char.IsDigit(firstChar);
                            
                            if(!isNumber)
                            {
                                Console.Clear();
                                goto case 5;
                            }
                            
                            CustomerId = Convert.ToInt32(CustomerIdInput);

                        }
                        else
                        {
                            Console.Clear();
                            goto case 5;
                        }     
                       

                        // Header output
                        Console.Write("\nCUSTOMER ID\tACCOUNT NUMBER\tTYPE\t\tBALANCE\n");

                        // Use a variable called "Total" to store the total balance the customer has
                        // in all his accounts in the bank
                        double Total = 0;

                        foreach(Account account in accountList)
                        {

                            // Only display the accounts whose customer ID matches the one
                            // entered by the customer
                            
                            if(account.CustomerId == CustomerId)
                            {
                                                                
                                account.GenerateInterest();
                                
                                // Additionally, look up all the deposits that have been made to this account 
                                // and include them in the balance

                                foreach(Deposit deposit in depositList)
                                {

                                    if(deposit.AccountNumber == account.AccountNumber)
                                    {
                                        if(deposit.DepositAmount >=0 )
                                        {
                                            deposit.GenerateInterest();
                                            account.EndingBalance += deposit.DepositPlusInterest;
                                        }
                                        else
                                        {
                                            account.EndingBalance += deposit.DepositAmount;
                                        }
                                        
                                    }

                                }
                                
                                Console.Write("\n" + account.CustomerId + "\t\t" + account.AccountNumber + "\t\t" + account.AccountType + "\t" + String.Format("{0:C}", Convert.ToDouble(account.EndingBalance)) + "\n");
                                
                                // Accumulate to "Total"
                                Total += account.EndingBalance;
                            }                        
                                                        
                        }

                        // Print out the total
                        Console.Write("\n\t\t\t\tTotal:    \t" + String.Format("{0:C}", Convert.ToDouble(Total)) + "\n");

                        goback:

                        int cont = -1;
                        while(cont<0)
                        {
                            Console.WriteLine("\nEnter 1 to return to the Main Menu\n");
                            string input = Console.ReadLine();

                            if(!string.IsNullOrEmpty(input))
                            {                
                                char firstChar = input[0];
                                bool isNumber = Char.IsDigit(firstChar);
                            
                                if(!isNumber)
                                {
                                    goto goback;
                                }
                            
                                cont = Convert.ToInt32(input);

                                if(cont==1)
                                {
                                    goto Start;
                                }

                                else
                                {
                                    goto goback;
                                }

                            }
                            
                            else
                            {
                                goto goback;
                            }     
                        }
                                  
                        break;
                        
                    case 6:

                        Console.Clear();
                        
                        Console.WriteLine("\nView Account Details of a Selected Account\n");
                        
                        // Ask the user to enter his/her customer ID first
                        // This way, we will be able to display only the accounts
                        // in the account list whose customer ID matches the one
                        // entered by the user

                        Console.Write("Enter your Customer ID: ");

                        string IdInput = Console.ReadLine();

                        int Id;

                        if(!string.IsNullOrEmpty(IdInput))
                        {                
                            char firstChar = IdInput[0];
                            bool isNumber = Char.IsDigit(firstChar);
                            
                            if(!isNumber)
                            {
                                Console.Clear();
                                goto case 6;
                            }
                            
                            Id = Convert.ToInt32(IdInput);

                        }
                        else
                        {
                            Console.Clear();
                            goto case 6;
                        }     

                      
                        Console.Write("\nYou have the following accounts open at Big Bank Inc.\n");

                        // Header output
                        Console.Write("\nACCOUNT NUMBER\tTYPE\n");
                      
                        foreach(Account account in accountList)
                        {

                            // Only display the accounts whose customer ID matches the one
                            // entered by the customer
                            
                            if(account.CustomerId == Id)
                            {
                                
                                Console.Write("\n" + account.AccountNumber + "\t\t" + account.AccountType + "\n");
                                
                            }                        
                                                        
                        }

                        // Ask the user to enter the account number for which he/she wishes
                        // to see details

                        enteraccno:
                        
                        Console.Write("\nEnter an Account Number: ");

                        string AccountNoInput = Console.ReadLine();

                        int AccountNo;

                        if(!string.IsNullOrEmpty(AccountNoInput))
                        {                
                            char firstChar = AccountNoInput[0];
                            bool isNumber = Char.IsDigit(firstChar);
                            
                            if(!isNumber)
                            {
                                goto enteraccno;
                            }
                            
                            AccountNo = Convert.ToInt32(AccountNoInput);

                        }
                        else
                        {
                            goto enteraccno;
                        }     
                       
                        // Display contents of object

                        Console.Clear(); 

                        foreach(Account selectedAcct in accountList)
                        {

                            // Only display the accounts whose customer ID matches the one
                            // entered by the customer
                            
                            if(selectedAcct.AccountNumber == AccountNo)
                            {
                                
                                Console.WriteLine("\nAccount Type: " + selectedAcct.AccountType + "\n");
                            
                                Console.WriteLine("\nAccount Number: " + selectedAcct.AccountNumber + "\n");

                                Console.WriteLine("Customer ID: " + selectedAcct.CustomerId + "\n");
                                                                    
                                Console.WriteLine("Interest Rate: " + String.Format("{0:P2}", Convert.ToDouble(selectedAcct.InterestRate)) + "\n");

                                Console.WriteLine("Date Opened: " + String.Format("{0:MM/dd/yyyy}", selectedAcct.DateOpened) + "\n");

                                Console.WriteLine("Number of Years: " + selectedAcct.Years + "\n");

                                Console.WriteLine("Opening Balance: " + String.Format("{0:C}", Convert.ToDouble(selectedAcct.OpeningBalance)) + "\n");

                                Console.WriteLine("Interest Generated: " + String.Format("{0:C}", Convert.ToDouble(selectedAcct.Interest)) + "\n");
                                                                                                   
                                Console.WriteLine("\nDeposits and Withdrawals Made\n");

                                Console.WriteLine("\nWithdrawals shown as negative, like (100.00)\n");

                                double TotalDeposits = 0;

                                double TotalDepInterest = 0;

                                foreach(Deposit deposit in depositList)
                                {

                                    if(deposit.AccountNumber == selectedAcct.AccountNumber)
                                    {
                                        Console.WriteLine("\nDate: " + deposit.DepositDate);
                                        Console.WriteLine("Deposit Amount: " + String.Format("{0:C}", Convert.ToDouble(deposit.DepositAmount)));
                                        Console.WriteLine("Interest Rate: " + String.Format("{0:P2}", Convert.ToDouble(deposit.InterestRate)));
                                        Console.WriteLine("Years: " + deposit.Years);

                                        // Only generate interest if non-negative. If it was 
                                        // negative (a withdrawal) do not generate any negative interest

                                        if(deposit.DepositAmount >= 0)
                                        {
                                            deposit.GenerateInterest();
                                        }
                                        
                                        Console.WriteLine("Interest Earned in " + deposit.Years + " years : " + String.Format("{0:C}", Convert.ToDouble(deposit.Interest)));
                                        Console.WriteLine("Deposit Plus Interest " + String.Format("{0:C}", Convert.ToDouble(deposit.DepositPlusInterest)));
                                        TotalDeposits += deposit.DepositAmount;
                                        TotalDepInterest += deposit.Interest;
                                        
                                    }

                                }

                                selectedAcct.EndingBalance = selectedAcct.OpeningBalance + selectedAcct.Interest + TotalDeposits + TotalDepInterest;
                                    
                                Console.WriteLine("\nEnding Balance: " + String.Format("{0:C}", Convert.ToDouble(selectedAcct.EndingBalance)) + "\n");
                         
                            }                        
                                                        
                        }

                        back:

                        cont = -1;
                        while(cont<0)
                        {
                            Console.WriteLine("\nEnter 1 to return to the Main Menu\n");
                            string input = Console.ReadLine();

                            if(!string.IsNullOrEmpty(input))
                            {                
                                char firstChar = input[0];
                                bool isNumber = Char.IsDigit(firstChar);
                            
                                if(!isNumber)
                                {
                                    goto back;
                                }
                            
                                cont = Convert.ToInt32(input);

                                if(cont==1)
                                {
                                    goto Start;
                                }

                                else
                                {
                                    goto back;
                                }

                            }
                            
                            else
                            {
                                goto back;
                            }     
                        }
                                  
                        break;

                    case 7:

                        Console.WriteLine("Quit");
                        break;
                  
                }

                //SOURCE: https://www.daniweb.com/programming/software-development/threads/430807/get-date-from-console-window

                bool ValidateDate(string Date)
                {

                    CultureInfo provider = CultureInfo.InvariantCulture;

                    try
                    {
                        DateTime.ParseExact(Date, "MM/dd/yyyy", provider);
                        
                    }

                    catch
                    {
                        Console.WriteLine("Date Invalid.");
                        return false;

                    }

                    return true;

                }


            }
        }
    }
