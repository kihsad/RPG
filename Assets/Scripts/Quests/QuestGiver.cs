using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGiver : NPC
{

    [SerializeField]
    private Quest[] _quest;

    public Quest[] Quests => _quest;


}
