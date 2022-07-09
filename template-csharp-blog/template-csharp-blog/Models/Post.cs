namespace template_csharp_blog.Models
{
    public class Post
    {
      
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public string Title { get; set; }

        public string Body { get; set; }
        public string Author { get; set; }
       
    
     


    }
}
