using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cow_Behavior : MonoBehaviour
{
    public GameObject player;
    private float timer = 0.0f;
    private float walkWaitTime = 5.0f;

    private void Update()
    {
        if (PlayerPrefs.HasKey("Difficulty"))
        {
            string difficulty = PlayerPrefs.GetString("Difficulty");
            timer += Time.deltaTime;
            if (difficulty == "Hard")
            {
                walkWaitTime = 1.0f;
            }
            if ((difficulty == "Medium" || difficulty == "Hard") && walkWaitTime < timer)
            {
                int direction = Random.Range(1, 5);
                switch (direction)
                {
                    case 1:
                        gameObject.transform.position += Vector3.forward;
                        break;
                    case 2:
                        gameObject.transform.position += Vector3.back;
                        break;
                    case 3:
                        gameObject.transform.position += Vector3.left;
                        break;
                    case 4:
                    default:
                        gameObject.transform.position += Vector3.right;
                        break;
                }
                walkWaitTime = timer + 5.0f;
            }
        }
    }
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Terrain")
        {
            gameObject.transform.position += Vector3.up;
        }
    }
}
