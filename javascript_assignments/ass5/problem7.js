class Animal {
  makeSound() {
    console.log("Some sound");
  }
}

class Dog extends Animal {
  makeSound() { console.log("Bark"); }
}
class Cat extends Animal {
  makeSound() { console.log("Meow"); }
}
class Cow extends Animal {
  makeSound() { console.log("Moo"); }
}

[ new Dog(), new Cat(), new Cow() ].forEach(a => a.makeSound());