using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestScript : MonoBehaviour
{
    public Quest MyQuest { get; set; }
    private bool _markedComplete=false;

    public void Select()
    {
        GetComponent<Text>().color = Color.red;
        QuestLog.Instance.ShowDescription(MyQuest);
    }
    public void Deselect()
    {
        GetComponent<Text>().color = Color.white;
    }

    public void IsComplete()
    {
        if(MyQuest.isComplete&&!_markedComplete)
        {
            _markedComplete = true;
            GetComponent<Text>().text = "[" + MyQuest.Level + "]" + MyQuest.Title + "(C)";
            MessageFeedManager.Instance.WriteMessage(string.Format("{0}(C)", MyQuest.Title));
        }
        else if(!MyQuest.isComplete)
        {
            _markedComplete = false;
            GetComponent<Text>().text = "[" + MyQuest.Level + "]" + MyQuest.Title;
        }
    }
}
