using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cleanup : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 1);
    }

}
