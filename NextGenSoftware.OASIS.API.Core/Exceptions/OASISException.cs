﻿using System;
using NextGenSoftware.OASIS.API.Core.Helpers;
using NextGenSoftware.OASIS.API.Core.Interfaces;

namespace NextGenSoftware.OASIS.API.Core.Exceptions
{
    // NOTE: ONLY USE IN VERY RARE CASES WHERE THE NORMAL OASISRESULT ERROR HANDLING IS NOT POSSIBLE.
    // EXCEPTIONS SHOULD BE EXCEPTIONAL! ;-)
    public class OASISException<T> : Exception where T : IHolon
    {
        public OASISException(string reason, OASISResult<T> result) : base()
        {
            Reason = reason;
            Result = result;
        }

        public string Reason { get; set; }
        public OASISResult<T> Result { get; set; }
    }
}