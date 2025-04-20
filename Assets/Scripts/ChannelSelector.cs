using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Diagnostics;

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
        channelText.text = selectChannel;
        if(selectChannel == "17"){
            ClueManager.instance.isTVFound = true;
            SceneController.instance.ChangeScene("Scenes/TVChannelScene"); 
        } 
        if(selectChannel.Length >= 2){
            selectChannel = "";
        } 
        
    }
    public void AddChannel(string channel) {
        selectChannel += channel;
    }
}
