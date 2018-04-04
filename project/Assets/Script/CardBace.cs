using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public abstract class CardBace : MonoBehaviour {
    enum Attibute { fire, ice, land }

    private SpriteRenderer spriteRanderer;

    public int hp;
    public int cost;
    public int dmg;
    public int serialNumber;
    //public string name = new S;
    public int attribute;
    public Sprite sprite;

    public abstract void Ability();
    public void InsertSprite()
    {
        spriteRanderer = GetComponent<SpriteRenderer>();
        spriteRanderer.sprite = sprite;
    }  
}





