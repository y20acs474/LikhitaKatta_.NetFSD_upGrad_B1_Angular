class Employee {
  constructor(name, salary) {
    this.name = name;
    this.salary = salary;
  }

  getDetails() {
    console.log(this.name, this.salary);
  }
}

class Manager extends Employee {
  constructor(name, salary, bonus) {
    super(name, salary);
    this.bonus = bonus;
  }

  getTotalSalary() {
    return this.salary + this.bonus;
  }
}

class Director extends Manager {
  constructor(name, salary, bonus, stockOptions) {
    super(name, salary, bonus);
    this.stockOptions = stockOptions;
  }

  getFullCompensation() {
    return this.salary + this.bonus + this.stockOptions;
  }
}

const d = new Director("Likhita", 50000, 10000, 20000);
console.log(d.getFullCompensation());