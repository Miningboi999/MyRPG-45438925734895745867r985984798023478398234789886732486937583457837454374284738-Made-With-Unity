using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharStats
{
    // Start is called before the first frame update
    void Start()
    {
        EquipmentManager.instance.onEquipmentChanged += OnEquipmentChanged;
    }



    void OnEquipmentChanged(Equipment newItem, Equipment oldItem)
    {

    }
}
