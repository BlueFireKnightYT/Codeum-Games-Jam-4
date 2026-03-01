using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class changeColors : MonoBehaviour
{
    SpriteRenderer sr;

    public float timeToWhite;

    public bool red = false;
    public bool blue = false;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    public void Red(InputAction.CallbackContext context)
    {
        if (context.performed && this.enabled)
        {
            if (!red && !blue)
            { 
                sr.color = Color.red;

                red = true;
                blue = false;

                StartCoroutine(BackToWhite());
            }
        }
    }

    public void Blue(InputAction.CallbackContext context)
    {
        if (context.performed && this.enabled)
        {
            if (!red && !blue)
            {
                sr.color = Color.blue;

                blue = true;
                red = false;

                StartCoroutine(BackToWhite());
            }
        }
    }

    IEnumerator BackToWhite()
    {
        yield return new WaitForSeconds(timeToWhite);
        sr.color = Color.white;

        blue = false;
        red = false;
    }
}
