using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEditor.Progress;

public class CraftManager : MonoBehaviour
{

    public List<Item> itemList;
    public string[] recipes;
    public Item[] recipeResults;
    public InventorySlot resultSlot;
    public InventoryManager inventoryManager;


    public InventorySlot inventorySlot1, inventorySlot2;
    public List<InventorySlot> inventorySlot;
    public InventorySlot[] inventorySlots;

    [HideInInspector] public string items;

    public string currentRecipeString;

    private bool isCreated;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (inventorySlot1.transform.childCount > 0 && inventorySlot2.transform.childCount > 0)
        {
            CheckForCreatedRecipes();
        }
    }

    void CheckForCreatedRecipes()
    {

        currentRecipeString = "";

        foreach (Item item in itemList)
        {
            if (item != null)
            {
                foreach (InventorySlot slot in inventorySlot)
                {
                    if (slot.transform.childCount > 0)
                    {
                        InvetoryItem itemInSlot = slot.GetComponentInChildren<InvetoryItem>();
                        items = itemInSlot.item.name;
                        currentRecipeString += items;

                        print("itemS: " + items);

                        print("Current Recipe String : " + currentRecipeString);

                    }
                }

            }
            else
            {
                currentRecipeString += "null";
            }

            CreateRecipe();

            return;
        }
    }

    void CreateRecipe()
    {
        for (int i = 0; i < recipes.Length; i++)
        {
            if (recipes[i] == currentRecipeString)
            {
                recipes[i] = recipeResults[i].name;

                if (resultSlot.transform.childCount <= 0)
                {
                    recipes[i] = currentRecipeString;
                    inventoryManager.SpawnItem(recipeResults[i], resultSlot);
                    isCreated = true;
                }
            }
        }



        if (isCreated == true)
        {
            if (resultSlot.transform.childCount <= 0)
            {
                print("destuido");

                foreach (InventorySlot slot in inventorySlot)
                {

                    //slot.transform.GetChild(0).gameObject.SetActive(false);
                    Destroy(slot.transform.GetChild(0).gameObject);

                    slot.transform.DetachChildren();

                }

            }
        }

    }
}