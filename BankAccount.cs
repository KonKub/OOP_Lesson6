using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lesson6
{
    enum AccountType { Current, Savings }

    class BankAccount
    {
        static private int NumberGenerator = 0;

        private int _number;
        private decimal _balance;
        private AccountType _type;

        public BankAccount() : this(0, AccountType.Current)
        {
        }

        public BankAccount(decimal ABalance) : this(ABalance, AccountType.Current)
        {
        }

        public BankAccount(decimal ABalance, AccountType AType)
        {
            NumberGenerator++;
            _number = NumberGenerator;
            _balance = ABalance;
            _type = AType;
        }

        public int Number
        {
            get
            {
                return _number;
            }
            set
            {
                _number = value;
            }
        }
        public decimal Balance
        {
            get
            {
                return _balance;
            }
            set
            {
                _balance = value;
            }
        }
        public AccountType Type
        {
            get
            {
                return _type;
            }
            set
            {
                _type = value;
            }
        }

        public override string ToString()
        {
            string AccType = "Неизвестен";

            if (_type == AccountType.Current) AccType = "Текущий";
            if (_type == AccountType.Savings) AccType = "Сберегательный";
            return $"Счёт: {_number}. Тип счёта: {AccType}. Текущий баланс: {_balance}.";
        }

        public static bool operator ==(BankAccount account1, BankAccount account2)
        {
            return account1.Equals(account2);
        }

        public static bool operator !=(BankAccount account1, BankAccount account2)
        {
            return !account1.Equals(account2);
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (GetType() != obj.GetType())
                return false;

            BankAccount account = (BankAccount)obj;

            if (_number != account._number)
                return false;
            if (_type != account._type)
                return false;

            return _balance == account._balance;
        }

        public override int GetHashCode()
        {
            return _number ^ (int)_balance ^ (int)_type;
        }

        public void PutInAccount(decimal ASum)
        {
            _balance += ASum;
            Console.WriteLine($"Текущий баланс: {_balance}.");
        }

        public bool WithdrawFromAccount(decimal ASum)
        {
            if (_balance >= ASum)
            {
                _balance = _balance - ASum;
                Console.WriteLine($"Со счета {_number} снято {ASum}. Текущий баланс: {_balance}.");
                return true;
            }
            else
            {
                Console.WriteLine($"Не хватает средств на счете {_number}. Текущий баланс: {_balance}.");
                return false;
            }
        }
        public void TransferFromAnotherAccount(BankAccount AnotherAccount, decimal ASum)
        {
            if (AnotherAccount.WithdrawFromAccount(ASum))
            {
                _balance = _balance + ASum;
                Console.WriteLine($"Пополнение счета {_number} на сумму {ASum}. Текущий баланс: {_balance}.");
            }
            else
            {
                Console.WriteLine($"Не удалось пополнить счет {_number}.");
            }
            Console.WriteLine("");
        }
    }
}
