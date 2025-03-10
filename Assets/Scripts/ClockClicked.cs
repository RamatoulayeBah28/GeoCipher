using UnityEngine;

public class ClockClicked : MonoBehaviour
{
    public GameObject clock;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        clock.SetActive(false);
    }

    // Update is called once per frame
    void OnMouseDown(){
        clock.SetActive(true);
    }

    public void Close(){
        clock.SetActive(false);
    }
}
