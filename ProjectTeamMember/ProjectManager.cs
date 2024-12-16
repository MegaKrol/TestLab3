using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTeamMember
{
    public class ProjectManager
    {
        private readonly Dictionary<string, List<TeamMember>> _projects = new Dictionary<string, List<TeamMember>>();

        public void AddTeamMember(string projectName, TeamMember member)
        {
            if (!_projects.ContainsKey(projectName))
            {
                _projects[projectName] = new List<TeamMember>();
            }

            if (_projects[projectName].Any(m => m.MemberId == member.MemberId))
            {
                throw new InvalidOperationException("Людина з таким айді вже існує!");
            }

            _projects[projectName].Add(member);
        }

        public void RemoveTeamMember(string projectName, int memberId)
        {
            if (!_projects.ContainsKey(projectName))
            {
                throw new KeyNotFoundException("Проєкт не знайдено");
            }

            var member = _projects[projectName].FirstOrDefault(m => m.MemberId == memberId);
            if (member == null)
            {
                throw new InvalidOperationException("Члена команди з таким айді не знайдено!");
            }

            _projects[projectName].Remove(member);
        }

        public List<TeamMember> GetTeamMembers(string projectName)
        {
            if (!_projects.ContainsKey(projectName))
            {
                throw new KeyNotFoundException("Project not found.");
            }

            return _projects[projectName];
        }
    }
}
