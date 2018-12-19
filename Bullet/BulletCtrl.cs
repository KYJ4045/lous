using System.Collections;
using UnityEngine;

public class BulletCtrl : MonoBehaviour
{

    public static int Damage = 10;
    public float Speed = 10;

    [SerializeField]
    private static float DestroyTime = 0.0f;

    void Start()
    {
        GetComponent<Rigidbody>().AddForce(transform.forward * Speed);
    }
    void Update()
    {
        if (DestroyTime < 3.0f)
        {
            DestroyTime += Time.deltaTime;
        }
        else if (DestroyTime >= 3.0f)
        {
            Destroy(this.gameObject);
            DestroyTime = 0.0f;
        }
    }
}
