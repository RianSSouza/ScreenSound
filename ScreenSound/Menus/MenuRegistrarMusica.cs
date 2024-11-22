using ScreenSound.Modelos;

namespace ScreenSound.Menus; 
internal class MenuRegistrarMusica : Menu{

    public override void Executar(Dictionary<string, Banda> bandasRegistradas) {
        base.Executar(bandasRegistradas);

        ExibirTituloDaOpcao("Registar Musica");
        Console.Write("Digite o nome da banda que deseja cadastrar a musica: ");
        string nomeDaBanda = Console.ReadLine()!;

        if (bandasRegistradas.ContainsKey(nomeDaBanda))
        {
            Banda banda = bandasRegistradas[nomeDaBanda];

            Console.Write("Agora digite o título do álbum que deseja inserir a musica: ");
            string tituloAlbum = Console.ReadLine()!;

            if (banda.Albuns.Any(a => a.Nome.Equals(tituloAlbum)))
            {
                Album album = banda.Albuns.First(a => a.Nome.Equals(tituloAlbum));
                Console.Write($"Digite o nome da musica que deseja cadastrar: ");
                string tituloMusica = Console.ReadLine()!;

                if (album.Musicas.Any(m => m.Nome.Equals(tituloMusica)))
                {

                    Console.WriteLine($"\nA musica {tituloMusica} já está no album");
                    Thread.Sleep(2000);
                    Console.Clear();
                }
                else
                {
                    Musica novaMusica = new(tituloMusica, banda);
                    album.Musicas.Add(novaMusica);

                    Console.WriteLine($"\nA musica {tituloMusica} foi cadastrada com sucesso!");
                    Thread.Sleep(2000);
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
