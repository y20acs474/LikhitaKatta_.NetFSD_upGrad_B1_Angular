class Student {
  constructor(name) {
    this.name = name;
    this.marks = [];
  }

  addMark(mark) {
    this.marks.push(mark);
  }

  getAverage() {
    return this.marks.reduce((a, b) => a + b, 0) / this.marks.length;
  }

  getGrade() {
    const avg = this.getAverage();
    if (avg >= 90) return "A";
    if (avg >= 75) return "B";
    if (avg >= 50) return "C";
    return "Fail";
  }
}

const s = new Student("Likhita");
s.addMark(90);
s.addMark(80);
console.log(s.getAverage());
console.log(s.getGrade());