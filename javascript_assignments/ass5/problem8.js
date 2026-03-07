class Payment {
  pay(amount) {
    console.log("Paying", amount);
  }
}

class CreditCardPayment extends Payment {
  pay(amount) {
    console.log("Paid via Credit Card:", amount);
  }
}

class UPIPayment extends Payment {
  pay(amount) {
    console.log("Paid via UPI:", amount);
  }
}

class CashPayment extends Payment {
  pay(amount) {
    console.log("Paid via Cash:", amount);
  }
}


const payments = [
  new CreditCardPayment(),
  new UPIPayment(),
  new CashPayment()
];

payments.forEach(p => p.pay(1000));