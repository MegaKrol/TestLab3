using ProjectTeamMember;

ProjectManager projectManager = new ProjectManager();

// Add team members to a project
try
{
    projectManager.AddTeamMember("TA-22", new TeamMember("Dmytro Solomko", 1));
    projectManager.AddTeamMember("TA-22", new TeamMember("Artem Alekseev", 2));
    projectManager.AddTeamMember("TA-21", new TeamMember("Maria", 3));

    Console.WriteLine("Team members added successfully.");
}
catch (Exception ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}

// Display team members in TA-22
try
{
    Console.WriteLine("\nTeam members in TA-22:");
    var teamA = projectManager.GetTeamMembers("TA-22");
    foreach (var member in teamA)
    {
        Console.WriteLine(member);
    }
}
catch (Exception ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}

// Remove a team member from TA-22
try
{
    projectManager.RemoveTeamMember("TA-22", 1);
    Console.WriteLine("\nRemoved member with ID 1 from TA-22.");
}
catch (Exception ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}

// Display team members in TA-22 after removal
try
{
    Console.WriteLine("\nTeam members in TA-22 after removal:");
    var teamA = projectManager.GetTeamMembers("TA-22");
    foreach (var member in teamA)
    {
        Console.WriteLine(member);
    }
}
catch (Exception ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}
        