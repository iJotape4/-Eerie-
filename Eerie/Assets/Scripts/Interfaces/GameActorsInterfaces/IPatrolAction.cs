using System.Collections;

public interface IPatrolAction : IWalkAction, IPlayerDetecter
{
   public void Patrol();
   public new void DetectPlayer();
   public IEnumerator GoToNextPoint(int patrolPoint);
}
