using System;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    public enum ItemType
    {
        Weapon,
        Armor,
        Potion,
        Consumable,
        Misc
    }

    [Serializable]
    public struct ItemStats
    {
        public float damage;
        public float defense;
        public float weight;

        public ItemStats(float damage, float defense, float weight)
        {
            this.damage = damage;
            this.defense = defense;
            this.weight = weight;
        }
    }

    [Serializable]
    public class Item
    {
        public string itemName;
        public ItemType itemType;
        public ItemStats stats;
        public int price;
        public bool isEquipped;

        public Item(string name, ItemType type, ItemStats stats, int price)
        {
            itemName = name;
            itemType = type;
            this.stats = stats;
            this.price = price;
            isEquipped = false;
        }

        public string Describe()
        {
            return itemName + " (" + itemType + ")\n" +
                   "Damage: " + stats.damage +
                   ", Defense: " + stats.defense +
                   ", Weight: " + stats.weight +
                   ", Price: " + price;
        }
    }

    public string[] itemNames;
    public ItemType[] itemTypes;
    public ItemStats[] itemStats;
    public int[] itemPrices;
    public List<Item> items = new List<Item>();

    public ItemType filterType = ItemType.Weapon;

    private void Start()
    {
        CreateItemsFromConfig();
        foreach (Item item in items)
        {
            Debug.Log(item.Describe());
        }
    }

    private void CreateItemsFromConfig()
    {
        items.Clear();

        int count = Mathf.Min(itemNames.Length, itemTypes.Length, itemStats.Length, itemPrices.Length);

        for (int i = 0; i < count; i++)
        {
            Item newItem = new Item(itemNames[i], itemTypes[i], itemStats[i], itemPrices[i]);
            items.Add(newItem);
        }
    }

    public List<Item> GetItemsByType(ItemType type)
    {
        List<Item> result = new List<Item>();

        foreach (Item item in items)
        {
            if (item.itemType == type)
            {
                result.Add(item);
            }
        }

        return result;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Items van type: " + filterType);
            List<Item> filtered = GetItemsByType(filterType);

            foreach (Item item in filtered)
            {
                Debug.Log(item.Describe());
            }
        }
    }
}