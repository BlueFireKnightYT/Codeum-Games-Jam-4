using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HpSys : MonoBehaviour
{
    public Image heart1;
    public Image heart2;
    public Image heart3;

    public Sprite emptyHeart;
    public GameObject defeatMenu;
    public TextMeshProUGUI highscoreTxt;

    public int hp = 3;

    PlayPlayerSoundEffect sfx;
    changeColors change;
    public SpawnEnemies spawn;

    private void Start()
    {
        sfx = GetComponent<PlayPlayerSoundEffect>();
        change = GetComponent<changeColors>();
    }
    public void UpdateHearts()
    {
        if (hp == 2)
        {
            sfx.hurtAudio();
            heart1.sprite = emptyHeart;
        }
        if (hp == 1)
        {
            sfx.hurtAudio();
            heart2.sprite = emptyHeart;
        }
        if (hp == 0)
        {
            sfx.dieAudio();
            heart3.sprite = emptyHeart;
            defeatMenu.SetActive(true);
            highscoreTxt.text = "Highscore: " + PlayerPrefs.GetInt("Highscore").ToString();

            change.enabled = false;
            spawn.StopAllCoroutines();
        }
    }
}
