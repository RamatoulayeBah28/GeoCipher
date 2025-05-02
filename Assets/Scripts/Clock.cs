using UnityEngine;

public class Clock : MonoBehaviour
{
    public GameObject minuteHand;
    private Transform min;
    private Collider2D minCol;

    public GameObject hourHand;
    private Transform hr;
    private Collider2D hrCol;
    private Vector3 screenPos;
    private float angleOffset;

    public int correctHour;
    public int correctMinute;

    private bool isUnlocked = false;

    private bool testHourDrag = false;
    private bool hasDraggedHour = false;

    private bool testMinDrag = false;
    private bool hasDraggedMin = false;
    private void Start(){
        min = minuteHand.transform;
        minCol = minuteHand.GetComponent<Collider2D>();

        hr = hourHand.transform;
        hrCol = hourHand.GetComponent<Collider2D>();
    }

    private void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {   
            if(minCol == Physics2D.OverlapPoint(mousePos)){
                testMinDrag = true;
                hasDraggedMin = true;
                screenPos = Camera.main.WorldToScreenPoint(min.position);
                Vector3 vec3 = Input.mousePosition - screenPos;
                angleOffset = (Mathf.Atan2(min.right.y, min.right.x) - Mathf.Atan2(vec3.y, vec3.x)) * Mathf.Rad2Deg;
            }
            if(hrCol == Physics2D.OverlapPoint(mousePos)){
                testHourDrag = true;
                hasDraggedHour = true;
                screenPos = Camera.main.WorldToScreenPoint(hr.position);
                Vector3 vec3 = Input.mousePosition - screenPos;
                angleOffset = (Mathf.Atan2(hr.right.y, hr.right.x) - Mathf.Atan2(vec3.y, vec3.x)) * Mathf.Rad2Deg;
            }
        }
        if (Input.GetMouseButton(0))
        {
            if(testMinDrag){
            // if(minCol == Physics2D.OverlapPoint(mousePos)){
                Vector3 vec3 = Input.mousePosition - screenPos;
                float angle = Mathf.Atan2(vec3.y, vec3.x) * Mathf.Rad2Deg;
                min.eulerAngles = new Vector3(0, 0, angle + angleOffset);
            }
            if(testHourDrag){
            // if(hrCol == Physics2D.OverlapPoint(mousePos)){
                Vector3 vec3 = Input.mousePosition - screenPos;
                float angle = Mathf.Atan2(vec3.y, vec3.x) * Mathf.Rad2Deg;
                hr.eulerAngles = new Vector3(0, 0, angle + angleOffset);
            }
        }
        if(Input.GetMouseButtonUp(0)){
            if(testMinDrag)
            {
                testMinDrag = false;
            }

            if(testHourDrag)
            {
                testHourDrag = false;
            }

            if(!testMinDrag && !testHourDrag && hasDraggedHour && hasDraggedMin)
            {
                Time();
            }
            // Time();
        }
    }


    private void Time()
    {
        if(!isUnlocked){
            float minAngle = min.eulerAngles.z;
            float hrAngle = hr.eulerAngles.z;
        
            int mins = Mathf.RoundToInt(minAngle / 360f * 60f);
            int hrs = Mathf.RoundToInt(hrAngle / 360f * 12f);
        
            if (hrs == 0){
                hrs = 12;
            } else if(hrs != 12){
                hrs = 12 - hrs;
            }

            mins = (105 - mins) % 60;
        
            Debug.Log("Hour:" + hrs + ", " + " Minute:" + mins);
            Debug.Log("Correct hour:" + correctHour + ", " + " Correct minute:" + correctMinute);

            if(Mathf.Abs(correctMinute - mins) < 2 && correctHour == hrs){
                Debug.Log("Corret Time. Open the Picture");
                AudioManager.instance.PlayUnlocked();
                isUnlocked = true;
                ClueManager.instance.UnlockObject("Painting");
                SceneController.instance.ChangeScene("RoomScene");
            }
            else{
                Debug.Log("Wrong Time");
                AudioManager.instance.PlayNegative();
                ClueManager.instance.isPaintingAttemptWrong = true;
            }
        }
    }

}
