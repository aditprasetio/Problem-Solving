using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseMovment : MonoBehaviour
{
    public float moveSpeed;
    public float moveConstraint = 5.5f;
    private Vector3 targetMove;

    private Rigidbody2D PlayerRigidbody2D;

    private void Awake()
    {
        PlayerRigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {

    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePlayer = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (mousePlayer.x < moveConstraint && mousePlayer.x > -moveConstraint
                && mousePlayer.y < moveConstraint && mousePlayer.y > -moveConstraint)
            {
                targetMove = mousePlayer;
                targetMove.z = 0;
            }
        }

        if (transform.position != targetMove)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetMove, moveSpeed * Time.deltaTime);
        }
    }
}
