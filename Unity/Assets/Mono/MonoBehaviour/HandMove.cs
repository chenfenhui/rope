using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandMove : MonoBehaviour
{
    public Transform start;
    public Transform end;
    public float speed;
    // Start is called before the first frame update
    void OnEnable()
    {
        transform.localPosition = start.localPosition;
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate((end.position - transform.position) * speed * Time.deltaTime);
        if(Vector3.Distance(end.position ,transform.position)<=0.1f)
            gameObject.SetActive(false);
    }
}
