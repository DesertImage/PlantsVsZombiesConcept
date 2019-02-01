using UniRx;

namespace PlantsVsZombies.Settings
{
    public static class GameSettings
    {
        #region MUSIC/SOUND

        public static ReactiveProperty<bool> SoundEnabled = new BoolReactiveProperty();
        public static ReactiveProperty<float> SoundVolume = new FloatReactiveProperty();

        public static ReactiveProperty<bool> MusicEnabled = new BoolReactiveProperty();
        public static ReactiveProperty<float> MusicVolume = new FloatReactiveProperty();


        #endregion
    }
}