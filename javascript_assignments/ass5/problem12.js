class Wallet {
  #balance = 0;

  addMoney(a) { this.#balance += a; }
  spendMoney(a) { this.#balance -= a; }
  getBalance() { console.log(this.#balance); }
}

const w = new Wallet();
w.addMoney(500);
w.getBalance();