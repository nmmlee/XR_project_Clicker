using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    public float speed;
    public int direction;
    public int moveNum;

    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    MoveTrack moveTrack;

    int transformNum;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        moveTrack = GameObject.Find("MoveTrack").GetComponent<MoveTrack>();

        if (direction == -1)
            spriteRenderer.flipX = true;

        rigid.velocity = Vector2.right * speed * direction;

    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        if (moveNum == 1)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, moveTrack.Saebit[transformNum].position, 1 * Time.deltaTime);

            if (this.transform.position == moveTrack.Saebit[transformNum].position)
                transformNum++;
        }

        if (moveNum == 2)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, moveTrack.Central_Library[transformNum].position, 1 * Time.deltaTime);

            if (this.transform.position == moveTrack.Central_Library[transformNum].position)
                transformNum++;
        }

        if (moveNum == 3)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, moveTrack.Bima[transformNum].position, 1 * Time.deltaTime);

            if (this.transform.position == moveTrack.Bima[transformNum].position)
                transformNum++;
        }

        if (moveNum == 4)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, moveTrack.Hanwool[transformNum].position, 1 * Time.deltaTime);

            if (this.transform.position == moveTrack.Hanwool[transformNum].position)
                transformNum++;
        }

        if (moveNum == 5)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, moveTrack.Hwado[transformNum].position, 1 * Time.deltaTime);

            if (this.transform.position == moveTrack.Hwado[transformNum].position)
                transformNum++;
        }

        if (moveNum == 6)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, moveTrack.Yeongu[transformNum].position, 1 * Time.deltaTime);

            if (this.transform.position == moveTrack.Yeongu[transformNum].position)
                transformNum++;
        }

        if (moveNum == 7)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, moveTrack.Ogui[transformNum].position, 1 * Time.deltaTime);

            if (this.transform.position == moveTrack.Ogui[transformNum].position)
                transformNum++;
        }

        if (moveNum == 8)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, moveTrack.Nuri[transformNum].position, 1 * Time.deltaTime);

            if (this.transform.position == moveTrack.Nuri[transformNum].position)
                transformNum++;
        }

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == moveNum.ToString())
        {
            Destroy(this.gameObject);
        }

    }
}
