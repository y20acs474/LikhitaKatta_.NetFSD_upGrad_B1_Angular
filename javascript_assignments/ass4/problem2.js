let students = [
  { name: "Akhil", marks: 85 },
  { name: "Priya", marks: 72 },
  { name: "Ravi", marks: 90 },
  { name: "Meena", marks: 45 },
  { name: "Karan", marks: 30 }
];


let passed = students.filter(s => s.marks >= 40);
console.log("Passed:", passed);


let distinction = students.filter(s => s.marks >= 85);
console.log("Distinction:", distinction);


let avg = students.reduce((sum, s) => sum + s.marks, 0) / students.length;
console.log("Average:", avg);


let topper = students.reduce((max, s) =>
  s.marks > max.marks ? s : max
);
console.log("Topper:", topper);


let failedCount = students.filter(s => s.marks < 40).length;
console.log("Failed:", failedCount);


let graded = students.map(s => ({
  name: s.name,
  grade:
    s.marks >= 85 ? "A" :
    s.marks >= 60 ? "B" :
    s.marks >= 40 ? "C" : "Fail"
}));
console.log("Grades:", graded);


let ranked = [...students]
  .sort((a, b) => b.marks - a.marks)
  .map((s, i) => ({ ...s, rank: i + 1 }));
console.log("Ranked:", ranked);


let removeLowest = [...students].sort((a, b) => a.marks - b.marks).slice(1);
console.log("Removed Lowest:", removeLowest);


let leaderboard = [...students].sort((a, b) => b.marks - a.marks);
console.log("Leaderboard:", leaderboard);