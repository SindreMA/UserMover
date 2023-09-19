using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBot
{
    class AllClasses
    {
    }
    public class RaiderIORequest
    {
        public string name { get; set; }
        public string race { get; set; }
        public string _class { get; set; }
        public string active_spec_name { get; set; }
        public string active_spec_role { get; set; }
        public string gender { get; set; }
        public string faction { get; set; }
        public string region { get; set; }
        public string realm { get; set; }
        public string profile_url { get; set; }
        public Gear gear { get; set; }
        public Raid_Progression raid_progression { get; set; }
        public Mythic_Plus_Ranks mythic_plus_ranks { get; set; }
        public Mythic_Plus_Scores mythic_plus_scores { get; set; }
        public Previous_Mythic_Plus_Ranks previous_mythic_plus_ranks { get; set; }
        public Previous_Mythic_Plus_Scores previous_mythic_plus_scores { get; set; }
        public Mythic_Plus_Recent_Runs[] mythic_plus_recent_runs { get; set; }
        public Mythic_Plus_Best_Runs[] mythic_plus_best_runs { get; set; }
    }

    public class Gear
    {
        public int item_level_equipped { get; set; }
        public int item_level_total { get; set; }
        public int artifact_traits { get; set; }
    }

    public class Raid_Progression
    {
        public AntorusTheBurningThrone antorustheburningthrone { get; set; }
        public TombOfSargeras tombofsargeras { get; set; }
        public TheNighthold thenighthold { get; set; }
        public TheEmeraldNightmare theemeraldnightmare { get; set; }
        public TrialOfValor trialofvalor { get; set; }
    }

    public class AntorusTheBurningThrone
    {
        public string summary { get; set; }
        public int total_bosses { get; set; }
        public int normal_bosses_killed { get; set; }
        public int heroic_bosses_killed { get; set; }
        public int mythic_bosses_killed { get; set; }
    }

    public class TombOfSargeras
    {
        public string summary { get; set; }
        public int total_bosses { get; set; }
        public int normal_bosses_killed { get; set; }
        public int heroic_bosses_killed { get; set; }
        public int mythic_bosses_killed { get; set; }
    }

    public class TheNighthold
    {
        public string summary { get; set; }
        public int total_bosses { get; set; }
        public int normal_bosses_killed { get; set; }
        public int heroic_bosses_killed { get; set; }
        public int mythic_bosses_killed { get; set; }
    }

    public class TheEmeraldNightmare
    {
        public string summary { get; set; }
        public int total_bosses { get; set; }
        public int normal_bosses_killed { get; set; }
        public int heroic_bosses_killed { get; set; }
        public int mythic_bosses_killed { get; set; }
    }

    public class TrialOfValor
    {
        public string summary { get; set; }
        public int total_bosses { get; set; }
        public int normal_bosses_killed { get; set; }
        public int heroic_bosses_killed { get; set; }
        public int mythic_bosses_killed { get; set; }
    }

    public class Mythic_Plus_Ranks
    {
        public Overall overall { get; set; }
        public Tank tank { get; set; }
        public Healer healer { get; set; }
        public Dps dps { get; set; }
        public Class1 _class { get; set; }
        public Class_Tank class_tank { get; set; }
        public Class_Healer class_healer { get; set; }
        public Class_Dps class_dps { get; set; }
    }

    public class Overall
    {
        public int world { get; set; }
        public int region { get; set; }
        public int realm { get; set; }
    }

    public class Tank
    {
        public int world { get; set; }
        public int region { get; set; }
        public int realm { get; set; }
    }

    public class Healer
    {
        public int world { get; set; }
        public int region { get; set; }
        public int realm { get; set; }
    }

    public class Dps
    {
        public int world { get; set; }
        public int region { get; set; }
        public int realm { get; set; }
    }

    public class Class1
    {
        public int world { get; set; }
        public int region { get; set; }
        public int realm { get; set; }
    }

    public class Class_Tank
    {
        public int world { get; set; }
        public int region { get; set; }
        public int realm { get; set; }
    }

    public class Class_Healer
    {
        public int world { get; set; }
        public int region { get; set; }
        public int realm { get; set; }
    }

    public class Class_Dps
    {
        public int world { get; set; }
        public int region { get; set; }
        public int realm { get; set; }
    }

    public class Mythic_Plus_Scores
    {
        public int all { get; set; }
        public int dps { get; set; }
        public int healer { get; set; }
        public int tank { get; set; }
    }

    public class Previous_Mythic_Plus_Ranks
    {
        public Overall1 overall { get; set; }
        public Tank1 tank { get; set; }
        public Healer1 healer { get; set; }
        public Dps1 dps { get; set; }
        public Class2 _class { get; set; }
        public Class_Tank1 class_tank { get; set; }
        public Class_Healer1 class_healer { get; set; }
        public Class_Dps1 class_dps { get; set; }
    }

    public class Overall1
    {
        public int world { get; set; }
        public int region { get; set; }
        public int realm { get; set; }
    }

    public class Tank1
    {
        public int world { get; set; }
        public int region { get; set; }
        public int realm { get; set; }
    }

    public class Healer1
    {
        public int world { get; set; }
        public int region { get; set; }
        public int realm { get; set; }
    }

    public class Dps1
    {
        public int world { get; set; }
        public int region { get; set; }
        public int realm { get; set; }
    }

    public class Class2
    {
        public int world { get; set; }
        public int region { get; set; }
        public int realm { get; set; }
    }

    public class Class_Tank1
    {
        public int world { get; set; }
        public int region { get; set; }
        public int realm { get; set; }
    }

    public class Class_Healer1
    {
        public int world { get; set; }
        public int region { get; set; }
        public int realm { get; set; }
    }

    public class Class_Dps1
    {
        public int world { get; set; }
        public int region { get; set; }
        public int realm { get; set; }
    }

    public class Previous_Mythic_Plus_Scores
    {
        public int all { get; set; }
        public int dps { get; set; }
        public int healer { get; set; }
        public int tank { get; set; }
    }

    public class Mythic_Plus_Recent_Runs
    {
        public string dungeon { get; set; }
        public string short_name { get; set; }
        public int mythic_level { get; set; }
        public DateTime completed_at { get; set; }
        public int clear_time_ms { get; set; }
        public int num_keystone_upgrades { get; set; }
        public int score { get; set; }
        public string url { get; set; }
    }

    public class Mythic_Plus_Best_Runs
    {
        public string dungeon { get; set; }
        public string short_name { get; set; }
        public int mythic_level { get; set; }
        public DateTime completed_at { get; set; }
        public int clear_time_ms { get; set; }
        public int num_keystone_upgrades { get; set; }
        public int score { get; set; }
        public string url { get; set; }
    }

}
