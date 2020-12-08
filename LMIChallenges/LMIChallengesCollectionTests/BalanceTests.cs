using Microsoft.VisualStudio.TestTools.UnitTesting;
using LMIChallengesCollection;
using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;

namespace LMIChallengesCollection.Tests
{
    [TestClass()]
    public class BalanceTests
    {
        [TestMethod()]

        //Checking happy path scenario: withdrawing $10
        public void WithdrawTest_withdrawWithinBalance()
        {
            //This initiates the process by setting up the account with initial balance;
            Balance balanceChecker = new Balance();

            //withdraw amount
            balanceChecker.Withdraw(10);

            //Test
            balanceChecker.getBalance().Should().Be(990);
            
        }


        [TestMethod()]

        //Checking happy path scenario: withdrawing full balance at once
        public void WithdrawTest_withdrawFullBalanceatOnce()
        {
            //This initiates the process by setting up the account with initial balance;
            Balance balanceChecker = new Balance();

            //withdraw amount
            balanceChecker.Withdraw(1000);


            //Test
            balanceChecker.getBalance().Should().Be(0);

        }


        [TestMethod()]

        //Checking happy path scenario: withdrawing full balance within business rules
        public void WithdrawTest_withdrawFullBalancewithInBusinessRules()
        {
            //This initiates the process by setting up the account with initial balance;
            Balance balanceChecker = new Balance();

            //withdraw amount
            balanceChecker.Withdraw(500);
            balanceChecker.Withdraw(500);


            //Test
            balanceChecker.getBalance().Should().Be(0);

        }



        [TestMethod()]
        //Checking HappyPath scenario: withdrawing within business rules
        public void WithdrawTest_withinBusinessRules()
        {
            //This initiates the process by setting up the account with initial balance;
            Balance balanceChecker = new Balance();

            //withdraw amount
            balanceChecker.Withdraw(100);
            balanceChecker.Withdraw(200);
            balanceChecker.Withdraw(400);

            //Test
            balanceChecker.getBalance().Should().Be(300);

        }

        [TestMethod()]
        //Checking Negative scenario: withdrawing more than current balance
        public void WithdrawTest_withdrawalMoreThanCurrentBalance()
        {
            //This initiates the process by setting up the account with initial balance;
            Balance balanceChecker = new Balance();

            //withdraw amount
            double amount = 2000;
            Action action = () => balanceChecker.Withdraw(amount);

            //Test
            action.Should().Throw<ArgumentException>().WithMessage($"{amount},Withdrawal exceeds balance!");

        }

        [TestMethod()]
        //Checking Negative scenario: withdrawing $0
        public void WithdrawTest_zeroWithdrawal()
        {
            //This initiates the process by setting up the account with initial balance;
            Balance balanceChecker = new Balance();

            //withdraw amount
            Action action = () => balanceChecker.Withdraw(0);

            //Test
            action.Should().Throw<ArgumentException>().WithMessage("The withdrawl amount should be greater than or equal to $1");

        }

        [TestMethod()]
        //Checking Negative scenario: withdrawing negative amounts
        public void WithdrawTest_negativeAmoutWithdrawal()
        {
            //This initiates the process by setting up the account with initial balance;
            Balance balanceChecker = new Balance();

            //withdraw amount
            Action action = () => balanceChecker.Withdraw(-10);

            //Test
            action.Should().Throw<ArgumentException>().WithMessage("The withdrawl amount should be greater than or equal to $1");

        }

        [TestMethod()]
        //Checking by violating business rules : Withdrawing beyond frequency limit per day

        public void WithdrawTest_BeyondFrequencyLimit()
        {
            //This initiates the process by setting up the account with initial balance;
            Balance balanceChecker = new Balance();

            //withdraw amount
            for (int i = 0; i <= 2; i++)
                balanceChecker.Withdraw(200);

            Action action = () => balanceChecker.Withdraw(350);
            
            //Test
            action.Should().Throw<ArgumentException>().WithMessage("Sorry!! you have reached daily withdrawal frequency");
        }

    }
}