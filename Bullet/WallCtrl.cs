using System.Collections;
using UnityEngine;

public class WallCtrl : MonoBehaviour
{   
    void OnCollisionEnter(Collision col)
    {

        if (col.gameObject.tag == "Monster")
        {
            Debug.Log("Bullet Destory");
            Destroy(this.gameObject);
        }
        else if (col.gameObject.tag == "Wall")
        {
            Debug.Log("Bullet Destory With Wall");
            Destroy(this.gameObject);
        }
    }
}
