let student = {
  name:"Likhita",
  rollNo:474,
  marks:80
};

function updateStudentProfile(studentObj){
  let text =
  "Name: "+studentObj.name+
  "<br>Roll: "+studentObj.rollNo+
  "<br>Marks: "+studentObj.marks;

  document.getElementById("profile").innerHTML = text;
}

function updateMarks(newMarks){
  student.marks = newMarks;
  updateStudentProfile(student);
}

updateStudentProfile(student);