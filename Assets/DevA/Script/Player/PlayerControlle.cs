using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControlle: MonoBehaviour , IDamageAble , IHealAble
{

    [SerializeField] Rigidbody2D rb;
    [SerializeField] float speed;
    private Vector2 move;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2 (move.x * speed, move.y * speed);
    }
    public void Move(InputAction.CallbackContext context)
    {
        move = context.ReadValue<Vector2>();

    }
}
