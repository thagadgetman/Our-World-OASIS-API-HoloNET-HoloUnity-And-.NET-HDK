﻿using NextGenSoftware.OASIS.API.Core.Enums;
using NextGenSoftware.OASIS.API.Core.Helpers;
using System.Threading.Tasks;
using static NextGenSoftware.OASIS.API.Core.Events.Events;

namespace NextGenSoftware.OASIS.API.Core.Interfaces.STAR
{
    public interface ICelestialHolon : IHolon
    {
        // public int Dimension { get; set; } //TODO: May need this?
        //event HolonLoaded OnHolonLoaded;
        //event HolonsLoaded OnHolonsLoaded;
        //event HolonSaved OnHolonSaved;
        event Initialized OnInitialized;
        
        public SpaceQuadrantType SpaceQuadrant { get; set; }
        public int SpaceSector { get; set; }
        public float SuperGalacticLatitute { get; set; }
        public float SuperGalacticLongitute { get; set; }
        public float GalacticLatitute { get; set; }
        public float GalacticLongitute { get; set; }
        public float HorizontalLatitute { get; set; }
        public float HorizontalLongitute { get; set; }
        public float EquatorialLatitute { get; set; }
        public float EquatorialLongitute { get; set; }
        public float EclipticLatitute { get; set; }
        public float EclipticLongitute { get; set; }
        public int Size { get; set; }
        public int Radius { get; set; }
        public int Age { get; set; }
        public int Temperature { get; set; }
        GenesisType GenesisType { get; set; }
        bool IsInitialized { get; }

       // abstract Task<OASISResult<ICelestialHolon>> SaveAsync<T>(bool saveChildren = true, bool continueOnError = true) where T : ICelestialHolon, new();
       // abstract OASISResult<ICelestialHolon> Save<T>(bool saveChildren = true, bool continueOnError = true) where T : ICelestialHolon, new();
       // abstract Task<OASISResult<IHolon>> LoadAsync(bool loadChildren = true, bool continueOnError = true);
       // abstract OASISResult<IHolon> Load(bool loadChildren = true, bool continueOnError = true);
       // protected abstract Task InitializeAsync();
       // protected abstract void Initialize();
    }
}