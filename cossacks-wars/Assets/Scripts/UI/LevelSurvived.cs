using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class LevelSurvived : MonoBehaviour
{
    public Text RoundsText;

    private void OnEnable()
    {
        StartCoroutine(AnimateText());
    }

    IEnumerator AnimateText()
    {
        RoundsText.text = "0";
        int round = 0;

        yield return new WaitForSecondsRealtime(0.7f);

        while (round < PlayerStats.Rounds)
        {
            round++;
            RoundsText.text = round.ToString();

            yield return new WaitForSecondsRealtime(0.05f);
        }
    }
}
