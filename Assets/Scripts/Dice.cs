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
    private IFace currentFace = null;
    //------------------------------------------
    private bool rolling = true;
    private float faceChangeTime = 0;
    private float faceChangeFinishTime = 0;

    public Dice(enumFace[] facelist)
    {
        for (int i = 0; i < facelist.Length; i++)
        {
            IFace f = GetFaceFromEnum(facelist[i]);
            faces[i] = f;
        }
        currentFace = faces[0];
    }


    private void FixedUpdate()
    {
        if (rolling && Time.time - faceChangeTime > 0.1 )
        {

            int i = Random.Range(0, faces.Length);
            currentFace = faces[i];
            Debug.Log(currentFace);
            if (renderer.sprite = currentFace.GetSprite())
            {
                currentFace = faces[(i + 1)%faces.Length];
            }

            renderer.sprite = currentFace.GetSprite();
            faceChangeTime = Time.time;
        }
        else if (faceChangeFinishTime < Time.time)
        {
            rolling = false;
        }
    }

    public bool IsRolling()
    {
        return rolling;
    }

    public void Roll()
    {
        faceChangeFinishTime = Time.time + 3;
        rolling = true;
    }

    public IFace getFace()
    {
        return currentFace;
    }


    public enum enumFace
    {
        EmptyFace,
        HealFace,
        FireballFace,
        IceFace,
        VineFace
    }


    private IFace GetFaceFromEnum(enumFace face)
    {
        IFace f;
        switch (face)
        {
            case enumFace.EmptyFace:
                f = new EmptyFace();
                break;
            case enumFace.HealFace:
                f = new HealthFace();
                break;
            case enumFace.FireballFace:
                f = new FireballFace();
                break;
            case enumFace.IceFace:
                f = new IceFace();
                break;
            case enumFace.VineFace:
                f = new VineFace();
                break;
            default:
                f = new EmptyFace();
                Debug.Log("Could not find face of name: '" + face + "'. Made empty face instead");
                break;
        }
        f.Init();

        return f;
    }

}
