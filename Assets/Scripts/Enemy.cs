using UnityEngine;

public class Enemy : MonoBehaviour
{

    private void Update()
    {
        transform.position += new Vector3(1, 0, 0)*Time.deltaTime*0.1f;
    }
    public void LoadData(Save.EnemySaveData save)
    {
        transform.position = new Vector3(save.Position.x, save.Position.y, save.Position.z);
        transform.eulerAngles = new Vector3(save.Direction.x, save.Direction.y, save.Direction.z);
    }
}
