using System.Collections;
using UnityEngine;
using UnityEngine.Tilemaps;

public class HidMyRederer : MonoBehaviour
{
    public Tilemap hidTitle;
    public void HidThisAssets()
    {
        StartCoroutine(HidFadeoutTile());
    }

    private IEnumerator HidFadeoutTile()
    {
        float fadeDuration = .5f;
        float elapsedTime = 0f;

        Color startColor = hidTitle.color;
        Color targetColor = new Color(startColor.r, startColor.g, startColor.b, 0f); // a = 0

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            hidTitle.color = Color.Lerp(startColor, targetColor, elapsedTime / fadeDuration);
            yield return null;
        }

        hidTitle.color = targetColor;
    }
}
