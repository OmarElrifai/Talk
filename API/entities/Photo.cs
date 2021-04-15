using System.ComponentModel.DataAnnotations.Schema;

namespace API.entities
{
    [Table("Photos")]
    public class Photo
    {
        public int ID {get;set;}
        public string url{get;set;}
        public bool isMain{get;set;}
        public string PublicId{get;set;}
        public Appusers Appusers{get;set;}
        public int AppusersID{get;set;}
    }
}