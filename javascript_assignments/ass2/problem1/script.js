function generateGreeting(){
  let name = document.getElementById("nameInput").value;

  let greeting = "Hello, " + name + "! Welcome to our website.";

  document.getElementById("msg").innerText = greeting;
}