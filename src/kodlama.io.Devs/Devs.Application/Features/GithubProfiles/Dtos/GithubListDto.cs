using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs.Application.Features.GithubProfiles.Dtos
{
    public class GithubListDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string GithubUrl { get; set; }
    }
}
