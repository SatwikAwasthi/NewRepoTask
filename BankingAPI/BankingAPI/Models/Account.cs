using System;
using static BankingAPI.Models.Account;

namespace BankingAPI.Models
{
	public class Account
	{
        #region Properties
        public int AccNum { get; set; }
		public string AccName { get; set; }
		public string AccType { get; set; }
		public double AccBalance { get; set; }
		public bool AccIsActive { get; set; }
		#endregion Properties

		private static List<Account> lstAccounts = new List<Account>()
		{
			new Account(){AccNum = 101,AccName = "Ramesh",AccType = "Savings",AccBalance = 38000,AccIsActive = true},
			new Account(){AccNum = 102,AccName = "Adam",AccType = "Savings",AccBalance = 5600,AccIsActive = false},
			new Account(){AccNum = 103,AccName = "Aakash",AccType = "Current",AccBalance = 108000,AccIsActive = false},
			new Account(){AccNum = 104,AccName = "Supriya",AccType = "PF",AccBalance = 567890,AccIsActive = true},
			new Account(){AccNum = 105,AccName = "Rohit",AccType ="Current",AccBalance = 24770,AccIsActive = true}
		};

        #region Get methods
        public List<Account> DisplayAllAccounts()
		{
			if (lstAccounts.Any())
				return lstAccounts;
			else
				throw new Exception("Sorry,No Account Available");
		}

        public List<Account> DisplayAllAccountsByType(string accounttype)
        {
			List<Account> lstac = new List<Account>();
			lstac = lstAccounts.Where(x => x.AccType == accounttype).ToList();

            if (lstac.Any())
				return lstac;
			else
				throw new Exception("Sorry,No Account Available for given Account type");
        }

        public List<Account> DisplayAllAccountsByStatus(bool status)
        {
            var lstac = lstAccounts.Where(x => x.AccIsActive == status).ToList();
			if (lstac.Any())
				return lstac;
			else
				throw new Exception("Sorry,No Account Available for given status");
        }
        public Account DisplayAcountByID(int id)
        {
			var lstac = lstAccounts.Where(x => x.AccNum == id).Select(x => x).FirstOrDefault();
			if (lstac != null)
				return lstac;
			else
				throw new Exception("Sorry,No Account Available for given Account number");
        }
        #endregion Get methods

        public string AddNewAccount(Account acc)
        {
			if (!lstAccounts.Any(x => x.AccNum == acc.AccNum))
			{
				lstAccounts.Add(acc);
				return "Account Added successfully";
			}
			else
				throw new Exception("Sorry, Account number already exists.");
        }

        public string EditAccountDetail(Account acc)
        {
            var acnt = lstAccounts.Where(x => x.AccNum == acc.AccNum).Select(x => x).FirstOrDefault();
			if (acnt != null)
			{
				acnt.AccName = acc.AccName;
				acnt.AccType = acc.AccType;
				acnt.AccBalance = acc.AccBalance;
				acnt.AccIsActive = acc.AccIsActive;
				return "Account Edited successfully";
			}
			else
				throw new Exception("Sorry, Account number does not exists.");
        }

        public string DeleteAccount(int accnmbr)
        {
            var acnt = lstAccounts.Where(x => x.AccNum == accnmbr).Select(x => x).FirstOrDefault();
			if (acnt != null)
			{
				lstAccounts.Remove(acnt);
				return "Account Deleted successfully";
			}
			else
				throw new Exception("Sorry, Account number does not exists.");
        }
    }
}

