using UnityEngine;
using TMPro;

public class BestDistanceLoader : MonoBehaviour
{
    public TMP_Text bestText;

    private const string BEST_KEY = "BEST_DISTANCE";

    void OnEnable()
    {
        int best = PlayerPrefs.GetInt(BEST_KEY, 0);
        bestText.text = best + " points";
    }
}
