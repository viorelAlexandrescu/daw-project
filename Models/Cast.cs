namespace daw.Models
{
    public class Cast
    {
        public int movieId { get; set; }
        public int actorId { get; set; }

        public Movie movie { get; set; }
        public Actor actor { get; set; }
    }
    
}