using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Devs.Application.Features.GithubProfiles.Dtos
{
    public class DeletedGithubDto
    {
        public int Id { get; set; }
        public string GithubUrl { get; set; }
    }
}
