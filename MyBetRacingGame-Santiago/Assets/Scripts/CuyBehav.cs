using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class CuyBehav : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] PathCreator pathCreator;
    [SerializeField] float speed, minSpeed, maxSpeed;
    public bool canMove;
    float travelledDistance;

    [Header("LeaderBoard")]
    [SerializeField] GameObject leaderDetector;    
    public float magnitude;

    private void Update()
    {
        magnitude = transform.position.x - leaderDetector.transform.position.x;
        if (canMove)
        {
            travelledDistance += speed * Time.deltaTime;
            transform.position = pathCreator.path.GetPointAtDistance(travelledDistance);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("RotationObj"))
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            StartCoroutine(TurnOnCollider());
            Quaternion rotation = transform.rotation;
            rotation.z = collision.GetComponent<RotationObj>().RotationValue;
            transform.Rotate(Vector3.forward, collision.GetComponent<RotationObj>().RotationValue);

            Vector3 scale = transform.localScale;
            scale.y = collision.GetComponent<RotationObj>().ScaleValue;
            transform.localScale = scale;
        }
        if (collision.CompareTag("FinishLine"))
        {
            print("b");
            GameManager.instance.FinishRace(gameObject.name);
        }
        if (collision.CompareTag("Changer"))
        {
            speed = Random.Range(minSpeed, maxSpeed);
            print("a");
        }
        if(collision.CompareTag("LeaderUpdt"))
        {
            GameManager.instance.AddTrack();
            collision.gameObject.SetActive(false);
        }
    }

    IEnumerator TurnOnCollider()
    {
        yield return new WaitForSeconds(1.5f);

        gameObject.GetComponent<BoxCollider2D>().enabled = true;
    }
}
