using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject sword;
    public Vector2 swordyPos;
    public GameObject bat;
    public Vector2 batyPos;
    public GameObject hammer;
    public Vector2 hammeryPos;
    private GirlBattleController swordBC;
    private GirlBattleController hammerBC;
    private GirlBattleController batBC;

    public int currentLevel;
    public float speed;
    public GameObject PositionChangeUI;
    public TBFController TBFC;

    private Rigidbody2D body2d;
    public Vector2[] orderlocation;


    //public Vector2 levelStartPos;
    public List<GameObject> order;

    public State state;

    public enum State
    {
        Idle,
        Moving,
        Fighting,
        ChangePos
    }

    // Start is called before the first frame update
    void Start()
    {
        swordBC = sword.GetComponent<GirlBattleController>();
        swordyPos.y = -2.7f;
        hammerBC = hammer.GetComponent<GirlBattleController>();
        hammeryPos.y = -1.75f;
        batBC = bat.GetComponent<GirlBattleController>();
        batyPos.y = -3f;
        load(currentLevel);
        TBFC = GameObject.FindGameObjectWithTag("GameController").GetComponent<TBFController>();
        state = State.Idle;
        PositionChangeUI.SetActive(false);
        transform.position = GameObject.FindGameObjectWithTag("Respawn").transform.position;
        body2d = GetComponent<Rigidbody2D>();
        order.Clear();
        order.Add(sword);
        order.Add(bat); 
        order.Add(hammer);
        orderlocation = new Vector2[] { new Vector2(4, swordyPos.y), new Vector2(-3.75f, batyPos.y), new Vector2(-12, hammeryPos.y) };
        ChangePosition();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x <= 74)
        {
            if (state == State.Idle)
            {
                if (Input.GetKey(KeyCode.D))
                {
                    state = State.Moving;
                }
                //else
                //{
                //    state = State.Idle;
                //}
            }
            if (state == State.Moving && Input.GetKey(KeyCode.D))
            {
                body2d.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, 0);
            }
            else if (state != State.ChangePos && state != State.Fighting)
            {
                body2d.velocity = Vector2.zero;
                state = State.Idle;
            }
            else
            {
                body2d.velocity = Vector2.zero;
            }
        }
        else
        {
            body2d.velocity = Vector2.zero;
            state = State.Idle;
        }
    }

    public Vector2 GetPosition() { return transform.position; }

    public void ChangePosition()
    {
        int i = 0;
        foreach (GameObject o in order)
        {
            o.transform.localPosition= orderlocation[i];
            i++;
        }
    }

    public void ClearOrder()
    {
        order.Clear();
    }

    public void load(int level)
    {
        swordBC.load(level);
        batBC.load(level);
        hammerBC.load(level);
    }

    public void changePosBuff(PosBuff posBuff)
    {
        swordBC.PositionBuff(posBuff);
        batBC.PositionBuff(posBuff);
        hammerBC.PositionBuff(posBuff);
    }
}
