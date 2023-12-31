using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class QuestUIManager : MonoBehaviour {

    public static QuestUIManager uiManager;

    // BOOLS
    public bool questAvailable = false;
    public bool questRunning = false;
    private bool questPanelActive = false;
    private bool questLogPanelActive = false;

    // Panels
    public GameObject questPanel;
    public GameObject questLogPanel;

    // QUEST OBJECT
    private QuestObject currentQuestObject;

    // QUEST LISTS
    public List<Quest> availableQuests = new List<Quest>();
    public List<Quest> activeQuests = new List<Quest>();

    // BUTTONS 
    public GameObject qButton;
    public GameObject qButtonLog;
    private List<GameObject> qButtons = new List<GameObject>();

    // SPACER
    public Transform qButtonSpacer1;     // qButton available
    public Transform qButtonSpacer2;    // qButton running
    public Transform qlogButtonSpacer; // running in qLog

    // QUEST INFOS
    public TMP_Text questTitle;
    public TMP_Text questDescription;
    public TMP_Text questSummary;

    // QUEST LOG INFOS
    public TMP_Text questLogTitle;
    public TMP_Text questLogDescription;
    public TMP_Text questLogSummary;

  

    private void Awake()
    {       
        
        if (uiManager == null)
        {
            uiManager = this;
        }
        else if (uiManager != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        HideQuesPanel();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            questLogPanelActive = !questLogPanelActive;
            ShowQuestLogPanel();    
        }
    }

    // CALLED FROM QUEST OBJECT
    public void CheckQuests(QuestObject questObject)
    {
        currentQuestObject =  questObject;
        QuestManager.questManager.QuestRequest(questObject);

        if ((questRunning || questAvailable) && !questPanelActive)
        {
            ShowQuestPanel();

        }
        else
        {
            print("No Quests Available");
        }

    }

    // SHOW PANEL
    public void ShowQuestPanel()
    {
        questPanelActive = true;
        questPanel.SetActive(questPanelActive);
        
        // FILL IN DATA
        FillQuestButtons();
    }

    public void ShowQuestLogPanel()
    {
        questLogPanel.SetActive(questLogPanelActive);
        if(questLogPanelActive && !questPanelActive)
        {
            foreach (Quest curQuest in QuestManager.questManager.currentQuestList)
            {
                GameObject questButton = Instantiate(qButtonLog);
                QLogButton qbutton = questButton.GetComponent<QLogButton>();

                qbutton.questID = curQuest.id;
                qbutton.questTitle.text = curQuest.title;

                questButton.transform.SetParent(qlogButtonSpacer, false);
                qButtons.Add(questButton);
            }
        }

        else if (!questLogPanelActive && !questPanelActive)
        {
            HideQuestLogPanel();
        }

    }


    public void ShowQuestlog(Quest activeQuest)
    {
        questLogTitle.text = activeQuest.title;
        if(activeQuest.progess == Quest.QuestProgess.ACCEPTED)
        {
            questLogDescription.text = activeQuest.hint;
            questLogSummary.text = activeQuest.questObjective + " : " + activeQuest.questObjectiveCount + " / " + activeQuest.questObjectiveRequirement;
        }

        else if (activeQuest.progess == Quest.QuestProgess.COMPLETE)
        {
            questLogDescription.text = activeQuest.congratulation;
            questLogSummary.text = activeQuest.questObjective + " : " + activeQuest.questObjectiveCount + " / " + activeQuest.questObjectiveRequirement;
        }
    }


    // HIDE QUEST PANEL

    public void HideQuesPanel()
    {
        questPanelActive = false;
        questAvailable = false;
        questRunning = false;

        // CLEAR TEXT 
        questTitle.text = " ";
        questDescription.text = " ";
        questLogSummary.text = " ";

        // CLEAR LISTS
        availableQuests.Clear();
        activeQuests.Clear();

        // CLEAR BUTTON LIST

        for(int i = 0; i < qButtons.Count; i++)
        {
            Destroy(qButtons[i]);
        }

        qButtons.Clear();

        // HIDE

        questPanel.SetActive(questLogPanelActive);

    }

    // HIDE QUEST LOG PANEL

    public void HideQuestLogPanel()
    {
        questLogPanelActive = false;
        questLogTitle.text = "";
        questLogDescription.text = "";
        questLogSummary.text = "";

        // CLEAR BUTTON LIST
        for (int i = 0;i < qButtons.Count; i++)
        {
            Destroy(qButtons[i]);
        }

        qButtons.Clear();
        questLogPanel.SetActive(questLogPanelActive);

    }


    // FILL BUTTONS FOR QUEST PANEL
    void FillQuestButtons()
    {
        foreach(Quest availableQuest in availableQuests)
        {
            GameObject questButton = Instantiate(qButton);
            QButtonScript qBScript = questButton.GetComponent<QButtonScript>();

            qBScript.questID = availableQuest.id;
            qBScript.questTitle.text = availableQuest.title;


            questButton.transform.SetParent(qButtonSpacer1,false);
            qButtons.Add(questButton);
        }

        foreach (Quest activeQuest in activeQuests)
        {
            GameObject questButton = Instantiate(qButton);
            QButtonScript qBScript = questButton.GetComponent<QButtonScript>();

            qBScript.questID = activeQuest.id;
            qBScript.questTitle.text = activeQuest.title;

            questButton.transform.SetParent(qButtonSpacer2, false);
            qButtons.Add(questButton);
        }

    }

    // SHOW QUEST ON BUTTON PRESSED IN QUEST PANEL

    public void ShowSelectedQuest(int questID)
    {
        for (int i = 0; i < availableQuests.Count; i++)
        {
            if (availableQuests[i].id == questID)
            {
                questTitle.text = availableQuests[i].title;

                if (availableQuests[i].progess == Quest.QuestProgess.AVAILABLE)
                {
                    questDescription.text = availableQuests[i].description;
                    questSummary.text = availableQuests[i].questObjective + " : " + availableQuests[i].questObjectiveCount + " / " + availableQuests[i].questObjectiveRequirement;
                }

            }
        }

        for (int i = 0; i < activeQuests.Count; i++)
        {

            if (activeQuests[i].id == questID)
            {
                questTitle.text = activeQuests[i].title;
                if (activeQuests[i].progess == Quest.QuestProgess.ACCEPTED)
                {
                    questDescription.text = activeQuests[i].hint;
                    questSummary.text = activeQuests[i].questObjective + " : " + activeQuests[i].questObjectiveCount + " / " + activeQuests[i].questObjectiveRequirement;
                }
                else if (activeQuests[i].progess == Quest.QuestProgess.COMPLETE)
                {
                    questDescription.text = activeQuests[i].congratulation;
                    questSummary.text = activeQuests[i].questObjective + " : " + activeQuests[i].questObjectiveCount + " / " + activeQuests[i].questObjectiveRequirement;
                }
            }

        }


    }


}
