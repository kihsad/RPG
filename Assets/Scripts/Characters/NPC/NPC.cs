using UnityEngine;

public class NPC: MonoBehaviour
{
    [SerializeField]
    private Window _window;

    public bool _isInteracting { get; set; }

    public virtual void Interact()
    {
        if(!_isInteracting)
        {
            _isInteracting = true;
            _window.Open(this);
        }
    }
    public virtual void StopIntract()
    {
        if(_isInteracting||Vector3.Distance(Player.MyInstance.transform.position,transform.position)>3)
        {
            _isInteracting = false;
            _window.Close();
        }
    }
}
