﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MelonLoader;
using UnityEngine;

namespace AuthorableModifiers
{
    public class SpeedChange : Modifier
    {
        private RampMode rampmode = RampMode.Up;
        private bool tempoRampActive = false;
        private bool isOST = false;
        public SpeedChange(ModifierType _type, float _startTick, float _endTick, float _amount)
        {
            type = _type;
            startTick = _startTick;
            endTick = _endTick;
            amount = _amount;
            isOST = SongDataHolder.I.songData.IsCoreSong() || SongDataHolder.I.songData.dlc;
        }

        public override void Activate()
        {
            base.Activate();               
            MelonCoroutines.Start(TempoRamp());
        }

        public override void Deactivate()
        {
            base.Deactivate();
            if(amount >= 1f && !isOST) ScoreKeeper.I.GetScoreValidity();
            //MelonCoroutines.Start(TempoRamp());
        }

        public IEnumerator TempoRamp()
        {
            //float progress = 0;
            float oldSpeed = AudioDriver.I.GetSpeed();
            while (active)
            {
                float percentage = ((AudioDriver.I.mCachedTick - startTick) * 100f) / (endTick - startTick);
                float currentSpeed = Mathf.Lerp(oldSpeed, amount, percentage / 100f);
                AudioDriver.I.SetSpeed(currentSpeed);
                /*if (rampmode == RampMode.Up)
                {
                    AudioDriver.I.SetSpeed(currentSpeed);
                    if ((amount > 1f && AudioDriver.I.mSpeed >= amount) || (amount < 1f && AudioDriver.I.mSpeed <= amount))
                    {
                        AudioDriver.I.SetSpeed(amount);
                        tempoRampActive = false;
                        rampmode = RampMode.Down;
                        yield break;
                    }
                }
                else
                {
                    AudioDriver.I.SetSpeed(Mathf.Lerp(amount, 1f, progress / 200f));
                    if ((amount < 1f && AudioDriver.I.mSpeed >= 1f) || (amount > 1f && AudioDriver.I.mSpeed <= 1f))
                    {
                        AudioDriver.I.SetSpeed(1f);
                        tempoRampActive = false;
                        base.Deactivate();
                        yield break;
                    }
                }*/
                if (amount >= 1f && !isOST) ScoreKeeper.I.GetScoreValidity();
                //progress++;
                yield return new WaitForSecondsRealtime(Time.unscaledDeltaTime);
            }
            
        }

        private enum RampMode
        {
            Up,
            Down
        }
    }
}
