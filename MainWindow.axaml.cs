using Avalonia.Controls;
using Avalonia.Interactivity; 
using Avalonia.Input;
using System.Collections.Generic;
using Argos.Models;
using System.IO;
using System.Text.Json;


namespace Argos;

public partial class MainWindow : Window
{
    // Memória RAM do programa
    private List<Tarefa> _minhasTarefas = new List<Tarefa>();
    private const string ArquivoJson = "tarefas.json";

    public MainWindow()
    {
        InitializeComponent();
        CarregarDoArquivo();
    }

    // Função central 
    private void AdicionarNovaTarefa()
    {
        // Validar entrada
        string textoDigitado = CaixaDeTexto.Text ?? "";
        if (string.IsNullOrWhiteSpace(textoDigitado)) return;

        // Criar dado (Usando Model)
        //Em termos técnicos: "Instanciando um objeto/nova Tarefa"
        Tarefa novaTarefa = new Tarefa();
        novaTarefa.Descricao = textoDigitado;
        novaTarefa.Concluida = false;
        
        // Guardar na memória 
        // Adcionando a lista "secreta" _minhasTarefas
        _minhasTarefas.Add(novaTarefa);
        
        // Atualizar a interface (UI)
        // Criando checkbox visual para o usuário
        CheckBox checkboxVisual = new CheckBox();
        checkboxVisual.Content = novaTarefa.Descricao;
        checkboxVisual.IsChecked = novaTarefa.Concluida;

        // Adiciona na pilha visual (StackPanel)
        ListaDeTarefas.Children.Add(checkboxVisual);

        //4. Limpar a caixa para a próxima
        CaixaDeTexto.Text = "";

        SalvarNoArquivo();
    }

    // Mouse/Clique
    public void AoClicarNoBotao(object sender, RoutedEventArgs args)
    {
        AdicionarNovaTarefa();
    }
    // Teclado
    public void AoApertarTeclaNaCaixa(object sender, KeyEventArgs args)
    {
        // verifcar se a tecla é Enter
        if (args.Key == Key.Enter)
        {
            AdicionarNovaTarefa();
        }
    }
    // Transforma memória em arquivo
    private void SalvarNoArquivo()
    {
        // Serializar a lista de tarefas para JSON
        string json = JsonSerializer.Serialize(_minhasTarefas, new JsonSerializerOptions { WriteIndented = true});
      
        // Escreve texto no disco rígido
        File.WriteAllText(ArquivoJson, json);
    }

        // Arquivo em memória
        private void CarregarDoArquivo()
    {
        // Verifica se o arquivo existe
        if (!File.Exists(ArquivoJson)) return;
        {
            // Lê o conteúdo do arquivo
            string json = File.ReadAllText(ArquivoJson);
            
            // Desserializa o JSON para a lista de tarefas
            _minhasTarefas = JsonSerializer.Deserialize<List<Tarefa>>(json) ?? new List<Tarefa>();
            // O "?? new List<Tarefa>()" é segurança em caso de arquivo corrompido/vazio.

            // Atualiza a interface com as tarefas carregadas
            foreach (var tarefa in _minhasTarefas)
            {
                CheckBox checkboxVisual = new CheckBox();
                checkboxVisual.Content = tarefa.Descricao;
                checkboxVisual.IsChecked = tarefa.Concluida;
                ListaDeTarefas.Children.Add(checkboxVisual);
            }
        }
    }
}