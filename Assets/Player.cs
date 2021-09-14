using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    float JumpVelocity = 10;  // ジャンプ力

    Rigidbody2D rb2d;
    Animator thisAinme;
    SpriteRenderer thisRenderer;

    [SerializeField]
    private Sprite sp;

    private static bool isDead = false;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        thisAinme = GetComponent<Animator>();
        thisRenderer = GetComponent<SpriteRenderer>();

        TouchManager.Began += (info) =>
        {
            rb2d.velocity = Vector2.zero; // 落下速度リセットする
            rb2d.AddForce(transform.up * JumpVelocity, ForceMode2D.Impulse);    // 上方向に力を加える
        };
    }

    void Update()
    {
        if (isDead)
        {
            StartCoroutine(WaitGame(1.0f));
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isDead = true;
    }

    IEnumerator WaitGame(float second)
    {
        thisAinme.enabled = false;
        thisRenderer.sprite = sp;
        rb2d.simulated = false;
        yield return new WaitForSeconds(second);

        thisAinme.enabled = true;
        rb2d.simulated = true;
        isDead = false;
    }
}
