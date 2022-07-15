using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dice : MonoBehaviour
{

    public enum diceType {Utility, Attack, Defence, Blank };

    private diceType diceT = diceType.Blank;

    private SpriteRenderer renderer = null;

    private const int faceNum = 2;
    private List<Sprite> faces = new List<Sprite>();

    private bool rolling = true;
    private float imgChangeTime = 0;
    private float imgChangeFinishTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        faces.Add(Resources.Load<Sprite>("AttackFaces/ShittySpearIcon"));
        faces.Add(Resources.Load<Sprite>("AttackFaces/ShittySwordIcon"));

        imgChangeTime = Time.time;
        renderer = transform.GetComponent<SpriteRenderer>();

        Roll();
    }

    // Update is called once per frame
    void Update()
    {
        if (rolling && Time.time - imgChangeTime > 0.1 )
        {

            int i = Random.Range(0, faces.Count);
            Sprite face = faces[i];

            if (renderer.sprite = face)
            {
                face = faces[(i + 1)%faces.Count];
            }

            renderer.sprite = face;
            imgChangeTime = Time.time;
        }
    }

    private void FixedUpdate()
    {
        if (imgChangeFinishTime< Time.time)
        {
            rolling = false;
        }
    }


    public void Roll()
    {
        imgChangeFinishTime = Time.time + 3;
        rolling = true;
    }

}
