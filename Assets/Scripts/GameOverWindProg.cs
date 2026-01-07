using UnityEngine;

public class GameOverWindProg : MonoBehaviour
{
    public Transform wind;

    private void OnEnable()
    {
        wind.gameObject.SetActive(false);
    }
}
