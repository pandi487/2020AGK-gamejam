using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField]float moveSpeed;
    public int player_Hp;

    private Vector2 vector;

    public BoxCollider2D attack_Range;

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        moveSpeed = 10;
        player_Hp = 5;
    }

    void Update()
    {
        moveControl();
        if(player_Hp <= 0)
        {
            Destroy(gameObject);
            Destroy(GameObject.Find("Arrow"));
            Time.timeScale = 0;
        }
        animator.SetFloat("DirX", transform.position.x);
        animator.SetFloat("DirY", transform.position.y);
     //   animator.SetBool("Walking", true);
     //   animator.SetBool("Walking", false);
    }

    void moveControl()
    {
        float distanceX = Input.GetAxis("Horizontal") *Time.deltaTime *moveSpeed;
        float distanceY = Input.GetAxis("Vertical") *Time.deltaTime *moveSpeed;
        gameObject.transform.Translate(distanceX, 0, 0);
        gameObject.transform.Translate(0, distanceY, 0);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            if(player_Hp > 0)
                player_Hp--;

        }
        else if(collision.gameObject.tag == "Item")
        {
            BackPack.Instance.AddItem(collision.gameObject.GetComponent<Item>());
            Destroy(collision.gameObject);
            FloatingTextManager.Instance.CreateFloatingText(new Vector3(transform.position.x, transform.position.y + 1.5f, 1), collision.gameObject.GetComponent<Item>().item_Name + "을(를) 흭득하셨습니다.");
            Debug.Log(collision.gameObject.GetComponent<Item>().property.ToString() + " current : " + collision.gameObject.GetComponent<Item>().item_Count + " total : " + BackPack.Instance.FindItem(collision.gameObject.GetComponent<Item>().property).item_Count);
        }
    }
}