using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{

    [SerializeField] private GameObject mainInventory;
    [SerializeField] private GameObject craftStation;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        InventoryUi();
    }


    void InventoryUi()
    {
        if (!craftStation.gameObject.activeSelf) 
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                mainInventory.gameObject.SetActive(!mainInventory.gameObject.activeSelf);
            }
        }
    }
}
