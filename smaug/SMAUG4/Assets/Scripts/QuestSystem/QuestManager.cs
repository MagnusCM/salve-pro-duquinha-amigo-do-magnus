using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{

    public static QuestManager questManager;

    public List<Quest> questList = new List<Quest>(); // Master quest List

    public List<Quest> currentQuestList = new List<Quest>();

    // private vars for our QuestObject

    void Awake()
    {
        if(questManager == null)
        {
            questManager = this;
        }     
        else if(questManager != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    public void QuestRequest(QuestObject NPCQuestObject )
    {
        // AVAILABLE QUEST

        if(NPCQuestObject.availableQustIDs.Count > 0)
        {
            for(int i = 0; i < questList.Count; i++) 
            { 
                for(int j = 0; j < NPCQuestObject.availableQustIDs.Count; j++)
                {
                    if (questList[i].id == NPCQuestObject.availableQustIDs[j] && questList[i].progess == Quest.QuestProgess.AVAILABLE)
                    {
                        print("Quest ID:" + NPCQuestObject.availableQustIDs[j] + " " + questList[i].progess);

                        //AcceptQuest(NPCQuestObject.availableQustIDs[j]);

                        QuestUIManager.uiManager.questAvailable = true;
                        QuestUIManager.uiManager.availableQuests.Add(questList[i]);
                    }
                }
            }
        }

        // ACTIVE QUESTS

        for(int  i = 0; i < currentQuestList.Count; i++)
        {
            for (int j = 0; j < NPCQuestObject.receivableQustIDs.Count; j++)
            {
                if (currentQuestList[i].id == NPCQuestObject.receivableQustIDs[j] && (currentQuestList[i].progess == Quest.QuestProgess.ACCEPTED || currentQuestList[i].progess == Quest.QuestProgess.COMPLETE))
                {
                    print("Quest ID:" + NPCQuestObject.receivableQustIDs + " is " + currentQuestList[i].progess);

                    //CompleteQuest(NPCQuestObject.receivableQustIDs[j]);

                    QuestUIManager.uiManager.questRunning = true;
                    QuestUIManager.uiManager.activeQuests.Add(questList[i]);
                }
            }
        }
    }




    // ACCEPT QUEST

    public void AcceptQuest(int questID)
    {
        for (int i=0; i < questList.Count; i++) 
        { 
            if (questList[i].id == questID && questList[i].progess == Quest.QuestProgess.AVAILABLE)
            {
                currentQuestList.Add(questList[i]);
                questList[i].progess = Quest.QuestProgess.ACCEPTED;
            }
        }
    }

    // TODO GIVE UP QUEST


    //COMPLETE QUEST

    public void CompleteQuest(int questID)
    {
        for (int i = 0;  i < questList.Count; i++)
        {
            if (currentQuestList[i].id == questID && currentQuestList[i].progess == Quest.QuestProgess.COMPLETE)
            {
                currentQuestList[i].progess = Quest.QuestProgess.DONE;
                currentQuestList.Remove(currentQuestList[i]);

                // REWARD
            }
        }

        CheckChainQuest(questID);

    }

    // CHECK CAHIN QUEST

    void CheckChainQuest(int questID)
    {
        int num = 0;

        for(int i=0; i<questList.Count ; i++)
        {
            if (questList[i].id == questID && questList[i].nextQuest > 0)
            {
                num = questList[i].nextQuest;   
            }
        }

        if (num > 0)
        {
            for(int i = 0; i<questList.Count ;i++)
            {
                if (questList[i].id == num && questList[i].progess == Quest.QuestProgess.NOT_AVAILABLE)
                {
                    questList[i].progess = Quest.QuestProgess.AVAILABLE;
                }
            }
        }

    }


    // ADD ITEMS

    public void AddQuestItem(string questObjective, int itemAmount)
    {
        for (int i = 0; i < currentQuestList.Count; i++)
        {
            if (currentQuestList[i].questObjective == questObjective && currentQuestList[i].progess == Quest.QuestProgess.ACCEPTED)
            {
                currentQuestList[i].questObjectiveCount += itemAmount;
            }

            if (currentQuestList[i].questObjectiveCount >= currentQuestList[i].questObjectiveRequirement && currentQuestList[i].progess == Quest.QuestProgess.ACCEPTED)
            {
                currentQuestList[i].progess = Quest.QuestProgess.COMPLETE;
            }

        }

    }

    // TODO REMOVE ITEMS

    // BOOLS

    public bool RequestAvailableQuest(int questID)
    {
        for (int i = 0; i < questList.Count; i++)
        {
            if (questList[i].id == questID && questList[i].progess == Quest.QuestProgess.AVAILABLE )
            {
                return true;
            }
        }

        return false;
    }

    public bool RequestAcceptedQuest(int questID)
    {
        for (int i = 0; i < questList.Count; i++)
        {
            if (questList[i].id == questID && questList[i].progess == Quest.QuestProgess.ACCEPTED)
            {
                return true;
            }
        }

        return false;
    }

    public bool RequestCompleteQuest(int questID)
    {
        for (int i = 0; i < questList.Count; i++)
        {
            if (questList[i].id == questID && questList[i].progess == Quest.QuestProgess.COMPLETE)
            {
                return true;
            }
        }

        return false;
    }

    public bool CheckAvailableQuets(QuestObject NPCQuestObject)
    {
        for(int i = 0;i < questList.Count; i++)
        {
            for (int j = 0; j < NPCQuestObject.availableQustIDs.Count;  j++)
            {
                if (questList[i].id == NPCQuestObject.availableQustIDs[j] && questList[i].progess == Quest.QuestProgess.AVAILABLE)
                {
                    return true;
                }
            }
        }

        return false;

    }

    public bool CheckAcceptedQuets(QuestObject NPCQuestObject)
    {
        for (int i = 0; i < questList.Count; i++)
        {
            for (int j = 0; j < NPCQuestObject.receivableQustIDs.Count; j++)
            {
                if (questList[i].id == NPCQuestObject.receivableQustIDs[j] && questList[i].progess == Quest.QuestProgess.ACCEPTED)
                {
                    return true;
                }
            }
        }

        return false;

    }

    public bool CheckCompletedQuets(QuestObject NPCQuestObject)
    {
        for (int i = 0; i < questList.Count; i++)
        {
            for (int j = 0; j < NPCQuestObject.receivableQustIDs.Count; j++)
            {
                if (questList[i].id == NPCQuestObject.receivableQustIDs[j] && questList[i].progess == Quest.QuestProgess.COMPLETE)
                {
                    return true;
                }
            }
        }

        return false;

    }

    // SHOW QUEST LOG 

    public void ShowQuestLog(int questID)
    {
        for (int i =0; i<currentQuestList.Count;i++)
        {
            if (currentQuestList[i].id == questID)
            {
                QuestUIManager.uiManager.ShowQuestlog(currentQuestList[i]); 
            }
        }
    }


}
