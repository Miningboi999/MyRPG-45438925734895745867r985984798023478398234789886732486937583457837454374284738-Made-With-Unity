using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    #region  Singleton
    public static EquipmentManager instance;


    [SerializeField] GameObject helm;
    [SerializeField] GameObject pantLT;
    [SerializeField] GameObject pantRT;
    [SerializeField] GameObject pantL;
    [SerializeField] GameObject pantR;
    [SerializeField] GameObject shirtLT;
    [SerializeField] GameObject shirtRT;
    [SerializeField] GameObject shirtL;
    [SerializeField] GameObject shirtR;
    [SerializeField] GameObject shirtC;
    [SerializeField] GameObject sword;
    [SerializeField] GameObject animator;

    public bool holdsword = false;



    void Awake()
    {
        instance = this;
    }
    #endregion

    Equipment[] currentEquipment;

    Inventory inventory;

    public delegate void OnEquipmentChanged(Equipment newItem, Equipment oldItem);
    public OnEquipmentChanged onEquipmentChanged;

    void Start()
    {
        inventory = Inventory.instance;

        int numSlots = System.Enum.GetNames(typeof(EquipmentSlot)).Length;
        currentEquipment = new Equipment[numSlots];
    }



    public void Equip(Equipment newItem)
    {
        int slotIndex = (int)newItem.equipSlot;
        Equipment oldItem = null;
        if (currentEquipment[slotIndex] != null)
        {
            oldItem = currentEquipment[slotIndex];
            inventory.Add(oldItem);
        }

        if (onEquipmentChanged != null)
        {
            onEquipmentChanged.Invoke(newItem, oldItem);
        }
        currentEquipment[slotIndex] = newItem;
    }

    public void Unequip(int slotIndex)
    {
        if (currentEquipment[slotIndex] != null)
        {
            Equipment oldItem = currentEquipment[slotIndex];
            inventory.Add(oldItem);

            currentEquipment[slotIndex] = null;

            if (onEquipmentChanged != null)
            {
                onEquipmentChanged.Invoke(null, oldItem);
            }
        }
    }


    public void UnequipAll()
    {
        for (int i = 0; i < currentEquipment.Length; i++)
        {
            Unequip(i);
        }
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            UnequipAll();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            Unequip(3);
        }

        if (currentEquipment[0] != null)
        {
            helm.SetActive(true);
        }
        if (currentEquipment[0] == null)
            helm.SetActive(false);

        if (currentEquipment[2] != null)
        {
            pantLT.SetActive(true);
            pantRT.SetActive(true);
            pantL.SetActive(true);
            pantR.SetActive(true);
        }
        if (currentEquipment[2] == null)
        {
            pantLT.SetActive(false);
            pantRT.SetActive(false);
            pantL.SetActive(false);
            pantR.SetActive(false);
        }
        if (currentEquipment[1] != null)
        {
            shirtLT.SetActive(true);
            shirtRT.SetActive(true);
            shirtL.SetActive(true);
            shirtR.SetActive(true);
            shirtC.SetActive(true);
        }
        if (currentEquipment[1] == null)
        {
            shirtLT.SetActive(false);
            shirtRT.SetActive(false);
            shirtL.SetActive(false);
            shirtR.SetActive(false);
            shirtC.SetActive(false);
        }

        if (currentEquipment[3] != null)
        {
            sword.SetActive(true);
            animator.SetActive(true);
        }
        if (currentEquipment[3] == null)
        {
            sword.SetActive(false);
            animator.SetActive(false);
        }



    }
}
