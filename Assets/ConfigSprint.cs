using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfigSprint : MonoBehaviour
{
    [SerializeField] float max;
    FixedJoint2D joint;
    // Start is called before the first frame update
    void Start()
    {
        joint = GetComponent<FixedJoint2D>();
    }

    // Update is called once per frame
    void Update()
    {
    }
}
