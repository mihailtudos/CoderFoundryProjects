using CSharpMortgageCalculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSharpMortgageCalculator.Helpers
{
	public class LoanHelper
	{
		public Loan GetPayment(Loan loan)
		{
			loan.Payment = CalcPayment(loan.Amount, loan.Rate, loan.Term);
			//create a loop 1 to therm 
			//calculate payment schedule
			var balance = loan.Amount;
			var totalInterest = 0.0m;
			var monthlyInterest = 0.0m;
			var monthlyPrincipal = 0.0m;
			var monthlyRate = CalcMonthlyRate(loan.Rate);

			for (int month = 1; month <= loan.Term; month++)
			{
				monthlyInterest = CalculateMonthlyInterest(balance, monthlyRate);
				totalInterest += monthlyInterest;
				monthlyPrincipal = loan.Payment - monthlyInterest;
				balance -= monthlyPrincipal;

				LoanPayment loanPayment = new();
				loanPayment.Month = month;
				loanPayment.Payment = loan.Payment;
				loanPayment.MonthlyPrincipal = monthlyPrincipal;
				loanPayment.MonthlyInterest = monthlyInterest;
				loanPayment.TotalInterest = totalInterest;
				loanPayment.Balance = balance;

				//push payments into the loan 
				loan.Payments.Add(loanPayment);
			}

			loan.TotalInterest = totalInterest;
			loan.TotalCost = loan.Amount + totalInterest;

			return loan;
		}

		private decimal CalcPayment(decimal amount, decimal rate, int term)
		{
			decimal payment = 0.0m;
			var rateD = Convert.ToDouble(CalcMonthlyRate(rate));
			var amountD = Convert.ToDouble(amount);

			var paymentD = (amountD * rateD) / (1 - Math.Pow(1 + rateD, -term));


			return Convert.ToDecimal(paymentD);
		}

		private decimal CalcMonthlyRate(decimal rate)
		{
			return rate / 1200;
		}

		private decimal CalculateMonthlyInterest(decimal balance, decimal monthlyRate)
		{
			return balance * monthlyRate;
		}
	}
}
