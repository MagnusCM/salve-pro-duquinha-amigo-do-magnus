using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class CraftingStation : MonoBehaviour
{

    [SerializeField] private GameObject craftStation;
    [SerializeField] private GameObject mainInventoryGroup;
    [SerializeField] private RectTransform mainInventory;
    [SerializeField] private float interactionDistance = 3.0f;

    private bool isCraftingStationOpen = false;
    private Transform playerTransform;
    private Player player;

    // Start is called before the first frame update
    void Start()
    {
        mainInventory = (RectTransform)mainInventoryGroup.transform.GetChild(1);
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>(); 
    }

    // Update is called once per frame
    void Update()
    {

        float distance = Vector3.Distance(playerTransform.position, transform.position);

        if (distance < interactionDistance)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (isCraftingStationOpen)
                {
                    CloseCraftStation();
                }
                else
                {
                    OpenCraftStation();
                }
            }
        }
    }

        private void OpenCraftStation()
        {
            craftStation.SetActive(true);
            mainInventoryGroup.SetActive(true);
            mainInventory.anchoredPosition = new Vector3(-352, 44, 0);
            isCraftingStationOpen = true;
            player.speed = 0f;
        }

        private void CloseCraftStation()
        {
            craftStation.SetActive(false);
            mainInventory.anchoredPosition = new Vector3(0, 44, 0);
            mainInventoryGroup.SetActive(false);
            isCraftingStationOpen = false;
            player.speed = 10f;
        }
}
