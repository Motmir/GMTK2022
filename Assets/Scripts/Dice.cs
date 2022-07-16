using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dice : MonoBehaviour
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

    private void Awake()
    {
        for (int i = 0; i < faces.Length; i++){
            IFace f = new EmpyFace();
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

    

    public void Roll()
    {
        faceChangeFinishTime = Time.time + 3;
        rolling = true;
    }

    public IFace getFace()
    {
        return currentFace;
    }


}
