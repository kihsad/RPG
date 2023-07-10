using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "QuestItem", menuName = "Items/Quest", order = 3)]
public class QuestItem : Item
{
    public override string GetDescription()
    {
        return base.GetDescription() + string.Format("\nПредмет для квеста");
    } 
}
