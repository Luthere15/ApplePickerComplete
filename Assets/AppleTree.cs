using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("Set in Inspector")]
    // prefab for instantiating apples
    public GameObject applePrefab;

    //Speed at which the AppleTree moves
    public float speed = 1f;

    //Distance where AppleTree turns around
    public float leftAndRightEdge = 10f;

    //Chance that the AppleTree will change directions
    public float chanceTochangeDirections = 0.1f;

    //Rate at which Apples will be instantiated
    public float secondsBetweenAppleDrops = 1f;

    // Use this for initialization
    void Start()
    {
        Invoke("DropApple", 2f);
    }
    void DropApple()
    {
        GameObject apple = Instantiate<GameObject>(applePrefab);
        apple.transform.position = transform.position;
        Invoke("DropApple", secondsBetweenAppleDrops);
    }
	
	// Update is called once per frame
	void Update ()
    {
        //basic movement
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;
        //changing direction
        if (pos.x < -leftAndRightEdge)
        {
            speed = Mathf.Abs(speed);//move right
        }
        else if (pos.x > leftAndRightEdge)
        {
            speed = -Mathf.Abs(speed);//Move left
        }
        else if (Random.value < chanceTochangeDirections)
        {
            speed *= -1; //change direction
        }
	}

    void FixedUpdate()
    {
        if (Random.value<chanceTochangeDirections)
        {
            speed *= -1;
        }
    }
}
