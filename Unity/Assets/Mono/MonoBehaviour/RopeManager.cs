using Obi;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class RopeManager : MonoBehaviour
{
    public static RopeManager instance;
  //  public CarScript carScript;
    public GameObject Prefab;
    public int MaxRopes;
    public  bool Selectable=true;
    public List<GameObject> TheRopes = new List<GameObject>();
    public List<GameObject> TheRopes2 = new List<GameObject>();
    public int theNumberOfRope;//����������ӵ�����
    ObiSolver solver;

    public int AllLength;
    public int CurLength;

    //=============================================
    //ObiSolver solver;
    public float antiGravityScale = 2;
    ObiSolver.ObiCollisionEventArgs collisionEvent;
    //=================
    //============================

    void Awake()
    {
        if(instance == null)
            instance = this;

        solver = GetComponent<ObiSolver>();
        print("1");
    }


    public void setSelectable(bool b)
    {
        if(theNumberOfRope<MaxRopes&&b)
            Selectable = b;
    }

    public bool IsAllDragOver()
    {

        if (transform.childCount > 0)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                if (transform.GetChild(i).Find("Sphere").GetComponent<ObjectDragger>().dragable) { return false; }
            }
        }
        //print("============carScript.GameOverFail();===============");
        //   carScript.GameOverFail();
        return true;
    }

    public bool DeteIfAllRopeIsBroken()
    {
        
        if (transform.childCount > 0)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                if (!transform.GetChild(i).gameObject.GetComponent<RopeBreak>().IsBroken) { return false; }
            }
        }
        //print("============carScript.GameOverFail();===============");
     //   carScript.GameOverFail();
        return true;
    }

    public void ResetLevel()
    {
        MaxRopes = 4;
        for (int i = 0; i < TheRopes.Count; i++)
        {
            GameObject.Destroy(TheRopes[i].gameObject);
        }
        for (int i = 0; i < TheRopes2.Count; i++)
        {
            GameObject.Destroy(TheRopes2[i].gameObject);
        }
        TheRopes.Clear();
        TheRopes2.Clear();
        CurLength = 0;

        int count = GameObject.FindGameObjectsWithTag("Rod").Length;

        switch (count)
        {
            case 2:
                AllLength = 20;
                break;
            case 3:
                AllLength = 40;
                break;
            case 4:
                AllLength = 60;
                break;
            case 5:
                AllLength = 80;
                break;
            default:
                AllLength = 100;
                break;
                
        }

        
    }

    public bool IsOk(int length)
    {
        return AllLength - CurLength - length >= 0;
    
    }


    public void CreatDragableRope(Transform position)
    {
        GameObject go = Instantiate(Prefab, position.position + new Vector3(0, 1f, 0),Quaternion.identity, transform);
        go.transform.GetComponentInChildren<ObjectDragger>().AnchorStump = position;
        TheRopes.Add(go);
        TheRopes2.Add(go);
        go.transform.GetComponentInChildren<ObjectDragger>().MouseDown();
    }
   

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButtonDown(0)&&Selectable)
        {
            if (Input.GetMouseButton(0))//�ж��������Ƿ񱻵���
            {
                // ����һ�����λ��Ϊ���λ�õ�����
                Ray rays = Camera.main.ScreenPointToRay(Input.mousePosition);
                //�������Ի�ɫ�ı�ʾ����
                //Debug.DrawRay(rays.origin, rays.direction * 100, Color.yellow);
                //����һ��RayCast�������ڴ洢������Ϣ
                RaycastHit hit;
                Transform currentObject;

                //������������Ͷ���ȥ����������Ϣ�洢��hit��rays, out hit,Mathf.Infinity,3
                if (Physics.Raycast(rays, out hit, Mathf.Infinity, 1 << LayerMask.NameToLayer("Rod")))
                {

                    //��ȡ�����������Ķ���transfrom����
                    currentObject = hit.transform;
                    if (currentObject.CompareTag("Rod"))
                    {
                        CreatDragableRope(currentObject);

                        Selectable=false;
                    }

                }
       //         Debug.DrawLine(rays.origin, hitInfo1.point, Color.red);

            }
            
        }
    }


    void OnEnable()
    {
        solver.OnCollision += Solver_OnCollision;
    }

    void OnDisable()
    {
        solver.OnCollision -= Solver_OnCollision;
    }
    public int LinedATA = 0;
    public int VecotInt = 18;
    public bool isDuan= false;  //�ж��Ƿ����
    public float Linetime;
    public ObiSolver.ParticleInActor pac;
    void Solver_OnCollision(object sender, Obi.ObiSolver.ObiCollisionEventArgs e)
    {
        var world = ObiColliderWorld.GetInstance();



        // just iterate over all contacts in the current frame:
        foreach (Oni.Contact contact in e.contacts)
        {
            // if this one is an actual collision:
            if (contact.distance < 0.01 )
            {
               
                ObiSolver.ParticleInActor pa = solver.particleToActor[solver.simplices[contact.bodyA]];
                ObiColliderBase col = world.colliderHandles[contact.bodyB].owner;
    
                if (col != null&& col.gameObject.CompareTag("Car"))
                {

                    if (TheRopes.Count+1 >= LinedATA)
                    {
                       VecotInt = 500;
                    }
                    else if (TheRopes.Count+1 < LinedATA)
                    {

                        VecotInt = 2;
                    }
                    //       Debug.LogError(pa.actor.gameObject.GetComponent<ObiRope>().CalculateLength() + "===" + 2f * pa.actor.gameObject.GetComponent<RopeBreak>().deployedLength);
                    if (pa.actor.gameObject.GetComponent<ObiRope>().CalculateLength()>(VecotInt + pa.actor.gameObject.GetComponent<RopeBreak>().deployedLength))
                    {
                           pa.actor.gameObject.GetComponent<RopeBreak>().RandomCut();         //���Ѵ���
                       
                    }

                    Linetime += Time.deltaTime;
                    if (Linetime >=1.5f) {
                        Linetime = 0;
                        pac = pa;
                        LineManager();
                    }
                }
            }
        }

    }

    public void LineManager() {
        if (isDuan)
        {
            if (TheRopes.Count > 1)
            {  //ȷ����֤��������
                int i = Random.Range(1, 5);
                if (i == 1)
                {
                    print("ˢ��");
                    if (TheRopes.Count == 1)
                    {

                        return;
                    }
                    else if (TheRopes.Count > 1)
                    {
                        TheRopes.Remove(pac.actor.gameObject);
                        pac.actor.gameObject.GetComponent<RopeBreak>().RandomCut();         //���Ѵ���
                
                    }
                }
            }
        }
    }
}
