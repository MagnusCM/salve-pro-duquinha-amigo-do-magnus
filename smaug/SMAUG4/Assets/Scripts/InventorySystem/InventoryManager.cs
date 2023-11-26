using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public int maxStackedItem = 5;
    public InventoryManager instance;

    public GameObject inventoryItemPrefab;

    public InventorySlot[] inventorySlots;

    private int selectedSlot = -1;

    public void Awake()
    {
        instance = this;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ChangeSelectedSlots(0);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ChangeSelectedSlots(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ChangeSelectedSlots(2);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            ChangeSelectedSlots(3);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            ChangeSelectedSlots(4);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            ChangeSelectedSlots(5);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            ChangeSelectedSlots(6);
        }

    }

    void ChangeSelectedSlots(int newValue)
    {
        if (selectedSlot >= 0)
        {
            inventorySlots[selectedSlot].Deselect();
        }

        inventorySlots[newValue].Select();
        selectedSlot = newValue;

    }

    public bool AddItem(Item item)
    {
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            InventorySlot slot = inventorySlots[i];
            InvetoryItem itemInSlot = slot.GetComponentInChildren<InvetoryItem>();

            if (itemInSlot != null && itemInSlot.item == item && itemInSlot.count < maxStackedItem && itemInSlot.item.stackable == true)
            {
                itemInSlot.count++;
                itemInSlot.RefreshCount();
                return true;
            }
        }

        for (int i = 0; i < inventorySlots.Length; i++)
        {
            InventorySlot slot = inventorySlots[i];
            InvetoryItem itemInSlot = slot.GetComponentInChildren<InvetoryItem>();

            if (itemInSlot == null)
            {
                SpawnItem(item, slot);
                return true;
            }
        }
        return false;
    }

    public void SpawnItem(Item item, InventorySlot slot)
    {
        GameObject newItem = Instantiate(inventoryItemPrefab, slot.transform);
        InvetoryItem inventoryItem = newItem.GetComponent<InvetoryItem>();
        inventoryItem.InitializeItem(item);
    }

    // Saber qual item estamos selecioando para utilizar
    public Item GetSelectedItem(bool use)
    {
        InventorySlot slot = inventorySlots[selectedSlot];
        InvetoryItem itemInSlot = slot.GetComponentInChildren<InvetoryItem>();

        if (itemInSlot != null)
        {
            Item item = itemInSlot.item;

            if (use == true)
            {
                itemInSlot.count--;
            }

            if (itemInSlot.count <= 0)
            {
                Destroy(itemInSlot.gameObject);
            }
            else
            {
                itemInSlot.RefreshCount();
            }

            return item;
        }
        else
        {
            return null;
        }

    }

    //TODO USAR ITEM
    /*public void UseSelectedItem()
    {
        Item receivedItem = inventoryManager.GetSelectedItem(true);

        if (receivedItem != null)
        {
            // TODO lógica de utilizar item
            if (Input.GetKeyDown("KeyCode.U"))
                print("");
        }
    }*/
}

