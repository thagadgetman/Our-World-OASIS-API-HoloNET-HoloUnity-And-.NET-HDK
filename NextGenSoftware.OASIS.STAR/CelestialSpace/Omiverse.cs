﻿using System;
using System.Collections.Generic;
using NextGenSoftware.OASIS.API.Core.Enums;
using NextGenSoftware.OASIS.API.Core.Helpers;
using NextGenSoftware.OASIS.API.Core.Interfaces.STAR;
using NextGenSoftware.OASIS.STAR.CelestialBodies;
using NextGenSoftware.OASIS.STAR.Enums;
using NextGenSoftware.OASIS.STAR.EventArgs;

namespace NextGenSoftware.OASIS.STAR.CelestialSpace
{
    public class Omniverse : CelestialSpace, IOmiverse
    {
        private IOmniverseDimensions _dimensions = null;
        private List<IMultiverse> _multiverses = new List<IMultiverse>();

        //let's you jump between Multiverses/Dimensions.
        //public IGreatGrandSuperStar GreatGrandSuperStar { get; set; } = new GreatGrandSuperStar() 
        //{ 
        //    CreatedOASISType = new EnumValue<OASISType>(OASISType.STARCLI),
        //    Name = "GreatGrandSuperStar",
        //    Description = "GreatGrandSuperStar at the centre of the Omniverse (The OASIS). Can create Multiverses, Universes, Galaxies, SolarSystems, Stars, Planets (Super OAPPS) and moons (OAPPS)",
        //    ParentOmniverse = this,
        //    ParentOmniverseId = this.Id

        //}; 

        public IGreatGrandSuperStar GreatGrandSuperStar { get; set; }
       
        public IOmniverseDimensions Dimensions
        {
            get
            {
                return _dimensions;
            }
            set
            {
                _dimensions = value;
                RegisterAllCelestialSpaces();
            }
        }

        public List<IMultiverse> Multiverses
        {
            get
            {
                return _multiverses;
            }
            set
            {
                _multiverses = value;
                RegisterAllCelestialSpaces();
            }
        }

        public Omniverse() : base(HolonType.Omniverse) 
        {
            Init();
        }

        public Omniverse(Guid id) : base(id, HolonType.Omniverse) 
        {
            Init();
        }

        public Omniverse(Dictionary<ProviderType, string> providerKey) : base(providerKey, HolonType.Omniverse) 
        {
            Init();
        }

        private void Init()
        {
            this.Name = "The OASIS Omniverse";
            this.Description = "The OASIS Omniverse that contains everything else including Multiverses and dimensions 8-12, each of which contain it's own SuperVerse that spams all Multiverses/Universes & Dimensions (1-12).";
            CreatedOASISType = new EnumValue<OASISType>(OASISType.STARCLI);

            GreatGrandSuperStar = new GreatGrandSuperStar()
            {
                CreatedOASISType = new EnumValue<OASISType>(OASISType.STARCLI),
                Name = "GreatGrandSuperStar",
                Description = "GreatGrandSuperStar at the centre of the Omniverse (The OASIS). Can create Multiverses.",
                //Description = "GreatGrandSuperStar at the centre of the Omniverse (The OASIS). Can create Multiverses, Universes, Galaxies, SolarSystems, Stars, Planets (Super OAPPS) and moons (OAPPS)",
                ParentOmniverse = this,
                ParentOmniverseId = this.Id,
                ParentCelestialSpace = this,
                ParentCelestialSpaceId = this.Id,
                ParentHolon = this,
                ParentHolonId = this.Id
            };

            //GreatGrandSuperStar.OnCelestialBodySaved += GreatGrandSuperStar_OnCelestialBodySaved;
            base.RegisterCelestialBodies(new List<ICelestialBody>() { this.GreatGrandSuperStar }, false);

            ParentGreatGrandSuperStar = GreatGrandSuperStar;
            ParentGreatGrandSuperStarId = GreatGrandSuperStar.Id;
            ParentCelestialBody = GreatGrandSuperStar;
            ParentCelestialBodyId = GreatGrandSuperStar.Id;
            ParentHolon = GreatGrandSuperStar;
            ParentHolonId = GreatGrandSuperStar.Id;

            Dimensions = new OmniverseDimensions(this);

            //Add a default multiverse.
            Multiverse defaultMultiverse = new Multiverse(this)
            {
                Name = "Our Multiverse (Default Multiverse)",
                Description = "Our Multiverse that our Milky Way Galaxy belongs to, the default Multiverse. It contains dimensions 1-7, each of which contain it's own Universe."
            };

            defaultMultiverse.GrandSuperStar.Description = "The GrandSuperStar at the centre of our Multiverse/Universe. Can create Universes within it's parent Multiverse.";
            Multiverses.Add(defaultMultiverse); //NOTE: Adding items to a collection does not trigger the Property Setter.
            base.RegisterCelestialSpaces(this.Multiverses, false);
        }

        //private void GreatGrandSuperStar_OnCelestialBodySaved(object sender, API.Core.Events.CelestialBodySavedEventArgs e)
        //{
        //    STAR.ShowStatusMessage(e);
        //    GreatGrandSuperStar.OnCelestialBodySaved -= GreatGrandSuperStar_OnCelestialBodySaved;
        //}

        private void RegisterAllCelestialSpaces()
        {
            base.UnregisterAllCelestialSpaces();
            base.RegisterCelestialSpaces(new List<ICelestialSpace>() { Dimensions.EighthDimension, Dimensions.NinthDimension, Dimensions.TenthDimension, Dimensions.EleventhDimension, Dimensions.TwelfthDimension }, false);
            base.RegisterCelestialSpaces(this.Multiverses, false);
        }
    }
}