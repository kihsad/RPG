using RPGPlayer;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)) Save();
        if (Input.GetKeyDown(KeyCode.E)) Load();
    }
    private void Save()
    {
        try
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/" + "SaveTest.dat",FileMode.Create);
            
            SaveData data = new SaveData();
            SavePlayer(data); 
            bf.Serialize(file, data);
            file.Close();
        }
        catch(System.Exception)
        {
//errors here
        }
    }

    public void Load()
    {
        try
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/" + "SaveTest.dat", FileMode.Open);

            SaveData data = (SaveData)bf.Deserialize(file);
            file.Close();
            LoadPlayer(data);
        }
        catch (System.Exception)
        {
            //errors here
        }
    }

    private void SavePlayer(SaveData data)
    {
        data.MyPlayerData = new PlayerData(Player.MyInstance.MyLevel,Player.MyInstance.MyHealth,Player.MyInstance.MyHealth,Player.MyInstance.transform.position);
    }
    private void LoadPlayer(SaveData data)
    {
        Player.MyInstance.MyLevel = data.MyPlayerData.MyLevel;
    }
}
