﻿using System.Collections.Generic;
using System.Threading.Tasks;
using NextGenSoftware.OASIS.API.Core.Helpers;

namespace NextGenSoftware.OASIS.API.Core.Interfaces.STAR
{
    public interface IPlanetCore : ICelestialBodyCore
    {
        IPlanet Planet { get; set; }

        OASISResult<IEnumerable<IMoon>> GetMoons(bool refresh = true, bool loadChildren = true, bool recursive = true, int maxChildDepth = 0, bool continueOnError = true, int version = 0);
        Task<OASISResult<IEnumerable<IMoon>>> GetMoonsAsync(bool refresh = true, bool loadChildren = true, bool recursive = true, int maxChildDepth = 0, bool continueOnError = true, int version = 0);
        OASISResult<IEnumerable<IMoon>> SaveMoons(bool saveChildren = true, bool recursive = true, int maxChildDepth = 0, bool continueOnError = true);
        Task<OASISResult<IEnumerable<IMoon>>> SaveMoonsAsync(bool saveChildren = true, bool recursive = true, int maxChildDepth = 0, bool continueOnError = true);
    }
}