﻿using NextGenSoftware.OASIS.API.Core;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NextGenSoftware.OASIS.API.Providers.BlockStackOASIS
{
    public class BlockStackOASIS : OASISStorageBase, IOASISStorage, IOASISNET
    {
        public BlockStackOASIS()
        {
            this.ProviderName = "BlockStackOASIS";
            this.ProviderDescription = "BlockStack Provider";
            this.ProviderType = ProviderType.BlockStackOASIS;
            this.ProviderCategory = ProviderCategory.StorageAndNetwork;
        }

        public List<IHolon> GetHolonsNearMe(HolonType Type)
        {
            throw new NotImplementedException();
        }

        public List<IPlayer> GetPlayersNearMe()
        {
            throw new NotImplementedException();
        }

        public override Task<IProfile> LoadProfileAsync(string providerKey)
        {
            throw new NotImplementedException();
        }

        public override Task<IProfile> LoadProfileAsync(Guid Id)
        {
            throw new NotImplementedException();
        }

        public override Task<IProfile> LoadProfileAsync(string username, string password)
        {
            throw new NotImplementedException();
        }

        public override Task<IProfile> SaveProfileAsync(IProfile profile)
        {
            throw new NotImplementedException();
        }
    }
}