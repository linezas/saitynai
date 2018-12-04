namespace Saitynai.API.Models
{
    public class AppUser
    {
        public int id { get; set; }
        public string name { get; set; }
        public AppUser(string name)
        {
            this.name=name;
        }
        public AppUser()
        {
            
        }
        public AppUser(int id,string name)
        {
            this.name=name;
            this.id=id;
        }
    }
}