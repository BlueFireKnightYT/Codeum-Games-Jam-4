using UnityEngine;
using UnityEngine.InputSystem;

public class changeColors : MonoBehaviour
{
    SpriteRenderer sr;

    public bool red = false;
    public bool blue = false;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    public void Red(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            sr.color = Color.red;

            red = true;
            blue = false;
        }
    }

    public void Blue(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            sr.color = Color.blue;

            blue = true;
            red = false;
        }
    }
}
