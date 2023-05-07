using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject roomCamera;
    public GameObject sword;
    public Vector2 swordyPos;
    public GameObject bat;
    public Vector2 batyPos;
    public GameObject hammer;
    public Vector2 hammeryPos;
    public GirlBattleController swordBC;
    public GirlBattleController hammerBC;
    public GirlBattleController batBC;
    public InventoryController inventoryController;

    public int currentLevel;
    public float speed;
    public GameObject PositionChangeUI;
    public TBFController TBFC;

    private Rigidbody2D body2d;
    public Vector2[] orderlocation;

    public int money;
    public int experiencePts;


    //public Vector2 levelStartPos;
    public List<GameObject> order;

    public State state;

    public int location;
    public Vector3 roomSpawn;
    private Vector3 beforeRoom;

    public enum State
    {
        //Menu,
        Idle,
        Moving,
        Fighting,
        ChangePos,
        Boss1, 
        Boss2, 
        Boss3
    }
    private void Awake()
    {
        //DontDestroyOnLoad(this.gameObject);
        //if (GameObject.Find(gameObject.name)
        //         && GameObject.Find(gameObject.name) != this.gameObject)
        //{
        //    Destroy(GameObject.Find(gameObject.name));
        //}
    }
    // Start is called before the first frame update
    void Start()
    {
        swordBC = sword.GetComponent<GirlBattleController>();
        swordyPos.y = -2.7f;
        hammerBC = hammer.GetComponent<GirlBattleController>();
        hammeryPos.y = -3f;
        batBC = bat.GetComponent<GirlBattleController>();
        batyPos.y = -3f;
        loadLevel(currentLevel);
        TBFC = GameObject.FindGameObjectWithTag("TBFC").GetComponent<TBFController>();
        //state = State.Idle;
        //state = State.Boss1;
        PositionChangeUI.SetActive(false);
        transform.position = GameObject.FindGameObjectWithTag("Respawn").transform.position;
        roomSpawn = GameObject.FindGameObjectWithTag("RoomSpawn").transform.position;
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
        //if (state != State.Menu)
       // {
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
       // }
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

    public void loadLevel(int level)
    {
        swordBC.load(level);
        batBC.load(level);
        hammerBC.load(level);
    }

    public void load(PlayerData data) {
        currentLevel = data.level;
        
        batBC.setHealth(data.currentHealth[0]);
        swordBC.setHealth(data.currentHealth[1]);
        hammerBC.setHealth(data.currentHealth[2]);

        inventoryController.cigs = data.itemsCount[0];
        inventoryController.makeup = data.itemsCount[1];
        inventoryController.brush = data.itemsCount[2];
        inventoryController.mask = data.itemsCount[3];

        experiencePts = data.exp;
        money = data.money;

        location = data.location;

        loadLevel(currentLevel);
    }

    public void changePosBuff(PosBuff posBuff)
    {
        swordBC.PositionBuff(posBuff);
        batBC.PositionBuff(posBuff);
        hammerBC.PositionBuff(posBuff);
    }

    public void Room()
    {
        beforeRoom = transform.position;
        mainCamera.SetActive(false);
        roomCamera.SetActive(true);
        transform.position = roomSpawn;
        state = State.Boss1;
    }
}
