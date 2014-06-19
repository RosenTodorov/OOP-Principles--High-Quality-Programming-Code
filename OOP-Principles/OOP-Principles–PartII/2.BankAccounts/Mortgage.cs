using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.BankAccounts
{
    public class Mortgage : Accounts, IDeposit
    {
        public Mortgage(Customer customer, decimal balance, decimal interestRate)
            : base(customer, balance, interestRate)
        {
            if (this.InterestRate <= 0 || this.Balance <= 0)
            {
                throw new ArgumentException("Balance and interest rate must be greater than zero.");
            }
        }

        public override decimal GetInterestAmount(int months)
        {
            if (this.Customer == Customer.Individual && months > 6)
            {
                return (this.Balance * (this.InterestRate / 100) * (months - 6));
            }
            else if (this.Customer == Customer.Individual && months <= 6)
            {
                return (this.Balance * (this.InterestRate / 100) * months);
            }
            else if (this.Customer == Customer.Company && months > 12)
            {
                return ((this.Balance * (this.InterestRate / 100 / 2) * 12) + this.Balance * (this.InterestRate / 100) * (months - 12));
            }
            else if (this.Customer == Customer.Company && months <= 12)
            {
                return (this.Balance * (this.InterestRate / 100) * months);
            }

            return 0;
        }

        public override void DepositMoney(decimal sum)
        {
            this.Balance += sum;
        }

        public override void WithdrawMoney(decimal sum)
        {
            try
            {
                throw new InvalidOperationException("Lion and mortage accounts can not withdraw money");
            }
            catch (InvalidOperationException exc)
            {
                Console.WriteLine(exc.Message);
            }
        }
    }
}
    


