using System;

class MainClass {
  public static void Main (string[] args) {
    var badassVegan = new Character(80, "Badass vegan", 80, "celery", 8);
    

    var popeye = new Character(200, "Popeye", 200, "sailor's", 20);

    while (popeye.GetHealth() > 0 && badassVegan.GetHealth() > 0){
      badassVegan.Attack(popeye);
      popeye.Attack(badassVegan);
    }

    if(badassVegan.GetHealth() > 0) {
      Console.WriteLine("Badass vegan wins!");
    } else {
      Console.WriteLine("Popeye wins!");
    }
  }
}


class Character {
  private int health = 100;
  private int attackDamage = 0;
  private string name = "Default character";
  private int stamina = 100;
  private string hat = "fedora";

  public Character(int _health, string _name, int _stamina, string _hat, int _attackDamage) {
    health = _health;
    name = _name;
    stamina = _stamina;
    hat = _hat;
    attackDamage = _attackDamage;

    Console.WriteLine("Creating a new character called {0}, with a {1} hat.", name, hat);
  }

  public void TakeDamage(int damage) {
    Console.WriteLine("{0} just took {1} damage!", name, damage);
    health -= damage;
    Console.WriteLine("{0} now have {1} health", name, health);
  }

  public void Attack(Character opponent) {
    if (stamina > 0) {
      Console.WriteLine("{0} attacks {1}!", name, opponent.name);

      opponent.TakeDamage(attackDamage);
      stamina -= 10;
    } else {
      Console.WriteLine("{0} is way too tired to attack", name);
    }
  }

  public int GetHealth() {
    return health;
  }
}