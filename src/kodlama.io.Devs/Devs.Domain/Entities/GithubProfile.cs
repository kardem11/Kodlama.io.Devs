using Core.Persistence.Repositories;
using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Devs.Domain.Entities
{
    public class GithubProfile:Entity
    {
        public int UserId { get; set; }
        public string Github { get; set; }
        public virtual User? User { get; set; }

        public GithubProfile(int Id, int userId, string github)
        {
            Id = Id;
            UserId = userId;
            Github = github;
        }

        public GithubProfile()
        {
        }
    }

}
