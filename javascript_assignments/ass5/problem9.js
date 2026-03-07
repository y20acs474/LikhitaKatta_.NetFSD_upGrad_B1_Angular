class Product {
  constructor({ name, price, category = "General" }) {
    this.name = name;
    this.price = price;
    this.category = category;
  }

  show = () => console.log(`${this.name} - ${this.price} - ${this.category}`);
}

const p = new Product({ name: "Phone", price: 20000 });
p.show();