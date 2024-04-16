using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInventory : MonoBehaviour
{
   public int NumberOfCollectables {get; private set;}

   public UnityEvent<PlayerInventory> OnItemCollected;

   public void ItemCollected(){
    NumberOfCollectables++;
    OnItemCollected.Invoke(this);

   }
}
