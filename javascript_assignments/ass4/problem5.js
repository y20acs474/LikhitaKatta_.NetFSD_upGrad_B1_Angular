let numbers = [10, 20, 30, 10, 40, 20, 50, 60, 60];


let unique = [...new Set(numbers)];
console.log("Unique:", unique);


let sorted = [...unique].sort((a, b) => b - a);
console.log("Second Largest:", sorted[1]);


let freq = numbers.reduce((acc, n) => {
  acc[n] = (acc[n] || 0) + 1;
  return acc;
}, {});
console.log("Frequency:", freq);


let firstUnique = numbers.find(n => freq[n] === 1);
console.log("First Non-Repeating:", firstUnique);


let rotated = numbers.slice(2).concat(numbers.slice(0, 2));
console.log("Rotated:", rotated);


let nested = [1, 2, [3, 4, [5]]];
let flat = nested.flat(Infinity);
console.log("Flattened:", flat);


let arr = [1, 2, 3, 5, 6];
let missing = arr.find((n, i) => n !== i + 1);
console.log("Missing:", missing - 1);