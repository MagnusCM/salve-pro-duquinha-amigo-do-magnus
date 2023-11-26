
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    public Image image;
    public Color selectedColor, notSelectedColor;

    public void Awake()
    {
        Deselect();
    }

    public void Select()
    {
        image.color = selectedColor;
    }

    public void Deselect()
    {
        image.color = notSelectedColor;
    }

    //Drag and Drop
    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount == 0)
        {
            InvetoryItem invetoryItem = eventData.pointerDrag.GetComponent<InvetoryItem>();
            invetoryItem.parentAfterDrag = transform;
        }

    }
}













