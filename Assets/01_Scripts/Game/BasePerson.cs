using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePerson:MonoBehaviour{
    private int hp;                                                 //生命值
    private int damage;                                             //攻击力
    private int resistance;                                         //抗性（受控制时间）
    private int speed;                                              //速度
    private int defense;                                            //防御
    private int penetrate;                                          //穿透

    #region 
    public int HP
    {
        get
        {
            return hp;
        }
        set
        {
            hp = value;
        }
    }

    public int Damage
    {
        get
        {
            return damage;
        }
        set
        {
            damage = value;
        }
    }

    public int Resistance
    {
        get
        {
            return resistance;
        }
        set
        {
            resistance = value;
        }
    }

    public int Speed
    {
        get
        {
            return speed;
        }
        set
        {
            speed = value;
        }
    }

    public int Defense
    {
        get
        {
            return defense;
        }
        set
        {
            defense = value;
        }
    }

    public int Penetrate
    {
        get
        {
            return penetrate;
        }
        set
        {
            penetrate = value;
        }
    }
    #endregion

    protected float velocity = 4.0f;                                //移动速度
    protected float jumpForce = 500.0f;                               //跳跃力度
    protected Animator anim;
    protected Rigidbody2D body;
    protected bool isRound = true;                                  //是否站在地面上

    protected virtual void Awake()
    {
        anim = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
    }

    protected virtual void FixedUpdate()
    {
        Move();
        Jump();
        Attack();
    }
    protected virtual void Move()                                   //移动
    {
        float h = Input.GetAxis("Horizontal");                                  
        transform.Translate(new Vector2(h * Time.deltaTime * velocity, 0));
        anim.SetFloat("Run", h);
        if (h < -0.1f)
        {
            transform.localScale = new Vector3(4, 4, 0);
        }
        else if (h > 0.1f)
        {
            transform.localScale = new Vector3(-4, 4, 0);
        }
    }

    protected virtual void Jump()                                   //跳跃
    {
        if (Input.GetKeyDown(KeyCode.Space) && isRound)                                   
        {
            body.AddForce(new Vector2(0, jumpForce));
            isRound = false;
            Debug.Log("进来欸");
        }
        if (isRound)
        {
            anim.SetBool("IsJump", false);
        }
        else
        {
            anim.SetBool("IsJump", true);
        }
    }

    protected virtual void Attack()                                 //攻击
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            anim.SetTrigger("Attack");
        }
    }

    protected virtual void Hurt()                                   //受伤
    {

    }

    protected virtual void Dizziness()                              //眩晕
    {

    }

    protected virtual void Die()                                    //死亡
    {
            
    }

    protected virtual void Win()                                    //胜利
    {

    }

    protected virtual void Lose()                                   //失败
    {

    }


    public virtual void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.collider.tag == "Collider")
        {
            isRound = true;
        }
    }
}
