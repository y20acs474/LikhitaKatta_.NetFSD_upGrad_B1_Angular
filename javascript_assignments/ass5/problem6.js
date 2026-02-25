class Shape {
  calculateArea() {}
}

class Circle extends Shape {
  constructor(r) {
    super();
    this.r = r;
  }
  calculateArea() {
    console.log(Math.PI * this.r * this.r);
  }
}

class Rectangle extends Shape {
  constructor(w, h) {
    super();
    this.w = w;
    this.h = h;
  }
  calculateArea() {
    console.log(this.w * this.h);
  }
}

const shapes = [new Circle(2), new Rectangle(3, 4)];
shapes.forEach(s => s.calculateArea());