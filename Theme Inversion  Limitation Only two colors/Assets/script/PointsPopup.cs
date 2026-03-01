using System.Collections;
using TMPro;
using UnityEngine;

public class PointsPopup : MonoBehaviour
{
    GameObject player;
    colliding pointsScript;

    public TMP_Text text;

    Rigidbody2D rb;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("player");
        pointsScript = player.GetComponent<colliding>();

        rb = GetComponent<Rigidbody2D>();

        text.text = "+" + pointsScript.addedPoints.ToString();
        rb.AddForce(new Vector2(Random.Range(-2, 2), Random.Range(2, 5)), ForceMode2D.Impulse);

        if (pointsScript.addedPoints == 5)
        {
            StartCoroutine(ChangeColor());
        }

        Destroy(this.gameObject, 1);
    }
    
    IEnumerator ChangeColor()
    {
        while (true)
        { 
            yield return new WaitForSeconds(0.1f);
            text.color = Color.yellow;
            yield return new WaitForSeconds(0.1f);
            text.color = Color.white;
        }
    }
}
