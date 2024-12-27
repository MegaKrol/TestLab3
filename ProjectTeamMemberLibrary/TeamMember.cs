using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTeamMember
{
    public class TeamMember
    {
        public string Name { get; set; }
        public int MemberId { get; set; }

        public TeamMember(string name, int memberId)
        {
            Name = name;
            MemberId = memberId;
        }
    }
}
