using UnityEngine;
using TMPro;

public class DistanceCounter : MonoBehaviour
{
    public TMP_Text distanceText;
    public TMP_Text distanceText2;

    [Header("Settings")]
    public float metersPerSecond = 1f; // сколько метров в секунду

    private float distance;
    private bool isRunning;

    private const string BEST_KEY = "BEST_DISTANCE";

    void OnEnable()
    {
        distance = 0f;
        isRunning = true;
        UpdateText();
    }

    void Update()
    {
        if (!isRunning) return;

        distance += metersPerSecond * Time.deltaTime;
        UpdateText();
    }

    void UpdateText()
    {
        distanceText.text = Mathf.FloorToInt(distance) + " points";
        distanceText2.text = Mathf.FloorToInt(distance) + " points";
    }

    // 🔴 Вызывать при стопе / конце игры
    public void StopAndSaveBest()
    {
        isRunning = false;

        int current = Mathf.FloorToInt(distance);
        int best = PlayerPrefs.GetInt(BEST_KEY, 0);

        if (current > best)
        {
            PlayerPrefs.SetInt(BEST_KEY, current);
            PlayerPrefs.Save();
        }
    }
}
