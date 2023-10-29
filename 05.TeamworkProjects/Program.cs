using System;
using System.Collections.Generic;
using System.Linq;

class Team
{
    public string TeamName { get; set; }
    public string Creator { get; set; }
    public List<string> Members { get; set; }

    public Team(string teamName, string creator)
    {
        TeamName = teamName;
        Creator = creator;
        Members = new List<string> { creator };
    }

    public void AddMember(string member)
    {
        Members.Add(member);
    }

    public override string ToString()
    {
        return $"{TeamName}\n- {Creator}\n-- {string.Join("\n-- ", Members.Skip(1).OrderBy(x => x))}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        Dictionary<string, Team> teams = new Dictionary<string, Team>();

        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            string[] input = Console.ReadLine().Split('-');
            string creator = input[0].Trim();
            string teamName = input[1].Trim();

            if (teams.ContainsKey(teamName))
            {
                Console.WriteLine($"Team {teamName} was already created!");
                continue;
            }

            if (teams.Values.Any(t => t.Creator == creator))
            {
                Console.WriteLine($"{creator} cannot create another team!");
                continue;
            }

            Team team = new Team(teamName, creator);
            teams.Add(teamName, team);
            Console.WriteLine($"Team {teamName} has been created by {creator}!");
        }

        string command;
        while ((command = Console.ReadLine()) != "end of assignment")
        {
            string[] input = command.Split("->");
            string member = input[0].Trim();
            string teamName = input[1].Trim();

            if (!teams.ContainsKey(teamName))
            {
                Console.WriteLine($"Team {teamName} does not exist!");
                continue;
            }

            if (teams.Values.Any(t => t.Members.Contains(member)))
            {
                Console.WriteLine($"Member {member} cannot join team {teamName}!");
                continue;
            }

            teams[teamName].AddMember(member);
        }

        var validTeams = teams.Values.Where(t => t.Members.Count > 1).OrderByDescending(t => t.Members.Count).ThenBy(t => t.TeamName);
        var teamsToDisband = teams.Values.Where(t => t.Members.Count == 1).OrderBy(t => t.TeamName);

        foreach (var team in validTeams)
        {
            Console.WriteLine(team);
        }

        Console.WriteLine("Teams to disband:");
        foreach (var team in teamsToDisband)
        {
            Console.WriteLine(team.TeamName);
        }
    }
}
