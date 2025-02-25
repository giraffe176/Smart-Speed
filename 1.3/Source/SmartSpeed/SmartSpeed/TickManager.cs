using System;
using Verse;

namespace SmartSpeed.Detouring
{
    internal class TickManager
    {
        public float TickRateMultiplier
        {
            get
            {
                var slower = Find.TickManager.slower;
                var currTimeSpeed = Find.TickManager.CurTimeSpeed;

                if (slower.ForcedNormalSpeed)
                {
                    if (currTimeSpeed == TimeSpeed.Paused)
                    {
                        return 0f;
                    }
                    switch (AcSmartSpeed.currSetting)
                    {
                        case AcSmartSpeed.Option.Slow:
                            return 0.5f;
                        case AcSmartSpeed.Option.Normal:
                            return 1f;
                        case AcSmartSpeed.Option.Fast:
                            return 2f;
                        case AcSmartSpeed.Option.Half:
                            return TickRate(currTimeSpeed) / 2f;
                        case AcSmartSpeed.Option.Ignore:
                            return TickRate(currTimeSpeed);
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }
                return TickRate(currTimeSpeed);
            }
        }
        private float TickRate(TimeSpeed currTimeSpeed)
        {
            switch ((int)currTimeSpeed)
            {
                case 0:
                    return 0f;
                case 1:
                    return Settings.onespeed;
                case 2:
                    return Settings.twospeed;
                case 3:
                    if (Current.Game.CurrentMap == null)
                    {
                        if (Settings.Nomapselected == true) { return 150f; }
                    }
                    if (this.NothingHappeningInGame())
                    {if (Settings.Nothinghappening == true) { return 12f; }
                    }
                    return Settings.threespeed;;
                case 4:
                    if (Current.Game.CurrentMap == null)
                    {
                            if (Settings.Nomapselected == true) { return 250f; }
                    }
                    return Settings.fourspeed;
                default:
                    return -1f;
            }
        }

        private bool NothingHappeningInGame()
        {
            Log.Message("This message never show up");
            return true;
        }
    }
}
