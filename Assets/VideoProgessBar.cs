using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Video;
using UnityEngine.UI;
using System;

public class VideoProgessBar : MonoBehaviour, IDragHandler, IPointerDownHandler
{
    [SerializeField]
    private VideoPlayer videoPlayer;

    private Image progress;

    private void Awake()
    {
       progress = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (videoPlayer.frameCount > 0){
            progress.fillAmount = (float)videoPlayer.frame/(float)videoPlayer.frameCount;
        }
    }
    public void OnDrag(PointerEventData eventData)
    {
        TrySkip(eventData);
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        TrySkip(eventData);
    }

    private void TrySkip(PointerEventData eventData)
    {
       Vector2 localPoint;
       if(RectTransformUtility.ScreenPointToLocalPointInRectangle(
        progress.rectTransform,eventData.position, null, out localPoint)){
            float pct = Mathf.InverseLerp(
                progress.rectTransform.rect.xMin, progress.rectTransform.rect.xMax, localPoint.x);
                SkipToPercent(pct);
       }
    }

    private void SkipToPercent(float pct)
    {
       var frame = videoPlayer.frameCount * pct;
       videoPlayer.frame = (long)frame;
    }
}
