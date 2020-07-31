using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit_Player : MonoBehaviour
{
    static int CreateNum;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        
        /*Create_Egg create_egg = GetComponent<Create_Egg>();
        
        if (coll.name.Equals ("Egg1"))
        {
            CreateNum = 1;
        }
        else if(coll.name.Equals("Egg2"))
        {
            CreateNum = 2;
        }
        else if(coll.name .Equals("Egg3"))
        {
            CreateNum = 3;
        }
        create_egg.Set_Create_Flg(CreateNum, true);
        CreateNum = 0;*/
    }
}
