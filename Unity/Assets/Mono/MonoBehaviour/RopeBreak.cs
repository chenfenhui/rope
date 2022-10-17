using Obi;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mail;
using UnityEngine;

public class RopeBreak : MonoBehaviour
{
    public float deployedLength;
    public bool IsBroken;
    ObiRope rope;
    public Vector3 RopeStarPointOffset;
    public Transform Obirope;
    public Transform Obirope_StartPoint;
    ObiParticleAttachment attachmentStart, attachmentEnd;
    private void Start()
    {
        //绑定绳子关节锚点
        attachmentStart = GetComponents<ObiParticleAttachment>()[0];
        attachmentEnd = GetComponents<ObiParticleAttachment>()[1];
        //attachmentStart.is

        //attachment = rope.gameObject.AddComponent<ObiParticleAttachment>();
        //var blueprint = rope.blueprint.groups[1];
        //attachment.target = transform;
        //attachment.particleGroup = blueprint;
        //attachment.attachmentType = ObiParticleAttachment.AttachmentType.Static;
    }
    public void setBreakThreshold(float fvalue)
    {
        attachmentStart.breakThreshold = fvalue;
        attachmentEnd.breakThreshold = fvalue;
    }
    private void Awake()
    {
        rope = GetComponent<ObiRope>();
        RopeStarPointOffset = Obirope.position - Obirope_StartPoint.position;//
        //print("================");
        //print(RopeStarPointOffset);


    }
    void Update()
    {

        if (Input.GetKey(KeyCode.K))
        {
            RandomCut();
        }
    }

    public void AddAttachment(Transform target, RopeDot dotIndex)
    {
        var blueprint = rope.blueprint.groups[(int)dotIndex];
        var attachment = rope.gameObject.AddComponent<ObiParticleAttachment>();
        attachment.target = target;
        attachment.particleGroup = blueprint;

        attachment.attachmentType = ObiParticleAttachment.AttachmentType.Static;
    }

    public void RandomCut()
    {
        // keep track of whether the rope was cut or not.
        // bool cut = false;
        if (!IsBroken)
        {
            IsBroken = true;

            rope.Tear(rope.elements[rope.elements.Count / 2]);            
            // If the rope was cut at any point, rebuilt constraints:
            if (IsBroken) rope.RebuildConstraintsFromElements();


            transform.parent.GetComponent<RopeManager>().DeteIfAllRopeIsBroken();
        }

    }


}
