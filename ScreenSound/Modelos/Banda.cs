namespace ScreenSound.Modelos;

internal class Banda : IAvaliavel {

    public List<Album> Albuns = new List<Album>();
    private List<Avaliacao> notas = new List<Avaliacao>();

    public Banda(string nome) {

        Nome = nome;
    }

    public string Nome { get; }
    public string? Resumo { get; set; } 

    public double Media {

        get {

            if (notas.Count == 0) return 0;
            else return Math.Round(notas.Average(a => a.Nota), 2);

        }
    }

    public void AdicionarNota(Avaliacao nota) {

        notas.Add(nota);
    }

    public void AdicionarAlbum(Album album) {
        Albuns.Add(album);
    }

    public void ExibirDiscografia() {
        Console.WriteLine($"Discografia da banda {Nome}");
        foreach (Album album in Albuns)
        {
            Console.WriteLine($"Álbum: {album.Nome} ({album.DuracaoTotal})");
        }
    }
}