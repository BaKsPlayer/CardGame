using System.Collections;
using TMPro;
using UnityEngine;

public class StatsFiller
{
    public static IEnumerator FillStats(TextMeshProUGUI text, int startValue, int endValue, float duration = 0.5f)
    {
        float timer = 0;

        while (timer < duration)
        {
            float nextValue = Mathf.Lerp(startValue, endValue, timer / duration);
            text.text = ((int)nextValue).ToString();

            timer += Time.deltaTime;

            yield return null;
        }

        text.text = endValue.ToString();
    }
}
