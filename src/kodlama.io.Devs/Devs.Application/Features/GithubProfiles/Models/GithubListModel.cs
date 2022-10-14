using Core.Persistence.Paging;
using Devs.Application.Features.GithubProfiles.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs.Application.Features.GithubProfiles.Models
{
    public class GithubListModel:BasePageableModel
    {
        public GithubListDto[] Items { get; set; }
    }
}
