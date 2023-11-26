using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loot : MonoBehaviour
{
    public InventoryManager inventoryManager;
    public Item item;

    [SerializeField] private GameObject buttonPress;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            buttonPress.gameObject.SetActive(true);

            if (Input.GetKey(KeyCode.F))
            {
                CollectItem();
            }

        }
    }

    private void OnTriggerExit(Collider other)
    {
        buttonPress.gameObject.SetActive(false);
    }

    private void CollectItem()
    {
        bool canAdd = inventoryManager.instance.AddItem(item);

        if (canAdd == true)
        {
            Destroy(gameObject);
        }

        if (item.name == "pickaxe")
        {
            QuestManager.questManager.AddQuestItem("Collect an item", 1);
        }
        else
        {
            return;
        }
    }


}



