using UnityEngine;
using System.Collections;

public class BMover : MonoBehaviour {

    public float speed;

	void Start () {

    }

	void Update () {

        transform.Translate(-Vector3.right * speed * Time.deltaTime);

    }
}
