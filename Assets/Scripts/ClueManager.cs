using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class ClueManager : MonoBehaviour
{
    public static ClueManager instance;

    public bool isBookUnlocked = false;
    public bool isTVFound = false;
    public bool isPaintingUnlocked = false;
    public bool isDrawerUnlocked = false;
    public bool isPaintingAttemptWrong = false;
    public Dictionary<string, bool> unlockedObj = new Dictionary<string, bool>();
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;

            DontDestroyOnLoad(gameObject);
            unlockedObj["TV"] = false;
            unlockedObj["Painting"] = false;
            unlockedObj["Drawer"] = false;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public bool IsUnlocked(string objectName){
        return unlockedObj.ContainsKey(objectName) && unlockedObj[objectName];
    }

    public void UnlockObject(string objectName){
        if(unlockedObj.ContainsKey(objectName)){
            unlockedObj[objectName] = true;
        }
    }
}
