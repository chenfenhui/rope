using Obi;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragChangeLength : MonoBehaviour
{
    public Transform start;
    public Transform ReStart;
    public ObiRope rope;
    public ObiParticleAttachment attachment;
    ObiRopeCursor cursor;
    public float LastDistance;
    public float Delta=0;
    Vector3 initLocation;
    void Start()
    {
        //绑定绳子关节锚点 
        //attachment = rope.gameObject.AddComponent<ObiParticleAttachment>();
        //var blueprint = rope.blueprint.groups[1];
        //attachment.target = transform;
        //attachment.particleGroup = blueprint;
        //attachment.attachmentType = ObiParticleAttachment.AttachmentType.Static;
        //initLocation = transform.position;
        cursor = rope.GetComponent<ObiRopeCursor>();
        LastDistance= (transform.position - start.position).magnitude;
    }

    // Update is called once per frame
    void Update()
    {
       float PresentDistance = (transform.position - start.position).magnitude;
       Delta = PresentDistance - LastDistance;
        if (Delta != 0) {
            cursor.ChangeLength(rope.restLength + Delta * 0.5f);
        }
       LastDistance = PresentDistance;

        if (Input.GetKey(KeyCode.S))
        {
            //设置绳子长度
            //cursor.ChangeLength(rope.restLength + 1f * Time.deltaTime);

            //当前绳子长度
            print(rope.CalculateLength());
        }
        

            //if (Input.GetKey(KeyCode.O))
            //{
            //    transform.position=ReStart.position;
            //}
        

    }
    private void Awake()
    {
        
    }

    private void OnEnable()
    {
        //transform.position = ReStart.position;
    }
}
