using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs.Domain.Entities
{
    public class Technology:Entity
    {
        public int ProgrammingLanguageId { get; set; }
        public string Name { get; set; }
        public virtual ProgrammingLanguage ProgrammingLanguage { get; set; }

        public Technology()
        {
        }

        public Technology(int programmingLanguageId, string name, int id)
        {
            ProgrammingLanguageId = programmingLanguageId;
            Name = name;
            Id = id;
        }
    }
}
