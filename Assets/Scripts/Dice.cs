using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dice
{
    private SpriteRenderer renderer = null;
    //------------------------------------------
    public enum diceType {Utility, Attack, Defence, Blank };
    //------------------------------------------
    private diceType diceT = diceType.Blank;
    private const int faceNum = 2;
    //------------------------------------------
    private IFace[] faces = new IFace[faceNum];
    //------------------------------------------
    private bool rolling = true;
    private float faceChangeTime = 0;
    private float faceChangeFinishTime = 0;



    void Start()
    {
        
    }


    void Update()
    {
        if (rolling && Time.time - faceChangeTime > 0.1 )
        {

            int i = Random.Range(0, faces.Length);
            IFace face = faces[i];

            if (renderer.sprite = face.GetSprite())
            {
                face = faces[(i + 1)%faces.Length];
            }

            renderer.sprite = face.GetSprite();
            faceChangeTime = Time.time;
        }
    }



    private void FixedUpdate()
    {
        if (faceChangeFinishTime < Time.time)
        {
            rolling = false;
        }
    }



    public void Roll()
    {
        faceChangeFinishTime = Time.time + 3;
        rolling = true;
    }

}
