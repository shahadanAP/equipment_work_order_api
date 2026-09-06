namespace EquipmentApi.Models
{
    public class CrewMembers{
        public int CrewMembersId{ get; set;}
        public string MemberName{ get; set; }
        public string MemberPosition{ get; set; }
        public int CrewId{ get; set; }

        public Crew Crew {get; set;}
    }
}