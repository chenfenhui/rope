using Obi;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum RopeDot
{
    end = 0,
    end2 = 1,
    start = 2,
    start2 = 3,
}

public class RopeCtrl : MonoBehaviour
{
    ObiRope rope;
    ObiRopeCursor cursor;
    Transform startRoot;
    Transform endRoot;
    public bool isOk;
    float length;

    public float dis;
    void Awake()
    {
        //绑定绳子关节锚点       
        rope = GetComponent<ObiRope>();        
        cursor = GetComponent<ObiRopeCursor>();
        startRoot = transform.Find("start");
        endRoot = transform.Find("end");
        isOk = false;
    }

    public void AddAttachment(Transform target, RopeDot dotIndex)
    {
        var blueprint = rope.blueprint.groups[(int)dotIndex];
        var attachment = rope.gameObject.AddComponent<ObiParticleAttachment>();
        attachment.target = target;
        attachment.particleGroup = blueprint;
        
        attachment.attachmentType = ObiParticleAttachment.AttachmentType.Static;
    }

    public void SetPos(Vector3 startPos = default, Vector3 endPos = default)
    {
        if (startPos != default)
        {
            startRoot.transform.position = new Vector3(startPos.x, 0.5f, startPos.z);

        }
        if (endPos != default)
        {
           // float dis = (endPos - startRoot.position).magnitude;
           // SetLength(dis);
            endRoot.transform.position = new Vector3(endPos.x, 0.5f, endPos.z);
            length = rope.CalculateLength();
        }

        //Debug.LogError(rope.CalculateLength() + "====" + rope.restLength);
    }

    public void SetLength(float length = 10f)
    {
        cursor.ChangeLength(length);
    }

    public void SetCarZ(float z)
    {
        length = z;
    }

    void Update()
    {
        //if (Input.GetKey(KeyCode.S))
        //{
        //    //设置绳子长度
        //    //cursor.ChangeLength(rope.restLength + 1f * Time.deltaTime);
        //    rope.Tear(rope.elements[rope.elements.Count / 2]);
        //    SetLength(rope.restLength);
        //    //当前绳子长度
        //    //print(rope.CalculateLength() + "===" + rope.restLength);
        //}

        ////cursor.ChangeLength(rope.restLength + Time.deltaTime);
        //print(rope.CalculateLength() + "===" + rope.restLength);

        if (isOk)
        {
            float z = (startRoot.transform.position.z + endRoot.transform.position.z) / 2;
            
            if (length - z > dis)
            {
                rope.Tear(rope.elements[rope.elements.Count / 2]);
            }
        }
    }
}
