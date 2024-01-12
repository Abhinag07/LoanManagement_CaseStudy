﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoanManagement.dao;
using LoanManagement.entity;


namespace LoanManagement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ILoanRepository loanRepository = new LoanRepositoryImpl();

			while (true) 
			{
                Console.ForegroundColor = ConsoleColor.DarkGray;
				Console.WriteLine("\n1. Apply for Loan");
				Console.WriteLine("2. Calculate interest");
				Console.WriteLine("3. Check Loan Status");
				Console.WriteLine("4. Calculate EMI for the loan");
				Console.WriteLine("5. Pay EMI of your loan");
				Console.WriteLine("6. Get All Loan Details");
				Console.WriteLine("7. Get Loan Details by Id");
				Console.WriteLine("8. Log Out");
                Console.ResetColor();
				Console.WriteLine("Choose options from above");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        try
                        {
                            Loan loan = new Loan();

                            Console.WriteLine("Enter loan details:");

                            Console.Write("Customer ID: ");
                            int customerId = int.Parse(Console.ReadLine());

                            Console.Write("Principal Amount: ");
                            decimal principalAmount = decimal.Parse(Console.ReadLine());

                            Console.Write("Interest Rate: ");
                            decimal interestRate = decimal.Parse(Console.ReadLine());

                            Console.Write("Loan Term (months): ");
                            int loanTerm = int.Parse(Console.ReadLine());

                            Console.Write("Loan Loan ID: ");
                            int loanId = int.Parse(Console.ReadLine());

                            Console.Write("Loan Type (CarLoan/HomeLoan): ");
                            string loanType = Console.ReadLine();

                            loan.CustomerId = customerId;
                            loan.PrincipalAmount = principalAmount;
                            loan.InterestRate = interestRate;
                            loan.LoanTerm = loanTerm;
                            loan.LoanId = loanId;
                            loan.LoanType = loanType;

                            loanRepository.ApplyLoan(loan);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case 2:
                        try
                        {
                            Console.WriteLine("Enter Loan Id to calculate interest");
                            int loanId = Convert.ToInt32(Console.ReadLine());
                            decimal interest = loanRepository.CalculateInterest(loanId);
                            Console.WriteLine("Interest amount is {0}", interest);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case 3:
                        try
                        {
                            Console.WriteLine("Enter LoanId to check loan status");
                            int loanId = Convert.ToInt32(Console.ReadLine());
                            loanRepository.LoanStatus(loanId);
                        }
                        catch(Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case 4:
                        try
                        {
                            Console.WriteLine("Enter LoanId to calculate EMI");
                            int loanId = Convert.ToInt32(Console.ReadLine());
                            decimal emi = loanRepository.CalculateEMI(loanId);
                            Console.WriteLine("EMI per month is {0}", emi);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    break;
                    case 5:
                        try
                        {
                            Console.WriteLine("Enter LoanId to pay EMI");
                            int loanId = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter amount u want to pay");
                            decimal amount = Convert.ToDecimal(Console.ReadLine());
                            loanRepository.LoanRepayment(loanId, amount);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;                    
                    case 6:
                        try
                        {
                            List<Loan> loans = new List<Loan>();
                            loans = loanRepository.GetAllLoans();
                            if(loans != null && loans.Count > 0)
                            {
                                foreach(Loan loan in loans)
                                {
                                    Console.WriteLine(loan);
                                    Console.WriteLine();
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case 7:
                        try
                        {
                            Console.WriteLine("Enter LoanId to get loan details");
                            int loanId = Convert.ToInt32(Console.ReadLine());
                            Loan loan = loanRepository.GetLoanById(loanId);
                            if(loan != null)
                            {
                                Console.WriteLine(loan);
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case 8:
                        Console.WriteLine("Loggin out...");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Wrong Option!");
                        break;
                }
            } 
        }
    }
}