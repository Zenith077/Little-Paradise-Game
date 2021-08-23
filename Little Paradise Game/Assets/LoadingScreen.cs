using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour
{
    public Image blackOutImage;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void FadeLoadScreen(Color newColor, float duration)
    {
        StartCoroutine(FadeRoutine(newColor, duration));
    }
    IEnumerator FadeRoutine(Color end, float duration)
    {
        Color start = blackOutImage.color;
        for (float t = 0f; t < duration; t += Time.deltaTime)
        {
            float normalizedTime = t / duration;
            //right here, you can now use normalizedTime as the third parameter in any Lerp from start to end
            blackOutImage.color = Color.Lerp(start, end, normalizedTime);
            yield return null;
        }

        blackOutImage.color = end; //without this, the value will end at something like 0.9992367
    }


}
