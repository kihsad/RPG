using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveLoadManager : MonoBehaviour
{
    private string filePath;
    public List<GameObject> EnemySaves = new List<GameObject>();
    private void Start()
    {
        Enemy[] _enemies = FindObjectsOfType<Enemy>();
        for (int i = 0; i < _enemies.Length; i++)
        {
            EnemySaves.Add(_enemies[i].gameObject);
        }
        filePath = Application.persistentDataPath + "/save.gamesave";
    }

    public void SaveGame()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream fs = new FileStream(filePath, FileMode.Create);

        Save save = new Save();
        save.SaveEnemies(EnemySaves);
        bf.Serialize(fs, save);
        fs.Close();
    }

    public void LoadGame()
    {
        if (!File.Exists(filePath)) return;

        BinaryFormatter bf = new BinaryFormatter();
        FileStream fs = new FileStream(filePath, FileMode.Open);

        Save save = (Save)bf.Deserialize(fs);
        fs.Close();

        int i = 0;
        foreach(var enemy in save.EnemiesData)
        {
            EnemySaves[i].GetComponent<Enemy>().LoadData(enemy);
            i++;
        }
    }
}

[System.Serializable]
public class Save
{
    [System.Serializable]
    public struct Vec3
    {
        public float x, y, z;

        public Vec3(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
    }
    [System.Serializable]
    public struct EnemySaveData
    {
        public Vec3 Position, Direction;
         public EnemySaveData(Vec3 pos , Vec3 dir)
        {
            Position = pos;
            Direction = dir;
        }
    }

    public List<EnemySaveData> EnemiesData = new List<EnemySaveData>();

    public void SaveEnemies(List<GameObject> enemies)
    {
        foreach( var GO in enemies)
        {
            var em = GO.GetComponent<Enemy>();

            Vec3 pos = new Vec3(GO.transform.position.x, GO.transform.position.y, GO.transform.position.z);
            Vec3 dir = new Vec3(em.transform.rotation.x, em.transform.rotation.y, em.transform.rotation.z);

            EnemiesData.Add(new EnemySaveData(pos, dir));
        }
    }
}