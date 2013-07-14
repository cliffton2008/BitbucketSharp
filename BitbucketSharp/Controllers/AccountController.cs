﻿using System.Collections.Generic;
using BitbucketSharp.Models;

namespace BitbucketSharp.Controllers
{
    /// <summary>
    /// A controller dedicated to the actions for the user logged in!
    /// </summary>
    public class AccountController : UserController
    {
        /// <summary>
        /// Email for this user
        /// </summary>
        public EmailController Emails { get; private set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="client"></param>
        public AccountController(Client client)
            : base(client, client.Username)
        {
            Emails = new EmailController(client);
        }

        /// <summary>
        /// Requests the repositories that the current logged in user is following
        /// </summary>
        /// <returns>A list of repositories</returns>
        public List<RepositoryDetailedModel> GetRepositories(bool forceCacheInvalidation = false)
        {
            return Client.Get<List<RepositoryDetailedModel>>("user/follows", forceCacheInvalidation);
        }

        /// <summary>
        /// Gets the privileges of user
        /// </summary>
        public AccountPrivileges GetPrivileges(bool forceCacheInvalidation = false)
        {
            return Client.Get<AccountPrivileges>("user/privileges", forceCacheInvalidation);
        }
    }
}
