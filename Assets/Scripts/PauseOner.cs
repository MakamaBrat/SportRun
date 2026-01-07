using UnityEngine;

public class PauseOner : MonoBehaviour
{
    public Transform pauseW;
    public AudioSource au;

    private void OnEnable()
    {
        pauseW.gameObject.SetActive(false);
        Time.timeScale = 1f;
    }

    public void pauseOner()
    {
        pauseW.gameObject.SetActive(!pauseW.gameObject.activeInHierarchy);
        au.Play();
        if(pauseW.gameObject.activeInHierarchy==true)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }
}
