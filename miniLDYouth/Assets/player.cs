using UnityEngine;
using System.Collections;
using System;

public class Player : LivingObjectClass
{
    #region exp
    private long _exp;
    private float _expModifierPerLevel;

    public float expModifierPerLevel_init = 1.5f;
    public long exp_init = 0;


    public long exp { get { return _exp - expMaxLastLevel; } }

    /// <summary>
    /// Maximale EXP im aktuellen Level
    /// </summary>
    public long expMax { get { return (long)Math.Pow(_expModifierPerLevel, level); } }
    private long expMaxLastLevel { get { return level == 1 ? 0L : (long)Math.Pow(_expModifierPerLevel, level - 1); } }
    #endregion

    #region level
    private int _level;

    public int level_init = 1;
    public int level { get { return _level; } }

    private void levelUp()
    {
        if (canLevelUp)
        {
            _level++;
            //TODO: add some magical effects
        }
    }
    private bool canLevelUp { get { return _exp >= expMax; } }
    #endregion

    #region stats
    private float _movementSpeed = 5.0f;
    public float movementSpeed { get { return _movementSpeed; } }
    private float _attackModifierPerLevel;
    private float _defenseModifierPerLevel;
    public float attackModifierPerLevel_init = 1.3f;
    public float defenseModifierPerLevel_init = 1.3f;
    //public float specialModifier = 1.5f;
    #endregion


    public Player() : base()
    {
        _level = level_init;
        _exp = exp_init;
        _expModifierPerLevel = expModifierPerLevel_init;
    }

    private void move()
    {
        if (!this.isAlive)
            return;

        Boolean left = Input.GetKey(KeyCode.A) | Input.GetKey(KeyCode.LeftArrow);
        Boolean right = Input.GetKey(KeyCode.D) | Input.GetKey(KeyCode.RightArrow);
        Boolean up = Input.GetKey(KeyCode.W) | Input.GetKey(KeyCode.UpArrow);
        Boolean down = Input.GetKey(KeyCode.S) | Input.GetKey(KeyCode.DownArrow);
        float updownSpeedModifier = 0.625f; //Simuliert quadratisches Spielfeld bei 16:9 Format
        float diagonalSpeedModifier = 0.727f;//nur bei 45° Bewegungen gültig!
        Boolean diagonal = (up | down) & (left | right);


        if (left & !right)
        {
            transform.localPosition += Vector3.left * Time.deltaTime * this.movementSpeed * (diagonal ? diagonalSpeedModifier : 1.0f);
        }
        else if (!left & right)
        {
            transform.localPosition += Vector3.right * Time.deltaTime * this.movementSpeed * (diagonal ? diagonalSpeedModifier : 1.0f);
        }


        if (up & !down)
        {
            transform.localPosition += Vector3.up * Time.deltaTime * this.movementSpeed * updownSpeedModifier * (diagonal ? diagonalSpeedModifier : 1.0f);
        }
        else if (!up & down)
        {
            transform.localPosition += Vector3.down * Time.deltaTime * this.movementSpeed * updownSpeedModifier * (diagonal ? diagonalSpeedModifier : 1.0f);
        }
    }


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        move();
        attack();
        updateFacingDirection();
        //levelUp();//triggern von expgain
    }

    private Boolean facingRight = false;
    private void flipX()
    {

        // Switch the way the player is labelled as facing
        if(facingRight != Camera.main.ScreenToWorldPoint(Input.mousePosition).x > transform.position.x)
        {
            facingRight = Camera.main.ScreenToWorldPoint(Input.mousePosition).x > transform.position.x;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }

    private void updateFacingDirection()
    {
        //Rotate Player
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 diff = mousePosition - transform.parent.localPosition;
        diff.Normalize();

        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.localRotation = Quaternion.Euler(0f, 0f, rot_z - 90);

        flipX();
        //Flip Sprites
        /*SpriteRenderer[] sprites = this.GetComponentsInChildren<SpriteRenderer>();
        foreach (SpriteRenderer sprite in sprites)
        {
            sprite.flipX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x > transform.position.x;
        }*/
    }

    private void attack()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {

        }
    }
}
