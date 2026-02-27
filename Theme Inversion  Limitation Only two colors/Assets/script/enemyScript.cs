using UnityEngine;

public class enemyScript : MonoBehaviour
{
    SpriteRenderer sr;
    Color[] colors = { Color.red, Color.blue };
    public bool isRed;
    GameObject player;
    private void Start()
    {
        Color selectedColor = colors[Random.Range(0, colors.Length)];

        sr = GetComponent<SpriteRenderer>();
        sr.color = selectedColor;

        isRed = (selectedColor == Color.red) ? true : false;

        player = GameObject.FindGameObjectWithTag("player");
    }

    private void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, 3f * Time.deltaTime);
    }
}
