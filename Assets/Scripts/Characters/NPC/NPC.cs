using UnityEngine;

public class NPC: MonoBehaviour
{
    [SerializeField]
    private Window _window;

    public bool _isInteracting { get; set; }

    public void Interact()
    {
        if(!_isInteracting)
        {
            _isInteracting = true;
            _window.Open(this);
        }
    }
    public void StopIntract()
    {
        if(_isInteracting)
        {
            _isInteracting = false;
            _window.Close();
        }
    }
}
