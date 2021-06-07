using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manger : MonoBehaviour
{
    public GameObject spawner;
    public GameObject player;
    void Start()
    {//z 300-650 x 300-700
        int x = (int) player.transform.position.x;
        int z = (int) player.transform.position.z;
        while (((int) Mathf.Abs(x - player.transform.position.x) < 100 || ((int) Mathf.Abs(z - player.transform.position.z) < 100))) {
            x = Random.Range(350, 600);
            z = Random.Range(350, 650);
        }
        gameObject.transform.position = new Vector3(x, 0.5f, z);
        Instantiate(spawner, gameObject.transform);
        Debug.Log(x + " " + z);
    }
}
