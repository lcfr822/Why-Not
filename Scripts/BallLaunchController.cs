using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLaunchController : MonoBehaviour
{
    public float launchSpeed = 5.0f;
    public GameObject ballPrefab;
    public GameObject launcherHintObject;
    public Transform fireEndpoint;

    private bool canLaunch = true;

    void Update()
    {
        if (canLaunch && FindObjectOfType<MasterGameplayManager>().gameRunning) { StartCoroutine(LaunchBall()); }
    }

    private IEnumerator LaunchBall()
    {
        canLaunch = false;
        Color temp = launcherHintObject.GetComponent<SpriteRenderer>().color;
        temp = new Color(temp.r, temp.g, temp.b, 0.0f);
        launcherHintObject.transform.rotation = new Quaternion(0.0f, 0.0f, Random.Range(-0.5f, 0.5f), 0.9f);
        yield return new WaitForSeconds(0.25f);
        temp.a = 1.0f;
        launcherHintObject.GetComponent<SpriteRenderer>().color = temp;

        transform.rotation = launcherHintObject.transform.rotation;
        Vector3 fireDirection = fireEndpoint.position - transform.position;
        GameObject ball = Instantiate(ballPrefab, transform.position, Quaternion.identity);
        ball.GetComponent<Rigidbody2D>().AddForce(fireDirection.normalized * launchSpeed, ForceMode2D.Impulse);
        
        yield return new WaitForSeconds(Random.Range(0.5f, 1.5f));
        canLaunch = true;
    }
}
