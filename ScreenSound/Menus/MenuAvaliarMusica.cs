using ScreenSound.Modelos;

namespace ScreenSound.Menus; 
internal class MenuAvaliarMusica : Menu{

    public override void Executar(Dictionary<string, Banda> bandasRegistradas) {
        base.Executar(bandasRegistradas);


        ExibirTituloDaOpcao("Avaliar Musica");
        Console.Write("Digite o nome da banda autora da musica: ");
        string nomeDaBanda = Console.ReadLine()!;

        if (bandasRegistradas.ContainsKey(nomeDaBanda))
        {
            Banda banda = bandasRegistradas[nomeDaBanda];

            Console.Write("Agora digite o título do álbum: ");
            string tituloAlbum = Console.ReadLine()!;

            if (banda.Albuns.Any(a => a.Nome.Equals(tituloAlbum)))
            {
                Album album = banda.Albuns.First(a => a.Nome.Equals(tituloAlbum));
                Console.Write($"Digite o nome da musica que deseja avaliar: ");
                string tituloMusica = Console.ReadLine()!;

                if (album.Musicas.Any(m => m.Nome.Equals(tituloMusica)))  {

                    Musica musica = album.Musicas.First(m => m.Nome.Equals(tituloMusica));

                    Console.Write($"Qual a nota que desaeja dar musica a {tituloMusica}: ");
                    Avaliacao nota = Avaliacao.Parse(Console.ReadLine()!);

                    musica.AdicionarNota(nota);

                    Console.WriteLine($"\nA nota {nota.Nota} foi registrada com sucesso para a musica {tituloMusica}");
                    Thread.Sleep(2000);
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine($"\nA musica {tituloMusica} não foi encontrada!");
                    Console.WriteLine("Digite uma tecla para voltar ao menu principal");
                    Console.ReadKey();
                    Console.Clear();
                }

            }
            else
            {
                Console.WriteLine($"\nO álbum {tituloAlbum} não foi encontrada!");
                Console.WriteLine("Digite uma tecla para voltar ao menu principal");
                Console.ReadKey();
                Console.Clear();
            }

        }
        else
        {
            Console.WriteLine($"\nA banda {nomeDaBanda} não foi encontrada!");
            Console.WriteLine("Digite uma tecla para voltar ao menu principal");
            Console.ReadKey();
            Console.Clear();
        }
    }
}

