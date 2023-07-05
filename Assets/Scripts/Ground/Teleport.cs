using UnityEngine;
public class Teleport : MonoBehaviour
{
    [SerializeField]
    private TeleportPosition _tpPos;
    private Player _player;
    [SerializeField]
    private TeleportUI _uiTeleport;

    private void Start()
    {
        _player = FindObjectOfType<Player>();
    }
    private void OnTriggerEnter(Collider other)
    {
        var player = other.gameObject.GetComponent<Player>();
        if (player is null) return;
        _player.GetComponent<Player>().enabled = false;
        Debug.Log(name);
        _uiTeleport.gameObject.SetActive(true);
    }

    public void Teleportation()
    {
        _player.GetAgent.Warp(_tpPos.transform.position);
        _player.GetComponent<Player>().enabled = true;
        _uiTeleport.gameObject.SetActive(false);
    }

}
