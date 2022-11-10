namespace Enemies
{
    public abstract class StaticEnemy : Enemy, IPlayerDetecter, IProjectilesSpawner
    {
        public abstract void DetectPlayer();
        public abstract void SpawnAProjectile();
    }
}
