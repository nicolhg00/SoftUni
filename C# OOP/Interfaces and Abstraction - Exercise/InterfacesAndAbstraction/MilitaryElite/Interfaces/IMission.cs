﻿using MilitaryElite.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Interfaces
{
    public interface IMission
    {
        public string CodeName { get; }
        public MissionStateEnum MissionState { get; }

        public void CompleteMission();
    }
}
