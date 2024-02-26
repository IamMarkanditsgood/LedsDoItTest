using Entities.Cathcable;
using Level.InitScriptableObjects.Catchable;

namespace Level.Creators
{
    public abstract class BasicCatchableCreator
    {
        public abstract void CreateObstacle();

        protected ObstacleConfig GetConfig(ObstacleTypes type)
        {
            ObstacleConfig obstacleConfig = LevelData.instance.ObstacleConfigList.ObstacleConfigs[type];
            return obstacleConfig;
        }
    }
}