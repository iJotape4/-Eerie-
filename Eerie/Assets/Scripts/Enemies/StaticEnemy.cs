namespace Enemies
{
    public abstract class StaticEnemy : Enemy, IPlayerDetecter, IProjectilesSpawner
    {
        public abstract bool DetectPlayer();
        public abstract void SpawnAProjectile();
    }
}
