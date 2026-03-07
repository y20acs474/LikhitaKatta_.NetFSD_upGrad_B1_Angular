class User {
  constructor() {
    this._password = "";
  }

  set password(p) {
    if (p.length < 6) console.log("Password too short");
    else this._password = p;
  }

  get password() {
    return this._password;
  }
}

const u = new User();
u.password = "abcdef";
console.log(u.password);