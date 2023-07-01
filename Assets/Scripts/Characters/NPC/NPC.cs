using UnityEngine;

public class NPC: MonoBehaviour
{
    [SerializeField]
    private Window _window;

    public bool isInteracting { get; set; }

    public void Interact()
    {
        if(!isInteracting)
        {
            isInteracting = true;
            _window.Open(this);
        }
    }
    public void StopIntract()
    {
        if(isInteracting)
        {
            isInteracting = false;
            _window.Close();
        }
    }
}
