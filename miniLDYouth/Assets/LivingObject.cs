using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public abstract class LivingObjectClass : MonoBehaviour
{
    #region healthAttributes
    public float healthMax_init = 100.0f;

    private float _healthMax = 100.0f;
    private float _health;
    public float health { get { return _health; } }
    public float healthMax { get { return _healthMax; } }
    #endregion
    #region healthMethods
    /// <summary>
    /// Setzt das Leben auf den höchsten Wert.
    /// </summary>
    public void healthRefill()
    {
        this._health = this._healthMax;
    }
    /// <summary>
    /// Erhöht das Leben um den angegebenen Wert.
    /// </summary>
    /// <param name="by"></param>
    public void healthRefill(float by)
    {
        this._health = normalizeHealth(this._health + by);
    }
    /// <summary>
    /// Verringert das Leben um den angegebenen Wert.
    /// </summary>
    /// <param name="by"></param>
    public void healthDecrease(float by)
    {
        this._health = normalizeHealth(this._health - by);
    }

    private float normalizeHealth(float newValue)
    {
        //Berechnet einen erlaubten Wert im Bereich 0 bis healthMax
        return newValue > _healthMax ? _healthMax : (newValue < 0.0f ? 0.0f : newValue);
    }
    #endregion

    #region stats

    #endregion


    public Boolean isAlive() { return health > 0f; }
    public LivingObjectClass()
    {
        _health = _healthMax = healthMax_init;
    }
}
