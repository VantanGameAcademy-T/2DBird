using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    float JumpVelocity = 10;  // ジャンプ力

    Rigidbody2D rb2d;

    [SerializeField]
    private Sprite sp;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        TouchManager.Began += (info) => 
        {
            rb2d.velocity = Vector2.zero; // 落下速度リセットする
            rb2d.AddForce(transform.up * JumpVelocity, ForceMode2D.Impulse);    // 上方向に力を加える
        };
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        Destroy(GetComponent<Animator>());
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        renderer.sprite = sp;
    }

}
