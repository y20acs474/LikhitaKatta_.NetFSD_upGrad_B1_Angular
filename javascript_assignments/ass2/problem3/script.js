let counter = 0;

function incrementCounter(step){
  counter += step;
  document.getElementById("count").innerText = counter;
}

function resetCounter(){
  counter = 0;
  document.getElementById("count").innerText = counter;
}