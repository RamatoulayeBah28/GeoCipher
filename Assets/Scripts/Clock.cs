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

    public int hour = 10;
    public int minute = 10;

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
                screenPos = Camera.main.WorldToScreenPoint(min.position);
                Vector3 vec3 = Input.mousePosition - screenPos;
                angleOffset = (Mathf.Atan2(min.right.y, min.right.x) - Mathf.Atan2(vec3.y, vec3.x)) * Mathf.Rad2Deg;
            }
            if(hrCol == Physics2D.OverlapPoint(mousePos)){
                screenPos = Camera.main.WorldToScreenPoint(hr.position);
                Vector3 vec3 = Input.mousePosition - screenPos;
                angleOffset = (Mathf.Atan2(hr.right.y, hr.right.x) - Mathf.Atan2(vec3.y, vec3.x)) * Mathf.Rad2Deg;
            }
        }
        if (Input.GetMouseButton(0))
        {
            if(minCol == Physics2D.OverlapPoint(mousePos)){
                Vector3 vec3 = Input.mousePosition - screenPos;
                float angle = Mathf.Atan2(vec3.y, vec3.x) * Mathf.Rad2Deg;
                min.eulerAngles = new Vector3(0, 0, angle + angleOffset);
            }
            if(hrCol == Physics2D.OverlapPoint(mousePos)){
                Vector3 vec3 = Input.mousePosition - screenPos;
                float angle = Mathf.Atan2(vec3.y, vec3.x) * Mathf.Rad2Deg;
                hr.eulerAngles = new Vector3(0, 0, angle + angleOffset);
            }
        }
        if(Input.GetMouseButtonUp(0)){
            Time();
        }
    }


    private void Time()
    {
        float minAngle = min.eulerAngles.z;
        float hrAngle = hr.eulerAngles.z;
    
        int mins = Mathf.CeilToInt(minAngle / 360f * 60f);
        int hrs = Mathf.CeilToInt(hrAngle / 360f * 12f);
    
        if (hrs == 0){
            hrs = 12;
        } else if(hrs != 12){
            hrs = 12 - hrs;
        }

        mins = (105 - mins) % 60;
    
        Debug.Log("Hour:" + hrs + ", " + "Minute:" + mins);

        if(Mathf.Abs(minute - mins) < 2 && hour == hrs){
            Debug.Log("Corret Time. Open the Picture");
        }
        else{
            Debug.Log("Wrong Time");
        }
    }

}
