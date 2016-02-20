using UnityEngine;
using System.Collections;
using System;

public class player : LivingObjectClass {
    #region exp
    public long exp_init = 0;
    private long _exp;
    private float _expModifierPerLevel = 1.5f;
    #endregion

    #region level
    public int level_init = 1;
    private int _level;
    public int level { get { return _level; } }
    public void levelUp()
    {
        if (canLevelUp())
        {
            _level++;
            //add some magical effects
        }
    }
    private bool canLevelUp()
    {
        return _exp > Math.Pow(_expModifierPerLevel, level);
    }
    #endregion

    #region stats
    private float _movementSpeed = 5.0f;
    public float movementSpeed { get { return _movementSpeed; } }

    #endregion


    public player() : base()
    {
        _level = level_init;
        _exp = exp_init;
    }
  

    public void move()
    {
        Boolean left = Input.GetKey(KeyCode.A) | Input.GetKey(KeyCode.LeftArrow);
        Boolean right = Input.GetKey(KeyCode.D) | Input.GetKey(KeyCode.RightArrow);
        Boolean up = Input.GetKey(KeyCode.W) | Input.GetKey(KeyCode.UpArrow);
        Boolean down = Input.GetKey(KeyCode.S) | Input.GetKey(KeyCode.DownArrow);
        float updownSpeedModifier = 0.625f; //Simuliert quadratisches Spielfeld bei 16:9 Format
        float diagonalSpeedModifier = 0.727f;//nur bei 45° Bewegungen gültig!
        Boolean diagonal = (up | down) & (left | right);


        if (left & !right)
        {
            transform.position += Vector3.left * Time.deltaTime * this.movementSpeed * (diagonal ? diagonalSpeedModifier : 1.0f);
        }
        else if (!left & right)
        {
            transform.position += Vector3.right * Time.deltaTime * this.movementSpeed * (diagonal ? diagonalSpeedModifier : 1.0f);
        }
        

        if(up & !down)
        {
            transform.position += Vector3.up * Time.deltaTime * this.movementSpeed * updownSpeedModifier * (diagonal ? diagonalSpeedModifier : 1.0f);
        } else if(!up & down)
        {
            transform.position += Vector3.down * Time.deltaTime * this.movementSpeed * updownSpeedModifier * (diagonal ? diagonalSpeedModifier : 1.0f);
        }
    }


	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        move();
        attack();
        //levelUp();//triggern von expgain
	}

    

    private void attack()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            //throw new NotImplementedException();
        }
    }
}
