using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Diagnostics;
using System.Collections;

public class ChannelSelector : MonoBehaviour
{
     [SerializeField]
    Text channelText;
    string selectChannel = "";

  
    void Start()
    {
    }

   
    void Update()
    {
         if (channelText != null)
    {
        channelText.text = string.IsNullOrEmpty(selectChannel) ? "Enter Channel" : selectChannel;
    }
       
        if(selectChannel.Length == 2){
          StartCoroutine(HandleCodeEntry());
        } 
        
    }
     IEnumerator HandleCodeEntry()
{
    yield return new WaitForSeconds(0.1f);
     if(selectChannel == "17"){
            ClueManager.instance.isTVFound = true;
            SceneController.instance.ChangeScene("Scenes/TVChannelScene"); 
        } 
}
   


    public void AddChannel(string channel) {
        selectChannel += channel;
    }

}