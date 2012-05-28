﻿using System.Collections.Generic;
using BitBucketSharp.Models;

namespace BitBucketSharp.Controllers
{
    /// <summary>
    /// A controller dedicated to the actions for the user logged in!
    /// </summary>
    public class AccountController : Controller
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
            : base(client)
        {
            Emails = new EmailController(client);
        }

        /// <summary>
        /// Requests the repositories that the current logged in user is following
        /// </summary>
        /// <returns>A list of repositories</returns>
        public List<RepositoryDetailedModel> GetRepositories()
        {
            return Client.Get<List<RepositoryDetailedModel>>("user/follows");
        }

    }
}
