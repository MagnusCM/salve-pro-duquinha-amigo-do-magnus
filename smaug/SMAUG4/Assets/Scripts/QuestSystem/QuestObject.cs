using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestObject : MonoBehaviour
{
    private bool  inTrigger = false;

    public List<int> availableQustIDs = new List<int>();
    public List<int> receivableQustIDs = new List<int>();

    public GameObject questMarker;
    public Image image;

    public Sprite questAvailableSprite;
    public Sprite questReceivableSprite;

    private void Start()
    {
        SetQuestMarker();
    }

    void SetQuestMarker()
    {
        if (QuestManager.questManager.CheckCompletedQuets(this))
        {
            questMarker.SetActive(true);
            image.sprite = questReceivableSprite;
            image.color = Color.yellow;
        }
        else if (QuestManager.questManager.CheckAvailableQuets(this))
        {
            questMarker.SetActive(true);
            image.sprite = questAvailableSprite;
            image.color = Color.yellow;
        }
        else if (QuestManager.questManager.CheckAcceptedQuets(this))
        {
            questMarker.SetActive(true);
            image.sprite = questReceivableSprite;
            image.color = Color.gray;
        }
        else
        {
            questMarker.SetActive(false);
        }

    }

    private void Update()
    {
        SetQuestMarker();

        if (inTrigger && Input.GetKeyDown(KeyCode.Space))
        {
            //quest ui manager

            //QuestManager.questManager.QuestRequest(this);

            QuestUIManager.uiManager.CheckQuests(this);

        }  
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inTrigger = true;   
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inTrigger = false;
        }
    }

}
