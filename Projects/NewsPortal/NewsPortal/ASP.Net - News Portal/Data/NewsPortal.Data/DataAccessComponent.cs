﻿using System;
using System.Data;
using System.Configuration;
using System.Text.RegularExpressions;

namespace NewsPortal.Data
{
    /// <summary>
    /// Base data access component class.
    /// </summary>
    public abstract class DataAccessComponent
    {
        protected const string CONNECTION_NAME = "name=NewsPortalEntities";

    }
}