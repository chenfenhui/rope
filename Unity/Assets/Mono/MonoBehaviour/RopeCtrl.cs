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
    void Awake()
    {
        //�����ӹؽ�ê��       
        rope = GetComponent<ObiRope>();        
        cursor = GetComponent<ObiRopeCursor>();
    }

    public void AddAttachment(Transform target, RopeDot dotIndex)
    {
        var blueprint = rope.blueprint.groups[(int)dotIndex];
        var attachment = rope.gameObject.AddComponent<ObiParticleAttachment>();
        attachment.target = target;
        attachment.particleGroup = blueprint;
        attachment.attachmentType = ObiParticleAttachment.AttachmentType.Static;
    }

    public void SetLength(float length = 10f)
    {
        cursor.ChangeLength(length);
    }


    //void Update()
    //{
    //    if (Input.GetKey(KeyCode.S))
    //    {
    //        //�������ӳ���
    //        cursor.ChangeLength(rope.restLength + 1f * Time.deltaTime);

    //        //��ǰ���ӳ���
    //        print(rope.CalculateLength());
    //    }
    //}
}
