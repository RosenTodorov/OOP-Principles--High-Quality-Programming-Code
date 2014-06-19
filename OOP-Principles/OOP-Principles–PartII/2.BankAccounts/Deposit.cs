using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.BankAccounts
{
    public class Deposit : Accounts, IWithdrawMoney, IDeposit
    {
        public Deposit(Customer customer, decimal balance, decimal interestRate)
            : base(customer, balance, interestRate)
        {
            if (this.InterestRate <= 0 || this.Balance <= 0)
            {
                throw new ArgumentException("Balance and interest rate must be greater than zero.");
            }
        }

        public override decimal GetInterestAmount(int months)
        {
            if (this.Balance > 0 && this.Balance <= 1000)
            {
                return 0;
            }
            else
            {
                return (this.Balance * (this.InterestRate / 100) * months);
            }
        }

        public override void WithdrawMoney(decimal sum)
        {
            try
            {
                if (this.Balance >= sum)
                {
                    this.Balance -= sum;
                }
                else
                {
                    throw new ArgumentException("Insuficient funds.");
                }
            }
            catch (ArgumentException exc)
            {
                Console.WriteLine(exc.Message);
            }
        }

        public override void DepositMoney(decimal sum)
        { 
            this.Balance += sum;
        }
    }
}


