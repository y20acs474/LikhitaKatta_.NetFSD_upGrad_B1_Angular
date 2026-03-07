let marks = 72;
let grade;

if(marks >= 75){
  grade = "A";
}
else if(marks >= 60){
  grade = "B";
}
else if(marks >= 40){
  grade = "C";
}
else{
  grade = "Fail";
}

console.log("Grade:", grade);