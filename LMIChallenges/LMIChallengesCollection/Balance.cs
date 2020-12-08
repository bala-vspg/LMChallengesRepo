using System;


namespace LMIChallengesCollection
{
    //This class contains the functionality for withdrawal process
    //Assumption #1: All transactions are happening on SAME DAY (for the sake of simplicity)
    //unless explicitely modified.
    //Assumption #2: We can withdraw only thrice a day
    public class Balance
    {
        private double m_balance { get; set; }
        private const double initialBalance = 1000;
        public int transactionOccurance = 0;
        
        
        public Balance()
        {
            //setting initial balance
            m_balance = initialBalance;
            
        }

        //This methods handles the withdrawal.
        //amount: this parameter is the amount that the user intends to withdraw
     
        public void Withdraw(double amount)
        {

            if (amount <= 0)
            {
                throw new ArgumentException("The withdrawl amount should be greater than or equal to $1");
            }
            if(!(checkWithdrawalRules()))
            {
                throw new ArgumentException("Sorry!! you have reached daily withdrawal frequency");
            }
            if (m_balance >= amount)
            {
                m_balance -= amount;
                transactionOccurance += 1;
            }
            else
            {
                throw new ArgumentException($"{amount},Withdrawal exceeds balance!");
            }
        }
        
        //This method checks business rules.
        //Currently for the sake of simplicity we are only checking per day transaction frequency.
        // as we are assuming that all trasactions are happening on same day
        //This can be used when additional rules are made like - reaching daily withdrawal amount limit etc.
        public bool checkWithdrawalRules()
        {
            return (transactionOccurance < 3) ? true : false;

        }
        public double getBalance()
        {
            return m_balance;
        }
     

    }
}
