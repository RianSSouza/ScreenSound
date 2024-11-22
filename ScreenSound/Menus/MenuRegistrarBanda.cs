using OpenAI_API;
using ScreenSound.Modelos;
using System.Linq;

namespace ScreenSound.Menus; 
internal class MenuRegistrarBanda : Menu{

    public override void Executar(Dictionary<string, Banda> bandasRegistradas) {

       base.Executar(bandasRegistradas);

        ExibirTituloDaOpcao("Registro das bandas");
        Console.Write("Digite o nome da banda que deseja registrar: ");
        string nomeDaBanda = Console.ReadLine()!;
        Banda banda = new Banda(nomeDaBanda);

        if (banda.Nome.Any(a => a.Equals(nomeDaBanda)))
        {
            Console.WriteLine($"A banda {nomeDaBanda} já está cadastrada");
            Console.WriteLine("\n Digite uma tecla para voltar ao menu principal");
            Console.ReadKey();
            Console.Clear();

        }
        else
        {
            bandasRegistradas.Add(nomeDaBanda, banda);

            //Coloque aqui sua API
            var client = new OpenAIAPI("");

            var chat = client.Chat.CreateConversation();

            chat.AppendSystemMessage($"Faça um resumo de 1 paragrafo da banda {nomeDaBanda} de maneira informal");

            string resposta = chat.GetResponseFromChatbotAsync().GetAwaiter().GetResult();
            banda.Resumo = resposta;

            Console.WriteLine($"A banda {nomeDaBanda} foi registrada com sucesso!");
            Console.WriteLine("\n Digite uma tecla para voltar ao menu principal");
            Console.ReadKey();
            Console.Clear();
        }
       
    }
}
