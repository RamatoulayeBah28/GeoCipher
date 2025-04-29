using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Diagnostics;
using System.Collections;
using System;

public class ChannelSelector : MonoBehaviour
{
     [SerializeField]
    Text channelText;
    string selectChannel = "";
    private bool isUnlocked = false;

  
    void Start()
    {
    }

   
    void Update()
    {
        channelText.text = selectChannel;    
         if(!isUnlocked && selectChannel.Length == 2){
          StartCoroutine(HandleCodeEntry());
        } 
        
    }
     IEnumerator HandleCodeEntry()
{
    yield return new WaitForSeconds(0.1f);
     if(selectChannel == "17"){
            isUnlocked = true;
            ClueManager.instance.isTVFound = true;
            SceneController.instance.ChangeScene("Scenes/TVChannelScene"); 
          
        } else {
                 yield return new WaitForSeconds(0.2f);
                 selectChannel = "";
            
        }
}
   


    public void AddChannel(string channel) {
        selectChannel += channel;
    }

}