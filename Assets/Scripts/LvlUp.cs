using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LvlUp 
{

    public int level;
    private float exp;
    private float expRequired;
    public float hp;                //Test
    public float x = 0.1f;
    public float y = 0.1f;
    public float z = 0.0f;
    public LvlUp()
    {
        level = 1;
        exp = 0;
        expRequired = 100;
    }
    
    // void Update()
    // {
    //     Exp();
    //     if (Input.GetKeyDown(KeyCode.E))
    //     {
    //         exp += 100;
    //     }
    // }


    
    public void LevelUp()
    {
        level += 1;
        exp = 0;

        gameObject.transform.localScale += new Vector3(x, y,z );
        switch (level)
        {
            case 1:
                expRequired = 100;
                print("Nice you are lvl 1");
                break;
            case 2:
                expRequired = 200;
                print("Nice you are lvl 2");
                break;
            case 3:
                expRequired = 300;
                print("Nice you are lvl 3");
                break;
            case 4:
                expRequired = 400;
                print("Nice you are lvl 4");
                break;
            case 5:
                expRequired = 500;
                print("Nice you are lvl 5");
                break;
            case 6:
                expRequired = 600;
                print("Nice you are lvl 6");
                break;
            case 7:
                expRequired = 700;
                print("Nice you are lvl 7");
                break;
            case 8:
                expRequired = 800;
                print("Nice you are lvl 8");
                break;
            case 9:
                expRequired = 900;
                print("Nice you are lvl 9");
                break;
            case 10:
                expRequired = 1000;
                print("Nice you are lvl 10");
                break;
            default:
                expRequired += (expRequired * 1.05f) + 200f;
                print("Nice you are lvl up");
                break;
        }
    }
    void Exp()
    {
        if (exp >= expRequired)
        {
            LevelUp();
        }
    }



}
