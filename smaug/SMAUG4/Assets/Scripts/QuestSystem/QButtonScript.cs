using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.UI;

public class QButtonScript : MonoBehaviour
{

    public int questID;
    public TMP_Text questTitle;

   // private GameObject acceptButton;
    private GameObject completeButton;
    private GameObject acceptButton;


    private QButtonScript acceptButtonscript;
    private QButtonScript completeButtonscript;


    [System.Obsolete]
    void Start()
    {
        //completeButton = GameObject.FindGameObjectWithTag("acceptButton");
        //acceptButtonscript = acceptButton.GetComponent<QButtonScript>();

      
        //completeButtonscript = completeButton.GetComponent<QButtonScript>();

        acceptButton = GameObject.FindGameObjectWithTag("acceptButton");
        print(acceptButton.name);

        acceptButtonscript = acceptButton.GetComponent<QButtonScript>();
        print(acceptButtonscript);

        completeButton = GameObject.FindGameObjectWithTag("completeButton");
        print(completeButton.name);

        completeButtonscript = completeButton.GetComponent<QButtonScript>();
        print(completeButtonscript);


        if (acceptButton == null)
        {
            Debug.LogError("acceptButton not found in the scene or not tagged properly.");
        }

        if (completeButton == null)
        {
            Debug.LogError("completeButton not found in the scene or not tagged properly.");
        }

        //acceptButton.SetActive(false);
        //completeButton.SetActive(false);


    }



    // SHOW ALL INFOS 
    public void ShowAllInfos()
    {
        QuestUIManager.uiManager.ShowSelectedQuest(questID);

        // Accept Button

        if (QuestManager.questManager.RequestAvailableQuest(questID))
        {
            
            acceptButton.SetActive(true);
            acceptButtonscript.questID = questID;
        }
        else
        {
            acceptButton.SetActive(false);
        }

        // Complete Button

        if (QuestManager.questManager.RequestCompleteQuest(questID))
        {
            completeButton.SetActive(true);
            completeButtonscript.questID = questID;
        }
        else
        {
            //completeButton.SetActive(false);
        }
    }

    public void AcceptQuest()
    {
        QuestManager.questManager.AcceptQuest(questID);
        QuestUIManager.uiManager.HideQuesPanel();

        //UPDATE ALL NPCS

        QuestObject[] currentQuestGuys = FindObjectsOfType(typeof(QuestObject)) as QuestObject[];
        foreach(QuestObject obj in currentQuestGuys)
        {
            //setquestMarker
        }

    }

    public void CompleteQuest()
    {
        QuestManager.questManager.CompleteQuest(questID);
        QuestUIManager.uiManager.HideQuesPanel();

        //UPDATE ALL NPCS

        QuestObject[] currentQuestGuys = FindObjectsOfType(typeof(QuestObject)) as QuestObject[];
        foreach (QuestObject obj in currentQuestGuys)
        {
            //setquestMarker
        }

    }

    public void ClosePanel()
    {
        QuestUIManager.uiManager.HideQuesPanel();
    }

}
