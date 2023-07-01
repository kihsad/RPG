using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quest
{
    [SerializeField]
    private string _title;

    [SerializeField]
    private string _description;
    [SerializeField]
    private CollectObjective[] _collectObjectives;
    [SerializeField]
    private KillObjective[] _killObjectives;

    public string Description
    {
        get => _description;
        set => _description = value;
    }
    public QuestScript MyQuestScript { get; set; }
    public string Title
    {
        get
        {
            return _title;
        }
        set
        {
            _title = value;
        }
    }

    public CollectObjective[] CollectObjectives => _collectObjectives;
    public KillObjective[] KillObjectives => _killObjectives;
    public bool isComplete
    {
        get
        {
            foreach (Objective obj in _collectObjectives)
            {
                if(!obj.IsComplete)
                {
                    return false;
                }
            }
            foreach (Objective obj in _killObjectives)
            {
                if (!obj.IsComplete)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
[System.Serializable]
public abstract class Objective
{
    [SerializeField]
    private int _amount;

    private int _currentAmount;
    [SerializeField]
    private string _type;

    public int Amount => _amount;
    public int CurrentAmount { get => _currentAmount; set => _currentAmount = value; }
    public string Type => _type;
    public bool IsComplete
    {
        get
        {
            return CurrentAmount >= Amount;
        }
    }
}

[System.Serializable]
public class CollectObjective : Objective
{
    public void UpdateItemCount(Item item)
    {
        if(Type.ToLower() == item.Title.ToLower())
        {
            CurrentAmount = InventoryScript.Instance.GetItemCount(item.Title);
            QuestLog.Instance.UpdateSelected();
            QuestLog.Instance.CheckCompletion();
        }
    }
    public void UpdateItemCount()
    {
            CurrentAmount = InventoryScript.Instance.GetItemCount(Type);
            QuestLog.Instance.UpdateSelected();
            QuestLog.Instance.CheckCompletion();
    }
}
[System.Serializable]
public class KillObjective : Objective
{
    public void UpdateKillCount(Character character)
    {
        if(Type == character.Type)
        {
            CurrentAmount++;
            QuestLog.Instance.CheckCompletion();
            QuestLog.Instance.UpdateSelected();
        }
    }
}