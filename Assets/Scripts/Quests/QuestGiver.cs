using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGiver : NPC
{

    [SerializeField]
    private Quest[] _quests;

    [SerializeField]
    private Sprite _questionSprite,_exclamationSprite;
    [SerializeField]
    private SpriteRenderer _statusRenderer;

    public Quest[] Quests => _quests;

    private void Start()
    {
            foreach(Quest quest in _quests)
        {
            quest.MyQuestGiver = this;
        }
    }
    public void UpdateQuestStatus()
    {
        int count = 0;
        foreach(Quest quest in _quests)
        {
            if(quest!=null)
            {
                if(quest.isComplete&&QuestLog.Instance.HasQuest(quest))
                {
                    _statusRenderer.sprite = _exclamationSprite;
                    break;
                }
                else if(!QuestLog.Instance.HasQuest(quest))
                {
                    _statusRenderer.sprite = _questionSprite;
                    break;
                }
                else if (!quest.isComplete && QuestLog.Instance.HasQuest(quest))
                {
                    _statusRenderer.sprite = _exclamationSprite;
                    break;
                }

            }
            else
            {
                count++;
                if(count == _quests.Length)
                {
                    _statusRenderer.enabled = false;
                }
            }
        }
    }
}
