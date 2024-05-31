using UnityEngine;

public class Monster : MonoBehaviour
{
    public float MonsterHP = 30f;
    public float MonsterDamage = 2f;
    public float MonsterExp = 3;

    private float moveTime = 0;
    private float TurnTime = 0;

    public float MoveSpeed = 3f;
    public GameObject[] ItemObj;

    private Animator MonsterAnimator;

    void Start()
    {
        MonsterAnimator = this.GetComponent<Animator>();
    }

    void Update()
    {
        MonsterMove();
    }

    private void MonsterMove()
    {
        moveTime += Time.deltaTime;

        if (moveTime <= TurnTime)
        {
            this.transform.Translate(MoveSpeed * Time.deltaTime, 0, 0);
        }
        else
        {
            TurnTime = Random.Range(1, 5);
            moveTime = 0;

            transform.Rotate(0, 180, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            MonsterAnimator.SetTrigger("Attack");
            GameManager.Instance.PlayerHP -= MonsterDamage;
        }

        if (collision.gameObject.tag == "Attack")
        {
            MonsterAnimator.SetTrigger("Damage");
            MonsterHP -= collision.gameObject.GetComponent<Attack>().AttackDamge;

            if (MonsterHP <= 0)
            {
                MonsterDie();
            }
        }
    }

    private void MonsterDie()
    {
        MonsterAnimator.SetTrigger("Die");
        GameManager.Instance.PlayerExp += MonsterExp;


        GetComponent<Collider2D>().enabled = false;
        Destroy(gameObject, 1.5f);
    }
    private void OnDestroy()
    {
        int itemRandom = Random.Range(0, ItemObj.Length * 2);
        if (itemRandom < ItemObj.Length)
        {
            Instantiate(ItemObj[itemRandom], new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
        }

    }

}
