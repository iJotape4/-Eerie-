using System.Collections;

public interface IPatrolAction : IWalkAction, IPlayerDetecter
{
   public void Patrol();
   public new bool DetectPlayer();
   public IEnumerator GoToNextPoint(int patrolPoint);
}
