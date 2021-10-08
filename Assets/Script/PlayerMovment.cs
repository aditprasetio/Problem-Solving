using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    public float moveSpeed;
    private Rigidbody2D player_rigidbody;

    private void Awake()
    {
        player_rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        player_rigidbody.AddForce(new Vector2(1, 1) * moveSpeed);
    }
}
