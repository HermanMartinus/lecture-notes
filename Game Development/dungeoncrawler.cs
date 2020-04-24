using System;
using System.Collections.Generic;

class MainClass {
  public static void Main (string[] args) {
    Character character = InitializeCharacter();

    List<Room> rooms = new List<Room>();
    rooms.Add(InitializeRoom());
    rooms.Add(InitializeRoom());
    rooms.Add(InitializeRoom());
    rooms.Add(InitializeRoom());
    rooms.Add(InitializeRoom());

    int currentRoomIndex = 0;
    Room currentRoom = rooms[currentRoomIndex];
    bool gameOver = false;
    while (!gameOver) {
      Console.WriteLine("1: Search room\n2: Move to next room\n3: Go back to previous room");

      int selectedAction = int.Parse(Console.ReadLine());

      if (selectedAction == 1) {
        SearchRoom(currentRoom, character);
      } else if (selectedAction == 2) {
        if(currentRoomIndex == rooms.Count-1) {
          gameOver = true;
        } else {
          Console.WriteLine("You have moved to the next room");
          currentRoomIndex++;
          currentRoom = rooms[currentRoomIndex];
        }
      } else if (selectedAction == 3) {
        if(currentRoomIndex > 0) {
          Console.WriteLine("You have moved to the previous room");
          currentRoomIndex--;
          currentRoom = rooms[currentRoomIndex];
        } else {
          Console.WriteLine("You are in the first room and cannot move back");
        }
      } else {
        Console.WriteLine("That was not a valid action");
      }
    }

    Console.WriteLine("{0} has made it out alive!", character);
  }

  public static Character InitializeCharacter() {
    Character character1 = new Character("Maximus Ironthumper");
    Character character2 = new Character("Popeye");
    Character character3 = new Character("The Queen of England");
    Character character4 = new Character("Sonic");
    Character character5 = new Character("James from next door");
    List<Character> characters = new List<Character>(){character1, character2, character3, character4, character5};

    Console.WriteLine("Select a character:");

    for (int i=0; i<characters.Count; i++) {
      Console.WriteLine("{0}: {1}", i+1, characters[i].name);
    }

    int selectedCharacter = int.Parse(Console.ReadLine());

    Console.WriteLine("You have selected {0}", characters[selectedCharacter-1].name);
    return characters[selectedCharacter-1];
  }

  public static Room InitializeRoom() {
    List<Item> allItems = new List<Item>();
    allItems.Add(new Item("dagger of stabbing", 8));
    allItems.Add(new Item("biceps of breaking", 14));
    allItems.Add(new Item("fists of fury", 8));
    allItems.Add(new Item("staff of wisdom", 8));
    allItems.Add(new Item("mother's spoon", 8));
    allItems.Add(new Item("sacred flipflop", 8));
    allItems.Add(new Item("bowl of bowels", 8));
    allItems.Add(new Item("gimp mast", 8));
    allItems.Add(new Item("bag of suspicious balls", 8));
    allItems.Add(new Item("stick of truth", 8));

    Random rnd = new Random();

    int numberOfItems = rnd.Next(1,4);

    List<Item> currentRoomItems = new List<Item>();
    for (int i=0; i<numberOfItems; i++) {
      Item addedItem = allItems[rnd.Next(0, allItems.Count)];
      currentRoomItems.Add(addedItem);
    }
    Room currentRoom = new Room(currentRoomItems);
    return currentRoom;
  }

  public static void SearchRoom (Room currentRoom, Character character) {
    List<Item> itemsInRoom = currentRoom.Search();
    Console.WriteLine("Do you want to pick any of these up?\n If not (0)");
    int selectedItem = int.Parse(Console.ReadLine());
    if(selectedItem != 0) {
      character.PickupItem(itemsInRoom[selectedItem-1]);
    }
  }
}

class Character {
  public string name = "";
  List<Item> inventory = new List<Item>();

  public Character(string _name) {
    name = _name;
  }

  public void PickupItem(Item item) {
    if (inventory.Contains(item)) {
      Console.WriteLine("{0} is already in your inventory", item.name);
    } else {
      Console.WriteLine("{0} has picked up the {1}", name, item.name);
      inventory.Add(item);
    }
  }
}

class Item {
  public string name = "";
  private int damage = 0;

  public Item(string _name, int _damage) {
    name = _name;
    damage = _damage;
  }
}

class Room {
  private List<Item> items = new List<Item>();

  public Room(List<Item> _items) {
    items = _items;
  }

  public List<Item> Search() {
    Console.WriteLine("Items in room:");

    for (int i=0; i<items.Count; i++) {
      Console.WriteLine("{0}: {1}", i+1, items[i].name);
    }

    return items;
  }
}