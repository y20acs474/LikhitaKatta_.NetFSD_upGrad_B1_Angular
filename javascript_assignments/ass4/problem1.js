let books = [
  { id: 1, title: "JavaScript Basics", price: 450, stock: 10 },
  { id: 2, title: "React Guide", price: 650, stock: 5 },
  { id: 3, title: "Node.js Mastery", price: 550, stock: 8 },
  { id: 4, title: "CSS Complete", price: 300, stock: 12 }
];


let titles = books.map(b => b.title);
console.log("Titles:", titles);


let totalValue = books.reduce((sum, b) => sum + b.price * b.stock, 0);
console.log("Total Value:", totalValue);


let costly = books.filter(b => b.price > 500);
console.log("Above 500:", costly);


let increased = books.map(b => ({ ...b, price: b.price * 1.05 }));
console.log("Price +5%:", increased);


let sorted = [...books].sort((a, b) => a.price - b.price);
console.log("Sorted:", sorted);


let removed = books.filter(b => b.id !== 2);
console.log("After Remove:", removed);


let outOfStock = books.some(b => b.stock === 0);
console.log("Out of Stock?", outOfStock);


let grouped = {
  low: books.filter(b => b.price < 500),
  high: books.filter(b => b.price >= 500)
};
console.log("Grouped:", grouped);


let discount = books.map(b =>
  b.price > 600 ? { ...b, price: b.price * 0.9 } : b
);
console.log("Discounted:", discount);


let invoice = books.map(b => b.title).join(", ");
console.log("Invoice:", invoice);