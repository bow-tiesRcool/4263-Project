using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject sword;
    public GameObject bat;
    public GameObject hammer;
    public int currentLevel;
    public float speed;
    public GameObject PositionChangeUI;
    public TBFController TBFC;

    private Rigidbody2D body2d;
    private Vector2[] orderlocation;

    [HideInInspector]
    public Vector2 levelStartPos = new Vector2(-16.5f, -2.5f);
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
        TBFC = GameObject.FindGameObjectWithTag("GameController").GetComponent<TBFController>();
        state = State.Idle;
        PositionChangeUI.SetActive(false);
        orderlocation= new Vector2[] { new Vector2(0, 0), new Vector2(-1.5f, 0), new Vector2(-3, 0) };
        transform.position = GameObject.FindGameObjectWithTag("Respawn").transform.position;
        body2d = GetComponent<Rigidbody2D>();
        order.Clear();
        order.Add(sword);
        order.Add(bat); 
        order.Add(hammer);
        ChangePosition();
    }

    // Update is called once per frame
    void Update()
    {
        if (state == State.Idle)
        {
            if (Input.GetKey(KeyCode.D)){
                state = State.Moving;
            }
            else
            {
                state = State.Idle;
            }
        }
        if (state == State.Moving && Input.GetKey(KeyCode.D))
        {
            body2d.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, 0);
        }
        else 
        {
            body2d.velocity = Vector2.zero;
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
}
