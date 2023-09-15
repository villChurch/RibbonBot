namespace RibbonBotDAL.Model
{
    public class UserPet
    {
        public long id {  get; set; }
        public long petid { get; set; } 
        public string? owner { get; set; }
        public string? name { get; set; }
        public bool adult { get; set; }
       
    }
}
