using Framework.Timer;

namespace DesertImage.Pools
{
    public class PoolTimers : Pool<Timer>
    {
        protected override Timer CreateInstance(Timer objInstance)
        {
            var timer = new Timer();
            
            timer.onCreate();
            
            return  timer;
        }

        protected override void ReturnInstance(Timer objInstance)
        {
            base.ReturnInstance(objInstance);
            
            objInstance.returnToPool();
        }
    }
}