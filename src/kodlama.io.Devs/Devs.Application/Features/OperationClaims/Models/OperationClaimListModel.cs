using Core.Persistence.Paging;
using Devs.Application.Features.OperationClaims.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs.Application.Features.OperationClaims.Models
{
    public class OperationClaimListModel:BasePageableModel
    {
        public OperationClaimListDto[]Items { get; set; }
    }
}
