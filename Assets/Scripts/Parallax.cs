using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{

    private float length, startPosition, distance, temp;
    [SerializeField] private GameObject camera;
    [SerializeField] private float parallaxEffect;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        temp = (camera.transform.position.x * (1-parallaxEffect));
        distance = (camera.transform.position.x * parallaxEffect);

        transform.position = new Vector3(startPosition - distance, transform.position.y, transform.position.z);

        /*if (temp > startPosition + length) startPosition += length;
        else if (temp < startPosition - length) startPosition -= length;*/
    }
}
