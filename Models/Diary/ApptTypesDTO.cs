namespace WebApi.Models.Diary


{
    public class ApptTypesDTO
    {
        public int TypeId { get; set; }
        public string TypeText { get; set; }
        public string TypeCode { get; set; }
        public int? Order { get; set; }
    }
}