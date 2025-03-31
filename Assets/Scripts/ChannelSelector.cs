using UnityEngine;
using UnityEngine.UI;

public class ChannelSelector : MonoBehaviour
{
     [SerializeField]
    Text channelText;
    string selectChannel = "";

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        channelText.text = selectChannel;
        if(selectChannel == "17"){
            SceneController.instance.ChangeScene("Scenes/TVChannelScene"); 
        } 
        if(selectChannel.Length >= 2){
            selectChannel = "";
        } 
        Debug.Log($"Channel: {selectChannel}");
    }
    public void AddDigit(string digit) {
        selectChannel += digit;
    }
}
