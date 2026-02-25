class Vehicle {
  constructor(brand, speed) {
    this.brand = brand;
    this.speed = speed;
  }

  start() {
    console.log("Vehicle started");
  }
}

class Car extends Vehicle {
  constructor(brand, speed, fuelType) {
    super(brand, speed);
    this.fuelType = fuelType;
  }

  showDetails() {
    console.log(this.brand, this.speed, this.fuelType);
  }
}

const car = new Car("Toyota", 120, "Petrol");
car.start();
car.showDetails();