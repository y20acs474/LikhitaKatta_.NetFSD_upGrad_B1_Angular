let user = {
  name:"sai",
  age:24,
  city:"Hyderabad"
};

function showUser(){
  displayUserInfo(user);
}

function displayUserInfo(userObj){
  document.getElementById("u1").innerText="Name: "+userObj.name;
  document.getElementById("u2").innerText="Age: "+userObj.age;
  document.getElementById("u3").innerText="City: "+userObj.city;
}