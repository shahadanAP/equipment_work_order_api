namespace EquipmentApi.Models{

    public class WorkOrders{
        
        public int Id { get; set;}
        public int CrewId { get; set;}
        public int EquipmentId { get; set; }
        public DateTime DateOfWork { get; set;}
        public bool EquipmentAssigned { get; set; }
        public string Status{ get; set; }
    }
}