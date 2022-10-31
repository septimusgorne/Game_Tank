using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [System.Serializable]
    public class Item
    {
        public int id;
        public string name;
        public Sprite Image;
    }

    public List<Item> Items;
}
