namespace ScreenSound.Modelos;

internal class Musica : IAvaliavel {

    private List<Avaliacao> notas = new();

    public Musica(string nome, Banda artista) {

        Nome = nome;
        Artista = artista;

    }

    public string Nome { get; }
    public Banda Artista { get; }
    public int Duracao { get; set; }
    public bool Disponivel { get; set; }
    public string DescricaoResumida => $"A música {Nome} pertence à banda {Artista}";

    public double Media {

        get {

            if (notas.Count == 0) return 0;
            else return Math.Round(notas.Average(a => a.Nota), 2);

        }

    }
    public void AdicionarNota(Avaliacao nota) {

        notas.Add(nota);
    }

    public void ExibirFichaTecnica() {
        Console.WriteLine($"Nome: {Nome}");
        Console.WriteLine($"Artista: {Artista.Nome}");
        Console.WriteLine($"Duração: {Duracao}");
        if (Disponivel)
        {
            Console.WriteLine("Disponível no plano.");
        }
        else
        {
            Console.WriteLine("Adquira o plano Plus+");
        }
    }

}