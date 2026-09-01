using System.Text.Json.Serialization;

namespace DevBlog.Api.Models
{
    public class Postagem
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Conteudo { get; set; }
        public DateTime DataPublicacao { get; set; }

        public int AutorId { get; set; }

        [JsonIgnore]
        public Autor autor { get; set; }

        public ICollection<Comentario> Comentarios { get; set; }
    }
   
}
