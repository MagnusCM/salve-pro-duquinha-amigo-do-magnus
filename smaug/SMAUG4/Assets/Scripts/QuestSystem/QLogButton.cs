using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QLogButton : MonoBehaviour { 


    public int questID;
    public TMP_Text questTitle;


    public void Start()
    {
    }

    public void ShowAllInfos()
    {
        QuestManager.questManager.ShowQuestLog(questID);
    }


    public void ClosePanel() 
    { 
    
        QuestUIManager.uiManager.HideQuestLogPanel();
    
    }
}
