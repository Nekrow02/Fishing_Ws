using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeRenderer : MonoBehaviour
{
    public SpriteRenderer sr;

    public Text calander;
    public Color day;
    public Color night;
    private int date = 0;

    public float oneDay;
    public float currentTime;

    [Range(0.01f, 0.2f)]
    public float transitionTime;

    bool isSwap = false;

    private void Awake()
    {
        float spritex = sr.sprite.bounds.size.x;
        float spritey = sr.sprite.bounds.size.y;

        float screenY = Camera.main.orthographicSize * 2;
        float screenX = screenY / Screen.height * Screen.width;
        transform.localScale = new Vector2(Mathf.Ceil(screenX / spritex), Mathf.Ceil(screenY / spritey));

        calander.text = string.Format(Global.date.ToString()+" 일 차");
        sr.color = day;
    }

    // Update is called once per frame
    void Update()
    {
        if(date != Global.date)
        {
            date = Global.date;
            calander.text = string.Format(Global.date.ToString() + " 일 차");
        }


        currentTime += Time.deltaTime;
        if (currentTime >= oneDay)
        {
            currentTime = 0;
            Global.date += 1;
            Debug.Log(Global.date.ToString());
        }


        if(!isSwap)
        {
            if(Mathf.FloorToInt(oneDay*0.4f)==Mathf.FloorToInt(currentTime))
            {
                isSwap = true;
                StartCoroutine(SwapColor(sr.color, night));
            }
            else if(Mathf.FloorToInt(oneDay*0.9f)==Mathf.FloorToInt(currentTime))
            {
                isSwap = true;
                StartCoroutine(SwapColor(sr.color, day));
            }
        }
    }
    public IEnumerator SwapColor(Color start, Color end)
    {
        float t = 0;
        while(t<1)
        {
            t += Time.deltaTime * (1 / (transitionTime * oneDay));
            sr.color = Color.Lerp(start, end, t);
            yield return null;
        }
        isSwap = false;
    }
}
