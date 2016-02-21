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

        _attackModifierPerLevel = attackModifierPerLevel_init;
        _defenseModifierPerLevel = defenseModifierPerLevel_init;
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
        flipSprite();
        updateFacingDirection();
        //levelUp();//triggern von expgain
    }

    

    private void updateFacingDirection()
    {
        //Get the Screen positions of the object
        Vector2 positionOnScreen = Camera.main.WorldToViewportPoint(transform.position);

        //Get the Screen position of the mouse
        Vector2 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);

        //Get the angle between the points
        float angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);

        //Ta Daaa
        transform.rotation = Quaternion.Euler(new Vector3(90.0f, 0f, angle));
    }

    private float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }

    private void attack()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {

        }
    }

    private void flipSprite()
    {
        Transform transf = gameObject.transform;
        if ((transf.rotation.eulerAngles.y > 90 & transf.rotation.eulerAngles.y < 270))
        {
            transf.localScale = new Vector3(transf.localScale.x, -1, transf.localScale.z);
        }
        else
        {
            transf.localScale = new Vector3(transf.localScale.x, 1, transf.localScale.z);
        }
    }
}
