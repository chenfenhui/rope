using UnityEngine;
using System.Collections;
using Obi;

public class ObjectDragger : MonoBehaviour
{
    public RopeBreak ropeBreak;

    private Vector3 screenPoint;
    private Vector3 offset;
    public Transform AnchorStump;
    public float MoveToTargetSpeed;
    //public Transform Other1, Other2, Other3;
    public bool dragable = true;
    Vector3 initPosition;

    public int lastLength;

    private void Start()
    {
        initPosition = transform.position;
    }
    private void Awake()
    {

    }

    private void Update()
    {
        MouseDrag();
        if (Input.GetMouseButtonUp(0))
        {
            
            OnMouseUp();
        }
    }

    public void MouseDown()
    {
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }
    public void OnMouseUp()
    {
        if (dragable)
        {
            Ray rays = Camera.main.ScreenPointToRay(Input.mousePosition);//???DragableBall拦截了射线 不能获取球后面的 物体！！
            RaycastHit hit;
            Transform currentObject;
            if (Physics.Raycast(rays, out hit))//将创建的射线投射出去并将反馈信息存储到hit中
            {
                currentObject = hit.transform;
                if (!(currentObject.CompareTag("Rod") && (currentObject.position - AnchorStump.position).magnitude > 2))
                {
                    Debug.LogError("OnMouseUp");
                    transform.parent.parent.GetComponent<RopeManager>().CurLength -= (int)transform.parent.GetComponent<ObiRope>().CalculateLength();
                    transform.parent.parent.GetComponent<RopeManager>().Selectable = true;
                    GameObject.Destroy(transform.parent.gameObject);
                    //StartCoroutine(MoveToPosition(initPosition));
                }
            }
        }
    }

    public void MouseDrag()
    {
        if (dragable)
        {
            Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
            transform.position = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;

            transform.parent.parent.GetComponent<RopeManager>().CurLength -= lastLength;
            transform.parent.parent.GetComponent<RopeManager>().CurLength += (int)transform.parent.GetComponent<ObiRope>().CalculateLength();
            lastLength = (int)transform.parent.GetComponent<ObiRope>().CalculateLength();
            if (!transform.parent.parent.GetComponent<RopeManager>().IsOk(0))
            {
                GameObject.Destroy(transform.parent.gameObject);
                transform.parent.parent.GetComponent<RopeManager>().Selectable = true;
                transform.parent.parent.GetComponent<RopeManager>().CurLength -= lastLength;
                return;
            }


            Ray rays = Camera.main.ScreenPointToRay(Input.mousePosition);//???DragableBall拦截了射线 不能获取球后面的 物体！！
            RaycastHit hit;
            Transform currentObject;
            //Physics.Raycast(ray, out hitInfo, Mathf.Infinity, mask.value)
            if (Physics.Raycast(rays, out hit, Mathf.Infinity, 1 << LayerMask.NameToLayer("Rod")))//将创建的射线投射出去并将反馈信息存储到hit中
            {
                
                currentObject = hit.transform;
                Debug.Log(currentObject.gameObject.name);
                if (currentObject.CompareTag("Rod") && (currentObject.position - AnchorStump.position).magnitude > 2)
                {
                    
                    //transform.position = currentObject.transform.position;
                    StartCoroutine(MoveToPosition(currentObject.transform.position));
                    //transform.parent.parent.GetComponent<RopeManager>().SetTheNumberOfRope(transform.parent.parent.GetComponent<RopeManager>().theNumberOfRope + 1);
                    transform.parent.parent.GetComponent<RopeManager>().setSelectable(true);// = true;//TheNemberOfRope
                    transform.parent.GetComponent<RopeBreak>().deployedLength = transform.parent.GetComponent<ObiRope>().CalculateLength();
                    dragable = false;

                    if (transform.parent.parent.GetComponent<RopeManager>().isPlay2)
                    {
                        transform.parent.GetComponent<RopeBreak>().attachmentEnd.target = currentObject;
                        RopeManager.instance.lineCount++;
                    }

                    //  transform.parent.parent.GetComponent<RopeManager>().CurLength += (int)transform.parent.GetComponent<ObiRope>().CalculateLength();
                }
            }
        }
    }
    IEnumerator MoveToPosition(Vector3 targetPosition)//协程平滑移动
    {
        while (transform.position != targetPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, MoveToTargetSpeed * Time.deltaTime);
            //transform.rotation= Quaternion.Slerp()
            yield return 0;
        }
    }


}