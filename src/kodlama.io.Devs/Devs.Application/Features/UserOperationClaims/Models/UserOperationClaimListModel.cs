using Core.Persistence.Paging;
using Devs.Application.Features.UserOperationClaims.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs.Application.Features.UserOperationClaims.Models
{
    public class UserOperationClaimListModel : BasePageableModel
    {
        public UserOperationClaimListDto[] Items { get; set; }
    }
}
