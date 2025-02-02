﻿using NextGenSoftware.OASIS.API.Providers.SOLANAOASIS.Entities.DTOs.Common;

namespace NextGenSoftware.OASIS.API.Providers.SOLANAOASIS.Infrastructure.Entities.DTOs.Requests
{
    public sealed class MintNftRequest : BaseExchangeRequest
    {
        public int MintDecimals { get; set; } = 2;
    }
}