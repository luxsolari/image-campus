using Evaluacion_II;
using Evaluacion_II.Champions;
using Evaluacion_II.Enums;

public class Program
{
    public static void Main(string[] args)
    {
        BaseChampionData myBaseChampData = new BaseChampionData();
        myBaseChampData.Name = "Teemo";
        myBaseChampData.Roles = new List<Role>();
        myBaseChampData.Roles.Add(Role.MARKSMAN);
        myBaseChampData.Roles.Add(Role.ASSASSIN);
        myBaseChampData.IsRanged = true;
        myBaseChampData.AttackRange = 500f;
        
        Champion teemo = new Champion(myBaseChampData);
        teemo.showChampionInfo();
    }
}