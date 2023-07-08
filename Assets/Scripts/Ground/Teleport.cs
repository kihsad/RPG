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

    public void OnSetActive()
    {
        _uiTeleport.gameObject.SetActive(true);
        QuestGiverWindow.Instance.Close();
    }

    public void Teleportation()
    {
        _player.GetAgent.Warp(_tpPos.transform.position);
        _player.GetComponent<Player>().enabled = true;
        _uiTeleport.gameObject.SetActive(false);
    }

}
