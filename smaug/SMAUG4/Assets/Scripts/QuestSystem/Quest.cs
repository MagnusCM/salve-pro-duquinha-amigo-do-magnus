using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UIElements;

[System.Serializable]
public class Quest
{
   
    public enum QuestProgess{NOT_AVAILABLE, AVAILABLE , ACCEPTED, COMPLETE,DONE }

    public string title;
    public int id;                        //Quest ID number
    public QuestProgess progess;
    public string description;
    public string hint;
    public string congratulation;
    public string summary;
    public int nextQuest;

    public string questObjective;
    public int questObjectiveCount;       //Current number of questObjectives count
    public int questObjectiveRequirement;

    //public int expReward;
    //public int goldReward;
    public string itemReward;

}
