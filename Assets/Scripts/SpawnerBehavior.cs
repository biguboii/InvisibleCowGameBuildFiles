using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBehavior : MonoBehaviour
{
    public GameObject animal;

    private void Awake()
    {
        Instantiate(animal, gameObject.transform);
    }
}
