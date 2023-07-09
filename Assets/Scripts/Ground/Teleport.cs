using UnityEngine;
public class Teleport : MonoBehaviour
{
    [SerializeField]
    private TeleportPosition _tpPos;
    private Player _player;
    [SerializeField]
    private TeleportUI _uiTeleport;

    private bool isComplete=false;

    private void Start()
    {
        _player = FindObjectOfType<Player>();
    }

    public void OnSetActive()
    {
        _uiTeleport.gameObject.SetActive(true);
        QuestGiverWindow.Instance.Close();
        isComplete = true;
    }


    private void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponent<Player>();
        if (player == null&&isComplete) return;
        _uiTeleport.gameObject.SetActive(true);
    }

    public void Teleportation()
    {
        _player.GetAgent.Warp(_tpPos.transform.position);
        _player.GetComponent<Player>().enabled = true;
        _uiTeleport.gameObject.SetActive(false);
    }

}
