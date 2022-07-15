using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHasLocomotionData
{
    public LocomotionData GetData { get; }
}

// 로코모션, 즉 뜀박질 애니 및 상태를 실행할때 필요한 데이터들은 무엇이 있는가
[Serializable]
public class LocomotionData
{
    public int currentIndex;
    public List<Transform> Pathes;
    public System.Action OnArrived;

    public Transform GetCurrentTransform()
    {
        if (currentIndex < 0 || currentIndex >= Pathes.Count)
            return null;

        return Pathes[currentIndex];
    }

    void IncreaseCurrentIndex()
    {
        currentIndex++;
        if(currentIndex >= Pathes.Count)
        {
            // 목적지에 도달
            if (OnArrived != null)
                OnArrived.Invoke();

            OnArrived = null;
            currentIndex = Pathes.Count - 1;
        }
    }

    public void TryCheckDestination(Vector3 position)
    {
        var currentTr = GetCurrentTransform();
        var dirTo = currentTr.position - position;
        if(dirTo.magnitude <= 0.1f)
        {
            // 도착
            IncreaseCurrentIndex();
        }
    }
}

public class Locomotion : StateMachineBehaviour
{
    public float speed;

    LocomotionData data;
    bool isInited = false;
    Rigidbody rd2d;

    private void Init(Animator animator)
    {
        if (isInited)
            return;
        isInited = true;

        IHasLocomotionData ihas = animator.GetComponentInParent<IHasLocomotionData>();
        if(ihas != null)
        {
            data = ihas.GetData;
        }

        rd2d = animator.GetComponent<Rigidbody>();
    }
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);

        // 초기화 호출해줌
        // 이 상태가 되었을 때
        Init(animator);
        LookAtDestination(animator);
    }

    private void LookAtDestination(Animator animator)
    {
        if (data == null)
            return;

        var destinationTr = data.GetCurrentTransform();
        if (destinationTr == null)
            return;

        animator.transform.LookAt(destinationTr, Vector3.up);
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateUpdate(animator, stateInfo, layerIndex);
        LookAtDestination(animator);

        if (rd2d == null)
            return;

        var nextPos = Vector3.MoveTowards(animator.transform.position, data.GetCurrentTransform().position, Time.fixedDeltaTime * speed);
        rd2d.MovePosition(nextPos);
        data.TryCheckDestination(animator.transform.position);
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateExit(animator, stateInfo, layerIndex);
        animator.SetBool("IsWalk", false);
        animator.SetBool("IsRun", false);
        animator.ResetTrigger("Z_Idle");
    }

    // OnStateEnter is called before OnStateEnter is called on any state inside this state machine
    //override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateUpdate is called before OnStateUpdate is called on any state inside this state machine
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called before OnStateExit is called on any state inside this state machine
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called before OnStateMove is called on any state inside this state machine
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateIK is called before OnStateIK is called on any state inside this state machine
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMachineEnter is called when entering a state machine via its Entry Node
    //override public void OnStateMachineEnter(Animator animator, int stateMachinePathHash)
    //{
    //    
    //}

    // OnStateMachineExit is called when exiting a state machine via its Exit Node
    //override public void OnStateMachineExit(Animator animator, int stateMachinePathHash)
    //{
    //    
    //}
}
