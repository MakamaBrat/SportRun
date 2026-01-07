using UnityEngine;

public class PlayerProg : MonoBehaviour
{
    public MenuTravel menuTravel;
    public SnowflakeCounter snowCounter;
    public DistanceCounter dis;
    public AudioSource goodSound;
    public AudioSource badSound;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag=="Bad")
        {
        
            menuTravel.makeMenu(3);
            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
            if (collision.gameObject.tag == "Bad")
            {
                badSound.Play();
                dis.StopAndSaveBest();
                menuTravel.makeMenu(3);
                Destroy(collision.gameObject);
            }

        if (collision.gameObject.tag == "Good")
        {
            goodSound.Play();
            snowCounter.AddSnowflakes(1);
            Destroy(collision.gameObject);
        }

    }
}
