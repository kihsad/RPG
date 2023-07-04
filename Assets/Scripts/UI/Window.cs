using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Window : MonoBehaviour
{
    [SerializeField]
    private CanvasGroup _canvasGroup;
    private NPC _npc;

    public virtual void Open(NPC npc)
    {
        _npc = npc;
        _canvasGroup.alpha = 1;
        _canvasGroup.blocksRaycasts = true;
    }
    public virtual void Close()
    {
        _npc._isInteracting = false;
        _canvasGroup.alpha = 0;
        _canvasGroup.blocksRaycasts = false;
        _npc = null;
    }
}
