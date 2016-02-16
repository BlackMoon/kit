// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DefaultRegistry.cs" company="Web Advanced">
// Copyright 2012 Web Advanced (www.webadvanced.com)
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0

// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;
using Kit.Dal;
using Kit.Dal.Oracle;

namespace WebClient.DependencyResolution {
    using StructureMap.Configuration.DSL;
    using StructureMap.Graph;
	
    public class DefaultRegistry : Registry {
        #region Constructors and Destructors

        public DefaultRegistry() {
            Scan(
                scan => {
                    scan.TheCallingAssembly();
                    scan.WithDefaultConventions();
					scan.With(new ControllerConvention());
                });
            
            For<IDbManager>().Use(() => BuildDbManager());
        }

        private IDbManager BuildDbManager()
        {
            IDbManager dbManager = null;

            ConnectionStringSettings cssDefault = ConfigurationManager.ConnectionStrings["Default"];
            if (cssDefault != null)
            {
                Type t = DbManagerFactory.GetDbManagerType(cssDefault.ProviderName);

                ClaimsPrincipal cp = HttpContext.Current.User as ClaimsPrincipal;
                if (cp != null)
                {
                    ClaimsIdentity claimsIdentity = (ClaimsIdentity)cp.Identity;

                    // Access claims
                    string user = null, passwd = null, server = null;
                    foreach (Claim claim in claimsIdentity.Claims)
                    {
                        switch (claim.Type)
                        {
                            case ClaimTypes.Name:
                                user = claim.Value;
                                break;

                            case "Password":
                                passwd = claim.Value;
                                break;

                            case "Server":
                                server = claim.Value;
                                break;
                        }
                    }

                    string connStr = "Data Source=" + server + ";User Id=" + user + ";Password=" + passwd;
                    dbManager = (IDbManager) Activator.CreateInstance(t, connStr);
                }
            }

            return dbManager;
        }

        #endregion
    }
}