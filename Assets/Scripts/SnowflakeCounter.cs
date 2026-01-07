using UnityEngine;
using TMPro;

public class SnowflakeCounter : MonoBehaviour
{
    public TMP_Text snowflakeText;

    private int snowflakes;

    void OnEnable()
    {
        snowflakes = 0;
        UpdateText();
    }

    void UpdateText()
    {
        snowflakeText.text = snowflakes.ToString();
    }

    // ➕ Вызывать при подборе снежинки
    public void AddSnowflakes(int amount = 1)
    {
        snowflakes += amount;
        UpdateText();
    }

    // (опционально) получить текущее количество
    public int GetSnowflakes()
    {
        return snowflakes;
    }
}
