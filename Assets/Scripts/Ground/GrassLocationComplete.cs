using UnityEngine;

public class GrassLocationComplete : MonoBehaviour
{
    [SerializeField]
    private GameObject _closedDoor;
    [SerializeField]
    private GameObject _openedDoor;
    [SerializeField]
    private Transform _skeletonsParent;
    [SerializeField]
    private QuestGiver _npcQuest;

    public bool SkeletonsCount
    {
        get
        {
            return _skeletonsParent.childCount<=0;
        }
    }
    private static GrassLocationComplete instance;
    public static GrassLocationComplete Instance
    {
        get
        {
            if(instance==null)
            {
                instance = FindObjectOfType<GrassLocationComplete>();
            }
            return instance;
         }
    }

    private void Awake()
    {
        _closedDoor.SetActive(false);
        _npcQuest.GetComponent<Collider>().enabled = false;
    }
    public void OpenDoors()
    {
        Destroy(_openedDoor);
        _closedDoor.SetActive(true);
    }

    private void Update()
    {
        if(SkeletonsCount)
        {
            _npcQuest.GetComponent<Collider>().enabled = true;
        }
    }
}
