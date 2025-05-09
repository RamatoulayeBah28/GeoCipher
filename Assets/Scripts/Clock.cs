using UnityEngine;

/*
Handles the logic for the clock clue,
including rotating the clock hands and verifying if the correct time is set.

The correct clock time can be configured in the Unity editor.

By Batsambuu Batbold with the help of ChatGPT, modified by Katherene Lugo for the painting scene
*/

public class Clock : MonoBehaviour
{
    public GameObject minuteHand;
    public GameObject hourHand;
    public int correctHour;
    public int correctMinute;

    public static int count = 0;

    private Transform minute;
    private Transform hour;
    private Collider2D minuteCollider;

    private bool isDragging = false;
    private bool isUnlocked = false;
    private bool hasDragged = false;

    private Vector3 clockAngle;
    private Vector3 clockPos;

    private float totalMinuteRotation = 0f;
    private float totalHourRotation = 0f;
    private float lastMouseAngle;


    private void Start(){
        minute = minuteHand.transform;
        minuteCollider = minuteHand.GetComponent<Collider2D>();
        hour = hourHand.transform;
    }

    private void Update()
    {   
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 centerToMouse = mouseWorldPos - minute.position;

        if (Input.GetMouseButtonDown(0) && minuteCollider == Physics2D.OverlapPoint(mouseWorldPos))
        {
            isDragging = true;
            totalMinuteRotation = minute.eulerAngles.z;
            totalHourRotation = hour.eulerAngles.z;
            lastMouseAngle = Mathf.Atan2(centerToMouse.y, centerToMouse.x) * Mathf.Rad2Deg;
            hasDragged = true;
        }

        if (Input.GetMouseButton(0) && isDragging)
        {
            float currentMouseAngle = Mathf.Atan2(centerToMouse.y, centerToMouse.x) * Mathf.Rad2Deg;
            float deltaAngle = Mathf.DeltaAngle(lastMouseAngle, currentMouseAngle);

            totalMinuteRotation += deltaAngle;
            totalHourRotation += deltaAngle / 12f;

            minute.eulerAngles = new Vector3(0, 0, totalMinuteRotation);
            hour.eulerAngles = new Vector3(0, 0, totalHourRotation);

            lastMouseAngle = currentMouseAngle;
        }


        if (Input.GetMouseButtonUp(0))
        {
            if (isDragging)
            {
                isDragging = false;
            }

            if (!isDragging && hasDragged)
            {
                CheckTime();
            }
        }
    }


    private void CheckTime()
    {
        if (!isUnlocked)
        {
            float minAngle = minute.eulerAngles.z;
            float hrAngle = hour.eulerAngles.z;

            int mins = Mathf.RoundToInt(minAngle / 360f * 60f);
            int hrs = Mathf.FloorToInt(hrAngle / 360f * 12f) + 1;

            if (hrs == 0)
            {
                hrs = 12;
            }
            else if (hrs != 12)
            {
                hrs = 12 - hrs;
            }

            mins = (105 - mins) % 60;

            Debug.Log("Hour:" + hrs + ", " + " Minute:" + mins);
            Debug.Log("Correct hour:" + correctHour + ", " + " Correct minute:" + correctMinute);

            if (Mathf.Abs(correctMinute - mins) < 2 && correctHour == hrs)
            {
                Debug.Log("Correct Time. Open the Picture");
                AudioManager.instance.PlayUnlocked();
                isUnlocked = true;
                ClueManager.instance.UnlockObject("Painting");
                SceneController.instance.ChangeScene("RoomScene");

                if (count == 0)
                {
                    count++;
                }
            }
            else
            {
                Debug.Log("Wrong Time");
                AudioManager.instance.PlayNegative();
                ClueManager.instance.isPaintingAttemptWrong = true;
            }
        }
    }

}
