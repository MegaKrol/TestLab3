using ProjectTeamMember;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTeamMemberTest
{
    public class ProjectManagerTests
    {
        private ProjectManager _projectManager = new ProjectManager();

        [Fact]
        public void Initialization()
        {
            _projectManager = new ProjectManager();
        }

        [Fact]
        public void CreateTeamMember_ShouldInitializeCorrectly()
        {
            var member = new TeamMember("Krasan Danylo", 1);
            Assert.Equal("Krasan Danylo", member.Name);
            Assert.Equal(1, member.MemberId);
        }

        [Fact]
        public void AddTeamMember_ShouldAddMemberToProject()
        {
            var member = new TeamMember("Olexander Hizun", 1);
            _projectManager.AddTeamMember("TA-22", member);

            var members = _projectManager.GetTeamMembers("TA-22");
            //Assert.Equal(1, members.Count);
           //Assert.Equal("John Doe", members[0].Name);
            Assert.Contains(member, members);
        }

        [Fact]
        public void AddTeamMemberWithDuplicateId_ShouldThrowException()
        {
            var member1 = new TeamMember("Olexander Hizun", 1);
            var member2 = new TeamMember("Olexander Melnik", 1);

            _projectManager.AddTeamMember("TA-22", member1);
            Assert.Throws<InvalidOperationException>(() => _projectManager.AddTeamMember("TA-22", member2));
        }

        [Fact]
        public void RemoveTeamMember_ShouldRemoveMemberFromProject()
        {
            var member = new TeamMember("Maria Stelmah", 1);
            _projectManager.AddTeamMember("TA-22", member);

            var members = _projectManager.GetTeamMembers("TA-22");

            Assert.Equal(1, members.Count);

            _projectManager.RemoveTeamMember("TA-22", 1);

            members = _projectManager.GetTeamMembers("TA-22");
            Assert.Equal(0, members.Count);
        }

        [Fact]
        public void RemoveTeamMember_ShouldThrowException_WhenMemberNotFound()
        {
            var member = new TeamMember("Olexander Melnik", 1);
            _projectManager.AddTeamMember("TA-22", member);

            Assert.Throws<InvalidOperationException>(() => _projectManager.RemoveTeamMember("TA-22", 99));
        }

        [Fact]
        public void GetTeamMembers_ShouldReturnListOfMembers()
        {
            var member1 = new TeamMember("MegaMaxik", 1);
            var member2 = new TeamMember("Dmytro Solomko", 2);
            var member3 = new TeamMember("Serhiy Bocion", 3);
            var member4 = new TeamMember("Artem Alekseev", 4);
            var member5 = new TeamMember("Serbenivskiy Myron", 5);

            _projectManager.AddTeamMember("TA-22", member1);
            _projectManager.AddTeamMember("TA-22", member2);
            _projectManager.AddTeamMember("TA-22", member3);
            _projectManager.AddTeamMember("TA-22", member4);
            _projectManager.AddTeamMember("TA-22", member5);


            var members = _projectManager.GetTeamMembers("TA-22");

            Assert.Equal(5, members.Count);
            Assert.Equal("MegaMaxik", members[0].Name);
            Assert.Equal("Dmytro Solomko", members[1].Name);
            Assert.Equal("Serhiy Bocion", members[2].Name);
            Assert.Equal("Artem Alekseev", members[3].Name);
            Assert.Equal("Serbenivskiy Myron", members[4].Name);
        }

        [Fact]
        public void GetTeamMembers_ShouldThrowException_WhenProjectNotFound()
        {
            Assert.Throws<KeyNotFoundException>(() => _projectManager.GetTeamMembers("NonExistentProject"));
        }
    }
}
