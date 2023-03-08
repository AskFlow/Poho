using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escape_Controller : MonoBehaviour
{
    [SerializeField] private NavAgentMover mover = null;
    [SerializeField] private float displacementDist = 5f;
    [SerializeField] private float repelsDist = 1f;
    [SerializeField] private float repelsSpeed = 1000f;
    private Collider player = null;
    public float teleportCooldown;
    public float repelsCooldown;
    float lastTeleport;
    float lastRepels;

    private bool Teleport(Vector3 pos) 
    {
        if (Time.time-lastTeleport<teleportCooldown)
        {
            return false;
        }
        Debug.Log("Teleport");
        lastTeleport = Time.time;
        mover.Teleport(pos);
        return true;
    }

    private bool Repousser() 
    {
        if (Time.time-lastRepels<repelsCooldown)
        {
            return false;
        }
        if (player.gameObject.GetComponent<NavAgentMover>()) {
            Vector3 normDir = (transform.position - player.transform.position).normalized;
            normDir.y = 0;
            normDir.z = 0;
            if (transform.position.x - player.transform.position.x >= 0) {
                normDir.x = 1;
            } else {
                normDir.x = -1;
            }
            if (player.transform.position.x > (transform.position.x - 3) && player.transform.position.x < (transform.position.x + 3)) {
                Debug.Log("Repousse");
                lastRepels = Time.time;
                player.gameObject.GetComponent<NavAgentMover>().MoveToPos(player.transform.position - (normDir * repelsDist), repelsSpeed);
                return true;                  
            } else {
                return false;
            }
        } else {
            return false;
        }
    }

    private Color origColor;
    private void SetOriginalColor()
    {
        var rend = GetComponentInChildren<Renderer>();
        origColor = rend.material.color;
    }

    private void ChangeColor(Color color)
    {
        var rend = GetComponentInChildren<Renderer>();
        rend.material.color = color;
    }

    public void BecomePreyOf(Collider player)
    {
        //print("ENNEMY 2 :: " + player + " started chasing " + name);
        this.player = player;

        ChangeColor(Color.yellow);
    }

    private void StopBeingChased() 
    {
        player = null;

        ChangeColor(origColor);
    }

    public int playerLevel() => 0;

    void Start() 
    {
        SetOriginalColor();

        lastTeleport = Time.time-teleportCooldown;
        lastRepels = Time.time-repelsCooldown;
    }

    private void Update()
    {
        if (player)
            Evadeplayer();
        else
            Idle();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        //If it looks like it's coming toward me
        //if (Vector3.Dot(other.transform.forward.normalized, transform.position.normalized) > .5f)
            BecomePreyOf(other);
    }

    private void OnTriggerExit(Collider other)
    {
        //if the exiting object is the player that was chasing me
        if (other.CompareTag("Player") && (player != null && other.transform == player.transform))
            Invoke("StopBeingChased", .5f);//this will happen after x seconds
            //CoroutineRunner.DelayedAction(() => StopBeingChased(), .5f);
    }

    private void Evadeplayer() 
    {
        Vector3 normDir = (player.transform.position - transform.position).normalized;
        normDir.y = 0;
        normDir.z = 0;
        if (player.transform.position.x - transform.position.x >= 0) {
            normDir.x = 1;
        } else {
            normDir.x = -1;
        }
        Repousser();
        bool tp = Teleport(transform.position - (normDir * displacementDist));
        if (!tp)
        {
            mover.MoveToPos(transform.position - (normDir * displacementDist));
        }
    }

    private float nextCluckTime = 0f;
    private float nextMoveTime = 0f;
    const float MIN_BTWN_CLUCKS = 2.0f;
    const float MAX_BTWN_CLUCKS = 12.0f;
    const float MIN_BTWN_MOVES = 2.0f;
    private void Idle() 
    {
        if (mover.HasArrived && PassedTime(nextMoveTime))
        {
            nextMoveTime = SetFutureRandomTime(MIN_BTWN_MOVES, 5f);
            //mover.MoveToPos(Vec3_Utils.PlaceNearMe(transform, 12f));
        }

        if (PassedTime(nextCluckTime)) 
        {
            nextCluckTime = SetFutureRandomTime(MIN_BTWN_CLUCKS, MAX_BTWN_CLUCKS);
            /*
            print(
                ProbablityReached(.05f) ? 
                name + ": Cluck" : 
                name + ": Just clucking around");
            */
        }
    }
    //Making stuff easier to read and reproduce
    private static bool ProbablityReached(float lowestForSuccess) => Random.Range(0f, 1f) >= lowestForSuccess;
    private static bool PassedTime(float time) => Time.time >= time;
    private static float SetFutureRandomTime(float min, float max) => Time.time + Random.Range(min, max);
}
