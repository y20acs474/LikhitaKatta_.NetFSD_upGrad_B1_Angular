class BankAccount {
  constructor(accountHolder, balance) {
    this.accountHolder = accountHolder;
    this.balance = balance;
  }

  deposit(amount) {
    this.balance += amount;
  }

  withdraw(amount) {
    if (amount > this.balance) {
      console.log("Insufficient balance");
    } else {
      this.balance -= amount;
    }
  }

  checkBalance() {
    console.log(`Balance: ${this.balance}`);
  }
}

const acc = new BankAccount("Likhita", 1000);
acc.deposit(500);
acc.withdraw(200);
acc.checkBalance();