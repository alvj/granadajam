using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour {

    [SerializeField] float damping;
    
	void Update () {
        Vector3 pos = transform.position;
        pos.y = Mathf.Sin(Time.time / damping);
        this.transform.position = pos;
	}
}
