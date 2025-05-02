using System.Collections;
using UnityEngine;

public class PaintingController : MonoBehaviour
{
    private bool hasShaken = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        if(ClueManager.instance.isPaintingAttemptWrong && !hasShaken)
        {
            ShakePainting();
            hasShaken = true;
            ClueManager.instance.isPaintingAttemptWrong = false;
        }

        if(ClueManager.instance.IsUnlocked("Painting") && !hasShaken)
        {
            SlidePainting();
            hasShaken = true;
        }
    }

    public void ShakePainting()
    {
        StartCoroutine(ShakerAlgo());
    }

    private IEnumerator ShakerAlgo()
    {
        Vector3 origPos = transform.localPosition;
        float shakeAmt = 0.05f;
        float shakeTimeAmt = 0.3f;
        float elapsedTime = 0f;

        while (elapsedTime < shakeTimeAmt)
        {
            float moveX = Random.Range(-shakeAmt, shakeAmt);
            float moveY = Random.Range(-shakeAmt, shakeAmt);
            transform.localPosition = origPos + new Vector3(moveX, moveY, 0);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        transform.localPosition = origPos;
    }

    public void SlidePainting()
    {
        StartCoroutine(SlidingAlgo());
    }

    private IEnumerator SlidingAlgo()
    {
        Vector3 origPos = transform.localPosition;
        Vector3 endPos = origPos - new Vector3(1f,0,0);
        float elapsedTime = 0f;
        float slideDuration = 1f;
        while(elapsedTime < slideDuration)
        {
            transform.localPosition = Vector3.Lerp(origPos,endPos, 1);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        transform.localPosition = endPos;
    }

}
