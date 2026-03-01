using TMPro;
using UnityEngine;

public class colliding : MonoBehaviour
{
    PlayPlayerSoundEffect sfx;
    changeColors playerColorScript;
    enemyScript enemyScript;
    HpSys hp;

    public int points;
    public int addedPoints;

    public TextMeshProUGUI pointsShowcase;
    public GameObject textPopup;
    public Transform popupSpawnPos;
    

    private void Start()
    {
        sfx = GetComponent<PlayPlayerSoundEffect>();
        playerColorScript = GetComponent<changeColors>();
        hp = GetComponent<HpSys>();

        points = 0;
        pointsShowcase.text = "Score: " + 0;
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        enemyScript = other.GetComponent<enemyScript>();

        if (playerColorScript.red && enemyScript.isRed)
        {
            addPointsBasedOnDistance(other.gameObject);
            Instantiate(textPopup, popupSpawnPos);
            Destroy(other.gameObject);
        }
        else if (playerColorScript.blue && !enemyScript.isRed)
        {
            addPointsBasedOnDistance(other.gameObject);
            Instantiate(textPopup, popupSpawnPos);
            Destroy(other.gameObject);
        }
        else if(other.transform.position == transform.position)
        {
            hp.hp -= 1;
            hp.UpdateHearts();
            Destroy(other.gameObject);
        }
    }

    void addPointsBasedOnDistance(GameObject other)
    {
        sfx.breakAudio();
        float distance = Vector2.Distance(transform.position, other.transform.position);

        if (distance < 0.9f)
        {
            if (distance < 0.6f)
            {
                if (distance < 0.4f)
                {
                    if (distance < 0.2f)
                    {
                        if (distance < 0.1f)
                        {
                            addedPoints = 5;
                        }
                        else addedPoints = 4;
                    }
                    else addedPoints = 3;
                }
                else addedPoints = 2;
            }
            else addedPoints = 1;
        }
        else addedPoints = 0;
        addPoints(addedPoints);
    }

    void addPoints(int addedPoints)
    {
        points += addedPoints;
        pointsShowcase.text = "Score: " + points.ToString();
        if (PlayerPrefs.GetInt("Highscore") < points) PlayerPrefs.SetInt("Highscore", points);
    }
}
