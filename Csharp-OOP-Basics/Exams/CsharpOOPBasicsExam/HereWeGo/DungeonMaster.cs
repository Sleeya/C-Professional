using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class DungeonMaster
{
    private List<Character> characters;
    private List<Item> items;
    private int lastSurvivorRounds;

    public DungeonMaster()
    {
        this.characters = new List<Character>();
        this.items = new List<Item>();
    }
    public string JoinParty(string[] args)
    {
        string faction = args[0];
        string characterType = args[1];
        string name = args[2];
        var character = CharacterFactory.CreateCharacter(faction, characterType, name);
        characters.Add(character);
        return $"{name} joined the party!";
    }

    public string AddItemToPool(string[] args)
    {
        string itemName = args[0];
        var currentItem = ItemFactory.CreateItem(itemName);
        items.Add(currentItem);

        return $"{itemName} added to pool.";
    }

    public string PickUpItem(string[] args)
    {
        string characterName = args[0];

        ValidateCharName(characterName);
        var currentChar = characters.FirstOrDefault(x => x.Name == characterName);
        if (items.Count == 0)
        {
            throw new InvalidOperationException("No items left in pool!");
        }
        var currentItem = items.Last();

        currentChar.ReceiveItem(currentItem);
        items.RemoveAt(items.Count - 1);
        return $"{characterName} picked up {currentItem.GetType().Name}!";
    }

    public string UseItem(string[] args)
    {
        string characterName = args[0];
        string itemName = args[1];

        ValidateCharName(characterName);
        var currentChar = characters.FirstOrDefault(x => x.Name == characterName);
        var item = currentChar.Bag.GetItem(itemName);
        currentChar.UseItem(item);

        return $"{characterName} used {itemName}.";
    }

    public string UseItemOn(string[] args)
    {
        string giverName = args[0];
        string receiverName = args[1];
        string itemName = args[2];

        ValidateCharName(giverName);
        var giverChar = characters.FirstOrDefault(x => x.Name == giverName);
        ValidateCharName(receiverName);
        var recieverChar = characters.FirstOrDefault(x => x.Name == receiverName);
        var item = giverChar.Bag.GetItem(itemName);

        giverChar.UseItemOn(item, recieverChar);

        return $"{giverName} used {itemName} on {receiverName}.";
    }

    public string GiveCharacterItem(string[] args)
    {
        string giverName = args[0];
        string receiverName = args[1];
        string itemName = args[2];

        ValidateCharName(giverName);
        var giverChar = characters.FirstOrDefault(x => x.Name == giverName);
        ValidateCharName(receiverName);
        var recieverChar = characters.FirstOrDefault(x => x.Name == receiverName);
        var item = giverChar.Bag.GetItem(itemName);

        giverChar.GiveCharacterItem(item, recieverChar);

        return $"{giverName} gave {receiverName} {itemName}.";
    }

    public string GetStats()
    {
        StringBuilder result = new StringBuilder();

        var sortedChars = this.characters.OrderByDescending(x => x.IsAlive).ThenByDescending(x => x.Health);
        foreach (var character in sortedChars)
        {
            result.AppendLine(
                $"{character.Name} - HP: {character.Health}/{character.BaseHealth}, AP: {character.Armor}/{character.BaseArmor}," +
                $" Status: {(character.IsAlive ? "Alive" : "Dead")}");
        }

        return result.ToString().Trim();
    }

    public string Attack(string[] args)
    {
        string attackerName = args[0];
        string receiverName = args[1];

        ValidateCharName(attackerName);
        ValidateCharName(receiverName);

        var attacker = characters.FirstOrDefault(x => x.Name == attackerName);
        var receiver = characters.FirstOrDefault(x => x.Name == receiverName);

        if (attacker.GetType().Name != "Warrior")
        {
            throw new ArgumentException($"{attackerName} cannot attack!");
        }

        ((IAttackable)attacker).Attack(receiver);

        StringBuilder builder = new StringBuilder();
        builder.AppendLine(
            $"{attackerName} attacks {receiverName} for {attacker.AbilityPoints} hit points! {receiverName} has {receiver.Health}/" +
            $"{receiver.BaseHealth} HP and {receiver.Armor}/{receiver.BaseArmor} AP left!");
        if (!receiver.IsAlive)
        {
            builder.AppendLine($"{receiverName} is dead!");
        }

        return builder.ToString().Trim();
    }

    public string Heal(string[] args)
    {
        string healerName = args[0];
        string healingReceiverName = args[1];

        ValidateCharName(healerName);
        ValidateCharName(healingReceiverName);

        var healer = characters.FirstOrDefault(x => x.Name == healerName);
        var healingReceiver = characters.FirstOrDefault(x => x.Name == healingReceiverName);

        if (healer.GetType().Name != "Cleric")
        {
            throw new ArgumentException($"{healerName} cannot heal!");
        }

        ((IHealable)healer).Heal(healingReceiver);

        StringBuilder builder = new StringBuilder();
        builder.AppendLine($"{healer.Name} heals {healingReceiver.Name} for {healer.AbilityPoints}!" +
                           $" {healingReceiver.Name} has {healingReceiver.Health} health now!");

        return builder.ToString().Trim();

    }

    public string EndTurn(string[] args)
    {
        var aliveCharacters = characters.Where(c => c.IsAlive).ToArray();
        StringBuilder builder = new StringBuilder();

        foreach (var character in aliveCharacters)
        {
            double healthBeforeRest = character.Health;
            character.Rest();
            builder.AppendLine($"{character.Name} rests ({healthBeforeRest} => {character.Health})");
        }

        if (aliveCharacters.Length < 2)
        {
            lastSurvivorRounds++;
        }

        return builder.ToString().Trim();
    }

    public bool IsGameOver()
    {
        if (characters.Select(x => x.IsAlive).Count() < 2 && lastSurvivorRounds > 1)
        {
            return true;
        }


        return false;
    }

    private void ValidateCharName(string name)
    {
        if (!characters.Any(x => x.Name == name))
        {
            throw new ArgumentException($"Character {name} not found!");
        }
    }
}
