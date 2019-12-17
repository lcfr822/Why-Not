using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMouseController : MonoBehaviour
{
    void Update()
    {
        // Move the platform to location beneath the Cursor at a height of -4.0.
        if (FindObjectOfType<MasterGameplayManager>().gameRunning)
        {
            gameObject.transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, -4.0f, 0.0f);
        }
    }

    /// <summary>
    /// Detect collisions on the platform while the game session is running. 
    /// If the colliding object is a ball and not "dead", increase score and start the ball's destruction sequence.
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!FindObjectOfType<MasterGameplayManager>().gameRunning) { return; }

        if (collision.gameObject.tag.ToLower().Equals("ball") && !collision.gameObject.name.ToLower().Contains("dead"))
        {
            collision.gameObject.name += "DEAD";
            collision.gameObject.GetComponent<Animator>().SetTrigger("BallBounced");
            Destroy(collision.gameObject, 1.0f);

            float accuracyModifier = Mathf.Abs((transform.position - collision.gameObject.transform.position).x).RangeMap(0.0f, 1.0f, 5.0f, -5.0f);
            FindObjectOfType<MasterGameplayManager>().AddScore(10, accuracyModifier);
        }
    }
}
