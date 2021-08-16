using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyExploration.Inventories;
public interface IConsumable 
{
    bool Consume(InventoryItem item);
}
