let cart = [
  { id: 1, product: "Laptop", price: 60000, qty: 1 },
  { id: 2, product: "Headphones", price: 2000, qty: 2 },
  { id: 3, product: "Mouse", price: 800, qty: 1 }
];


let total = cart.reduce((sum, p) => sum + p.price * p.qty, 0);
console.log("Total:", total);


let updatedQty = cart.map(p =>
  p.id === 2 ? { ...p, qty: p.qty + 1 } : p
);
console.log("Qty Updated:", updatedQty);


let removed = cart.filter(p => p.id !== 3);
console.log("Removed:", removed);


let discounted = cart.map(p =>
  p.price > 10000 ? { ...p, price: p.price * 0.9 } : p
);
console.log("Discounted:", discounted);


let sorted = [...cart].sort(
  (a, b) => a.price * a.qty - b.price * b.qty
);
console.log("Sorted:", sorted);


let costly = cart.some(p => p.price > 50000);
console.log("Costly item?", costly);


let allInStock = cart.every(p => p.qty > 0);
console.log("All in stock?", allInStock);


let invoice = cart
  .map(p => `${p.product} x${p.qty} = ₹${p.price * p.qty}`)
  .join("\n");
console.log("Invoice:\n" + invoice);


let expensive = cart.reduce((max, p) =>
  p.price > max.price ? p : max
);
console.log("Most Expensive:", expensive);


let gst = total * 0.18;
console.log("GST:", gst);