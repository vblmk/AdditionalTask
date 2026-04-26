// See https://aka.ms/new-console-template for more information

using AdditionalTask;

Console.WriteLine("Hello, World!");

Weapon weapon1 = new Weapon("sword", 10, ItemRarity.Rare, 25);
Weapon weapon2 = new Weapon("axe", 17.5, ItemRarity.Epic, 50);
Weapon weapon3 = new Weapon("akademka", 0, ItemRarity.Legendary, 100500);

Armor armor1 = new Armor("iron armor", 25, ItemRarity.Common, 7);
Armor armor2 = new Armor("diamond armor", 15, ItemRarity.Epic, 15);
Armor armor3 = new Armor("\"Created with Gemini\" statement", 0, ItemRarity.Legendary, 100500);

Potion potion1 = new Potion("Heal potion", 0.5, ItemRarity.Common, 25);
Potion potion2 = new Potion("Poison potion", 0.5, ItemRarity.Common, -25);
Potion potion3 = new Potion("Big potion", 0.5, ItemRarity.Epic, 75);

List<Item> itemsToAdd = new List<Item>{weapon1, weapon2, weapon3, armor1, armor2, armor3, potion1, potion2, potion3};
Hero hero;

while (true)
{
    Console.WriteLine("enter hero name\n>");
    var n = Console.ReadLine();
    
    Console.WriteLine("enter hero attack\n>");
    var tryA = int.TryParse(Console.ReadLine(), out int a);
    
    if (!tryA)
    {
        Console.WriteLine("invalid input");
        continue;
    }

    Console.WriteLine("enter hero defense\n>");
    var tryD = int.TryParse(Console.ReadLine(), out int d);
    
    if (!tryD)
    {
        Console.WriteLine("invalid input");
        continue;
    }
    
    Console.WriteLine("enter hero msx hp\n>");
    var tryH = int.TryParse(Console.ReadLine(), out int h);
    
    if (!tryH)
    {
        Console.WriteLine("invalid input");
        continue;
    }
    
    Console.WriteLine("enter hero weight limit\n>");
    var tryW = double.TryParse(Console.ReadLine(), out double w);
    
    if (!tryW)
    {
        Console.WriteLine("invalid input");
        continue;
    }

    if (!string.IsNullOrWhiteSpace(n))
    {    
        hero = new Hero(n, a, d, h, w);
        break;
    }
    
    Console.WriteLine("invalid input");
}

while (true)
{
    Console.WriteLine("enter option\n" +
                      "1. show inventory\n" +
                      "2. add item(-s)\n" +
                      "3. use item\n" +
                      "4. sort inventory by rarity\n" +
                      "5. show characteristics\n" +
                      "0. exit\n" +
                      ">");

    switch (Console.ReadLine())
    {
        case "1":
            Console.WriteLine($" {hero.Name}'s ----- inventory -----");
            hero.ShowInventory();
            Console.WriteLine($" --- weight: {hero.Inventory.CurrentWeight}/{hero.Inventory.WeightLimit} ---");
            break;
        
        case "2":
            Console.WriteLine("choose item to add");
            foreach (var item in itemsToAdd)
                Console.WriteLine(item + "\n");

            string c = Console.ReadLine();
            
            if (!string.IsNullOrEmpty(c))
            {
                Item itemToAdd = itemsToAdd.FirstOrDefault(item => item.Name == c);

                if (itemToAdd != null)
                {
                    hero.Inventory.Add(itemToAdd);
                }
            }
            else
            {
                Console.WriteLine("invalid input");
            }

            break;


        case "3":
            Console.WriteLine($" {hero.Name}'s ----- inventory -----");
            hero.ShowInventory();
            Console.WriteLine("choose item to use\n>");
            string? itemName = Console.ReadLine();

            if (!string.IsNullOrEmpty(itemName))
            {
                Item item = hero.Inventory.GetByName(itemName);
                if (item != null)
                {
                    item.Use(hero);
                    Console.WriteLine($"item {item.Name} used");
                    hero.ShowCharacteristics();
                }
                else
                {
                    Console.WriteLine("no such item in inventory");
                }
            }
            else
            {
                Console.WriteLine("invalid input");
            }

            break;
        
        case "4":
            Console.WriteLine($" {hero.Name}'s ----- inventory -----");
            hero.Inventory.SortByRarity();
            hero.ShowInventory();
            break;
        
        case "5":
            Console.WriteLine("----- characteristics -----");
            hero.ShowCharacteristics();
            break;
        
        case "0":
            Console.WriteLine("bye-bye!");
            return;
    }
}